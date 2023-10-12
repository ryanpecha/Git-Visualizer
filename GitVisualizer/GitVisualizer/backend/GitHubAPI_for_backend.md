Overall (for backend developers):

- Make sure you set a user agent via: <clientVariable>.DefaultRequestHeaders.UserAgent.Add().
- Make sure to set your accepted reponse type via: <clientVariable>.DefaultRequestHeaders.Accept.Add()
- Know the basic of "basic authentication" and using "Bearer token" in the Authorization header.
- TEMP: Client ID and secret are stored in the Github class for now. DON'T SHARE WITH ANYONE.

Implementation Specifics:
- None of the methods should block. Do NOT write blocking code!