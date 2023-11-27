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
            branchesControl.OnBranchesControlFocus();
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
  
    }
}
