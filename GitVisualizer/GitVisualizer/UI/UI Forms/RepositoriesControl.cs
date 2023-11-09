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
        private String selected_repo;
        public RepositoriesControl()
        {
            githubAPI = Program.Github;
            selected_repo = "";
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
            GitAPI.Scanning.scanForAllReposAsync(InitCallback);
        }

        public String GetSelectedRepo()
        {
            return selected_repo;
        }

        private void InitCallback()
        {
            Debug.WriteLine("InitCallback()");
            //AddReposToTable();
            Invoke(AddReposToTable);
        }

        /// <summary>
        /// Main thread function to populate data grid cells with APi result repos
        /// </summary>
        public void AddReposToTable()
        {
            Debug.WriteLine("AddReposToTable()");
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

        private void TrackDirectory(object sender, EventArgs e)
        {
            GitAPI.Actions.LocalActions.userSelectTrackDirectory(false, InitCallback);
        }
        private void TrackDirectoryRecursive(object sender, EventArgs e)
        {
            GitAPI.Actions.LocalActions.userSelectTrackDirectory(true, InitCallback);
        }

        private void RevokeGithubAuthenticationButtonPressed(object sender, EventArgs e)
        {
            //TODO: Revoke function
            Program.Github.DeleteToken();
        }
        private void repositoriesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell local = (DataGridViewTextBoxCell)
                repositoriesGridView.Rows[e.RowIndex].Cells[0];
            DataGridViewTextBoxCell remote = (DataGridViewTextBoxCell)
                repositoriesGridView.Rows[e.RowIndex].Cells[1];

            if (local != null && remote != null)
            {
                // select remote without local copy
                if (local.Value.ToString() == "Clone to Local")
                {
                    selected_repo = remote.Value.ToString();
                }
                // select local without remote copy
                else if (remote.Value.ToString() == "Push to remote")
                {
                    selected_repo = local.Value.ToString();
                }
                // select both
                else
                {
                    selected_repo = remote.Value.ToString();
                }
                Debug.WriteLine(selected_repo);
            }
        }

        private void openOnGithubcomToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void repositoriesControlPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
