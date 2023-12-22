namespace GitVisualizer.UI.UI_Forms
{
    partial class RepositoriesControl
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
            repositoriesGridView = new DataGridView();
            localReposColumn = new DataGridViewTextBoxColumn();
            remoteReposColumn = new DataGridViewTextBoxColumn();
            repositoriesControlPanel = new Panel();
            activeRepoPanel = new Panel();
            activeRepositoryTextLabel = new Label();
            activeRepoLabel = new Label();
            titleLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            localReposLabel = new Label();
            createNewLocalRepoButton = new Button();
            trackExistingReposButton = new Button();
            trackedReposLabel = new Label();
            localRepoComboBox = new ComboBox();
            untrackReposButton = new Button();
            reposButtonsMainPanel = new Panel();
            repositoriesButtonsSplitContainer = new SplitContainer();
            flowLayoutPanel3 = new FlowLayoutPanel();
            localRepoButtonsLabel = new Label();
            setAsActiveRepoButton = new Button();
            openInFileExplorerButton = new Button();
            createNewRemoteRepoButton = new Button();
            flowLayoutPanel4 = new FlowLayoutPanel();
            remoteRepoButtonsLabel = new Label();
            openOnGithubComButton = new Button();
            cloneToLocalButton = new Button();
            ((System.ComponentModel.ISupportInitialize)repositoriesGridView).BeginInit();
            repositoriesControlPanel.SuspendLayout();
            activeRepoPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            reposButtonsMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)repositoriesButtonsSplitContainer).BeginInit();
            repositoriesButtonsSplitContainer.Panel1.SuspendLayout();
            repositoriesButtonsSplitContainer.Panel2.SuspendLayout();
            repositoriesButtonsSplitContainer.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // repositoriesGridView
            // 
            repositoriesGridView.AllowUserToDeleteRows = false;
            repositoriesGridView.AllowUserToResizeRows = false;
            repositoriesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            repositoriesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            repositoriesGridView.Columns.AddRange(new DataGridViewColumn[] { localReposColumn, remoteReposColumn });
            repositoriesGridView.Dock = DockStyle.Fill;
            repositoriesGridView.ImeMode = ImeMode.Off;
            repositoriesGridView.Location = new Point(280, 0);
            repositoriesGridView.Margin = new Padding(6);
            repositoriesGridView.MultiSelect = false;
            repositoriesGridView.Name = "repositoriesGridView";
            repositoriesGridView.ReadOnly = true;
            repositoriesGridView.RowHeadersVisible = false;
            repositoriesGridView.RowHeadersWidth = 51;
            repositoriesGridView.RowTemplate.Height = 25;
            repositoriesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            repositoriesGridView.ShowEditingIcon = false;
            repositoriesGridView.Size = new Size(895, 537);
            repositoriesGridView.TabIndex = 0;
            repositoriesGridView.CellClick += repositoriesGridView_CellContentClick;
            // 
            // localReposColumn
            // 
            localReposColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            localReposColumn.HeaderText = "Local Repositories";
            localReposColumn.MinimumWidth = 6;
            localReposColumn.Name = "localReposColumn";
            localReposColumn.ReadOnly = true;
            localReposColumn.ToolTipText = "Repository Folders stored locally on your device, which hold the files you modify directly on your computer.";
            // 
            // remoteReposColumn
            // 
            remoteReposColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            remoteReposColumn.HeaderText = "Remote Repositories";
            remoteReposColumn.MinimumWidth = 6;
            remoteReposColumn.Name = "remoteReposColumn";
            remoteReposColumn.ReadOnly = true;
            remoteReposColumn.Resizable = DataGridViewTriState.True;
            // 
            // repositoriesControlPanel
            // 
            repositoriesControlPanel.AutoSize = true;
            repositoriesControlPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            repositoriesControlPanel.BorderStyle = BorderStyle.FixedSingle;
            repositoriesControlPanel.Controls.Add(activeRepoPanel);
            repositoriesControlPanel.Controls.Add(titleLabel);
            repositoriesControlPanel.Controls.Add(flowLayoutPanel1);
            repositoriesControlPanel.Dock = DockStyle.Left;
            repositoriesControlPanel.Location = new Point(0, 0);
            repositoriesControlPanel.MinimumSize = new Size(280, 280);
            repositoriesControlPanel.Name = "repositoriesControlPanel";
            repositoriesControlPanel.Size = new Size(280, 675);
            repositoriesControlPanel.TabIndex = 1;
            // 
            // activeRepoPanel
            // 
            activeRepoPanel.Controls.Add(activeRepositoryTextLabel);
            activeRepoPanel.Controls.Add(activeRepoLabel);
            activeRepoPanel.Dock = DockStyle.Top;
            activeRepoPanel.Location = new Point(0, 54);
            activeRepoPanel.Name = "activeRepoPanel";
            activeRepoPanel.Size = new Size(278, 107);
            activeRepoPanel.TabIndex = 4;
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
            titleLabel.FlatStyle = FlatStyle.Flat;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Margin = new Padding(3, 0, 3, 10);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(278, 54);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Repositories";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 441);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(8);
            flowLayoutPanel1.Size = new Size(278, 232);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(localReposLabel);
            flowLayoutPanel2.Controls.Add(createNewLocalRepoButton);
            flowLayoutPanel2.Controls.Add(trackExistingReposButton);
            flowLayoutPanel2.Controls.Add(trackedReposLabel);
            flowLayoutPanel2.Controls.Add(localRepoComboBox);
            flowLayoutPanel2.Controls.Add(untrackReposButton);
            flowLayoutPanel2.Dock = DockStyle.Top;
            flowLayoutPanel2.Location = new Point(11, 11);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(4);
            flowLayoutPanel2.Size = new Size(253, 209);
            flowLayoutPanel2.TabIndex = 8;
            // 
            // localReposLabel
            // 
            localReposLabel.AutoSize = true;
            localReposLabel.Dock = DockStyle.Top;
            localReposLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            localReposLabel.Location = new Point(7, 4);
            localReposLabel.Name = "localReposLabel";
            localReposLabel.Size = new Size(93, 21);
            localReposLabel.TabIndex = 8;
            localReposLabel.Text = "Local Repos";
            // 
            // createNewLocalRepoButton
            // 
            createNewLocalRepoButton.Dock = DockStyle.Top;
            createNewLocalRepoButton.FlatStyle = FlatStyle.Flat;
            createNewLocalRepoButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            createNewLocalRepoButton.Location = new Point(7, 28);
            createNewLocalRepoButton.Name = "createNewLocalRepoButton";
            createNewLocalRepoButton.Size = new Size(240, 38);
            createNewLocalRepoButton.TabIndex = 6;
            createNewLocalRepoButton.Text = "Create New Local Repo";
            createNewLocalRepoButton.UseVisualStyleBackColor = true;
            createNewLocalRepoButton.Click += OnCreateNewLocalRepoButton;
            // 
            // trackExistingReposButton
            // 
            trackExistingReposButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            trackExistingReposButton.Dock = DockStyle.Top;
            trackExistingReposButton.FlatStyle = FlatStyle.Flat;
            trackExistingReposButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            trackExistingReposButton.Location = new Point(7, 72);
            trackExistingReposButton.Name = "trackExistingReposButton";
            trackExistingReposButton.Size = new Size(240, 36);
            trackExistingReposButton.TabIndex = 7;
            trackExistingReposButton.Text = "Track Existing Repos";
            trackExistingReposButton.UseVisualStyleBackColor = true;
            trackExistingReposButton.Click += OnTrackExistingReposButton;
            // 
            // trackedReposLabel
            // 
            trackedReposLabel.AutoSize = true;
            trackedReposLabel.Dock = DockStyle.Top;
            trackedReposLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            trackedReposLabel.Location = new Point(7, 111);
            trackedReposLabel.Name = "trackedReposLabel";
            trackedReposLabel.Size = new Size(110, 21);
            trackedReposLabel.TabIndex = 9;
            trackedReposLabel.Text = "Tracked Repos";
            // 
            // localRepoComboBox
            // 
            localRepoComboBox.Dock = DockStyle.Top;
            localRepoComboBox.FormattingEnabled = true;
            localRepoComboBox.Location = new Point(7, 135);
            localRepoComboBox.Name = "localRepoComboBox";
            localRepoComboBox.Size = new Size(240, 23);
            localRepoComboBox.TabIndex = 7;
            localRepoComboBox.Text = "Local Repo...";
            // 
            // untrackReposButton
            // 
            untrackReposButton.Dock = DockStyle.Top;
            untrackReposButton.FlatStyle = FlatStyle.Flat;
            untrackReposButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            untrackReposButton.Location = new Point(7, 164);
            untrackReposButton.Name = "untrackReposButton";
            untrackReposButton.Size = new Size(240, 38);
            untrackReposButton.TabIndex = 6;
            untrackReposButton.Text = "Untrack Repos";
            untrackReposButton.UseVisualStyleBackColor = true;
            untrackReposButton.Click += OnUntrackReposButton;
            // 
            // reposButtonsMainPanel
            // 
            reposButtonsMainPanel.Controls.Add(repositoriesButtonsSplitContainer);
            reposButtonsMainPanel.Dock = DockStyle.Bottom;
            reposButtonsMainPanel.Location = new Point(280, 537);
            reposButtonsMainPanel.Name = "reposButtonsMainPanel";
            reposButtonsMainPanel.Size = new Size(895, 138);
            reposButtonsMainPanel.TabIndex = 3;
            // 
            // repositoriesButtonsSplitContainer
            // 
            repositoriesButtonsSplitContainer.Dock = DockStyle.Fill;
            repositoriesButtonsSplitContainer.IsSplitterFixed = true;
            repositoriesButtonsSplitContainer.Location = new Point(0, 0);
            repositoriesButtonsSplitContainer.Name = "repositoriesButtonsSplitContainer";
            // 
            // repositoriesButtonsSplitContainer.Panel1
            // 
            repositoriesButtonsSplitContainer.Panel1.Controls.Add(flowLayoutPanel3);
            // 
            // repositoriesButtonsSplitContainer.Panel2
            // 
            repositoriesButtonsSplitContainer.Panel2.Controls.Add(flowLayoutPanel4);
            repositoriesButtonsSplitContainer.Size = new Size(895, 138);
            repositoriesButtonsSplitContainer.SplitterDistance = 441;
            repositoriesButtonsSplitContainer.SplitterWidth = 2;
            repositoriesButtonsSplitContainer.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(localRepoButtonsLabel);
            flowLayoutPanel3.Controls.Add(setAsActiveRepoButton);
            flowLayoutPanel3.Controls.Add(openInFileExplorerButton);
            flowLayoutPanel3.Controls.Add(createNewRemoteRepoButton);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(0, 0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new Padding(8);
            flowLayoutPanel3.Size = new Size(441, 138);
            flowLayoutPanel3.TabIndex = 9;
            // 
            // localRepoButtonsLabel
            // 
            localRepoButtonsLabel.AutoSize = true;
            localRepoButtonsLabel.Dock = DockStyle.Top;
            flowLayoutPanel3.SetFlowBreak(localRepoButtonsLabel, true);
            localRepoButtonsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            localRepoButtonsLabel.Location = new Point(11, 8);
            localRepoButtonsLabel.Name = "localRepoButtonsLabel";
            localRepoButtonsLabel.Size = new Size(53, 21);
            localRepoButtonsLabel.TabIndex = 4;
            localRepoButtonsLabel.Text = "Local: ";
            // 
            // setAsActiveRepoButton
            // 
            setAsActiveRepoButton.FlatStyle = FlatStyle.Flat;
            setAsActiveRepoButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            setAsActiveRepoButton.Location = new Point(11, 45);
            setAsActiveRepoButton.Name = "setAsActiveRepoButton";
            setAsActiveRepoButton.Size = new Size(148, 28);
            setAsActiveRepoButton.TabIndex = 6;
            setAsActiveRepoButton.Tag = "repoButton";
            setAsActiveRepoButton.Text = "Set As Active Repo";
            setAsActiveRepoButton.UseVisualStyleBackColor = true;
            setAsActiveRepoButton.Visible = false;
            setAsActiveRepoButton.Click += OnSetAsActiveRepoButton;
            // 
            // openInFileExplorerButton
            // 
            openInFileExplorerButton.FlatStyle = FlatStyle.Flat;
            openInFileExplorerButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            openInFileExplorerButton.Location = new Point(165, 45);
            openInFileExplorerButton.Name = "openInFileExplorerButton";
            openInFileExplorerButton.Size = new Size(148, 28);
            openInFileExplorerButton.TabIndex = 7;
            openInFileExplorerButton.Tag = "repoButton";
            openInFileExplorerButton.Text = "Open In File Explorer";
            openInFileExplorerButton.UseVisualStyleBackColor = true;
            openInFileExplorerButton.Visible = false;
            openInFileExplorerButton.Click += OnOpenInFileExplorerButton;
            // 
            // createNewRemoteRepoButton
            // 
            createNewRemoteRepoButton.FlatStyle = FlatStyle.Flat;
            createNewRemoteRepoButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            createNewRemoteRepoButton.Location = new Point(11, 79);
            createNewRemoteRepoButton.Name = "createNewRemoteRepoButton";
            createNewRemoteRepoButton.Size = new Size(148, 28);
            createNewRemoteRepoButton.TabIndex = 0;
            createNewRemoteRepoButton.Tag = "repoButton";
            createNewRemoteRepoButton.Text = "Create Remote Repo";
            createNewRemoteRepoButton.UseVisualStyleBackColor = true;
            createNewRemoteRepoButton.Visible = false;
            createNewRemoteRepoButton.Click += OnCreateNewRemoteRepoButton;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(remoteRepoButtonsLabel);
            flowLayoutPanel4.Controls.Add(openOnGithubComButton);
            flowLayoutPanel4.Controls.Add(cloneToLocalButton);
            flowLayoutPanel4.Dock = DockStyle.Fill;
            flowLayoutPanel4.Location = new Point(0, 0);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Padding = new Padding(8);
            flowLayoutPanel4.Size = new Size(452, 138);
            flowLayoutPanel4.TabIndex = 10;
            // 
            // remoteRepoButtonsLabel
            // 
            remoteRepoButtonsLabel.AutoSize = true;
            remoteRepoButtonsLabel.Dock = DockStyle.Top;
            flowLayoutPanel4.SetFlowBreak(remoteRepoButtonsLabel, true);
            remoteRepoButtonsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            remoteRepoButtonsLabel.Location = new Point(11, 8);
            remoteRepoButtonsLabel.Name = "remoteRepoButtonsLabel";
            remoteRepoButtonsLabel.Size = new Size(71, 21);
            remoteRepoButtonsLabel.TabIndex = 5;
            remoteRepoButtonsLabel.Text = "Remote: ";
            // 
            // openOnGithubComButton
            // 
            openOnGithubComButton.FlatStyle = FlatStyle.Flat;
            flowLayoutPanel4.SetFlowBreak(openOnGithubComButton, true);
            openOnGithubComButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            openOnGithubComButton.Location = new Point(11, 45);
            openOnGithubComButton.Name = "openOnGithubComButton";
            openOnGithubComButton.Size = new Size(148, 28);
            openOnGithubComButton.TabIndex = 6;
            openOnGithubComButton.Tag = "repoButton";
            openOnGithubComButton.Text = "Open on Github.com";
            openOnGithubComButton.UseVisualStyleBackColor = true;
            openOnGithubComButton.Visible = false;
            openOnGithubComButton.Click += OnOpenOnGithubComButton;
            // 
            // cloneToLocalButton
            // 
            cloneToLocalButton.FlatStyle = FlatStyle.Flat;
            cloneToLocalButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cloneToLocalButton.Location = new Point(11, 79);
            cloneToLocalButton.Name = "cloneToLocalButton";
            cloneToLocalButton.Size = new Size(148, 28);
            cloneToLocalButton.TabIndex = 0;
            cloneToLocalButton.Tag = "repoButton";
            cloneToLocalButton.Text = "Clone To Local";
            cloneToLocalButton.UseVisualStyleBackColor = true;
            cloneToLocalButton.Visible = false;
            cloneToLocalButton.Click += OnCloneToLocalButton;
            // 
            // RepositoriesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(repositoriesGridView);
            Controls.Add(reposButtonsMainPanel);
            Controls.Add(repositoriesControlPanel);
            Margin = new Padding(6, 3, 3, 3);
            Name = "RepositoriesControl";
            Size = new Size(1175, 675);
            ((System.ComponentModel.ISupportInitialize)repositoriesGridView).EndInit();
            repositoriesControlPanel.ResumeLayout(false);
            activeRepoPanel.ResumeLayout(false);
            activeRepoPanel.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            reposButtonsMainPanel.ResumeLayout(false);
            repositoriesButtonsSplitContainer.Panel1.ResumeLayout(false);
            repositoriesButtonsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)repositoriesButtonsSplitContainer).EndInit();
            repositoriesButtonsSplitContainer.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private void ApplyColorTheme(UITheme.AppTheme theme)
        {
            BackColor = theme.AppBackground;
            ForeColor = theme.TextSoft;




            /// Apply themes to all buttons
            IEnumerable<Control> buttons = this.Controls.OfType<Control>().Where(x => x is Button);
            foreach (Button button in buttons)
            {
                button.BackColor = theme.ElementBackground;
                button.ForeColor = theme.TextSelectable;
            }


            activeRepoLabel.ForeColor = theme.TextNormal;
            localReposLabel.ForeColor = theme.TextNormal;
            trackedReposLabel.ForeColor = theme.TextNormal;


            repositoriesGridView.BackgroundColor = theme.ElementBackground;
            repositoriesGridView.ForeColor = theme.TextSelectable;
            repositoriesGridView.DefaultCellStyle.ForeColor = theme.TextSelectable;
            repositoriesGridView.DefaultCellStyle.BackColor = theme.ElementBackground;
            repositoriesGridView.ColumnHeadersDefaultCellStyle.ForeColor = theme.TextSelectable;
            repositoriesGridView.ColumnHeadersDefaultCellStyle.BackColor = theme.ElementBackground;
            repositoriesGridView.EnableHeadersVisualStyles = false;

            repositoriesGridView.DefaultCellStyle.SelectionBackColor = theme.ElementSelected;
            repositoriesGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = repositoriesGridView.DefaultCellStyle.BackColor;


            repositoriesControlPanel.BackColor = theme.PanelBackground;
            repositoriesControlPanel.ForeColor = theme.TextBright;

            reposButtonsMainPanel.BackColor = theme.ElementBackground;
            reposButtonsMainPanel.ForeColor = theme.TextSelectable;
            localRepoButtonsLabel.ForeColor = theme.TextNormal;
            remoteRepoButtonsLabel.ForeColor = theme.TextNormal;

            activeRepositoryTextLabel.ForeColor = theme.TextSoft;

        }
        public DataGridView repositoriesGridView;
        private Panel repositoriesControlPanel;
        private Button grantAccessButton;
        private Label titleLabel;
        private Panel buttonsPanel;
        private Panel reposButtonsMainPanel;
        private SplitContainer repositoriesButtonsSplitContainer;
        private Button cloneToLocalButton;
        private Button createNewRemoteRepoButton;
        private Label activeRepoLabel;
        private Panel activeRepoPanel;
        private Label activeRepositoryTextLabel;
        private Label localRepoButtonsLabel;
        private Label remoteRepoButtonsLabel;
        private Button setAsActiveRepoButton;
        private Button openInFileExplorerButton;
        private Button openOnGithubComButton;
        private DataGridViewTextBoxColumn localReposColumn;
        private DataGridViewTextBoxColumn remoteReposColumn;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button untrackReposButton;
        private ComboBox localRepoComboBox;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button trackExistingReposButton;
        private Button createNewLocalRepoButton;
        private Label localReposLabel;
        private Label trackedReposLabel;
        private FlowLayoutPanel flowLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel4;
    }
}
