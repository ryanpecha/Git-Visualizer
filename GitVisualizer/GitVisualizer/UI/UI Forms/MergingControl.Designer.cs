namespace GitVisualizer.UI.UI_Forms
{
    partial class MergingControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            commitChangesButton = new Button();
            mergingControlPanel = new Panel();
            checkedOutBranchPanel = new Panel();
            checkedOutBranchTextLabel = new Label();
            checkedOutBranchLabel = new Label();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            commitSyncLabel = new Label();
            commitMessageTextBox = new TextBox();
            syncButton = new Button();
            outgoingCountLabel = new Label();
            outgoingCountTextLabel = new Label();
            incomingCountLabel = new Label();
            incomingCountTextLabel = new Label();
            activeRepoPanel = new Panel();
            activeRepositoryTextLabel = new Label();
            activeRepoLabel = new Label();
            titleLabel = new Label();
            mergingPanel = new Panel();
            diffPanel = new Panel();
            diffGridView = new DataGridView();
            oldChangesColumn = new DataGridViewTextBoxColumn();
            newChangesColumn = new DataGridViewTextBoxColumn();
            commonBranchesButtonsPanel = new Panel();
            stageChangesSplitContainer = new SplitContainer();
            stagedChangesDataGridView = new DataGridView();
            fileColumn = new DataGridViewTextBoxColumn();
            unstageColumn = new DataGridViewButtonColumn();
            stagedChangesBarPanel = new Panel();
            stagedChangesLabel = new Label();
            unstageAllButton = new Button();
            unstagedChangesDataGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            undoColumn = new DataGridViewButtonColumn();
            unstagedChangesBarPanel = new Panel();
            stageAllButton = new Button();
            unstagedChangesLabel = new Label();
            undoAllButton = new Button();
            mergingControlPanel.SuspendLayout();
            checkedOutBranchPanel.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            activeRepoPanel.SuspendLayout();
            mergingPanel.SuspendLayout();
            diffPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)diffGridView).BeginInit();
            commonBranchesButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stageChangesSplitContainer).BeginInit();
            stageChangesSplitContainer.Panel1.SuspendLayout();
            stageChangesSplitContainer.Panel2.SuspendLayout();
            stageChangesSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stagedChangesDataGridView).BeginInit();
            stagedChangesBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)unstagedChangesDataGridView).BeginInit();
            unstagedChangesBarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // commitChangesButton
            // 
            commitChangesButton.Enabled = false;
            commitChangesButton.FlatStyle = FlatStyle.Flat;
            commitChangesButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            commitChangesButton.Location = new Point(15, 87);
            commitChangesButton.Name = "commitChangesButton";
            commitChangesButton.Size = new Size(181, 28);
            commitChangesButton.TabIndex = 16;
            commitChangesButton.Text = "Commit Staged Changes";
            commitChangesButton.UseVisualStyleBackColor = true;
            commitChangesButton.Click += OnCommitChangesButton;
            // 
            // mergingControlPanel
            // 
            mergingControlPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mergingControlPanel.BorderStyle = BorderStyle.FixedSingle;
            mergingControlPanel.Controls.Add(checkedOutBranchPanel);
            mergingControlPanel.Controls.Add(panel1);
            mergingControlPanel.Controls.Add(activeRepoPanel);
            mergingControlPanel.Controls.Add(titleLabel);
            mergingControlPanel.Dock = DockStyle.Left;
            mergingControlPanel.Location = new Point(0, 0);
            mergingControlPanel.MinimumSize = new Size(280, 280);
            mergingControlPanel.Name = "mergingControlPanel";
            mergingControlPanel.Size = new Size(280, 675);
            mergingControlPanel.TabIndex = 4;
            // 
            // checkedOutBranchPanel
            // 
            checkedOutBranchPanel.Controls.Add(checkedOutBranchTextLabel);
            checkedOutBranchPanel.Controls.Add(checkedOutBranchLabel);
            checkedOutBranchPanel.Dock = DockStyle.Top;
            checkedOutBranchPanel.Location = new Point(0, 161);
            checkedOutBranchPanel.Name = "checkedOutBranchPanel";
            checkedOutBranchPanel.Size = new Size(278, 107);
            checkedOutBranchPanel.TabIndex = 18;
            // 
            // checkedOutBranchTextLabel
            // 
            checkedOutBranchTextLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            checkedOutBranchTextLabel.Location = new Point(3, 21);
            checkedOutBranchTextLabel.Name = "checkedOutBranchTextLabel";
            checkedOutBranchTextLabel.Padding = new Padding(12, 0, 0, 0);
            checkedOutBranchTextLabel.Size = new Size(267, 77);
            checkedOutBranchTextLabel.TabIndex = 4;
            // 
            // checkedOutBranchLabel
            // 
            checkedOutBranchLabel.AutoSize = true;
            checkedOutBranchLabel.Dock = DockStyle.Top;
            checkedOutBranchLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkedOutBranchLabel.Location = new Point(0, 0);
            checkedOutBranchLabel.Name = "checkedOutBranchLabel";
            checkedOutBranchLabel.Padding = new Padding(12, 0, 0, 0);
            checkedOutBranchLabel.Size = new Size(184, 21);
            checkedOutBranchLabel.TabIndex = 3;
            checkedOutBranchLabel.Text = "Checked Out to Branch:";
            checkedOutBranchLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 486);
            panel1.Name = "panel1";
            panel1.Size = new Size(278, 187);
            panel1.TabIndex = 17;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(commitSyncLabel);
            flowLayoutPanel1.Controls.Add(commitMessageTextBox);
            flowLayoutPanel1.Controls.Add(commitChangesButton);
            flowLayoutPanel1.Controls.Add(syncButton);
            flowLayoutPanel1.Controls.Add(outgoingCountLabel);
            flowLayoutPanel1.Controls.Add(outgoingCountTextLabel);
            flowLayoutPanel1.Controls.Add(incomingCountLabel);
            flowLayoutPanel1.Controls.Add(incomingCountTextLabel);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(12);
            flowLayoutPanel1.Size = new Size(278, 187);
            flowLayoutPanel1.TabIndex = 18;
            // 
            // commitSyncLabel
            // 
            commitSyncLabel.AutoSize = true;
            commitSyncLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            commitSyncLabel.Location = new Point(15, 12);
            commitSyncLabel.Name = "commitSyncLabel";
            commitSyncLabel.Size = new Size(133, 21);
            commitSyncLabel.TabIndex = 25;
            commitSyncLabel.Text = "Commit and Sync";
            // 
            // commitMessageTextBox
            // 
            commitMessageTextBox.Location = new Point(15, 36);
            commitMessageTextBox.MaxLength = 150;
            commitMessageTextBox.Multiline = true;
            commitMessageTextBox.Name = "commitMessageTextBox";
            commitMessageTextBox.PlaceholderText = "Enter commit message... <Required>";
            commitMessageTextBox.Size = new Size(243, 45);
            commitMessageTextBox.TabIndex = 8;
            commitMessageTextBox.TextChanged += commitMessageTextBox_TextChanged;
            // 
            // syncButton
            // 
            syncButton.FlatStyle = FlatStyle.Flat;
            syncButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            syncButton.Location = new Point(202, 87);
            syncButton.Name = "syncButton";
            syncButton.Size = new Size(56, 28);
            syncButton.TabIndex = 17;
            syncButton.Text = "Sync";
            syncButton.UseVisualStyleBackColor = true;
            syncButton.Click += OnSyncButton;
            // 
            // outgoingCountLabel
            // 
            outgoingCountLabel.Dock = DockStyle.Top;
            outgoingCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            outgoingCountLabel.Location = new Point(15, 118);
            outgoingCountLabel.Name = "outgoingCountLabel";
            outgoingCountLabel.Padding = new Padding(8, 4, 0, 0);
            outgoingCountLabel.Size = new Size(80, 34);
            outgoingCountLabel.TabIndex = 21;
            outgoingCountLabel.Text = "Outgoing:";
            // 
            // outgoingCountTextLabel
            // 
            outgoingCountTextLabel.Dock = DockStyle.Top;
            flowLayoutPanel1.SetFlowBreak(outgoingCountTextLabel, true);
            outgoingCountTextLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            outgoingCountTextLabel.Location = new Point(101, 118);
            outgoingCountTextLabel.Name = "outgoingCountTextLabel";
            outgoingCountTextLabel.Padding = new Padding(0, 4, 0, 0);
            outgoingCountTextLabel.Size = new Size(48, 34);
            outgoingCountTextLabel.TabIndex = 22;
            outgoingCountTextLabel.Text = "0";
            // 
            // incomingCountLabel
            // 
            incomingCountLabel.Dock = DockStyle.Top;
            incomingCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            incomingCountLabel.Location = new Point(15, 152);
            incomingCountLabel.Name = "incomingCountLabel";
            incomingCountLabel.Padding = new Padding(8, 0, 0, 0);
            incomingCountLabel.Size = new Size(80, 34);
            incomingCountLabel.TabIndex = 23;
            incomingCountLabel.Text = "Incoming:";
            // 
            // incomingCountTextLabel
            // 
            incomingCountTextLabel.Dock = DockStyle.Top;
            incomingCountTextLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            incomingCountTextLabel.Location = new Point(101, 152);
            incomingCountTextLabel.Name = "incomingCountTextLabel";
            incomingCountTextLabel.Size = new Size(48, 34);
            incomingCountTextLabel.TabIndex = 24;
            incomingCountTextLabel.Text = "0";
            // 
            // activeRepoPanel
            // 
            activeRepoPanel.Controls.Add(activeRepositoryTextLabel);
            activeRepoPanel.Controls.Add(activeRepoLabel);
            activeRepoPanel.Dock = DockStyle.Top;
            activeRepoPanel.Location = new Point(0, 54);
            activeRepoPanel.Name = "activeRepoPanel";
            activeRepoPanel.Size = new Size(278, 107);
            activeRepoPanel.TabIndex = 10;
            // 
            // activeRepositoryTextLabel
            // 
            activeRepositoryTextLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            activeRepositoryTextLabel.Location = new Point(3, 21);
            activeRepositoryTextLabel.Name = "activeRepositoryTextLabel";
            activeRepositoryTextLabel.Padding = new Padding(12, 0, 0, 0);
            activeRepositoryTextLabel.Size = new Size(267, 77);
            activeRepositoryTextLabel.TabIndex = 4;
            activeRepositoryTextLabel.Text = "Select a Local Repo to Set Workspace";
            // 
            // activeRepoLabel
            // 
            activeRepoLabel.AutoSize = true;
            activeRepoLabel.Dock = DockStyle.Top;
            activeRepoLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            activeRepoLabel.Location = new Point(0, 0);
            activeRepoLabel.Name = "activeRepoLabel";
            activeRepoLabel.Padding = new Padding(12, 0, 0, 0);
            activeRepoLabel.Size = new Size(146, 21);
            activeRepoLabel.TabIndex = 3;
            activeRepoLabel.Text = "Active Repository:";
            activeRepoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Margin = new Padding(0);
            titleLabel.MinimumSize = new Size(280, 54);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(280, 54);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Changes";
            // 
            // mergingPanel
            // 
            mergingPanel.Controls.Add(diffPanel);
            mergingPanel.Controls.Add(commonBranchesButtonsPanel);
            mergingPanel.Dock = DockStyle.Fill;
            mergingPanel.Location = new Point(280, 0);
            mergingPanel.Name = "mergingPanel";
            mergingPanel.Size = new Size(895, 675);
            mergingPanel.TabIndex = 5;
            // 
            // diffPanel
            // 
            diffPanel.Controls.Add(diffGridView);
            diffPanel.Dock = DockStyle.Fill;
            diffPanel.Location = new Point(0, 0);
            diffPanel.Name = "diffPanel";
            diffPanel.Size = new Size(895, 475);
            diffPanel.TabIndex = 4;
            // 
            // diffGridView
            // 
            diffGridView.AllowUserToAddRows = false;
            diffGridView.AllowUserToDeleteRows = false;
            diffGridView.AllowUserToResizeColumns = false;
            diffGridView.AllowUserToResizeRows = false;
            diffGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            diffGridView.Columns.AddRange(new DataGridViewColumn[] { oldChangesColumn, newChangesColumn });
            diffGridView.Dock = DockStyle.Fill;
            diffGridView.Location = new Point(0, 0);
            diffGridView.Name = "diffGridView";
            diffGridView.RowHeadersVisible = false;
            diffGridView.RowTemplate.Height = 25;
            diffGridView.Size = new Size(895, 475);
            diffGridView.TabIndex = 19;
            // 
            // oldChangesColumn
            // 
            oldChangesColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            oldChangesColumn.HeaderText = "Old Changes";
            oldChangesColumn.Name = "oldChangesColumn";
            oldChangesColumn.Resizable = DataGridViewTriState.False;
            oldChangesColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // newChangesColumn
            // 
            newChangesColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            newChangesColumn.HeaderText = "New Changes";
            newChangesColumn.Name = "newChangesColumn";
            newChangesColumn.Resizable = DataGridViewTriState.False;
            newChangesColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // commonBranchesButtonsPanel
            // 
            commonBranchesButtonsPanel.Controls.Add(stageChangesSplitContainer);
            commonBranchesButtonsPanel.Dock = DockStyle.Bottom;
            commonBranchesButtonsPanel.Location = new Point(0, 475);
            commonBranchesButtonsPanel.Name = "commonBranchesButtonsPanel";
            commonBranchesButtonsPanel.Padding = new Padding(12);
            commonBranchesButtonsPanel.Size = new Size(895, 200);
            commonBranchesButtonsPanel.TabIndex = 11;
            // 
            // stageChangesSplitContainer
            // 
            stageChangesSplitContainer.Dock = DockStyle.Fill;
            stageChangesSplitContainer.IsSplitterFixed = true;
            stageChangesSplitContainer.Location = new Point(12, 12);
            stageChangesSplitContainer.Name = "stageChangesSplitContainer";
            // 
            // stageChangesSplitContainer.Panel1
            // 
            stageChangesSplitContainer.Panel1.Controls.Add(stagedChangesDataGridView);
            stageChangesSplitContainer.Panel1.Controls.Add(stagedChangesBarPanel);
            // 
            // stageChangesSplitContainer.Panel2
            // 
            stageChangesSplitContainer.Panel2.Controls.Add(unstagedChangesDataGridView);
            stageChangesSplitContainer.Panel2.Controls.Add(unstagedChangesBarPanel);
            stageChangesSplitContainer.Size = new Size(871, 176);
            stageChangesSplitContainer.SplitterDistance = 428;
            stageChangesSplitContainer.SplitterWidth = 12;
            stageChangesSplitContainer.TabIndex = 0;
            // 
            // stagedChangesDataGridView
            // 
            stagedChangesDataGridView.AllowUserToAddRows = false;
            stagedChangesDataGridView.AllowUserToDeleteRows = false;
            stagedChangesDataGridView.AllowUserToResizeColumns = false;
            stagedChangesDataGridView.AllowUserToResizeRows = false;
            stagedChangesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            stagedChangesDataGridView.Columns.AddRange(new DataGridViewColumn[] { fileColumn, unstageColumn });
            stagedChangesDataGridView.Dock = DockStyle.Fill;
            stagedChangesDataGridView.Location = new Point(0, 25);
            stagedChangesDataGridView.MultiSelect = false;
            stagedChangesDataGridView.Name = "stagedChangesDataGridView";
            stagedChangesDataGridView.ReadOnly = true;
            stagedChangesDataGridView.RowHeadersVisible = false;
            stagedChangesDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            stagedChangesDataGridView.RowTemplate.Height = 25;
            stagedChangesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            stagedChangesDataGridView.Size = new Size(428, 151);
            stagedChangesDataGridView.TabIndex = 0;
            stagedChangesDataGridView.CellClick += OnStagedFileCellSelected;
            stagedChangesDataGridView.CellContentClick += stagedChangesDataGridView_CellContentClick;
            // 
            // fileColumn
            // 
            fileColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fileColumn.HeaderText = "File";
            fileColumn.Name = "fileColumn";
            fileColumn.ReadOnly = true;
            fileColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // unstageColumn
            // 
            unstageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            unstageColumn.HeaderText = "Unstage";
            unstageColumn.Name = "unstageColumn";
            unstageColumn.ReadOnly = true;
            unstageColumn.Resizable = DataGridViewTriState.False;
            unstageColumn.Text = "unstage";
            unstageColumn.Width = 60;
            // 
            // stagedChangesBarPanel
            // 
            stagedChangesBarPanel.Controls.Add(stagedChangesLabel);
            stagedChangesBarPanel.Controls.Add(unstageAllButton);
            stagedChangesBarPanel.Dock = DockStyle.Top;
            stagedChangesBarPanel.Location = new Point(0, 0);
            stagedChangesBarPanel.Name = "stagedChangesBarPanel";
            stagedChangesBarPanel.Size = new Size(428, 25);
            stagedChangesBarPanel.TabIndex = 0;
            // 
            // stagedChangesLabel
            // 
            stagedChangesLabel.AutoSize = true;
            stagedChangesLabel.Dock = DockStyle.Left;
            stagedChangesLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            stagedChangesLabel.Location = new Point(0, 0);
            stagedChangesLabel.Name = "stagedChangesLabel";
            stagedChangesLabel.Size = new Size(108, 19);
            stagedChangesLabel.TabIndex = 10;
            stagedChangesLabel.Text = "Staged Changes";
            // 
            // unstageAllButton
            // 
            unstageAllButton.Dock = DockStyle.Right;
            unstageAllButton.FlatStyle = FlatStyle.Flat;
            unstageAllButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            unstageAllButton.Location = new Point(350, 0);
            unstageAllButton.Name = "unstageAllButton";
            unstageAllButton.Size = new Size(78, 25);
            unstageAllButton.TabIndex = 9;
            unstageAllButton.Text = "Unstage All";
            unstageAllButton.UseVisualStyleBackColor = true;
            unstageAllButton.Click += OnUnstageAllButton;
            // 
            // unstagedChangesDataGridView
            // 
            unstagedChangesDataGridView.AllowUserToAddRows = false;
            unstagedChangesDataGridView.AllowUserToDeleteRows = false;
            unstagedChangesDataGridView.AllowUserToResizeColumns = false;
            unstagedChangesDataGridView.AllowUserToResizeRows = false;
            unstagedChangesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            unstagedChangesDataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewButtonColumn1, undoColumn });
            unstagedChangesDataGridView.Dock = DockStyle.Fill;
            unstagedChangesDataGridView.Location = new Point(0, 25);
            unstagedChangesDataGridView.MultiSelect = false;
            unstagedChangesDataGridView.Name = "unstagedChangesDataGridView";
            unstagedChangesDataGridView.ReadOnly = true;
            unstagedChangesDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            unstagedChangesDataGridView.RowHeadersVisible = false;
            unstagedChangesDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            unstagedChangesDataGridView.RowTemplate.Height = 25;
            unstagedChangesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            unstagedChangesDataGridView.Size = new Size(431, 151);
            unstagedChangesDataGridView.TabIndex = 1;
            unstagedChangesDataGridView.CellClick += OnUnstagedFileCellSelected;
            unstagedChangesDataGridView.CellContentClick += unstagedChangesDataGridView_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.HeaderText = "File";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewButtonColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewButtonColumn1.HeaderText = "Stage";
            dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            dataGridViewButtonColumn1.ReadOnly = true;
            dataGridViewButtonColumn1.Resizable = DataGridViewTriState.False;
            dataGridViewButtonColumn1.Text = "+";
            dataGridViewButtonColumn1.Width = 44;
            // 
            // undoColumn
            // 
            undoColumn.HeaderText = "Undo";
            undoColumn.MinimumWidth = 44;
            undoColumn.Name = "undoColumn";
            undoColumn.ReadOnly = true;
            undoColumn.Width = 44;
            // 
            // unstagedChangesBarPanel
            // 
            unstagedChangesBarPanel.Controls.Add(stageAllButton);
            unstagedChangesBarPanel.Controls.Add(unstagedChangesLabel);
            unstagedChangesBarPanel.Controls.Add(undoAllButton);
            unstagedChangesBarPanel.Dock = DockStyle.Top;
            unstagedChangesBarPanel.Location = new Point(0, 0);
            unstagedChangesBarPanel.Name = "unstagedChangesBarPanel";
            unstagedChangesBarPanel.Size = new Size(431, 25);
            unstagedChangesBarPanel.TabIndex = 1;
            // 
            // stageAllButton
            // 
            stageAllButton.Dock = DockStyle.Right;
            stageAllButton.FlatStyle = FlatStyle.Flat;
            stageAllButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            stageAllButton.Location = new Point(299, 0);
            stageAllButton.Name = "stageAllButton";
            stageAllButton.RightToLeft = RightToLeft.Yes;
            stageAllButton.Size = new Size(66, 25);
            stageAllButton.TabIndex = 11;
            stageAllButton.Text = "Stage All";
            stageAllButton.UseVisualStyleBackColor = true;
            stageAllButton.Click += OnStageAllButton;
            // 
            // unstagedChangesLabel
            // 
            unstagedChangesLabel.AutoSize = true;
            unstagedChangesLabel.Dock = DockStyle.Left;
            unstagedChangesLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            unstagedChangesLabel.Location = new Point(0, 0);
            unstagedChangesLabel.Name = "unstagedChangesLabel";
            unstagedChangesLabel.Size = new Size(125, 19);
            unstagedChangesLabel.TabIndex = 10;
            unstagedChangesLabel.Text = "Unstaged Changes";
            // 
            // undoAllButton
            // 
            undoAllButton.Dock = DockStyle.Right;
            undoAllButton.FlatStyle = FlatStyle.Flat;
            undoAllButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            undoAllButton.Location = new Point(365, 0);
            undoAllButton.Name = "undoAllButton";
            undoAllButton.RightToLeft = RightToLeft.Yes;
            undoAllButton.Size = new Size(66, 25);
            undoAllButton.TabIndex = 9;
            undoAllButton.Text = "Undo All";
            undoAllButton.UseVisualStyleBackColor = true;
            undoAllButton.Click += OnRevertAllButton;
            // 
            // MergingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mergingPanel);
            Controls.Add(mergingControlPanel);
            Margin = new Padding(1);
            Name = "MergingControl";
            Size = new Size(1175, 675);
            Load += MergingControl_Load;
            mergingControlPanel.ResumeLayout(false);
            checkedOutBranchPanel.ResumeLayout(false);
            checkedOutBranchPanel.PerformLayout();
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            activeRepoPanel.ResumeLayout(false);
            activeRepoPanel.PerformLayout();
            mergingPanel.ResumeLayout(false);
            diffPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)diffGridView).EndInit();
            commonBranchesButtonsPanel.ResumeLayout(false);
            stageChangesSplitContainer.Panel1.ResumeLayout(false);
            stageChangesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stageChangesSplitContainer).EndInit();
            stageChangesSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stagedChangesDataGridView).EndInit();
            stagedChangesBarPanel.ResumeLayout(false);
            stagedChangesBarPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)unstagedChangesDataGridView).EndInit();
            unstagedChangesBarPanel.ResumeLayout(false);
            unstagedChangesBarPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private void ApplyColorTheme(UITheme.AppTheme theme)
        {
            mergingControlPanel.BackColor = theme.PanelBackground;
            mergingControlPanel.ForeColor = theme.TextBright;

            stagedChangesDataGridView.BackColor = theme.ElementBackground;
            stagedChangesDataGridView.ForeColor = theme.TextSelectable;

            stagedChangesDataGridView.BackgroundColor = theme.ElementBackground;
            stagedChangesDataGridView.ForeColor = theme.TextSelectable;
            stagedChangesDataGridView.DefaultCellStyle.ForeColor = theme.TextNormal;
            stagedChangesDataGridView.DefaultCellStyle.BackColor = theme.ElementBackground;
            stagedChangesDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = theme.TextSelectable;
            stagedChangesDataGridView.ColumnHeadersDefaultCellStyle.BackColor = theme.ElementBackground;
            stagedChangesDataGridView.EnableHeadersVisualStyles = false;

            stagedChangesDataGridView.DefaultCellStyle.SelectionBackColor = theme.ElementSelected;
            stagedChangesDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = stagedChangesDataGridView.DefaultCellStyle.BackColor;

            unstagedChangesDataGridView.BackColor = theme.ElementBackground;
            unstagedChangesDataGridView.ForeColor = theme.TextSelectable;

            unstagedChangesDataGridView.BackgroundColor = theme.ElementBackground;
            unstagedChangesDataGridView.ForeColor = theme.TextSelectable;
            unstagedChangesDataGridView.DefaultCellStyle.ForeColor = theme.TextNormal;
            unstagedChangesDataGridView.DefaultCellStyle.BackColor = theme.ElementBackground;
            unstagedChangesDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = theme.TextSelectable;
            unstagedChangesDataGridView.ColumnHeadersDefaultCellStyle.BackColor = theme.ElementBackground;
            unstagedChangesDataGridView.EnableHeadersVisualStyles = false;
            unstagedChangesDataGridView.DefaultCellStyle.SelectionBackColor = theme.TextBright;

            unstagedChangesDataGridView.DefaultCellStyle.SelectionBackColor = theme.ElementSelected;
            unstagedChangesDataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = unstagedChangesDataGridView.DefaultCellStyle.BackColor;

            stageChangesSplitContainer.ForeColor = theme.TextNormal;


            activeRepoLabel.ForeColor = theme.TextNormal;
            checkedOutBranchLabel.ForeColor = theme.TextNormal;
            incomingCountLabel.ForeColor = theme.TextNormal;
            outgoingCountLabel.ForeColor = theme.TextNormal;
            commitSyncLabel.ForeColor = theme.TextNormal;

            diffGridView.ColumnHeadersDefaultCellStyle.BackColor = theme.ElementBackground;
            diffGridView.ColumnHeadersDefaultCellStyle.ForeColor = theme.TextSelectable;

            diffGridView.BackgroundColor = theme.ElementBackground;
            diffGridView.DefaultCellStyle.ForeColor = theme.TextNormal;
            diffGridView.DefaultCellStyle.BackColor = theme.ElementBackground;
            diffGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            diffGridView.EnableHeadersVisualStyles = false;

            diffGridView.DefaultCellStyle.SelectionBackColor = theme.ElementSelected;

        }
        private Panel mergingControlPanel;
        private Label titleLabel;
        private Panel mergingPanel;
        private Panel diffPanel;
        private Panel activeRepoPanel;
        private Label activeRepositoryTextLabel;
        private Label activeRepoLabel;
        private TextBox commitMessageTextBox;
        private Panel panel1;
        private Panel commonBranchesButtonsPanel;
        private SplitContainer stageChangesSplitContainer;
        private DataGridView stagedChangesDataGridView;
        private GroupBox unstagedChangesBox;
        private DataGridView unstagedChangesDataGridView;
        private DataGridViewTextBoxColumn fileColumn;
        private DataGridViewButtonColumn unstageColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private DataGridViewButtonColumn undoColumn;
        private Button commitChangesButton;
        private Panel stagedChangesBarPanel;
        private Button unstageAllButton;
        private Label stagedChangesLabel;
        private Panel unstagedChangesBarPanel;
        private Label unstagedChangesLabel;
        private Button undoAllButton;
        private Button stageAllButton;
        private Button syncButton;
        private Panel checkedOutBranchPanel;
        private Label checkedOutBranchTextLabel;
        private Label checkedOutBranchLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label outgoingCountLabel;
        private Label outgoingCountTextLabel;
        private Label incomingCountLabel;
        private Label incomingCountTextLabel;
        private Label commitSyncLabel;
        private DataGridView diffGridView;
        private DataGridViewTextBoxColumn oldChangesColumn;
        private DataGridViewTextBoxColumn newChangesColumn;
    }
}
