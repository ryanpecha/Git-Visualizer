using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitVisualizer.UI.UI_Forms
{
    public partial class MergingControl : UserControl
    {


        private UI.UITheme.AppTheme theme = MainForm.AppTheme;
        private List<Tuple<string, string>> stagedChanges = new List<Tuple<string, string>>();
        private List<Tuple<string, string>> unstagedChanges = new List<Tuple<string, string>>();
        private List<Tuple<string, string>> diffResults = new List<Tuple<string, string>>();

        public MergingControl()
        {
            InitializeComponent();
            ApplyColorTheme(MainForm.AppTheme);
        }

        public void OnMergingControlFocus()
        {
            UpdateGridViews();
            UpdateLiveReposAndBranch();

        }


        private void UpdateLiveReposAndBranch()
        {


            if (GitAPI.liveRepository == null) { return; }

            Program.MainForm.UpdateAppTitle();
            activeRepositoryTextLabel.Text = GitAPI.liveRepository.title;
            activeRepositoryTextLabel.ForeColor = MainForm.AppTheme.TextBright;

            if (GitAPI.liveBranch != null)
            {
                checkedOutBranchTextLabel.Text = "Branch: " + GitAPI.liveBranch.title;
            }

            else if (GitAPI.liveCommit != null)
            {
                checkedOutBranchTextLabel.Text = "Commit: " + GitAPI.liveCommit.shortCommitHash;
            }

        }
        private void UpdateGridViews()
        {
            stagedChanges = GitAPI.Getters.getStagedFiles();
            unstagedChanges = GitAPI.Getters.getUnStagedFiles();
            stagedChangesDataGridView.Rows.Clear();
            unstagedChangesDataGridView.Rows.Clear();
            foreach (Tuple<string, string> change in stagedChanges)
            {
                string filename = Path.GetFileName(change.Item2) + " (" + change.Item2 + ")";
                int index = stagedChangesDataGridView.Rows.Add(filename, "-");
                stagedChangesDataGridView.Rows[index].Cells[0].ToolTipText = change.Item2;
                stagedChangesDataGridView.Rows[index].Cells[1].Style.ForeColor = theme.TextSelectable;
                stagedChangesDataGridView.Rows[index].Cells[1].Style.BackColor = theme.ElementBackground;
            }
            foreach (Tuple<string, string> change in unstagedChanges)
            {
                string filename = Path.GetFileName(change.Item2) + " (" + change.Item2 + ")";
                int index = unstagedChangesDataGridView.Rows.Add(filename, "+", "<-");
                unstagedChangesDataGridView.Rows[index].Cells[0].ToolTipText = change.Item2;
            }

            if (GitAPI.commitsBehind != null)
            {
                incomingCountTextLabel.Text = GitAPI.commitsBehind.ToString();
            }
            if (GitAPI.commitsAhead != null)
            {

                outgoingCountTextLabel.Text = GitAPI.commitsAhead.ToString();
            }

        }
        private void MergingControl_Load(object sender, EventArgs e)
        {

        }

        private void stagedChangesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 1) { return; }
            Debug.WriteLine("UNSTAGING " + stagedChanges[e.RowIndex].Item2);
            GitAPI.Actions.LocalActions.unStageChange(stagedChanges[e.RowIndex].Item2);
            UpdateGridViews();
        }

        private void unstagedChangesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) { return; }
            if (e.ColumnIndex == 1)
            {
                GitAPI.Actions.LocalActions.stageChange(unstagedChanges[e.RowIndex].Item2);
                UpdateGridViews();
            }
            else if (e.ColumnIndex == 2)
            {
                GitAPI.Actions.LocalActions.revertUnstagedChange(unstagedChanges[e.RowIndex].Item2);
                UpdateGridViews();
            }
        }

        private void commitMessageTextBox_TextChanged(object sender, EventArgs e)
        {
            if (commitMessageTextBox.Text.Length == 0)
            {
                commitChangesButton.Enabled = false;
            }
            else
            {
                commitChangesButton.Enabled = true;
            }
        }

        private void OnUnstageAllButton(object sender, EventArgs e)
        {
            GitAPI.Actions.LocalActions.unstageAllStagedChanges();
            UpdateGridViews();
        }

        private void OnStageAllButton(object sender, EventArgs e)
        {
            GitAPI.Actions.LocalActions.stageAllUnstagedChanges();
            UpdateGridViews();

        }
        private void OnRevertAllButton(object sender, EventArgs e)
        {
            GitAPI.Actions.LocalActions.revertAllUnstagedChanges();
            UpdateGridViews();
        }

        private void OnCommitChangesButton(object sender, EventArgs e)
        {
            string message = commitMessageTextBox.Text;
            GitAPI.Actions.LocalActions.commitStagedChanges(message);
            commitMessageTextBox.Text = string.Empty;
            UpdateGridViews();
        }

        private void OnSyncButton(object sender, EventArgs e)
        {
            GitAPI.Actions.RemoteActions.sync();
            UpdateGridViews();


        }

        private void UpdateDiffGridView()
        {
            diffGridView.Rows.Clear();
            foreach (Tuple<string, string> diff in diffResults)
            {
                int rowIndex = diffGridView.Rows.Add(diff.Item1, diff.Item2);
                if (diff.Item1.StartsWith("@"))
                {
                    diffGridView.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Aquamarine;
                }

                if (diff.Item1.StartsWith("+"))
                {
                    diffGridView.Rows[rowIndex].Cells[0].Style.BackColor = Color.DarkOliveGreen;
                }
                if (diff.Item1.StartsWith("-"))
                {
                    diffGridView.Rows[rowIndex].Cells[0].Style.BackColor = Color.DarkRed;
                }


                if (diff.Item2.StartsWith("+"))
                {
                    diffGridView.Rows[rowIndex].Cells[1].Style.BackColor = Color.DarkOliveGreen;
                }
                if (diff.Item2.StartsWith("-"))
                {
                    diffGridView.Rows[rowIndex].Cells[1].Style.BackColor = Color.DarkRed;
                }

            }
        }

        private void OnUnstagedFileCellSelected(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex != 0) { return; }
            string filePath = unstagedChanges[e.RowIndex].Item2;

            Debug.WriteLine("SELECTED FILE FOR DIFF: " + filePath);
            diffResults = GitAPI.Getters.getFileDiff(filePath, false);
            UpdateDiffGridView();
        }


        private void OnStagedFileCellSelected(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0) { return; }
            string filePath = stagedChanges[e.RowIndex].Item2;

            Debug.WriteLine("SELECTED FILE FOR DIFF: " + filePath);
            diffResults = GitAPI.Getters.getFileDiff(filePath, true);
            UpdateDiffGridView();
        }

    }
}
