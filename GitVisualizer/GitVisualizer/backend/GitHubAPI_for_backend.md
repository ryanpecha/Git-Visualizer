Overall (for backend developers):
- Make sure you set a user agent via: <clientVariable>.DefaultRequestHeaders.UserAgent.Add().
- Make sure to set your accepted reponse type via: <clientVariable>.DefaultRequestHeaders.Accept.Add()
- Know the basic of "basic authentication" and using "Bearer token" in the Authorization header.
- TEMP: Client ID and secret are stored in the Github class for now. DON'T SHARE WITH ANYONE.

Instructions:
- For the app to access a user's API, first call GivePermission(). userCode should have a value after it runs. Displays userCode to user.
- Calls WaitForAuthorization(). This function will simply wait for user to input userCode into https://github.com/login/device.
- NOTE: I will leave it to frontend to decide how they can prompt user to enter userCode to website.
- To test WaitForAuthorization() is successful, you can retrieve the user's repository list via: GetRepositories().
- IF you want to delete a user token (might be useful for security purposes), call DeleteToken() when you no longer need the GitHub API.

Implementation Specifics:
- None of the methods should block. Do NOT write blocking code!
- Please see TestAsync for a simple example of how getting the GitHub user's repository list would look like.
- Many of the methods are asynchronous, meaning you might have to use await or put my code inside a loop so you can retrieve data appropriately.
  I tend to create an infinite loop after calling my TestAsync() method so that the method has time to process the API.

Members that you can get from class object:
- userCode: A String for user code. Displays this to user so they can go to https://github.com/login/device and enter it to give app's read/write repository permission.
- repos: A List of Repo class objects. A Repo object has 2 fields: String name and String git_url.
- username: A String for the Github username
- userGitHubURL: A String for the Github user profile page.

API:
- createAuthenticatedGit(int i): returns a String URL for which you can use git clone on that URL. The parameter selects which element of <repos> you can to retrieve.
  For Backend developers: Using git clone with this will actually bypass any needs to enter password for future git pull/push. There might also be other functionalities being bypassed as well.

- None of the methods below should block. Hopefully, your frontend UI won't freeze due to the following methods:

- Github(): creates the Github object. Nothing in it for now.
- GivePermission(): Used along with WaitForAuthorization(). Starts the process to get user's permission to view/write to their repositories.
- WaitForAuthorization(): Used along with GivePermission(). Polls website for authorization from user.
- GetRepositories(): Retrieve user's repository list. See <repos> member.
- DeleteToken(): Deletes user access token, essentially disassociating user from the API.
- GetRepositories(): Retrieve user's repository into <repos> member variable.