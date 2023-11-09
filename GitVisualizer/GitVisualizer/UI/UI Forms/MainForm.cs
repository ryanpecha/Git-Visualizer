using Namotion.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitVisualizer.UI.UI_Forms
{
    public partial class MainForm : Form
    {
        public static UITheme.AppTheme AppTheme = UITheme.DarkTheme;
        //public static UITheme.AppTheme AppTheme = UITheme.BlueThemeDark;
        //public static UITheme.AppTheme AppTheme = UITheme.BlueThemeLight;

        private RepositoriesControl repositoriesControl = new();
        private BranchesControl branchesControl = new();
        private MergingControl mergingControl = new();

        public MainForm()
        {
            InitializeComponent();
            ApplyColorTheme(AppTheme);
            CheckValidation();
        }

        private void MainFormLoad(object sender, EventArgs e) { }

        /// <summary>
        /// Checks if user has already logged in with this device, and show login page if not
        /// </summary>
        private void CheckValidation()
        {
            Debug.WriteLine("CHECKING VALIDATION");
            Debug.WriteLine(
                $"LOADED SETTINGS rememberGitHubLogin={GVSettings.data.rememberGitHubLogin}"
            );
            if (!GVSettings.data.rememberGitHubLogin)
            {
                Debug.WriteLine("DELETING LOCAL CREDENTIALS");
                GitAPI.github.DeleteToken();
            }
            if (!Github.LoadStoredCredentials())
            {
                Debug.WriteLine("LOADING SETUP FORM");
                SetupForm setup = new SetupForm();
                Hide();
                // Shows setup page as dialog, so closing it returns here
                setup.ShowDialog();
                SetVisibleCore(false);
            }
            ShowControlInMainPanel(repositoriesControl);
            repositoriesControl.EnterControl();
        }

        public void OnRepositoriesButtonPress(object sender, EventArgs e)
        {
            ShowControlInMainPanel(repositoriesControl);
        }

        public void OnBranchesButtonPress(object sender, EventArgs e)
        {
            ShowControlInMainPanel(branchesControl);
        }

        public void OnMergingButtonPress(object sender, EventArgs e)
        {
            ShowControlInMainPanel(mergingControl);
        }

        /// <summary>
        /// Clears current main panel control and swaps it for given User Control view
        /// </summary>
        /// <param name="control"></param>
        private void ShowControlInMainPanel(UserControl control)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Re opens the main window after it has been hidden
        /// </summary>
        public void ReOpenWindow()
        {
            Debug.WriteLine("REOPEN");
            this.Show();
            this.SetVisibleCore(true);
            this.MaximizeBox = true;
        }

        private void pushButton_Click(object sender, EventArgs e)
        {
            String repo_name = repositoriesControl.GetSelectedRepo();
            if (repo_name != null && repo_name.Length > 0)
            {
                RepositoryLocal? local_repo = null;
                RepositoryRemote? remote_repo = null;

                if (GitAPI.Getters.getLocalRepositories().ContainsKey(repo_name))
                {
                    local_repo = GitAPI.Getters.getLocalRepositories()[repo_name];
                }
                // check if repo is remote
                if (GitAPI.Getters.getRemoteRepositories().ContainsKey(repo_name))
                {
                    remote_repo = GitAPI.Getters.getRemoteRepositories()[repo_name];
                }
                
                if (local_repo != null)
                {
                    if (remote_repo != null)
                    {
                        GitAPI.Actions.RemoteActions.pushCommitToRemoteRepository();
                    }
                    else
                    {
                        // TODO: add name to create method???
                        GitAPI.Actions.RemoteActions.createRemoteRepository();
                    }
                }
            }
        }

        private void pullButton_Click(object sender, EventArgs e)
        {
            
        }

        private void fetchButton_Click(object sender, EventArgs e)
        {
            // find selected repository
        }

        private void undoButton_Click(object sender, EventArgs e)
        {

        }
    }
}
