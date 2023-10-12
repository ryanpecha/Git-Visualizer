Overall (for frontend developers):

- We are connecting to the GitHub API via GitHub's OAuth App feature.
- Nam registered our program as an OAuth App on GitHub.
- TEMP: Client ID and secret for the app are stored in the Github class for now. DON'T SHARE WITH ANYONE.

Instructions:
- For the app to access a user's API, first call GivePermission(). userCode should have a value after it runs. Displays userCode to user.
- Calls WaitForAuthorization(). This function will simply wait for user to input userCode into https://github.com/login/device.
- NOTE: I will leave it to frontend to decide how they can prompt user to enter userCode to website.
- To test WaitForAuthorization() is successful, you can retrieve the user's repository list via: GetRepositories().
- IF you want to delete a user token (might be useful for security purposes), call DeleteToken() when you no longer need the GitHub API.

- Please see TestAsync for a simple example of how getting the GitHub user's repository list would look like.

Implementation Specifics:
- All of these functions do not return anything useful.
- I set up members that you can access directly:
- userCode: displays this to user so they can go to https://github.com/login/device and enter it to give app's read/write repository permission.

API:
- None of the methods in the API should block. Hopefully, your frontend UI won't freeze due to the following methods:

- Github(): creates the Github object. Nothing in it for now.
- GivePermission(): Used along with WaitForAuthorization(). Starts the process to get user's permission to view/write to their repositories.
- WaitForAuthorization(): Used along with GivePermission(). Polls website for authorization from user.
- GetRepositories(): Retrieve user's repository list as a JSON object. TODO: Has really BAD formatting. Need to format for frontend.
- DeleteToken(): Deletes user access token, essentially disassociating user from the API.