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
            commonRepoButtonsPanel = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            createNewLocalRepoButton = new Button();
            trackExistingReposButton = new Button();
            activeRepoPanel = new Panel();
            activeRepositoryTextLabel = new Label();
            activeRepoLabel = new Label();
            titleLabel = new Label();
            reposButtonsMainPanel = new Panel();
            repositoriesButtonsSplitContainer = new SplitContainer();
            openInFileExplorerButton = new Button();
            setAsActiveRepoButton = new Button();
            localRepoButtonsLabel = new Label();
            createNewRemoteRepoButton = new Button();
            openOnGithubComButton = new Button();
            remoteRepoButtonsLabel = new Label();
            cloneToLocalButton = new Button();
            ((System.ComponentModel.ISupportInitialize)repositoriesGridView).BeginInit();
            repositoriesControlPanel.SuspendLayout();
            commonRepoButtonsPanel.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            activeRepoPanel.SuspendLayout();
            reposButtonsMainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)repositoriesButtonsSplitContainer).BeginInit();
            repositoriesButtonsSplitContainer.Panel1.SuspendLayout();
            repositoriesButtonsSplitContainer.Panel2.SuspendLayout();
            repositoriesButtonsSplitContainer.SuspendLayout();
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
            repositoriesControlPanel.Controls.Add(commonRepoButtonsPanel);
            repositoriesControlPanel.Controls.Add(activeRepoPanel);
            repositoriesControlPanel.Controls.Add(titleLabel);
            repositoriesControlPanel.Dock = DockStyle.Left;
            repositoriesControlPanel.Location = new Point(0, 0);
            repositoriesControlPanel.MinimumSize = new Size(280, 280);
            repositoriesControlPanel.Name = "repositoriesControlPanel";
            repositoriesControlPanel.Size = new Size(280, 675);
            repositoriesControlPanel.TabIndex = 1;
            // 
            // commonRepoButtonsPanel
            // 
            commonRepoButtonsPanel.Controls.Add(flowLayoutPanel1);
            commonRepoButtonsPanel.Dock = DockStyle.Bottom;
            commonRepoButtonsPanel.Location = new Point(0, 536);
            commonRepoButtonsPanel.Name = "commonRepoButtonsPanel";
            commonRepoButtonsPanel.Size = new Size(278, 137);
            commonRepoButtonsPanel.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(createNewLocalRepoButton);
            flowLayoutPanel1.Controls.Add(trackExistingReposButton);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(8);
            flowLayoutPanel1.Size = new Size(278, 137);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // createNewLocalRepoButton
            // 
            createNewLocalRepoButton.Dock = DockStyle.Top;
            createNewLocalRepoButton.FlatStyle = FlatStyle.Flat;
            createNewLocalRepoButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            createNewLocalRepoButton.Location = new Point(11, 11);
            createNewLocalRepoButton.Name = "createNewLocalRepoButton";
            createNewLocalRepoButton.Size = new Size(254, 38);
            createNewLocalRepoButton.TabIndex = 6;
            createNewLocalRepoButton.Text = "Create New Local Repo";
            createNewLocalRepoButton.UseVisualStyleBackColor = true;
            createNewLocalRepoButton.Click += OnCreateNewLocalRepoButton;
            // 
            // trackExistingReposButton
            // 
            trackExistingReposButton.Dock = DockStyle.Top;
            trackExistingReposButton.FlatStyle = FlatStyle.Flat;
            trackExistingReposButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            trackExistingReposButton.Location = new Point(11, 55);
            trackExistingReposButton.Name = "trackExistingReposButton";
            trackExistingReposButton.Size = new Size(254, 36);
            trackExistingReposButton.TabIndex = 7;
            trackExistingReposButton.Text = "Track Existing Repos";
            trackExistingReposButton.UseVisualStyleBackColor = true;
            trackExistingReposButton.Click += OnTrackExistingReposButton;
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
            titleLabel.FlatStyle = FlatStyle.Flat;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Margin = new Padding(3, 0, 3, 10);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(278, 54);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Repositories";
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
            repositoriesButtonsSplitContainer.Panel1.Controls.Add(openInFileExplorerButton);
            repositoriesButtonsSplitContainer.Panel1.Controls.Add(setAsActiveRepoButton);
            repositoriesButtonsSplitContainer.Panel1.Controls.Add(localRepoButtonsLabel);
            repositoriesButtonsSplitContainer.Panel1.Controls.Add(createNewRemoteRepoButton);
            // 
            // repositoriesButtonsSplitContainer.Panel2
            // 
            repositoriesButtonsSplitContainer.Panel2.Controls.Add(openOnGithubComButton);
            repositoriesButtonsSplitContainer.Panel2.Controls.Add(remoteRepoButtonsLabel);
            repositoriesButtonsSplitContainer.Panel2.Controls.Add(cloneToLocalButton);
            repositoriesButtonsSplitContainer.Size = new Size(895, 138);
            repositoriesButtonsSplitContainer.SplitterDistance = 441;
            repositoriesButtonsSplitContainer.SplitterWidth = 2;
            repositoriesButtonsSplitContainer.TabIndex = 0;
            // 
            // openInFileExplorerButton
            // 
            openInFileExplorerButton.FlatStyle = FlatStyle.Flat;
            openInFileExplorerButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            openInFileExplorerButton.Location = new Point(6, 69);
            openInFileExplorerButton.Name = "openInFileExplorerButton";
            openInFileExplorerButton.Size = new Size(148, 28);
            openInFileExplorerButton.TabIndex = 7;
            openInFileExplorerButton.Tag = "repoButton";
            openInFileExplorerButton.Text = "Open In File Explorer";
            openInFileExplorerButton.UseVisualStyleBackColor = true;
            openInFileExplorerButton.Visible = false;
            openInFileExplorerButton.Click += OnOpenInFileExplorerButton;
            // 
            // setAsActiveRepoButton
            // 
            setAsActiveRepoButton.FlatStyle = FlatStyle.Flat;
            setAsActiveRepoButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            setAsActiveRepoButton.Location = new Point(6, 35);
            setAsActiveRepoButton.Name = "setAsActiveRepoButton";
            setAsActiveRepoButton.Size = new Size(148, 28);
            setAsActiveRepoButton.TabIndex = 6;
            setAsActiveRepoButton.Tag = "repoButton";
            setAsActiveRepoButton.Text = "Set As Active Repo";
            setAsActiveRepoButton.UseVisualStyleBackColor = true;
            setAsActiveRepoButton.Visible = false;
            setAsActiveRepoButton.Click += OnSetAsActiveRepoButton;
            // 
            // localRepoButtonsLabel
            // 
            localRepoButtonsLabel.Dock = DockStyle.Top;
            localRepoButtonsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            localRepoButtonsLabel.Location = new Point(0, 0);
            localRepoButtonsLabel.Name = "localRepoButtonsLabel";
            localRepoButtonsLabel.Size = new Size(441, 32);
            localRepoButtonsLabel.TabIndex = 4;
            localRepoButtonsLabel.Text = "Local: ";
            // 
            // createNewRemoteRepoButton
            // 
            createNewRemoteRepoButton.FlatStyle = FlatStyle.Flat;
            createNewRemoteRepoButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            createNewRemoteRepoButton.Location = new Point(6, 103);
            createNewRemoteRepoButton.Name = "createNewRemoteRepoButton";
            createNewRemoteRepoButton.Size = new Size(148, 28);
            createNewRemoteRepoButton.TabIndex = 0;
            createNewRemoteRepoButton.Tag = "repoButton";
            createNewRemoteRepoButton.Text = "Create Remote Repo";
            createNewRemoteRepoButton.UseVisualStyleBackColor = true;
            createNewRemoteRepoButton.Visible = false;
            // 
            // openOnGithubComButton
            // 
            openOnGithubComButton.FlatStyle = FlatStyle.Flat;
            openOnGithubComButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            openOnGithubComButton.Location = new Point(3, 35);
            openOnGithubComButton.Name = "openOnGithubComButton";
            openOnGithubComButton.Size = new Size(148, 28);
            openOnGithubComButton.TabIndex = 6;
            openOnGithubComButton.Tag = "repoButton";
            openOnGithubComButton.Text = "Open on Github.com";
            openOnGithubComButton.UseVisualStyleBackColor = true;
            openOnGithubComButton.Visible = false;
            openOnGithubComButton.Click += OnOpenOnGithubComButton;
            // 
            // remoteRepoButtonsLabel
            // 
            remoteRepoButtonsLabel.Dock = DockStyle.Top;
            remoteRepoButtonsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            remoteRepoButtonsLabel.Location = new Point(0, 0);
            remoteRepoButtonsLabel.Name = "remoteRepoButtonsLabel";
            remoteRepoButtonsLabel.Size = new Size(452, 32);
            remoteRepoButtonsLabel.TabIndex = 5;
            remoteRepoButtonsLabel.Text = "Remote: ";
            // 
            // cloneToLocalButton
            // 
            cloneToLocalButton.FlatStyle = FlatStyle.Flat;
            cloneToLocalButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cloneToLocalButton.Location = new Point(3, 69);
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
            commonRepoButtonsPanel.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            activeRepoPanel.ResumeLayout(false);
            activeRepoPanel.PerformLayout();
            reposButtonsMainPanel.ResumeLayout(false);
            repositoriesButtonsSplitContainer.Panel1.ResumeLayout(false);
            repositoriesButtonsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)repositoriesButtonsSplitContainer).EndInit();
            repositoriesButtonsSplitContainer.ResumeLayout(false);
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
        private Panel commonRepoButtonsPanel;
        private DataGridViewTextBoxColumn localReposColumn;
        private DataGridViewTextBoxColumn remoteReposColumn;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button createNewLocalRepoButton;
        private Button trackExistingReposButton;
    }
}
