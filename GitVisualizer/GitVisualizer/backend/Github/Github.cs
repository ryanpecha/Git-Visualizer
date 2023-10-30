using System.Text;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Http;
using System.Numerics;

using CredentialManagement;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using GitVisualizer;

/// <summary>
/// Class <c>Github</c> contains methods to abstract the interaction with the GitHub API and contain many of Github user's data.
/// </summary>
public class Github
{
    /// <summary>
    /// Class <c>CredentialStore</c> contains methods to work with Windows Credential Manager to read and write GitHub user's data.
    /// </summary>
    private static class CredentialStore
    {
        private static String userTarget = "VisualizerGitHub_user";

        /// <summary>
        /// Saves GitHub user's credential to Windows Credential Manager.
        /// </summary>
        /// <param name="username">The GitHub username.</param>
        /// <param name="token">The token.</param>
        /// <returns>true if credential is saved. false otherwise.</returns>
        public static bool SaveCredential(String username, String token)
        {
            Credential credential = new Credential();
            credential.Target = userTarget;

            if (!credential.Exists())
            {
                Debug.Write($"DeleteCredential(): credential stored.");
                credential.Username = username;
                credential.Password = token;
                credential.Type = CredentialType.Generic;
                credential.PersistanceType = PersistanceType.LocalComputer;
                credential.Save();
                return true;
            }
            Debug.Write($"DeleteCredential(): credential already exists. Not writing anything.");
            return false;
        }

        /// <summary>
        /// Retrieves user's token from Windows Credential Manager.
        /// </summary>
        /// <returns>A String for the token. null if retrieval fails.</returns>
        public static String GetToken()
        {
            Credential credential = new Credential();
            credential.Target = userTarget;
            if (credential.Exists())
            {
                credential.Load();
                return credential.Password;
            }
            return null;
        }

        /// <summary>
        /// Retrieves user's username from Windows Credential Manager.
        /// </summary>
        /// <returns>A String for the username. empty string if retrieval fails.</returns>
        public static String GetUserName()
        {
            Credential credential = new Credential();
            credential.Target = userTarget;
            if (credential.Exists())
            {
                credential.Load();
                return credential.Username;
            }
            return null;
        }

