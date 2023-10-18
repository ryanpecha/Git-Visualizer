using System.Text;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Http;
using System.Numerics;

/// <summary>
/// Class <c>Github</c> contains methods to abstract the interaction with the GitHub API and contain many of Github user's data.
/// </summary>
public class Github
{

    // members that can change during runtime
    public static String? userCode { get; private set; }
    public static String? deviceCode;
    public static String accessToken { get; private set; }

    // end section

    private static String tempClientID = "a6b32f8800218e8eab39";
    private static String tempClientSecret = "15b4419077375217ebfcc678d0b106b002bff374";
    private static int interval = 5;

    private static readonly HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://api.github.com/"),
    };
    private static ProductInfoHeaderValue product = new ProductInfoHeaderValue("product", "1");
    private static MediaTypeWithQualityHeaderValue jsonType = new MediaTypeWithQualityHeaderValue("application/json");
    private static MediaTypeWithQualityHeaderValue githubType = new MediaTypeWithQualityHeaderValue("application/vnd.github+json");

    // GitHub user information

    public List<Repo>? repos { get; private set; }
    public String? username { get; private set; }
    public String? avatarURL { get; private set; }
    public String? userGitHubURL { get; private set; }


    /// <summary>
    /// The .ctor.
    /// </summary>
    public Github()
    {
    }

    /// <summary>
    /// The give permission.
    /// </summary>
    /// <returns>The task object.</returns>
    public async Task GivePermission()
    {
        await Task.Run(RegisterUser);
    }

    /// <summary>
    /// The method waits for the user to authorize the app to read and write to the user's repository.
    /// </summary>
    /// <returns>The task object.</returns>
    public async Task WaitForAuthorization()
    {
        await Task.Run(PollAuthorizationDevice);
    }

    /// <summary>
    /// The method gets a list of the user repository as JSON.
    /// </summary>
    /// <returns>The task object.</returns>
    public async Task GetRepositories()
    {
        // TODO: Format the JSON to make it easier to work in frontend.
        await Task.Run(GetRepoList);
    }

    /// <summary>
    /// The method deletes the user access token, essentially disassociating them from the app.
    /// </summary>
    /// <returns>The task object.</returns>
    public async Task DeleteToken()
    {
        await Task.Run(RevokeAccessToken);
    }

    /// <summary>
    /// The method runs the request to get specific information about the user.
    /// </summary>
    /// <returns>The task object.</returns>
    public async Task GetUserInfo()
    {
        // TODO: Format the JSON to make it easier to work in frontend.
        await Task.Run(GetGitHubUser);
    }

    /// <summary>
    /// Testing method for Nam. Do not call.
    /// </summary>
    public async void TestAsync()
    {
        await GivePermission();

        Debug.Write("userCode: " + userCode);


        if (userCode != null)
            await WaitForAuthorization();

        await GetUserInfo();
        await GetRepoList();

        int i = 0;
        foreach (Repo x in repos)
        {
            Debug.WriteLine(i + " " + x.name + " " + x.git_url);
            Debug.WriteLine(CreateAuthenticatedGit(i));
            i++;
        }


        await DeleteToken();
    }

    /// <summary>
    /// Returns an authenticated string good for git cloning.
    /// </summary>
    /// <param name="i">An int to grab index of the repo.</param>
    /// <returns>The string URL for git cloning.</returns>
    public String CreateAuthenticatedGit(int i)
    {
        if (repos == null)
        {
            return "";
        }
        else if (i < 0 || i > repos.Count)
            return "createAuthenticatedGit(): Invalid index: " + i;

        return "https://" + accessToken + "@" + repos[i].git_url;
    }

    /// <summary>
    /// The private method to handle registering user with the app.
    /// </summary>
    /// <returns>The Task<String> object that can be awaited for the String</returns>
    private async Task<String> RegisterUser()
    {
        using StringContent jsonContent = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                client_id = tempClientID,
                scope = "repo"
            }),
            Encoding.UTF8,
             jsonType);

        CommonHelper();
        HttpResponseMessage response = await sharedClient.PostAsync("https://github.com/login/device/code", jsonContent);

        if (response.IsSuccessStatusCode)
        {
            String content = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("RegisterUser(): User code generated successfully");
            JObject json = JObject.Parse(content);

            string s = json["interval"].ToString();
            interval = int.Parse(s);
            deviceCode = json["device_code"].ToString();
            Debug.WriteLine(content);
            Debug.WriteLine("----------------");
            userCode = json["user_code"].ToString();

            return userCode;
        }

        Debug.WriteLine("RegisterUser(): User code generation failed");
        return null;
    }

    /// <summary>
    /// The private method to handle registering user with the app.
    /// </summary>
    /// <returns>The task object.</returns>
    private async Task PollAuthorizationDevice()
    {
        if (userCode == null)
        {
            Debug.WriteLine("PollAuthorizationDevice(): No user code. Cannot poll until we know user have access to a user code.");
            return;
        }

        CommonHelper();
        PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromSeconds(interval + 5));
        int max = 10;

        while (await timer.WaitForNextTickAsync() && max > 0)
        {
            String status = await SendAuthorizationRequest();
            if (status != null)
                break;
            max--;
        }
    }

    /// <summary>
    /// The private method to handle polling for the user to grant the app the appropriate permission to read/write to repository.
    /// </summary>
    /// <returns>The Task<String> object that can be awaited for the String</returns>
    private async Task<String> SendAuthorizationRequest()
    {
        HttpResponseMessage response;
        StringContent jsonContent = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                client_id = tempClientID,
                device_code = deviceCode,
                grant_type = "urn:ietf:params:oauth:grant-type:device_code"
            }),
            Encoding.UTF8,
            jsonType);

        response = await sharedClient.PostAsync("https://github.com/login/oauth/access_token", jsonContent);

        if (response.IsSuccessStatusCode)
        {

            String content = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(content);

            if (!content.Contains("error"))
            {
                JObject json = JObject.Parse(content);
                accessToken = json["access_token"].ToString();
            }
        }
        return accessToken;
    }

    /// <summary>
    /// The private method to handle getting the GitHub user's repository list.
    /// </summary>
    /// <returns>The Task<String> object that can be awaited for the String</returns>
    private async Task<String> GetRepoList()
    {
        if (accessToken == null)
            return "";
        CommonAuthenticatedHelper();

        HttpResponseMessage response = await sharedClient.GetAsync($"{sharedClient.BaseAddress}user/repos");

        if (response.IsSuccessStatusCode)
        {
            String content = await response.Content.ReadAsStringAsync();
            JArray array = JArray.Parse(content);
            int gitEndIndex = 6;

            repos = ((JArray)array).Select(repo => new Repo
            {
                name = (string)repo["name"],
                git_url = ((string)repo["git_url"]).Substring(gitEndIndex)
            }).ToList();
        }

        return "";
    }

    /// <summary>
    /// The private method to handle getting the GitHub user's public information.
    /// </summary>
    /// <returns>The Task<String> object that can be awaited for the String</returns>
    private async Task<String> GetGitHubUser()
    {
        if (accessToken == null)
            return "";
        CommonAuthenticatedHelper();

        HttpResponseMessage response = await sharedClient.GetAsync($"{sharedClient.BaseAddress}user");

        if (response.IsSuccessStatusCode)
        {
            String content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            username = json["login"].ToString();
            avatarURL = json["avatar_url"].ToString();
            userGitHubURL = json["html_url"].ToString();
        }

        return username;
    }


    /// <summary>
    /// The private method to revoke a user access token.
    /// </summary>
    /// <returns>The Task<String> object that can be awaited for the String</returns>
    private async Task<bool> RevokeAccessToken()
    {
        if (accessToken == null)
        {
            Debug.WriteLine("RevokeAccessToken(): Access token is already deleted or null.");
            return false;
        }

        StringContent jsonContent = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                access_token = accessToken,
            }),
            Encoding.UTF8,
            jsonType);

        var request = new HttpRequestMessage(HttpMethod.Delete, $"{sharedClient.BaseAddress}applications/{tempClientID}/token");
        request.Headers.Add("Accept", "application/vnd.github+json");
        request.Headers.Add("User-Agent", product.ToString());
        request.Content = jsonContent;

        var authenticationString = $"{tempClientID}:{tempClientSecret}";
        var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

        HttpResponseMessage response = await sharedClient.SendAsync(request);

        if (response.StatusCode.ToString() == "NoContent")
        {
            Debug.WriteLine("RevokeAccessToken(): Access token revoked/deleted.");

            accessToken = username = avatarURL = userGitHubURL = null;
            return true;
        }

        Debug.WriteLine("RevokeAccessToken(): Failed to delete access token.");
        return false;
    }

    /// <summary>
    /// A helper method that can be used many times. Reset the Http client to make the formatting of requests easier to do.
    /// </summary>
    private void CommonHelper()
    {
        sharedClient.DefaultRequestHeaders.Accept.Clear();
        sharedClient.DefaultRequestHeaders.UserAgent.Add(product);
        sharedClient.DefaultRequestHeaders.Accept.Add(jsonType);
    }

    /// <summary>
    /// A helper method for authenticated requests that can be used many times.
    /// </summary>
    private void CommonAuthenticatedHelper()
    {
        sharedClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        sharedClient.DefaultRequestHeaders.UserAgent.Add(product);
        sharedClient.DefaultRequestHeaders.Accept.Add(githubType);
    }
}