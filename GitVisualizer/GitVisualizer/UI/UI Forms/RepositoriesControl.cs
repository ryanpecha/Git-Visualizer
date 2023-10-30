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
        public void EnterControl()
        {
            //GetLocalRepositoriesData();
            //GetRemoteRepositoriesData();
            //AddReposToTable();
            GitAPI.initializeAsync(InitCallback);
        }

        private void InitCallback()
        {
            Invoke(AddReposToTable);
        }
        /// <summary>
        /// Main thread function to populate data grid cells with APi result repos
        /// </summary>
        public void AddReposToTable()
        {
            List<Tuple<string, RepositoryLocal?, RepositoryRemote?>> allRepos = GitAPI.Getters.getAllRepositories();

   
            repositoriesGridView.Rows.Clear();



            foreach (Tuple<string, RepositoryLocal?, RepositoryRemote?> repoTuple in allRepos)
            {
                // repoTile, local, remote

                if (repoTuple.Item2 != null && repoTuple.Item3 != null)
                {
                    repositoriesGridView.Rows.Add(repoTuple.Item2.dirPath, repoTuple.Item3.title);
                }
                else if (repoTuple.Item2 != null)
                {
                    repositoriesGridView.Rows.Add(repoTuple.Item2.dirPath, "Push to remote");
                }
                else if (repoTuple.Item3 != null)
                {
                    repositoriesGridView.Rows.Add("Clone to Local", repoTuple.Item3.title);
                }

            }
            /*
            for (int i = 0; i < githubRepositories.Count; i++)
            {
                repositoriesGridView.Rows.Add("Local path for: " + githubRepositories[i].title, githubRepositories[i].title);
            }
            */

        }

        private void repositoriesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void openOnGithubcomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
