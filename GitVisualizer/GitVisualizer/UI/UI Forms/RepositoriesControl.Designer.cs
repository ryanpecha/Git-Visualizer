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
            buttonsPanel = new Panel();
            revokeAccessButton = new Button();
            grantAccessButton = new Button();
            titleLabel = new Label();
            reposButtonsMainPanel = new Panel();
            repositoriesButtonsSplitContainer = new SplitContainer();
            cloneToLocalButton = new Button();
            createNewRemoteRepoButton = new Button();
            localRepoButtonsLabel = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)repositoriesGridView).BeginInit();
            repositoriesControlPanel.SuspendLayout();
            activeRepoPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
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
            repositoriesGridView.Size = new Size(895, 555);
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
            repositoriesControlPanel.Controls.Add(buttonsPanel);
            repositoriesControlPanel.Controls.Add(titleLabel);
            repositoriesControlPanel.Dock = DockStyle.Left;
            repositoriesControlPanel.Location = new Point(0, 0);
            repositoriesControlPanel.MinimumSize = new Size(280, 280);
            repositoriesControlPanel.Name = "repositoriesControlPanel";
            repositoriesControlPanel.Size = new Size(280, 675);
            repositoriesControlPanel.TabIndex = 1;
            repositoriesControlPanel.Paint += repositoriesControlPanel_Paint;
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
            activeRepoLabel.Click += label1_Click;
            // 
            // buttonsPanel
            // 
            buttonsPanel.AutoSize = true;
            buttonsPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonsPanel.Controls.Add(revokeAccessButton);
            buttonsPanel.Controls.Add(grantAccessButton);
            buttonsPanel.Dock = DockStyle.Bottom;
            buttonsPanel.Location = new Point(0, 493);
            buttonsPanel.MinimumSize = new Size(0, 180);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(278, 180);
            buttonsPanel.TabIndex = 2;
            // 
            // revokeAccessButton
            // 
            revokeAccessButton.FlatStyle = FlatStyle.Flat;
            revokeAccessButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            revokeAccessButton.Location = new Point(47, 28);
            revokeAccessButton.Name = "revokeAccessButton";
            revokeAccessButton.Size = new Size(166, 54);
            revokeAccessButton.TabIndex = 0;
            revokeAccessButton.Text = "Revoke Access";
            revokeAccessButton.UseVisualStyleBackColor = true;
            revokeAccessButton.Click += RevokeGithubAuthenticationButtonPressed;
            // 
            // grantAccessButton
            // 
            grantAccessButton.FlatStyle = FlatStyle.Flat;
            grantAccessButton.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            grantAccessButton.Location = new Point(47, 106);
            grantAccessButton.Name = "grantAccessButton";
            grantAccessButton.Size = new Size(166, 54);
            grantAccessButton.TabIndex = 0;
            grantAccessButton.Text = "Grant Access";
            grantAccessButton.UseVisualStyleBackColor = true;
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
            reposButtonsMainPanel.Location = new Point(280, 555);
            reposButtonsMainPanel.Name = "reposButtonsMainPanel";
            reposButtonsMainPanel.Size = new Size(895, 120);
            reposButtonsMainPanel.TabIndex = 3;
            // 
            // repositoriesButtonsSplitContainer
            // 
            repositoriesButtonsSplitContainer.Dock = DockStyle.Fill;
            repositoriesButtonsSplitContainer.Location = new Point(0, 0);
            repositoriesButtonsSplitContainer.Name = "repositoriesButtonsSplitContainer";
            // 
            // repositoriesButtonsSplitContainer.Panel1
            // 
            repositoriesButtonsSplitContainer.Panel1.Controls.Add(localRepoButtonsLabel);
            repositoriesButtonsSplitContainer.Panel1.Controls.Add(cloneToLocalButton);
            // 
            // repositoriesButtonsSplitContainer.Panel2
            // 
            repositoriesButtonsSplitContainer.Panel2.Controls.Add(label1);
            repositoriesButtonsSplitContainer.Panel2.Controls.Add(createNewRemoteRepoButton);
            repositoriesButtonsSplitContainer.Size = new Size(895, 120);
            repositoriesButtonsSplitContainer.SplitterDistance = 446;
            repositoriesButtonsSplitContainer.SplitterWidth = 2;
            repositoriesButtonsSplitContainer.TabIndex = 0;
            // 
            // cloneToLocalButton
            // 
            cloneToLocalButton.FlatStyle = FlatStyle.Flat;
            cloneToLocalButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            cloneToLocalButton.Location = new Point(142, 45);
            cloneToLocalButton.Name = "cloneToLocalButton";
            cloneToLocalButton.Size = new Size(148, 28);
            cloneToLocalButton.TabIndex = 0;
            cloneToLocalButton.Text = "Clone To Local";
            cloneToLocalButton.UseVisualStyleBackColor = true;
            cloneToLocalButton.Visible = false;
            cloneToLocalButton.Click += RevokeGithubAuthenticationButtonPressed;
            // 
            // createNewRemoteRepoButton
            // 
            createNewRemoteRepoButton.FlatStyle = FlatStyle.Flat;
            createNewRemoteRepoButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            createNewRemoteRepoButton.Location = new Point(150, 45);
            createNewRemoteRepoButton.Name = "createNewRemoteRepoButton";
            createNewRemoteRepoButton.Size = new Size(148, 28);
            createNewRemoteRepoButton.TabIndex = 0;
            createNewRemoteRepoButton.Text = "Create Remote Repo";
            createNewRemoteRepoButton.UseVisualStyleBackColor = true;
            createNewRemoteRepoButton.Visible = false;
            createNewRemoteRepoButton.Click += RevokeGithubAuthenticationButtonPressed;
            // 
            // localRepoButtonsLabel
            // 
            localRepoButtonsLabel.AutoSize = true;
            localRepoButtonsLabel.Dock = DockStyle.Top;
            localRepoButtonsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            localRepoButtonsLabel.Location = new Point(0, 0);
            localRepoButtonsLabel.Name = "localRepoButtonsLabel";
            localRepoButtonsLabel.Size = new Size(53, 21);
            localRepoButtonsLabel.TabIndex = 4;
            localRepoButtonsLabel.Text = "Local: ";
            localRepoButtonsLabel.TextAlign = ContentAlignment.MiddleCenter;
            localRepoButtonsLabel.Click += label1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 21);
            label1.TabIndex = 5;
            label1.Text = "Remote: ";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RepositoriesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(repositoriesGridView);
            Controls.Add(reposButtonsMainPanel);
            Controls.Add(repositoriesControlPanel);
            Name = "RepositoriesControl";
            Size = new Size(1175, 675);
            Load += RepositoriesControl_Load;
            ((System.ComponentModel.ISupportInitialize)repositoriesGridView).EndInit();
            repositoriesControlPanel.ResumeLayout(false);
            repositoriesControlPanel.PerformLayout();
            activeRepoPanel.ResumeLayout(false);
            activeRepoPanel.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            reposButtonsMainPanel.ResumeLayout(false);
            repositoriesButtonsSplitContainer.Panel1.ResumeLayout(false);
            repositoriesButtonsSplitContainer.Panel1.PerformLayout();
            repositoriesButtonsSplitContainer.Panel2.ResumeLayout(false);
            repositoriesButtonsSplitContainer.Panel2.PerformLayout();
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

            repositoriesControlPanel.BackColor = theme.PanelBackground;
            repositoriesControlPanel.ForeColor = theme.TextBright;

        }
        public DataGridView repositoriesGridView;
        private Panel repositoriesControlPanel;
        private Button grantAccessButton;
        private Button revokeAccessButton;
        private Label titleLabel;
        private Panel buttonsPanel;
        private Panel reposButtonsMainPanel;
        private SplitContainer repositoriesButtonsSplitContainer;
        private Button cloneToLocalButton;
        private Button createNewRemoteRepoButton;
        private DataGridViewTextBoxColumn localReposColumn;
        private DataGridViewTextBoxColumn remoteReposColumn;
        private Label activeRepoLabel;
        private Panel activeRepoPanel;
        private Label activeRepositoryTextLabel;
        private Label localRepoButtonsLabel;
        private Label label1;
    }
}
