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
        private Tuple<RepositoryLocal?, RepositoryRemote?> activeRepo = new Tuple<RepositoryLocal?, RepositoryRemote?>(null, null);
        private List<Tuple<RepositoryLocal?, RepositoryRemote?>> allRepos = new();



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
            GitAPI.Scanning.scanForAllReposAsync(InitCallback);
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
            allRepos = GitAPI.Getters.getAllRepositories();

            repositoriesGridView.Rows.Clear();
            repositoriesGridView.Columns.Clear();
            repositoriesGridView.DataSource = allRepos;
            repositoriesGridView.Columns[0].HeaderCell.Value = "Local Repositories";
            repositoriesGridView.Columns[1].HeaderCell.Value = "Remote Repositories";

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
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }

            activeRepo = (Tuple<RepositoryLocal?, RepositoryRemote?>)repositoriesGridView.Rows[e.RowIndex].DataBoundItem;
            Debug.WriteLine(activeRepo.Item2.title);
            if (activeRepo.Item1 == null)
            {
                Debug.WriteLine("Need to Clone a remote first!");
                return;
            }
            GitAPI.Actions.LocalActions.setLiveRepository(activeRepo.Item1);
        }


        private void repositoriesControlPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RepositoriesControl_Load(object sender, EventArgs e)
        {

        }

        private void remoteRepositoryActionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