        /// <summary>
        /// Deletes GitHub user's credential from Windows Credential Manager.
        /// </summary>
        /// <returns>true if deletion is successful. false otherwise.</returns>
        public static bool DeleteCredential()
        {
            Credential credential = new Credential();
            credential.Target = userTarget;
            if (credential.Exists())
            {
                Debug.Write($"DeleteCredential(): credential deleted.");
                credential.Delete();
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Gets or Sets the user code.
    /// </summary>
    public static String? userCode { get; private set; }
    public static String? deviceCode;

    /// <summary>
    /// Gets or Sets the access token.
    /// </summary>
    public static String? accessToken { get; private set; }

    /// <summary>
    /// URL for login with code page on github
    /// </summary>
    public const String deviceLoginCodeURL = "https://github.com/login/device";

    // end section

    private static String tempClientID = "a6b32f8800218e8eab39";
    private static String tempClientSecret = "15b4419077375217ebfcc678d0b106b002bff374";

    private static int interval = 1;

    private static readonly HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://api.github.com/"),
    };
    private static ProductInfoHeaderValue product = new ProductInfoHeaderValue("product", "1");
    private static MediaTypeWithQualityHeaderValue jsonType = new MediaTypeWithQualityHeaderValue("application/json");
    private static MediaTypeWithQualityHeaderValue githubType = new MediaTypeWithQualityHeaderValue("application/vnd.github+json");

    private bool rememberUserAccess = false;

    /// <summary>
    /// Gets or Sets the repo list.
    /// </summary>
    public List<RepositoryRemote>? repos { get; private set; }

    /// <summary>
    /// Gets or Sets the username.
    /// </summary>
    public String? username { get; private set; }

    /// <summary>
    /// Gets or Sets the avatar u r l.
    /// </summary>
    public String? avatarURL { get; private set; }

    /// <summary>
    /// Gets or Sets the user git hub u r l.
    /// </summary>
    public String? userGitHubURL { get; private set; }

    /// <summary>
    /// Gets or Sets the repo list.
    /// </summary>
    public String repoList { get; private set; }

    /// <summary>
    /// True if user wants to store access key in app, false if it wants to revoke it when app ends
    /// </summary>
    public bool RememberUserAccess => rememberUserAccess;

    /// <summary>
    /// The .ctor.
    /// </summary>
    public Github()
    {
    }

    /// <summary>
    /// Attempts to ask user to grant the app permission to read/write public repositories.
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
    public bool DeleteToken()
    {
        return RevokeAccessToken();
    }

    /// <summary>
    /// The method runs the request to get specific information about the user.
    /// </summary>
    /// <returns>The task object.</returns>
    public async Task GetUserInfo()
    {
        await Task.Run(GetGitHubUser);
    }

    /// <summary>
    /// Testing method for Nam. Do not call.
    /// </summary>
    public async void TestAsync()
    {

        // GitHub API code you can change.

        await GivePermission();

        //Debug.Write("userCode: " + userCode);

        // BEGIN of SECTION: this section is not necessary if retrieving from Windows Credential Manager
        if (userCode != null)
            await WaitForAuthorization();

        await GetUserInfo();
        // END of SECTION


        // have only 1 of the following 2 function calls run. SaveUser() saves credentials and ReadTokenAndUserName() read stored credential.
        // from storage.
        //SaveUser();
        //ReadTokenAndUserName();

        await GetRepoList();
        int i = 0;
        /*
        foreach (Repo x in repos)
        {
            Debug.WriteLine(i + " " + x.name + " " + x.git_url);
            Debug.WriteLine(CreateAuthenticatedGit(i));
            i++;
        }*/

        String repo_url = await CreateRepo("testingCreatingARepo");
        Debug.WriteLine(CreateAuthenticatedGit(repo_url));

        // delete stored storage credential
        DeleteStoredCredential();

        bool tokenRemoveSuccess = DeleteToken();
        Debug.WriteLine($"TOKEN REMOVED: {tokenRemoveSuccess}");
    }

    /// <summary>
    /// Returns an authenticated string good for git cloning.
    /// </summary>
    /// <param name="i">An int to grab index of the repo.</param>
    /// <returns>The string URL for git cloning.</returns>
    public String CreateAuthenticatedGit(int i)
    {
        if (repos == null)
            return null;
        else if (i < 0 || i > repos.Count)
            return "createAuthenticatedGit(): Invalid index: " + i;

        return "https://" + accessToken + "@" + repos[i].cloneUrlHTTPS;
    }

    /// <summary>
    /// Returns an authenticated string good for git cloning.
    /// </summary>
    /// <returns>The string URL for git cloning.</returns>
    public String CreateAuthenticatedGit(String url)
    {
        return "https://" + accessToken + "@" + url;
    }

    /// <summary>
    /// Allows external setting of remember user bool, which saves access token if true or
    /// revokes it on app close when false.
    /// </summary>
    /// <param name="isEnabled">a setter bool.</param>
    public void SetRememberUserAccessBool(bool isEnabled)
    {
        rememberUserAccess = isEnabled;
    }

    /// <summary>
    /// Saves the GitHub user's credentials into local computer.
    /// </summary>
    /// <returns>A bool. true if saved. false otherwise.</returns>
    public bool SaveUser()
    {
        if (username == null || accessToken == null)
        {
            Debug.WriteLine("SaveUser(): accessToken is null OR please call GetGitHubUser() before trying to save user credentials.");
            return false;
        }

        return CredentialStore.SaveCredential(username, accessToken);
    }

    /// <summary>
    /// Read token and user name from storage.
    /// </summary>
    /// <returns>true if members accessToken and username have been set properly. false otherwise.</returns>
    public bool ReadTokenAndUserName()
    {
        accessToken = CredentialStore.GetToken();
        username = CredentialStore.GetUserName();
        return accessToken != null && username != null;
    }

    /// <summary>
    /// Delete GitHub user's credential from storage. NOTE: Might be useful to restrict user's token as well.
    /// </summary>
    /// <returns>true if credential is deleted. false otherwise.</returns>
    public bool DeleteStoredCredential()
    {
        return CredentialStore.DeleteCredential();
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
                scope = "public_repo"
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
            return null;
        CommonAuthenticatedHelper();

        HttpResponseMessage response = await sharedClient.GetAsync($"{sharedClient.BaseAddress}user/repos");

        if (response.IsSuccessStatusCode)
        {
            String content = await response.Content.ReadAsStringAsync();
            JArray array = JArray.Parse(content);
            int gitEndIndex = 6;

            repos = ((JArray)array).Select(repo => new RepositoryRemote(
                title: (string)repo["name"],
                cloneUrlHTTPS: ((string)repo["git_url"]).Substring(gitEndIndex)
            )).ToList();
        }

        return null;
    }

    /// <summary>
    /// The private method to handle getting the GitHub user's public information.
    /// </summary>
    /// <returns>The Task<String> object that can be awaited for the String</returns>
    private async Task<String> GetGitHubUser()
    {
        if (accessToken == null)
            return null;
        CommonAuthenticatedHelper();

        HttpResponseMessage response = await sharedClient.GetAsync($"{sharedClient.BaseAddress}user");

        if (response.IsSuccessStatusCode)
        {
            String content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            username = json["login"].ToString();
            avatarURL = json["avatar_url"].ToString();
            userGitHubURL = json["html_url"].ToString();
            return username;
        }

        return null;
    }


    /// <summary>
    /// The private method to revoke a user access token. Method will also call DeleteStoredCredential().
    /// </summary>
    /// <returns>The Task<String> object that can be awaited for the String</returns>
    private bool RevokeAccessToken()
    {

        if (accessToken == null)
        {
            Debug.WriteLine("RevokeAccessToken(): Access token is already deleted or null.");
            return false;
        }

        Debug.WriteLine("Removing User token: " + accessToken);
        DeleteStoredCredential();

        StringContent jsonContent = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                access_token = accessToken,
            }),
            Encoding.UTF8,
            jsonType);

