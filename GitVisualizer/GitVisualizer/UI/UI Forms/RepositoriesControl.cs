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
    public partial class RepositoriesControl : UserControl
    {
        private Github githubAPI;
        public RepositoriesControl()
        {
            githubAPI = Program.Github;
            InitializeComponent();
            ApplyColorTheme(MainForm.AppTheme);
        }


        /// <summary>
        /// Use Github API to request remote repositories then add results to repos data grid table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PopulateReposDataGrid(object sender, EventArgs e)
        {
            GetRepositoriesData();
        }

        /// <summary>
        /// Async awaits Github API request to get all remote repositories before invoking main thread
        /// call to populate table cells with Repo info
        /// </summary>
        private async void GetRepositoriesData()
        {
            if (githubAPI == null) { return; }
            await githubAPI.GetRepositories();
            List<Repo> githubRepositories = githubAPI.repos;
            if (githubRepositories == null) { return; }
            foreach (Repo repo in githubRepositories)
            {
                Debug.WriteLine(repo.name);
            }
            Invoke(AddReposToTable);

        }

        /// <summary>
        /// Main thread function to populate data grid cells with APi result repos
        /// </summary>
        public void AddReposToTable()
        {
            List<Repo> githubRepositories = githubAPI.repos;
            for (int i = 0; i < githubRepositories.Count; i++)
            {
                repositoriesGridView.Rows.Add("Local path for: " + githubRepositories[i].name, githubRepositories[i].name);
            }

        }

        private void repositoriesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void openOnGithubcomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
