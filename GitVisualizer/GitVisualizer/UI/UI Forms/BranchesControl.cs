using Microsoft.ApplicationInsights;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitVisualizer.UI.UI_Forms
{
    public partial class BranchesControl : UserControl
    {
        private const int pixelsPerBranchNode = 32;
        private const int pixelsPerBranchRow = 42;
        private const int branchNodeRadius = 12;
        private List<Color> branchNodeColors =
            [Color.PowderBlue,
            Color.LightGreen,
            Color.DarkSalmon,
            Color.Gold,
            Color.Plum];

        private Tuple<List<Branch>, List<Commit>> commitHistory = null;
        Commit selectedCommit = null;
        private int currentDepth = 0;


        public BranchesControl()
        {
            InitializeComponent();
            ApplyColorTheme(MainForm.AppTheme);
        }

        public void OnBranchesControlFocus()
        {
            UpdateActiveRepoText();
            UpdateGridView();
        }

        private void UpdateActiveRepoText()
        {
            if (GitAPI.liveRepository == null) { return; }

            activeRepositoryTextLabel.Text = GitAPI.liveRepository.title;
            activeRepositoryTextLabel.ForeColor = MainForm.AppTheme.TextBright;
        }
        private void UpdateGridView()
        {
            // Update view by getting branch info
            branchesGridView.Rows.Clear();
            commitHistory = GitAPI.Getters.getCommitsAndBranches();
            foreach (Commit commit in commitHistory.Item2)
            {
                List<Branch> branches = commit.branches;
                string branchList = String.Join(", ", branches);
                Debug.WriteLine(commit.subject);
                int index = branchesGridView.Rows.Add(null, branchList, commit.shortCommitHash, commit.committerName, commit.committerDate, commit.subject);
                branchesGridView.Rows[index].Cells[0].ToolTipText = commit.longCommitHash;
            }
        }

        public void OnCheckoutToBranchButton()
        {
            Branch selected = null;
            GitAPI.Actions.LocalActions.checkoutBranch(selected);
        }

        public void OnDeleteBranchButton()
        {
            Branch selected = null;
            GitAPI.Actions.LocalActions.deleteBranchLocal(selected);
        }

        public void OnCreateBranchFromCurrentButton()
        {
            string title = null;
            Branch branch = GitAPI.Actions.LocalActions.createLocalBranch(title, GitAPI.liveCommit);
            GitAPI.Actions.RemoteActions.addLocalBranchToRemote(branch);
        }

        public void OnCheckoutToSelectedCommitButton()
        {
            if (selectedCommit == null) { return; }
            GitAPI.Actions.LocalActions.checkoutCommit(selectedCommit);
        }

        public void OnCreateBranchFromSelectedButton()
        {

        }

        /// <summary>
        /// Draws little circle nodes representing branches in the branch cell view on any cell draw event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BranchesGridViewDrawCell(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Ignore header row and any columns besides Graph column
            if (e.ColumnIndex > 0 || e.RowIndex == -1) { return; }

            Commit commit = commitHistory.Item2[e.RowIndex];


            // Get Branch index for offset
            int branchIndex = 1;
            // get node area in graph
            int xOffset = branchIndex * pixelsPerBranchNode;

            // Get branch color from index
            Pen pen = new Pen(branchNodeColors[branchIndex], 3);
            // Set position based on cell bounds using branch offset and radius
            int x = e.CellBounds.X + (xOffset / 2);
            int y = e.CellBounds.Y + ((e.CellBounds.Height / 2) - (branchNodeRadius / 2));
            // Paint background first, how the cell was going to do it anyways
            e.PaintBackground(e.CellBounds, true);
            // Save smoothing mode before changing, then change to antialias for smooth node drawing
            SmoothingMode prevSmoothing = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawEllipse(pen, x, y, branchNodeRadius, branchNodeRadius);
            e.Graphics.SmoothingMode = prevSmoothing;
            // Handle event and return to continue drawing
            e.Handled = true;
        }

        private void branchesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 1) { return; }
            selectedCommit = commitHistory.Item2[index];
            selectedCommitTextLabel.Text = "Selected Commit: " + selectedCommit.shortCommitHash;
        }
    }
}
