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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            commitChangesButton = new Button();
            mergingControlPanel = new Panel();
            panel1 = new Panel();
            commitMessageTextBox = new TextBox();
            activeRepoPanel = new Panel();
            activeRepositoryTextLabel = new Label();
            activeRepoLabel = new Label();
            titleLabel = new Label();
            mergingPanel = new Panel();
            diffPanel = new Panel();
            diffSplitContainer = new SplitContainer();
            diffFile1Group = new GroupBox();
            diffFile2Group = new GroupBox();
            diffControlPanel = new Panel();
            buttonSplitContainer = new SplitContainer();
            commonBranchesButtonsPanel = new Panel();
            stageChangesSplitContainer = new SplitContainer();
            stagedChangesGroup = new GroupBox();
            stagedChangesDataGridView = new DataGridView();
            fileColumn = new DataGridViewTextBoxColumn();
            unstageColumn = new DataGridViewButtonColumn();
            unstagedChangesBox = new GroupBox();
            unstagedChangesDataGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            undoColumn = new DataGridViewButtonColumn();
            mergingControlPanel.SuspendLayout();
            panel1.SuspendLayout();
            activeRepoPanel.SuspendLayout();
            mergingPanel.SuspendLayout();
            diffPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)diffSplitContainer).BeginInit();
            diffSplitContainer.Panel1.SuspendLayout();
            diffSplitContainer.Panel2.SuspendLayout();
            diffSplitContainer.SuspendLayout();
            diffControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)buttonSplitContainer).BeginInit();
            buttonSplitContainer.SuspendLayout();
            commonBranchesButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stageChangesSplitContainer).BeginInit();
            stageChangesSplitContainer.Panel1.SuspendLayout();
            stageChangesSplitContainer.Panel2.SuspendLayout();
            stageChangesSplitContainer.SuspendLayout();
            stagedChangesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stagedChangesDataGridView).BeginInit();
            unstagedChangesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)unstagedChangesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // commitChangesButton
            // 
            commitChangesButton.Enabled = false;
            commitChangesButton.FlatStyle = FlatStyle.Flat;
            commitChangesButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            commitChangesButton.Location = new Point(17, 71);
            commitChangesButton.Name = "commitChangesButton";
            commitChangesButton.Size = new Size(181, 28);
            commitChangesButton.TabIndex = 16;
            commitChangesButton.Text = "Commit Staged Changes";
            commitChangesButton.UseVisualStyleBackColor = true;
            // 
            // mergingControlPanel
            // 
            mergingControlPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mergingControlPanel.BorderStyle = BorderStyle.FixedSingle;
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
            // panel1
            // 
            panel1.Controls.Add(commitMessageTextBox);
            panel1.Controls.Add(commitChangesButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 474);
            panel1.Name = "panel1";
            panel1.Size = new Size(278, 199);
            panel1.TabIndex = 17;
            // 
            // commitMessageTextBox
            // 
            commitMessageTextBox.Location = new Point(17, 20);
            commitMessageTextBox.Multiline = true;
            commitMessageTextBox.Name = "commitMessageTextBox";
            commitMessageTextBox.Size = new Size(228, 45);
            commitMessageTextBox.TabIndex = 8;
            commitMessageTextBox.TextChanged += commitMessageTextBox_TextChanged;
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
            activeRepoLabel.Size = new Size(134, 21);
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
            diffPanel.Controls.Add(diffSplitContainer);
            diffPanel.Controls.Add(diffControlPanel);
            diffPanel.Dock = DockStyle.Fill;
            diffPanel.Location = new Point(0, 0);
            diffPanel.Name = "diffPanel";
            diffPanel.Size = new Size(895, 475);
            diffPanel.TabIndex = 4;
            // 
            // diffSplitContainer
            // 
            diffSplitContainer.Dock = DockStyle.Fill;
            diffSplitContainer.IsSplitterFixed = true;
            diffSplitContainer.Location = new Point(0, 50);
            diffSplitContainer.Margin = new Padding(8);
            diffSplitContainer.Name = "diffSplitContainer";
            // 
            // diffSplitContainer.Panel1
            // 
            diffSplitContainer.Panel1.Controls.Add(diffFile1Group);
            // 
            // diffSplitContainer.Panel2
            // 
            diffSplitContainer.Panel2.Controls.Add(diffFile2Group);
            diffSplitContainer.Size = new Size(895, 425);
            diffSplitContainer.SplitterDistance = 437;
            diffSplitContainer.SplitterWidth = 18;
            diffSplitContainer.TabIndex = 1;
            // 
            // diffFile1Group
            // 
            diffFile1Group.AutoSize = true;
            diffFile1Group.Dock = DockStyle.Fill;
            diffFile1Group.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            diffFile1Group.Location = new Point(0, 0);
            diffFile1Group.Margin = new Padding(6);
            diffFile1Group.Name = "diffFile1Group";
            diffFile1Group.Padding = new Padding(6);
            diffFile1Group.Size = new Size(437, 425);
            diffFile1Group.TabIndex = 0;
            diffFile1Group.TabStop = false;
            diffFile1Group.Text = "Diff_File1.txt";
            // 
            // diffFile2Group
            // 
            diffFile2Group.AutoSize = true;
            diffFile2Group.Dock = DockStyle.Fill;
            diffFile2Group.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            diffFile2Group.Location = new Point(0, 0);
            diffFile2Group.Name = "diffFile2Group";
            diffFile2Group.Size = new Size(440, 425);
            diffFile2Group.TabIndex = 1;
            diffFile2Group.TabStop = false;
            diffFile2Group.Text = "Diff_File2.txt";
            // 
            // diffControlPanel
            // 
            diffControlPanel.Controls.Add(buttonSplitContainer);
            diffControlPanel.Dock = DockStyle.Top;
            diffControlPanel.Location = new Point(0, 0);
            diffControlPanel.Name = "diffControlPanel";
            diffControlPanel.Size = new Size(895, 50);
            diffControlPanel.TabIndex = 0;
            // 
            // buttonSplitContainer
            // 
            buttonSplitContainer.Dock = DockStyle.Top;
            buttonSplitContainer.Location = new Point(0, 0);
            buttonSplitContainer.Margin = new Padding(8);
            buttonSplitContainer.Name = "buttonSplitContainer";
            buttonSplitContainer.Size = new Size(895, 50);
            buttonSplitContainer.SplitterDistance = 437;
            buttonSplitContainer.SplitterWidth = 18;
            buttonSplitContainer.TabIndex = 2;
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
            stageChangesSplitContainer.Panel1.Controls.Add(stagedChangesGroup);
            // 
            // stageChangesSplitContainer.Panel2
            // 
            stageChangesSplitContainer.Panel2.Controls.Add(unstagedChangesBox);
            stageChangesSplitContainer.Size = new Size(871, 176);
            stageChangesSplitContainer.SplitterDistance = 428;
            stageChangesSplitContainer.SplitterWidth = 12;
            stageChangesSplitContainer.TabIndex = 0;
            // 
            // stagedChangesGroup
            // 
            stagedChangesGroup.Controls.Add(stagedChangesDataGridView);
            stagedChangesGroup.Dock = DockStyle.Fill;
            stagedChangesGroup.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            stagedChangesGroup.Location = new Point(0, 0);
            stagedChangesGroup.Margin = new Padding(0);
            stagedChangesGroup.Name = "stagedChangesGroup";
            stagedChangesGroup.Padding = new Padding(0);
            stagedChangesGroup.Size = new Size(428, 176);
            stagedChangesGroup.TabIndex = 0;
            stagedChangesGroup.TabStop = false;
            stagedChangesGroup.Text = "Staged Changes";
            // 
            // stagedChangesDataGridView
            // 
            stagedChangesDataGridView.AllowUserToAddRows = false;
            stagedChangesDataGridView.AllowUserToDeleteRows = false;
            stagedChangesDataGridView.AllowUserToResizeColumns = false;
            stagedChangesDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            stagedChangesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            stagedChangesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            stagedChangesDataGridView.Columns.AddRange(new DataGridViewColumn[] { fileColumn, unstageColumn });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            stagedChangesDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            stagedChangesDataGridView.Dock = DockStyle.Fill;
            stagedChangesDataGridView.Location = new Point(0, 16);
            stagedChangesDataGridView.MultiSelect = false;
            stagedChangesDataGridView.Name = "stagedChangesDataGridView";
            stagedChangesDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            stagedChangesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            stagedChangesDataGridView.RowHeadersVisible = false;
            stagedChangesDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            stagedChangesDataGridView.RowTemplate.Height = 25;
            stagedChangesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            stagedChangesDataGridView.Size = new Size(428, 160);
            stagedChangesDataGridView.TabIndex = 0;
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
            // unstagedChangesBox
            // 
            unstagedChangesBox.Controls.Add(unstagedChangesDataGridView);
            unstagedChangesBox.Dock = DockStyle.Fill;
            unstagedChangesBox.Location = new Point(0, 0);
            unstagedChangesBox.Margin = new Padding(0);
            unstagedChangesBox.Name = "unstagedChangesBox";
            unstagedChangesBox.Padding = new Padding(0);
            unstagedChangesBox.Size = new Size(431, 176);
            unstagedChangesBox.TabIndex = 1;
            unstagedChangesBox.TabStop = false;
            unstagedChangesBox.Text = "Unstaged Changes";
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
            unstagedChangesDataGridView.Location = new Point(0, 16);
            unstagedChangesDataGridView.MultiSelect = false;
            unstagedChangesDataGridView.Name = "unstagedChangesDataGridView";
            unstagedChangesDataGridView.ReadOnly = true;
            unstagedChangesDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            unstagedChangesDataGridView.RowHeadersVisible = false;
            unstagedChangesDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            unstagedChangesDataGridView.RowTemplate.Height = 25;
            unstagedChangesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            unstagedChangesDataGridView.Size = new Size(431, 160);
            unstagedChangesDataGridView.TabIndex = 1;
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
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            activeRepoPanel.ResumeLayout(false);
            activeRepoPanel.PerformLayout();
            mergingPanel.ResumeLayout(false);
            diffPanel.ResumeLayout(false);
            diffSplitContainer.Panel1.ResumeLayout(false);
            diffSplitContainer.Panel1.PerformLayout();
            diffSplitContainer.Panel2.ResumeLayout(false);
            diffSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)diffSplitContainer).EndInit();
            diffSplitContainer.ResumeLayout(false);
            diffControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)buttonSplitContainer).EndInit();
            buttonSplitContainer.ResumeLayout(false);
            commonBranchesButtonsPanel.ResumeLayout(false);
            stageChangesSplitContainer.Panel1.ResumeLayout(false);
            stageChangesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stageChangesSplitContainer).EndInit();
            stageChangesSplitContainer.ResumeLayout(false);
            stagedChangesGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)stagedChangesDataGridView).EndInit();
            unstagedChangesBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)unstagedChangesDataGridView).EndInit();
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

            unstagedChangesDataGridView.BackColor = theme.ElementBackground;
            unstagedChangesDataGridView.ForeColor = theme.TextSelectable;

            unstagedChangesDataGridView.BackgroundColor = theme.ElementBackground;
            unstagedChangesDataGridView.ForeColor = theme.TextSelectable;
            unstagedChangesDataGridView.DefaultCellStyle.ForeColor = theme.TextNormal;
            unstagedChangesDataGridView.DefaultCellStyle.BackColor = theme.ElementBackground;
            unstagedChangesDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = theme.TextSelectable;
            unstagedChangesDataGridView.ColumnHeadersDefaultCellStyle.BackColor = theme.ElementBackground;
            unstagedChangesDataGridView.EnableHeadersVisualStyles = false;

            stagedChangesGroup.ForeColor = theme.TextNormal;
            unstagedChangesBox.ForeColor = theme.TextNormal;

            diffFile1Group.ForeColor = theme.TextHeader;
            diffFile2Group.ForeColor = theme.TextHeader;

            //chooseLocalButton.BackColor = theme.ElementBackground;
            //chooseRemoteButton.BackColor = theme.ElementBackground;
            //chooseLocalButton.ForeColor = theme.TextSelectable;
            //chooseRemoteButton.ForeColor = theme.TextSelectable;
        }
        private Panel mergingControlPanel;
        private Label titleLabel;
        private Panel mergingPanel;
        private Panel diffPanel;
        private SplitContainer diffSplitContainer;
        private GroupBox diffFile1Group;
        private GroupBox diffFile2Group;
        private Panel diffControlPanel;
        private SplitContainer buttonSplitContainer;
        private Panel activeRepoPanel;
        private Label activeRepositoryTextLabel;
        private Label activeRepoLabel;
        private TextBox commitMessageTextBox;
        private Panel panel1;
        private Panel commonBranchesButtonsPanel;
        private SplitContainer stageChangesSplitContainer;
        private GroupBox stagedChangesGroup;
        private DataGridView stagedChangesDataGridView;
        private GroupBox unstagedChangesBox;
        private DataGridView unstagedChangesDataGridView;
        private DataGridViewTextBoxColumn fileColumn;
        private DataGridViewButtonColumn unstageColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private DataGridViewButtonColumn undoColumn;
        private Button commitChangesButton;
    }
}