        var request = new HttpRequestMessage(HttpMethod.Delete, $"{sharedClient.BaseAddress}applications/{tempClientID}/grant");
        request.Headers.Add("Accept", "application/vnd.github+json");
        request.Headers.Add("User-Agent", product.ToString());
        request.Content = jsonContent;

        var authenticationString = $"{tempClientID}:{tempClientSecret}";
        var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64EncodedAuthenticationString);

        HttpResponseMessage response = sharedClient.Send(request);

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
    /// Method to create an empty public repo with a specified name on GitHub.
    /// </summary>
    /// <param name="repoName">The repo name.</param>
    /// <returns>The git clone url of the newly created GitHub repo.</returns>
    private async Task<String> CreateRepo(String repoName)
    {
        if (accessToken == null)
            return null;
        CommonAuthenticatedHelper();

        using StringContent jsonContent = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                name = repoName,
            }),
            Encoding.UTF8,
             jsonType);

        HttpResponseMessage response = await sharedClient.PostAsync("https://api.github.com/user/repos", jsonContent);
        if (response.StatusCode.ToString() == "Created")
        {
            Debug.WriteLine($"CreateRepo(): Repo {repoName} created.");
            String content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            int gitEndIndex = 8;
            return username = json["clone_url"].ToString().Substring(gitEndIndex);

        }

        Debug.WriteLine($"CreateRepo(): Repo {repoName} creation failed.");
        return null;
    }

    /// <summary>
    /// A helper method that can be used many times. Reset the Http client to make the formatting of requests easier to do.
    /// </summary>
    private void CommonHelper()
    {
        sharedClient.DefaultRequestHeaders.Clear();
        sharedClient.DefaultRequestHeaders.UserAgent.Add(product);
        sharedClient.DefaultRequestHeaders.Accept.Add(jsonType);
    }

    /// <summary>
    /// A helper method for authenticated requests that can be used many times.
    /// </summary>
    private void CommonAuthenticatedHelper()
    {
        sharedClient.DefaultRequestHeaders.Clear();
        sharedClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        sharedClient.DefaultRequestHeaders.UserAgent.Add(product);
        sharedClient.DefaultRequestHeaders.Accept.Add(githubType);
    }
}