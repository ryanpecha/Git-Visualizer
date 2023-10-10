using GitVisualizer.UI;

namespace GitVisualizer
{
    /// <summary>
    /// Code for the Workspace Form Window, including event handlers, color theme settings, and component initialization
    /// </summary>
    public partial class GitHelperLogin : Form
    {
        public UITheme.AppTheme AppTheme = UITheme.DarkTheme;
        public GitHelperLogin()
        {
            InitializeComponent();
            ApplyColorTheme(AppTheme);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event handler that highlights the Github login button to signify login is required for user's desired use case
        /// </summary>
        private void HighlightLoginButton(object sender, EventArgs e)
        {
            githubLoginButton.Select();
        }
        /// <summary>
        /// Event handler that highlights the Local Workspace button to signify no login is required for user's desired use case
        /// </summary>
        private void HighlightLocalButton(object sender, EventArgs e)
        {
            localWorkspaceButton.Select();
        }
    }
}