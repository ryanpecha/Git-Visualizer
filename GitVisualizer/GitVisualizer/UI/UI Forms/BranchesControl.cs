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
            Color.Plum,
            Color.Aqua,
            Color.Bisque,
            Color.DarkOliveGreen,
            Color.Orange];

        private Tuple<List<Branch>, List<Commit>> commitHistory = null;


        //private Tuple<List<Branch>, List<Commit>> commitHistory = null;
        Commit selectedCommit = null;
        
        
        private int currentGraphIndex = 0;


        public BranchesControl()
        {
            InitializeComponent();
            ApplyColorTheme(MainForm.AppTheme);
            checkoutBranchButton.Visible = false;
            deleteBranchButton.Visible = false;
        }


        public void OnBranchesControlFocus()
        {
            UpdateLiveReposAndBranch();
            UpdateGridView();
        }

        private void UpdateLiveReposAndBranch()
        {
            if (GitAPI.liveRepository == null) { return; }

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
        private void UpdateGridView()
        {
            // Update view by getting branch info
            branchesGridView.Rows.Clear();
            commitHistory = GitAPI.Getters.getCommitsAndBranches();

            Program.MainForm.UpdateAppTitle();

            foreach (Commit commit in commitHistory.Item2)
            {
                List<Branch> branches = commit.branches;
                string branchList = String.Join(", ", branches);
                Debug.WriteLine(commit.subject);
                int index = branchesGridView.Rows.Add(null, branchList, commit.shortCommitHash, commit.committerName, commit.committerDate, commit.subject);
                branchesGridView.Rows[index].Cells[0].ToolTipText = commit.longCommitHash;
            }

            branchComboBox.DataSource = commitHistory.Item1;
            if (commitHistory.Item1.Count > 0)
            {
                checkoutBranchButton.Visible = true;
                deleteBranchButton.Visible = true;
                newBranchFromCommitTextBox.Visible = true;
                createBranchFromCurrentButton.Visible = true;
            }

        }

        public void OnCheckoutToBranchButton(object sender, EventArgs e)
        {
            if (branchComboBox.Items.Count == 0) { return; }
            Branch selected = (Branch)branchComboBox.SelectedItem;
            GitAPI.Actions.LocalActions.checkoutBranch(selected);
            if (GitAPI.liveBranch == null) { return; }
            checkedOutBranchTextLabel.Text = "Branch: " + GitAPI.liveBranch.title;
            branchesGridView.Refresh();
        }

        public void OnDeleteBranchButton(object sender, EventArgs e)
        {
            if (branchComboBox.Items.Count == 0) { return; }
            //Branch selected = (Branch)branchComboBox.SelectedItem;
            Branch selected = null;
            GitAPI.Actions.LocalActions.deleteBranchLocal(selected);
        }

        public void OnCreateBranchFromCurrentButton(object sender, EventArgs e)
        {
            string title = newBranchFromCommitTextBox.Text;
            if (title.Length == 0) { return; }
            Branch branch = GitAPI.Actions.LocalActions.createLocalBranch(title, GitAPI.liveCommit);
            GitAPI.Actions.RemoteActions.addLocalBranchToRemote(branch);
        }

        public void OnCheckoutToSelectedCommitButton(object sender, EventArgs e)
        {
            if (selectedCommit == null) { return; }
            checkedOutBranchTextLabel.Text = "Commit: " + selectedCommit.shortCommitHash;
            GitAPI.Actions.LocalActions.checkoutCommit(selectedCommit);
            branchesGridView.Refresh();
        }

        public void OnCreateBranchFromSelectedButton(object sender, EventArgs e)
        {
            if (selectedCommit == null) { return; }
            string title = newBranchFromCommitTextBox.Text;
            if (title.Length == 0) { return; }
            GitAPI.Actions.LocalActions.createLocalBranch(title, selectedCommit);
        }

        private void branchesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0) { return; }
            selectedCommit = commitHistory.Item2[index];
            selectedCommitTextLabel.Text = "Selected Commit: " + selectedCommit.shortCommitHash + " - " + selectedCommit.subject;
            checkoutCommitButton.Visible = true;
            newBranchFromCommitTextBox.Visible = true;
            createBranchFromSelectedButton.Visible = true;
        }

        /// <summary>
        /// Draws little circle nodes representing branches in the branch cell view on any cell draw event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BranchesGridViewDrawCell(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //// Ignore header row and any columns besides Graph column
            if (e.ColumnIndex > 0 || e.RowIndex == -1) { return; }
            int lineXOffset = 6;

            Commit commit = commitHistory.Item2[e.RowIndex];


            int cellHeight = branchesGridView.RowTemplate.Height;
            int depthOffset = commit.graphColIndex + 1;
            

            SmoothingMode prevSmoothing = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.PaintBackground(e.CellBounds, true);
            

            int colorOffset = depthOffset % branchNodeColors.Count;
            

            int xOffset = depthOffset * pixelsPerBranchNode;
            Pen pen = new Pen(branchNodeColors[colorOffset], 3);




            // Node circles

            int x = e.CellBounds.X + (xOffset / 2);
            int y = e.CellBounds.Y + ((e.CellBounds.Height / 2) - (branchNodeRadius / 2));

            Point start = new Point(x, y);

            // Parents
            foreach (Tuple<int, int> targetCoord in commit.graphOutRowColPairs)
            {
                int xDiff = (targetCoord.Item2 - commit.graphColIndex) * (pixelsPerBranchNode);
                int yDiff = (targetCoord.Item1 - commit.graphRowIndex) * (pixelsPerBranchNode + 12);
                Pen linepen = new Pen(branchNodeColors[(targetCoord.Item2 + 1) % branchNodeColors.Count], 3);
                e.Graphics.DrawLine(linepen, start.X + lineXOffset, start.Y, start.X + xDiff + lineXOffset, start.Y - yDiff);
            }
            //// Children
            //foreach (Tuple<int, int> targetCoord in commit.graphInRowColPairs)
            //{
            //    int xDiff = (commit.graphColIndex - targetCoord.Item2) * pixelsPerBranchNode;
            //    int yDiff = (commit.graphRowIndex - targetCoord.Item1) * pixelsPerBranchNode;
            //    e.Graphics.DrawLine(pen, start.X + lineXOffset, start.Y, start.X - xDiff + lineXOffset, start.Y + yDiff);
            //}



            e.Graphics.FillEllipse(pen.Brush, x, y, branchNodeRadius, branchNodeRadius);
            if (commit == GitAPI.liveCommit)
            {
                pen.Color = Color.Black;
                e.Graphics.FillEllipse(pen.Brush, x + 3, y + 3, branchNodeRadius / 2, branchNodeRadius / 2);
            }

            e.Graphics.SmoothingMode = prevSmoothing;
            e.Handled = true;


            #region graphicOld
            //int curOffset = 1;
            //foreach (char symbol in curGraphLine)
            //{

            //    int colorOffset = curOffset % branchNodeColors.Count;
            //    Pen pen = new Pen(branchNodeColors[colorOffset], 3);
            //    int xOffset = curOffset * pixelsPerBranchNode;

            //    if (symbol == ' ') {
            //    }
            //    else if (symbol == '|')
            //    {
            //        int x = e.CellBounds.X + (xOffset/2);
            //        int offsetY = (cellHeight / 2);
            //        e.Graphics.DrawLine(pen, x + lineXOffset, e.CellBounds.Y + (offsetY * 2), x + lineXOffset, e.CellBounds.Y);

            //    }
            //    else if (symbol == '*')
            //    {
            //        int x = e.CellBounds.X + (xOffset / 2);
            //        int y = e.CellBounds.Y + ((e.CellBounds.Height / 2) - (branchNodeRadius / 2));

            //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //        e.Graphics.FillEllipse(pen.Brush, x, y, branchNodeRadius, branchNodeRadius);
            //        if (commit == GitAPI.liveCommit)
            //        {
            //            pen.Color = Color.Black;
            //            e.Graphics.FillEllipse(pen.Brush, x + 3, y + 3, branchNodeRadius/2, branchNodeRadius/2);
            //        }
            //    }
            //    else if (symbol == '&')
            //    {
            //        break;
            //    }
            //    curOffset++;

            //}

            //if (curMergeLine != string.Empty)
            //{
            //    curOffset = 1;
            //    foreach (char symbol in curMergeLine)
            //    {
            //        int colorOffset = curOffset % branchNodeColors.Count;


            //        int xOffset = curOffset * pixelsPerBranchNode;
            //        if (symbol == '|')
            //        {
            //            Pen pen = new Pen(branchNodeColors[colorOffset], 3);
            //            int x = e.CellBounds.X + (xOffset / 2);
            //            int offsetY = (cellHeight / 2);
            //            e.Graphics.DrawLine(pen, x + lineXOffset, e.CellBounds.Y + offsetY, x + lineXOffset, e.CellBounds.Y);
            //        }
            //        else if (symbol == '/')
            //        {
            //            Pen pen = new Pen(branchNodeColors[colorOffset - 1], 3);
            //            int x = e.CellBounds.X + (xOffset / 2);
            //            int offsetY = (cellHeight / 2);
            //            e.Graphics.DrawLine(pen, x - lineXOffset, e.CellBounds.Y + offsetY, x + lineXOffset, e.CellBounds.Y);
            //        }
            //        else if (symbol == '\\')
            //        {
            //            Pen pen = new Pen(branchNodeColors[colorOffset - 1], 3);
            //            int x = e.CellBounds.X + (xOffset / 2);
            //            int offsetY = (cellHeight / 2);
            //            e.Graphics.DrawLine(pen, x + lineXOffset, e.CellBounds.Y + offsetY, x - lineXOffset, e.CellBounds.Y);
            //        }

            //        curOffset++;
            //    }
            //}




            /*
            // Get Branch index for offset
            int branchIndex = 1;
            

            // Get branch color from index
            Pen pen = new Pen(branchNodeColors[branchIndex], 3);

            // Set position based on cell bounds using branch offset and radius
            //int x = e.CellBounds.X + (xOffset / 2);
            int y = e.CellBounds.Y + ((e.CellBounds.Height / 2) - (branchNodeRadius / 2));
            // Paint background first, how the cell was going to do it anyways
            e.PaintBackground(e.CellBounds, true);
            // Save smoothing mode before changing, then change to antialias for smooth node drawing
            SmoothingMode prevSmoothing = e.Graphics.SmoothingMode;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawEllipse(pen, x, y, branchNodeRadius, branchNodeRadius);
            if (commit == GitAPI.liveCommit)
            {
                e.Graphics.FillEllipse(pen.Brush, x, y, branchNodeRadius, branchNodeRadius);
            }

            e.Graphics.SmoothingMode = prevSmoothing;
            // Handle event and return to continue drawing
            */
            #endregion graphicOld

        }

        private Point PixelsFromCoord(int col, int row)
        {
            int x = 0;
            int y = 0;
            return new Point(x, y);
        }
    }
}
