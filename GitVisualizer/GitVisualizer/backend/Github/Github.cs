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
        private static string userTarget = "VisualizerGitHub_user";

        /// <summary>
        /// Saves GitHub user's credential to Windows Credential Manager.
        /// </summary>
        /// <param name="username">The GitHub username.</param>
        /// <param name="token">The token.</param>
        /// <returns>true if credential is saved. false otherwise.</returns>
        public static bool SaveCredential(string username, string token)
        {
            Credential credential = new Credential();
            credential.Target = userTarget;

            if (!credential.Exists())
            {
                Debug.Write($"SaveCredential(): credential stored.");
                credential.Username = username;
                credential.Password = token;
                credential.Type = CredentialType.Generic;
                credential.PersistanceType = PersistanceType.LocalComputer;
                credential.Save();
                return true;
            }
            Debug.Write($"SaveCredential(): credential already exists. Not writing anything.");
            return false;
        }

        /// <summary>
        /// Retrieves user's token from Windows Credential Manager.
        /// </summary>
        /// <returns>A String for the token. null if retrieval fails.</returns>
        public static string? GetToken()
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
        public static string? GetUserName()
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
            Debug.WriteLine("DeleteCredential()");
            Credential credential = new Credential();
            credential.Target = userTarget;
            if (credential.Exists())
            {
                Debug.WriteLine($"DeleteCredential(): credential deleted.");
                credential.Delete();
                return true;
            }
            return false;
        }
    }

    /// <summary> Gets or Sets the user code. </summary>
    public static string? userCode { get; private set; } = null;
    public static string? deviceCode = null;

    /// <summary> Gets or Sets the access token. </summary>
    public static string? accessToken { get; private set; } = null;

    /// <summary> URL for login with code page on github </summary>
    public const string API_DEVICE_LOGIN_CODE_URL = "https://github.com/login/device";
    private static readonly ProductInfoHeaderValue API_PRODUCT = new ProductInfoHeaderValue(
        "product",
        "1"
    );
    private static readonly MediaTypeWithQualityHeaderValue API_GITHUB_TYPE =
        new MediaTypeWithQualityHeaderValue("application/vnd.github+json");

    //
    private static readonly string API_TEMP_CLIENT_ID = "a6b32f8800218e8eab39";
    private static readonly string API_TEMP_CLIENT_SECRET =
        "15b4419077375217ebfcc678d0b106b002bff374";

    //
    private static readonly HttpClient API_SHARED_CLIENT =
        new() { BaseAddress = new Uri("https://api.github.com/"), };
    private static MediaTypeWithQualityHeaderValue API_JSON_TYPE =
        new MediaTypeWithQualityHeaderValue("application/json");

    //
    private static readonly int MAX_AUTH_WAIT_DUR = 30;
    private static double authTryInterval = 1;

    /// <summary>
    /// Gets or Sets the repo list.
    /// </summary>
    //public List<RepositoryRemote> repos { get; private set; }

    /// <summary>
    /// Gets or Sets the username.
    /// </summary>
    public static string? username { get; private set; }

    /// <summary>
    /// Gets or Sets the avatar u r l.
    /// </summary>
    public static string? avatarURL { get; private set; }

    /// <summary>
    /// Gets or Sets the user git hub u r l.
    /// </summary>
    public static string? userGitHubURL { get; private set; }

    /// <summary>
    /// Attempts to ask user to grant the app permission to read/write public repositories.
    /// </summary>
    /// <returns>The task object.</returns>
    public async Task<string?> GivePermission()
    {
        return await Task.Run(RegisterUser);
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
    public async Task<List<RepositoryRemote>?> ScanReposAsync()
    {
        // TODO: Format the JSON to make it easier to work in frontend.
        return await Task.Run(ScanApiRepos);
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
    /// Returns an authenticated string good for git cloning.
    /// </summary>
    /// <param name="i">An int to grab index of the repo.</param>
    /// <returns>The string URL for git cloning.</returns>
    public string? CreateAuthenticatedGit(string cloneUrlHTTPS)
    {
        return "https://" + accessToken + "@" + cloneUrlHTTPS;
    }

    /// <summary>
    /// Saves the GitHub user's credentials into local computer.
    /// </summary>
    /// <returns>A bool. true if saved. false otherwise.</returns>
    public bool SaveUser()
    {
        Debug.WriteLine("SAVING CREDENTIALS");
        if (username == null || accessToken == null)
        {
            Debug.WriteLine(
                "SaveUser(): accessToken is null OR please call GetGitHubUser() before trying to save user credentials."
            );
            return false;
        }
        return CredentialStore.SaveCredential(username, accessToken);
    }

    /// <summary>
    /// Read token and user name from storage.
    /// </summary>
    /// <returns>true if members accessToken and username have been set properly. false otherwise.</returns>
    public static bool LoadStoredCredentials()
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
    private async Task<string?> RegisterUser()
    {
        // user registraction request setup
        using StringContent jsonContent =
            new(
                System.Text.Json.JsonSerializer.Serialize(
                    new { client_id = API_TEMP_CLIENT_ID, scope = "repo" } // "public_repo" for public only, "repo" for private
                ),
                Encoding.UTF8,
                API_JSON_TYPE
            );
        // awaiting post of user registration
        CommonHelper();
        HttpResponseMessage response = await API_SHARED_CLIENT.PostAsync(
            "https://github.com/login/device/code",
            jsonContent
        );
        // parsing content
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("RegisterUser(): User code generated successfully");
            JObject resJson = JObject.Parse(content);
            //
            JToken? authTryIntervalToken = resJson.GetValue("interval");
            if (authTryIntervalToken == null)
            {
                Debug.WriteLine("interval not provided by github");
                return null;
            }
            else
            {
                Debug.WriteLine($"interval set to {authTryIntervalToken}");
                authTryInterval = double.Parse(authTryIntervalToken.ToString());
            }
            //
            JToken? deviceCodeToken = resJson.GetValue("device_code");
            if (deviceCodeToken == null)
            {
                Debug.WriteLine("intervalToken not provided by github");
                return null;
            }
            else
            {
                deviceCode = deviceCodeToken.ToString();
            }
            //
            JToken? userCodeToken = resJson.GetValue("user_code");
            if (userCodeToken == null)
            {
                Debug.WriteLine("intervalToken not provided by github");
                return null;
            }
            else
            {
                userCode = userCodeToken.ToString();
            }
            //
            Debug.WriteLine(content);
            Debug.WriteLine("----------------");
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
        Debug.WriteLine("poll");
        if (userCode == null)
        {
            Debug.WriteLine(
                "PollAuthorizationDevice(): No user code. Cannot poll until we know user have access to a user code."
            );
            return;
        }

        CommonHelper();

        PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromSeconds(authTryInterval + 5));
        int triesRemaining = MAX_AUTH_WAIT_DUR / (int)authTryInterval;
        while (await timer.WaitForNextTickAsync() && triesRemaining > 0)
        {
            string? status = await SendAuthorizationRequest();
            if (status != null)
            {
                await GetGitHubUser();
                if (!SaveUser())
                {
                    Debug.WriteLine("WARNING : Failed to save credentials");
                }
                break;
            }
            triesRemaining--;
        }
    }

    /// <summary>
    /// The private method to handle polling for the user to grant the app the appropriate permission to read/write to repository.
    /// </summary>
    /// <returns>The Task<String> object that can be awaited for the String</returns>
    private async Task<string?> SendAuthorizationRequest()
    {
        HttpResponseMessage response;
        StringContent jsonContent =
            new(
                System.Text.Json.JsonSerializer.Serialize(
                    new
                    {
                        client_id = API_TEMP_CLIENT_ID,
                        device_code = deviceCode,
                        grant_type = "urn:ietf:params:oauth:grant-type:device_code"
                    }
                ),
                Encoding.UTF8,
                API_JSON_TYPE
            );

        response = await API_SHARED_CLIENT.PostAsync(
            "https://github.com/login/oauth/access_token",
            jsonContent
        );

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(content);

            if (!content.Contains("error"))
            {
                JObject resJson = JObject.Parse(content);
                JToken? jAccessToken = resJson["access_token"];
                if (jAccessToken != null)
                {
                    accessToken = jAccessToken.ToString();
                    return accessToken;
                }
            }
        }
        return null;
    }

    /// <summary>
    /// The private method to handle getting the GitHub user's repository list.
    /// </summary>
    /// <returns>The Task<String> object that can be awaited for the String</returns>
    private async Task<List<RepositoryRemote>?> ScanApiRepos()
    {
        if (accessToken == null)
        {
            Debug.WriteLine("Tried to fetch repos without access token");
            return null;
        }

        CommonAuthenticatedHelper();

        HttpResponseMessage response = await API_SHARED_CLIENT.GetAsync(
            $"{API_SHARED_CLIENT.BaseAddress}user/repos?per_page=100"
        );

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            JArray jRemotesArray = JArray.Parse(content);
            List<RepositoryRemote> repositoryRemotes = new List<RepositoryRemote>();
            foreach (JToken jToken in jRemotesArray)
            {
                JToken? titleToken = jToken["name"];
                JToken? cloneUrlHTTPSToken = jToken["git_url"];
                if (titleToken == null)
                {
                    return null;
                }
                if (cloneUrlHTTPSToken == null)
                {
                    return null;
                }
                string title = titleToken.ToString();
                string cloneURL = cloneUrlHTTPSToken.ToString().Substring(6);
                string webURL = cloneURL.Substring(0,cloneURL.Length - 4);
                webURL = $"https://{webURL}";
                RepositoryRemote remote = new RepositoryRemote(title, cloneURL, webURL);
                Debug.WriteLine($"Scanned Remote Repo : {remote.title}");
                repositoryRemotes.Add(remote);
            }
            return repositoryRemotes;
        }

        return null;
    }

    /// <summary>
    /// The private method to handle getting the GitHub user's public information.
    /// </summary>
    /// <returns>The Task<String> object that can be awaited for the String</returns>
    private async Task<string?> GetGitHubUser()
    {
        if (accessToken == null)
        {
            Debug.WriteLine("Tried to get github user without access token");
            return null;
        }

        CommonAuthenticatedHelper();

        HttpResponseMessage response = await API_SHARED_CLIENT.GetAsync(
            $"{API_SHARED_CLIENT.BaseAddress}user"
        );

        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            JObject resJson = JObject.Parse(content);
            JToken? usernameToken = resJson["login"];
            if (usernameToken == null)
            {
                Debug.WriteLine("WARNING : github username is null");
                return null;
            }
            JToken? avatarURLToken = resJson["avatar_url"];
            if (avatarURLToken == null)
            {
                Debug.WriteLine("WARNING : github user avatar url is null");
                return null;
            }
            JToken? userGitHubURLToken = resJson["html_url"];
            if (userGitHubURLToken == null)
            {
                Debug.WriteLine("WARNING : github user html url is null");
                return null;
            }
            //
            username = usernameToken.ToString();
            avatarURL = avatarURLToken.ToString();
            userGitHubURL = userGitHubURLToken.ToString();
            //
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

        Debug.WriteLine("Removing User token");
        bool deleteCredentialSuccess = DeleteStoredCredential();
        if (!deleteCredentialSuccess) {
            Console.WriteLine("WARNING : failed to delete local credentials");
        }

        if (accessToken == null)
        {
            Debug.WriteLine("RevokeAccessToken(): Access token is already deleted or null.");
            return false;
        }

        StringContent jsonContent =
            new(
                System.Text.Json.JsonSerializer.Serialize(new { access_token = accessToken, }),
                Encoding.UTF8,
                API_JSON_TYPE
            );

        var request = new HttpRequestMessage(
            HttpMethod.Delete,
            $"{API_SHARED_CLIENT.BaseAddress}applications/{API_TEMP_CLIENT_ID}/grant"
        );
        request.Headers.Add("Accept", "application/vnd.github+json");
        request.Headers.Add("User-Agent", API_PRODUCT.ToString());
        request.Content = jsonContent;

        var authenticationString = $"{API_TEMP_CLIENT_ID}:{API_TEMP_CLIENT_SECRET}";
        var base64EncodedAuthenticationString = Convert.ToBase64String(
            System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString)
        );
        request.Headers.Authorization = new AuthenticationHeaderValue(
            "Basic",
            base64EncodedAuthenticationString
        );

        HttpResponseMessage response = API_SHARED_CLIENT.Send(request);

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
    private async Task<string?> CreateRepo(string repoName)
    {
        if (accessToken == null)
        {
            Debug.WriteLine("Tried to create remote github repo without access token");
            return null;
        }

        CommonAuthenticatedHelper();

        using StringContent jsonContent =
            new(
                System.Text.Json.JsonSerializer.Serialize(new { name = repoName, }),
                Encoding.UTF8,
                API_JSON_TYPE
            );

        HttpResponseMessage response = await API_SHARED_CLIENT.PostAsync(
            "https://api.github.com/user/repos",
            jsonContent
        );
        if (response.StatusCode.ToString() == "Created")
        {
            Debug.WriteLine($"CreateRepo(): Repo {repoName} created.");
            string content = await response.Content.ReadAsStringAsync();
            JObject resJson = JObject.Parse(content);
            JToken? cloneUrlToken = resJson["clone_url"];
            if (cloneUrlToken == null)
            {
                return null;
            }
            return cloneUrlToken.ToString().Substring(8);
        }

        Debug.WriteLine($"CreateRepo(): Repo {repoName} creation failed.");
        return null;
    }

    /// <summary>
    /// A helper method that can be used many times. Reset the Http client to make the formatting of requests easier to do.
    /// </summary>
    private void CommonHelper()
    {
        API_SHARED_CLIENT.DefaultRequestHeaders.Clear();
        API_SHARED_CLIENT.DefaultRequestHeaders.UserAgent.Add(API_PRODUCT);
        API_SHARED_CLIENT.DefaultRequestHeaders.Accept.Add(API_JSON_TYPE);
    }

    /// <summary>
    /// A helper method for authenticated requests that can be used many times.
    /// </summary>
    private void CommonAuthenticatedHelper()
    {
        API_SHARED_CLIENT.DefaultRequestHeaders.Clear();
        API_SHARED_CLIENT.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            accessToken
        );
        API_SHARED_CLIENT.DefaultRequestHeaders.UserAgent.Add(API_PRODUCT);
        API_SHARED_CLIENT.DefaultRequestHeaders.Accept.Add(API_GITHUB_TYPE);
    }
}
