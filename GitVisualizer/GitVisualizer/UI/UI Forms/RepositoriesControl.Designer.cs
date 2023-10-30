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
            components = new System.ComponentModel.Container();
            repositoriesGridView = new DataGridView();
            localReposColumn = new DataGridViewTextBoxColumn();
            localRepoContextMenuStrip = new ContextMenuStrip(components);
            trackDirectoryToolStripMenuItem = new ToolStripMenuItem();
            trackDirectoryRecursiveToolStripMenuItem = new ToolStripMenuItem();
            remoteReposColumn = new DataGridViewTextBoxColumn();
            remoteRepoContextMenuStrip = new ContextMenuStrip(components);
            makeActiveWorkspaceToolStripMenuItem = new ToolStripMenuItem();
            cloneToLocalRepoToolStripMenuItem = new ToolStripMenuItem();
            openOnGithubcomToolStripMenuItem = new ToolStripMenuItem();
            repositoriesControlPanel = new Panel();
            buttonsPanel = new Panel();
            revokeAccessButton = new Button();
            grantAccessButton = new Button();
            titleLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)repositoriesGridView).BeginInit();
            localRepoContextMenuStrip.SuspendLayout();
            remoteRepoContextMenuStrip.SuspendLayout();
            repositoriesControlPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // repositoriesGridView
            // 
            repositoriesGridView.AllowUserToDeleteRows = false;
            repositoriesGridView.AllowUserToOrderColumns = true;
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
            repositoriesGridView.RowTemplate.Height = 25;
            repositoriesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            repositoriesGridView.ShowEditingIcon = false;
            repositoriesGridView.Size = new Size(895, 675);
            repositoriesGridView.TabIndex = 0;
            repositoriesGridView.CellContentClick += repositoriesGridView_CellContentClick;
            // 
            // localReposColumn
            // 
            localReposColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            localReposColumn.ContextMenuStrip = localRepoContextMenuStrip;
            localReposColumn.HeaderText = "Local Repositories";
            localReposColumn.Name = "localReposColumn";
            localReposColumn.ReadOnly = true;
            localReposColumn.ToolTipText = "Repository Folders stored locally on your device, which hold the files you modify directly on your computer.";
            // 
            // localRepoContextMenuStrip
            // 
            localRepoContextMenuStrip.Items.AddRange(new ToolStripItem[] { trackDirectoryToolStripMenuItem, trackDirectoryRecursiveToolStripMenuItem });
            localRepoContextMenuStrip.Name = "localRepoContextMenuStrip";
            localRepoContextMenuStrip.Size = new Size(214, 48);
            // 
            // trackDirectoryToolStripMenuItem
            // 
            trackDirectoryToolStripMenuItem.Name = "trackDirectoryToolStripMenuItem";
            trackDirectoryToolStripMenuItem.Size = new Size(213, 22);
            trackDirectoryToolStripMenuItem.Text = "Track Directory";
            trackDirectoryToolStripMenuItem.Click += TrackDirectory;
            // 
            // trackDirectoryRecursiveToolStripMenuItem
            // 
            trackDirectoryRecursiveToolStripMenuItem.Name = "trackDirectoryRecursiveToolStripMenuItem";
            trackDirectoryRecursiveToolStripMenuItem.Size = new Size(213, 22);
            trackDirectoryRecursiveToolStripMenuItem.Text = "Track Directory (Recursive)";
            trackDirectoryRecursiveToolStripMenuItem.Click += TrackDirectoryRecursive;
            // 
            // remoteReposColumn
            // 
            remoteReposColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            remoteReposColumn.ContextMenuStrip = remoteRepoContextMenuStrip;
            remoteReposColumn.HeaderText = "Remote Repositories";
            remoteReposColumn.Name = "remoteReposColumn";
            remoteReposColumn.ReadOnly = true;
            remoteReposColumn.Resizable = DataGridViewTriState.True;
            // 
            // remoteRepoContextMenuStrip
            // 
            remoteRepoContextMenuStrip.Items.AddRange(new ToolStripItem[] { makeActiveWorkspaceToolStripMenuItem, cloneToLocalRepoToolStripMenuItem, openOnGithubcomToolStripMenuItem });
            remoteRepoContextMenuStrip.Name = "contextMenuStrip1";
            remoteRepoContextMenuStrip.Size = new Size(201, 70);
            remoteRepoContextMenuStrip.Text = "Remote Actions";
            // 
            // makeActiveWorkspaceToolStripMenuItem
            // 
            makeActiveWorkspaceToolStripMenuItem.Name = "makeActiveWorkspaceToolStripMenuItem";
            makeActiveWorkspaceToolStripMenuItem.Size = new Size(200, 22);
            makeActiveWorkspaceToolStripMenuItem.Text = "Make Active Workspace";
            // 
            // cloneToLocalRepoToolStripMenuItem
            // 
            cloneToLocalRepoToolStripMenuItem.Name = "cloneToLocalRepoToolStripMenuItem";
            cloneToLocalRepoToolStripMenuItem.Size = new Size(200, 22);
            cloneToLocalRepoToolStripMenuItem.Text = "Clone to Local Repo";
            // 
            // openOnGithubcomToolStripMenuItem
            // 
            openOnGithubcomToolStripMenuItem.Name = "openOnGithubcomToolStripMenuItem";
            openOnGithubcomToolStripMenuItem.Size = new Size(200, 22);
            openOnGithubcomToolStripMenuItem.Text = "Open on Github.com";
            // 
            // repositoriesControlPanel
            // 
            repositoriesControlPanel.AutoSize = true;
            repositoriesControlPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            repositoriesControlPanel.BorderStyle = BorderStyle.FixedSingle;
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
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(195, 45);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Repositories";
            // 
            // RepositoriesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(repositoriesGridView);
            Controls.Add(repositoriesControlPanel);
            Name = "RepositoriesControl";
            Size = new Size(1175, 675);
            ((System.ComponentModel.ISupportInitialize)repositoriesGridView).EndInit();
            localRepoContextMenuStrip.ResumeLayout(false);
            remoteRepoContextMenuStrip.ResumeLayout(false);
            repositoriesControlPanel.ResumeLayout(false);
            repositoriesControlPanel.PerformLayout();
            buttonsPanel.ResumeLayout(false);
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
        private ContextMenuStrip remoteRepoContextMenuStrip;
        private ToolStripMenuItem makeActiveWorkspaceToolStripMenuItem;
        private ToolStripMenuItem cloneToLocalRepoToolStripMenuItem;
        private ToolStripMenuItem openOnGithubcomToolStripMenuItem;
        private Panel repositoriesControlPanel;
        private Button grantAccessButton;
        private Button revokeAccessButton;
        private Label titleLabel;
        private Panel buttonsPanel;
        private ContextMenuStrip localRepoContextMenuStrip;
        private ToolStripMenuItem trackDirectoryToolStripMenuItem;
        private ToolStripMenuItem trackDirectoryRecursiveToolStripMenuItem;
        private DataGridViewTextBoxColumn localReposColumn;
        private DataGridViewTextBoxColumn remoteReposColumn;
    }
}
