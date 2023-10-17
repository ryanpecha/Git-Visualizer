using GitVisualizer.UI;
using GitVisualizer.UI.UI_Forms;
using System.Diagnostics;

namespace GitVisualizer
{
    /// <summary>
    /// Code for the Workspace Form Window, including event handlers, color theme settings, and component initialization
    /// </summary>
    public partial class SetupForm : Form
    {
        public UITheme.AppTheme AppTheme = UITheme.DarkTheme;

        public SetupForm()
        {
            InitializeComponent();
            ApplyColorTheme(AppTheme);
            this.FormClosing += new FormClosingEventHandler(Form1_Close);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
           // mainForm.Dispose();
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

        /// <summary>
        /// Loads main page routed from Remote login button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadMainAppFormRemote(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            this.SetVisibleCore(false);
            main.ShowDialog();
            this.Close();
        }
        /// <summary>
        /// Loads main page routed from local repository button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadMainAppFormLocal(object sender, EventArgs e)
        {
            Debug.WriteLine("Loading Main App...");
            MainForm main = new MainForm();
            main.ShowDialog();
            this.Close();
        }
    }
}