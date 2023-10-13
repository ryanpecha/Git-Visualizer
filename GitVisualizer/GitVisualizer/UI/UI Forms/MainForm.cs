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
        private bool hasCredentials = false;
        public UITheme.AppTheme AppTheme = UITheme.DarkTheme;
        public MainForm()
        {
            InitializeComponent();
            ApplyColorTheme(AppTheme);
            CheckValidation();
        }

        /// <summary>
        /// Checks if user has already logged in with this device, and show login page if not
        /// </summary>
        private void CheckValidation()
        {
            Debug.WriteLine("HERE");
            if (!hasCredentials)
            {
                SetupForm setup = new SetupForm(this);
                this.Hide();
                setup.ShowDialog();
                this.SetVisibleCore(false);
            }
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
