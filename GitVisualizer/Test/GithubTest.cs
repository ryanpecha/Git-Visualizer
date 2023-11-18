using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using GithubSpace;
using System.Diagnostics;
using Moq;
using System.Security.Policy;
using Moq.Protected;
using Newtonsoft.Json;
using System.Text;
using System.Runtime.InteropServices.JavaScript;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace GithubTestSpace
{
    [TestClass]
    public class GithubTest : Github
    {
        private static Github _github = new();
        private TestContext context;
        private static MediaTypeWithQualityHeaderValue jsonType = new MediaTypeWithQualityHeaderValue("application/json");
        private String mockAccessToken = "ghu_TEST";

        private async void MockUserCode()
        {
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                device_code = "123-345",
                user_code = "FEUK-EVMK",
                vertification_uri = "https://github.com/login/device",
                expires_in = "900",
                interval = "5"
            }),
            Encoding.UTF8,
            jsonType);

            string url = "https://github.com/login/device/code";

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            httpResponse.Content = json;

            

            Mock<HttpMessageHandler> mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Post && r.RequestUri.ToString().StartsWith(url)),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);

            HttpClient httpClient = new HttpClient(mockHandler.Object);
            _github = new(httpClient, url);

            //act
            Task task = Task.Run(() => _github.GivePermission());
            task.Wait();
        }

        private async void MockAccessCode()
        {
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                access_token = mockAccessToken,
                scope = "",
                token_type = "bearer"
            }),
            Encoding.UTF8,
            jsonType);

            string url = "https://github.com/login/oauth/access_token";

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            httpResponse.Content = json;

            Mock<HttpMessageHandler> mockHandler = new Mock<HttpMessageHandler>();

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Post && r.RequestUri.ToString().StartsWith(url)),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);

            HttpClient httpClient = new HttpClient(mockHandler.Object);
            SetHttpClient(httpClient, url);

            //act
            Task task = Task.Run(_github.WaitForAuthorization);
            task.Wait();
        }

        private void SetMockWebHandler(StringContent jsonObject, string urlString, System.Net.HttpStatusCode code, HttpMethod method)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = code;
            httpResponse.Content = jsonObject;

            Mock<HttpMessageHandler> mockHandler = new Mock<HttpMessageHandler>();


            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == method && r.RequestUri.ToString().StartsWith(urlString)),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);

            HttpClient httpClient = new HttpClient(mockHandler.Object);
            SetHttpClient(httpClient, urlString);
        }

        [TestMethod]
        public void GivePermission_GetUserCode_Test01()
        {
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                interval = 5,
                device_code = "340234",
                user_code = "GJE123"
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://github.com/login/device/code", System.Net.HttpStatusCode.OK, HttpMethod.Post);

            //act
            Task task = Task.Run(() => _github.GivePermission("public"));
            task.Wait();
            StringAssert.Equals(Github.userCode, "GJE123");
        }

        [TestMethod]
        public void GivePermission_FailGenerationCode_Test02()
        {
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                error = "error"
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://github.com/login/device/code", System.Net.HttpStatusCode.BadRequest, HttpMethod.Post);

            //act
            Task task = Task.Run(() => _github.GivePermission("public"));
            task.Wait();
            StringAssert.Equals(Github.userCode, null);
        }

        [TestMethod]
        public void GetRepositories_NoAccessToken_Test01()
        {
            _github = new();
            Task task = Task.Run(() => _github.GetRepositories());
            Assert.AreEqual(null, _github.repos);
        }

        [TestMethod]
        public void GetRepositories_AccessTokenExist_Test02()
        {
            Github.SetTestAccessCode();

            //arrange
            var reposList = new List<Repo>
                {
                    new Repo() { name="1", git_url="git://github.com/test/1.git"},
                    new Repo() { name="2", git_url="git://github.com/test/2.git"},
                    new Repo() { name="3", git_url="git://github.com/test/3.git"},
                    new Repo() { name="4", git_url="git://github.com/test/4.git"},
                };
            var json = JsonConvert.SerializeObject(reposList);

            string url = "http://localhost:1234";

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            httpResponse.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var emptyList = new List<Repo>
            {
            };
            var emptyJSON = JsonConvert.SerializeObject(emptyList);
            HttpResponseMessage emptyHttpResponse = new HttpResponseMessage();
            emptyHttpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            emptyHttpResponse.Content = new StringContent(emptyJSON, Encoding.UTF8, "application/json");

            Mock<HttpMessageHandler> mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString().StartsWith(url) && r.RequestUri.ToString().EndsWith("1")),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString().StartsWith(url) && r.RequestUri.ToString().EndsWith("2")),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(emptyHttpResponse);


            HttpClient httpClient = new HttpClient(mockHandler.Object);
            SetHttpClient(httpClient, url);

            //act
            Task task = Task.Run(() => _github.GetRepositories());
            task.Wait();

            for (int i = 0; i < _github.repos.Count; i++)
            {
                StringAssert.Equals(reposList[i].name, _github.repos[i].name);
                StringAssert.Equals(reposList[i].git_url.Substring(6), _github.repos[i].git_url);
            }
        }

        [TestMethod]
        public void WaitForAuthorization_RetrieveAccessToken_Test01()
        {
            MockUserCode();
            MockAccessCode();
            StringAssert.Equals(mockAccessToken, Github.accessToken);
        }

        [TestMethod]
        public void WaitForAuthorization_AccessDenied_Test02()
        {
            ResetData();
            SetUserCode();

            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                error = "access_denied"
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://github.com/login/oauth/access_token", System.Net.HttpStatusCode.OK, HttpMethod.Post);

            //act
            Task task = Task.Run(_github.WaitForAuthorization);
            task.Wait();
            Assert.AreEqual(null, accessToken);
        }

        [TestMethod]
        public void WaitForAuthorization_Timeout01_Test03()
        {
            ResetData();
            SetUserCode();

            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                error = "timeout"
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://github.com/login/oauth/access_token", System.Net.HttpStatusCode.OK, HttpMethod.Post);

            //act
            Task task = Task.Run(_github.WaitForAuthorization);
            task.Wait();
            Assert.AreEqual(null, accessToken);
        }

        [TestMethod]
        public void WaitForAuthorization_Timeout02_Test04()
        {
            ResetData();
            SetUserCode();

            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                waiting = "waiting for authorization"
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://github.com/login/oauth/access_token", System.Net.HttpStatusCode.BadRequest, HttpMethod.Post);

            //act
            Task task = Task.Run(_github.WaitForAuthorization);
            task.Wait();
            Assert.AreEqual(null, accessToken);
        }

        [TestMethod]
        public void WaitForAuthorization_NoUserCode_Test05()
        {
            Github.ResetData();
            Task task = Task.Run(WaitForAuthorization);
            Assert.AreEqual(null, Github.accessToken);
            task.Wait();
        }

        [TestMethod]
        public void GetUserInfo_GetUsername_Test01()
        {
            Github.SetTestAccessCode();

            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                login = "octocat",
                id = 1,
                node_id = "MDQ6VXNlcjE=",
                avatar_url = "https://github.com/images/error/octocat_happy.gif",
                gravatar_id = "none",
                url = "https://api.github.com/users/octocat",
                html_url = "https://github.com/octocat",
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://api.github.com/user", System.Net.HttpStatusCode.OK, HttpMethod.Get);

            //act
            Task task = Task.Run(_github.GetUserInfo);
            task.Wait();

            StringAssert.Equals("octocat", _github.username);
            StringAssert.Equals("https://github.com/images/error/octocat_happy.gif", _github.avatarURL);
            StringAssert.Equals("https://github.com/octocat", _github.userGitHubURL);
        }

        [TestMethod]
        public void GetUserInfo_NoAccessToken_Test02()
        {
            ResetData();
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                login = "octocat",
                id = 1,
                node_id = "MDQ6VXNlcjE=",
                avatar_url = "https://github.com/images/error/octocat_happy.gif",
                gravatar_id = "none",
                url = "https://api.github.com/users/octocat",
                html_url = "https://github.com/octocat",
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://api.github.com/user", System.Net.HttpStatusCode.OK, HttpMethod.Get);

            //act
            Task task = Task.Run(_github.GetUserInfo);
            task.Wait();

            StringAssert.Equals(null, _github.username);
        }

        [TestMethod]
        public void GetUserInfo_APIError_Test03()
        {
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://api.github.com/user", System.Net.HttpStatusCode.BadRequest, HttpMethod.Get);

            //act
            Task task = Task.Run(_github.GetUserInfo);
            task.Wait();

            StringAssert.Equals(null, _github.username);
        }

        [TestMethod]
        public void DeleteToken_DeleteValid_Test01()
        {
            Github.SetTestAccessCode();
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://api.github.com/applications/", System.Net.HttpStatusCode.NoContent, HttpMethod.Delete);

            //act
            Task task = Task.Run(_github.DeleteToken);
            task.Wait();
            StringAssert.Equals(null, Github.accessToken);
        }

        [TestMethod]
        public void DeleteToken_DeleteInvalid01_Test02()
        {
            Github.SetTestAccessCode();
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://api.github.com/applications/", System.Net.HttpStatusCode.BadRequest, HttpMethod.Delete);

            //act
            bool deleted = _github.DeleteToken();
            Assert.IsTrue(!deleted);
        }

        [TestMethod]
        public void DeleteToken_DeleteInvalid02_Test03()
        {
            Github.SetTestAccessCode();
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://api.github.com/applications/", System.Net.HttpStatusCode.NotModified, HttpMethod.Delete);

            //act
            bool deleted = _github.DeleteToken();
            Assert.IsTrue(!deleted);
        }

        [TestMethod]
        public void DeleteToken_NoAccessToken_Test03()
        {
            ResetData();
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://api.github.com/applications/", System.Net.HttpStatusCode.PartialContent, HttpMethod.Delete);

            //act
            bool deleted = _github.DeleteToken();
            Assert.IsTrue(!deleted);
        }

        [TestMethod]
        public void CreateAuthenticatedGit_int_Valid_Test01()
        {
            Github.SetTestAccessCode();

            //arrange
            var reposList = new List<Repo>
                {
                    new Repo() { name="1", git_url="git://github.com/test/1.git"},
                    new Repo() { name="2", git_url="git://github.com/test/2.git"},
                    new Repo() { name="3", git_url="git://github.com/test/3.git"},
                    new Repo() { name="4", git_url="git://github.com/test/4.git"},
                };
            var json = JsonConvert.SerializeObject(reposList);

            string url = "http://localhost:1234";

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            httpResponse.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var emptyList = new List<Repo>
            {
            };
            var emptyJSON = JsonConvert.SerializeObject(emptyList);
            HttpResponseMessage emptyHttpResponse = new HttpResponseMessage();
            emptyHttpResponse.StatusCode = System.Net.HttpStatusCode.OK;
            emptyHttpResponse.Content = new StringContent(emptyJSON, Encoding.UTF8, "application/json");

            Mock<HttpMessageHandler> mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString().StartsWith(url) && r.RequestUri.ToString().EndsWith("1")),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);

            mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get && r.RequestUri.ToString().StartsWith(url) && r.RequestUri.ToString().EndsWith("2")),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(emptyHttpResponse);


            HttpClient httpClient = new HttpClient(mockHandler.Object);
            SetHttpClient(httpClient, url);

            //act
            Task task = Task.Run(() => _github.GetRepositories());
            task.Wait();

            for (int i = 0; i < _github.repos.Count; i++)
                StringAssert.Equals($"https://{Github.accessToken}@github.com/test/{i + 1}.git", _github.CreateAuthenticatedGit(i));

            Assert.AreEqual($"createAuthenticatedGit(): Invalid index: {_github.repos.Count}", _github.CreateAuthenticatedGit(_github.repos.Count));
            Assert.AreEqual("createAuthenticatedGit(): Invalid index: -1", _github.CreateAuthenticatedGit(-1));
        }

        [TestMethod]
        public void CreateAuthenticatedGit_int_NoAccessToken_Test02()
        {
            ResetData();
            Assert.AreEqual(null, _github.CreateAuthenticatedGit(0));
        }

        [TestMethod]
        public void CreateAuthenticatedGit_str_Valid_Test01()
        {
            SetTestAccessCode();
            Assert.AreEqual($"https://{Github.accessToken}@test", _github.CreateAuthenticatedGit("test"));
        }

        [TestMethod]
        public void CreateAuthenticatedGit_str_NoAccessToken_Test02()
        {
            ResetData();
            Assert.AreEqual(null, _github.CreateAuthenticatedGit("test"));
        }

        [TestMethod]
        public void SetRememberUserAccessBool_Set_Test01()
        {
            _github.SetRememberUserAccessBool(true);
            Assert.AreEqual(true, _github.RememberUserAccess);

            _github.SetRememberUserAccessBool(false);
            Assert.AreEqual(false, _github.RememberUserAccess);
        }

        [TestMethod]
        public void CreateRepository_NoAccessToken_Test01()
        {
            ResetData();
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://api.github.com/applications/", System.Net.HttpStatusCode.Created, HttpMethod.Post);

            //act
            String result = Task.Run(() => _github.CreateRepo("test")).Result;
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void CreateRepository_Valid_Test02()
        {
            SetTestAccessCode();
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
                clone_url = "https://github.com/octocat/test.git"
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://api.github.com/user/repos", System.Net.HttpStatusCode.Created, HttpMethod.Post);

            //act
            String result = Task.Run(() => _github.CreateRepo("test")).Result;
            Assert.AreEqual("github.com/octocat/test.git", result);
        }

        [TestMethod]
        public void CreateRepository_BadAPIResponse_Test03()
        {
            SetTestAccessCode();
            using StringContent json = new(
            System.Text.Json.JsonSerializer.Serialize(new
            {
            }),
            Encoding.UTF8,
            jsonType);

            SetMockWebHandler(json, "https://api.github.com/user/repos", System.Net.HttpStatusCode.BadRequest, HttpMethod.Post);

            //act
            String result = Task.Run(() => _github.CreateRepo("test")).Result;
            Assert.AreEqual(null, result);
        }


        [TestMethod]
        public void Credential_SetGetDelete_Test01()
        {
            ResetData();
            SetUsername();
            SetTestAccessCode();

            string tempAccessToken = accessToken;
            string tempUsername = username;

            Assert.AreEqual(true, SaveUser());
            Assert.AreEqual(true, ReadTokenAndUserName());
            Assert.AreEqual(tempUsername, username);
            Assert.AreEqual(tempAccessToken, accessToken);
            Assert.AreEqual(true, DeleteStoredCredential());

        }

        [TestMethod]
        public void Credential_AlreadyExist_Test02()
        {
            ResetData();
            SetUsername();
            SetTestAccessCode();

            Assert.AreEqual(true, SaveUser());
            Assert.AreEqual(false, SaveUser());
            Assert.AreEqual(true, DeleteStoredCredential());
        }

        [TestMethod]
        public void Credential_RetrieveNothing_Test03()
        {
            ResetData();
            SetUsername();
            SetTestAccessCode();

            DeleteStoredCredential();
            Assert.AreEqual(false, ReadTokenAndUserName());
        }

        [TestMethod]
        public void Credential_AlreadyDeleted_Test04()
        {
            ResetData();
            SetUsername();
            SetTestAccessCode();

            DeleteStoredCredential();
            Assert.AreEqual(false, DeleteStoredCredential());
        }

        [TestMethod]
        public void Credential_NothingToSave_Test04()
        {
            ResetData();
            Assert.AreEqual(false, SaveUser());
        }
    }
}
