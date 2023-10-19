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
        private Github githubAPI;
        public MainForm()
        {
            githubAPI = Program.Github;
            InitializeComponent();
            ApplyColorTheme(AppTheme);
            CheckValidation();
            this.Activated += PopulateReposTable;

        }


        /// <summary>
        /// Checks if user has already logged in with this device, and show login page if not
        /// </summary>
        private void CheckValidation()
        {
            if (!hasCredentials)
            {
                SetupForm setup = new SetupForm();
                this.Hide();
                // Shows setup page as dialog, so closing it returns here
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

        public void PopulateReposTable(object sender, EventArgs e)
        {
            repositoriesGrid.Rows.Add("row1,col1", "row1,col2");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
