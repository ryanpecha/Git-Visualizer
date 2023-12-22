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

using GithubSpace;

namespace GitVisualizer.UI.UI_Forms
{
    public partial class RepositoriesControl : UserControl
    {
        private Github githubAPI;
        private Tuple<RepositoryLocal?, RepositoryRemote?> selectedRepo = new Tuple<RepositoryLocal?, RepositoryRemote?>(null, null);
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
            GitAPI.Scanning.scanForAllRepos(UpdateGridCallback);
        }



        public void UpdateGridCallback()
        {
            Debug.WriteLine("UpdateGridCallback()");
            //AddReposToTable();

            Invoke(AddReposToTable);
        }

        /// <summary>
        /// Main thread function to populate data grid cells with APi result repos
        /// </summary>
        public void AddReposToTable()
        {
            Program.MainForm.UpdateAppTitle();

            Debug.WriteLine("AddReposToTable()");
            allRepos = GitAPI.Getters.getAllRepositories();

            if (GitAPI.liveRepository != null)
            {
                activeRepositoryTextLabel.Text = GitAPI.liveRepository.title;
                activeRepositoryTextLabel.ForeColor = MainForm.AppTheme.TextBright;
            }


            //repositoriesGridView.Rows.Clear();
            repositoriesGridView.Columns.Clear();
            repositoriesGridView.DataSource = null;
            repositoriesGridView.DataSource = allRepos;
            repositoriesGridView.Columns[0].HeaderCell.Value = "Local Repositories";
            repositoriesGridView.Columns[1].HeaderCell.Value = "Remote Repositories";

            localRepoComboBox.DataSource = null;
            localRepoComboBox.DataSource = GitAPI.Actions.LocalActions.getTrackedDirs();
        }

        private void repositoriesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }

            selectedRepo = (Tuple<RepositoryLocal?, RepositoryRemote?>)repositoriesGridView.Rows[e.RowIndex].DataBoundItem;
            if (selectedRepo == null) { return; }
            // If local exists
            if (selectedRepo.Item1 != null)
            {
                localRepoButtonsLabel.Text = "Local: " + selectedRepo.Item1.title;
                cloneToLocalButton.Visible = false;
                setAsActiveRepoButton.Visible = true;
                openInFileExplorerButton.Visible = true;
            }
            else
            {
                localRepoButtonsLabel.Text = "No Local Repo, Need to Clone First!";
                cloneToLocalButton.Visible = true;
                setAsActiveRepoButton.Visible = false;
                openInFileExplorerButton.Visible = false;
            }

            // If remote exists
            if (selectedRepo.Item2 != null)
            {
                remoteRepoButtonsLabel.Text = "Remote: " + selectedRepo.Item2.title;
                createNewRemoteRepoButton.Visible = false;
                openOnGithubComButton.Visible = true;
            }
            else
            {
                remoteRepoButtonsLabel.Text = "No Remote for This Local. Create New Remote Repo First.";
                createNewRemoteRepoButton.Visible = true;
                openOnGithubComButton.Visible = false;
            }

        }

        private void OnCreateNewLocalRepoButton(object sender, EventArgs e)
        {
            GitAPI.Actions.LocalActions.createLocalRepository(UpdateGridCallback);
        }

        private void OnOpenInFileExplorerButton(object sender, EventArgs e)
        {
            if (selectedRepo == null && selectedRepo.Item1 == null) { return; }
            Process.Start("explorer.exe", selectedRepo.Item1.dirPath);

        }
        private void OnTrackExistingReposButton(object sender, EventArgs e)
        {
            GitAPI.Actions.LocalActions.userSelectTrackDirectory(true, UpdateGridCallback);
        }

        private void OnCloneToLocalButton(object sender, EventArgs e)
        {
            if (selectedRepo == null && selectedRepo.Item2 == null) { return; }
            GitAPI.Actions.RemoteActions.cloneRemoteRepository(selectedRepo.Item2, UpdateGridCallback);
        }

        private void OnSetAsActiveRepoButton(object sender, EventArgs e)
        {
            if (selectedRepo == null && selectedRepo.Item1 == null) { return; }
            GitAPI.Actions.LocalActions.setLiveRepository(selectedRepo.Item1);
            activeRepositoryTextLabel.Text = selectedRepo.Item1.title;
            activeRepositoryTextLabel.ForeColor = MainForm.AppTheme.TextBright;
            Program.MainForm.UpdateAppTitle();
        }

        private void OnOpenOnGithubComButton(object sender, EventArgs e)
        {
            if (selectedRepo == null && selectedRepo.Item2 == null) { return; }
            Process.Start(new ProcessStartInfo { FileName = selectedRepo.Item2.webURL, UseShellExecute = true });

        }

        private void OnCreateNewRemoteRepoButton(object sender, EventArgs e)
        {
            GitAPI.Actions.RemoteActions.createRemoteRepository(selectedRepo.Item1, UpdateGridCallback);
        }


        private void OnUntrackReposButton(object sender, EventArgs e)
        {
            LocalTrackedDir tracked = localRepoComboBox.SelectedItem as LocalTrackedDir;
            if (tracked == null) { return; }
            GitAPI.Actions.LocalActions.untrackDirectory(tracked, UpdateGridCallback);
        }
    }
}
