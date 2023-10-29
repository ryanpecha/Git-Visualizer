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
            remoteReposColumn = new DataGridViewTextBoxColumn();
            remoteRepoContextMenuStrip = new ContextMenuStrip(components);
            makeActiveWorkspaceToolStripMenuItem = new ToolStripMenuItem();
            cloneToLocalRepoToolStripMenuItem = new ToolStripMenuItem();
            activeRepoPanel = new Panel();
            activeRepoHeader = new Label();
            openOnGithubcomToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)repositoriesGridView).BeginInit();
            remoteRepoContextMenuStrip.SuspendLayout();
            activeRepoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // repositoriesGridView
            // 
            repositoriesGridView.AllowUserToDeleteRows = false;
            repositoriesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            repositoriesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            repositoriesGridView.Columns.AddRange(new DataGridViewColumn[] { localReposColumn, remoteReposColumn });
            repositoriesGridView.Dock = DockStyle.Left;
            repositoriesGridView.Location = new Point(0, 0);
            repositoriesGridView.MultiSelect = false;
            repositoriesGridView.Name = "repositoriesGridView";
            repositoriesGridView.ReadOnly = true;
            repositoriesGridView.RowTemplate.Height = 25;
            repositoriesGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            repositoriesGridView.Size = new Size(759, 675);
            repositoriesGridView.TabIndex = 0;
            repositoriesGridView.CellContentClick += repositoriesGridView_CellContentClick;
            // 
            // localReposColumn
            // 
            localReposColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            localReposColumn.HeaderText = "Local Repositories";
            localReposColumn.Name = "localReposColumn";
            localReposColumn.ReadOnly = true;
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
            // activeRepoPanel
            // 
            activeRepoPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            activeRepoPanel.Controls.Add(activeRepoHeader);
            activeRepoPanel.Dock = DockStyle.Right;
            activeRepoPanel.Location = new Point(757, 0);
            activeRepoPanel.Name = "activeRepoPanel";
            activeRepoPanel.Size = new Size(418, 675);
            activeRepoPanel.TabIndex = 1;
            // 
            // activeRepoHeader
            // 
            activeRepoHeader.AutoSize = true;
            activeRepoHeader.Font = new Font("Segoe UI", 32F, FontStyle.Regular, GraphicsUnit.Point);
            activeRepoHeader.Location = new Point(25, 15);
            activeRepoHeader.Name = "activeRepoHeader";
            activeRepoHeader.Size = new Size(354, 59);
            activeRepoHeader.TabIndex = 0;
            activeRepoHeader.Text = "Active Repository";
            // 
            // openOnGithubcomToolStripMenuItem
            // 
            openOnGithubcomToolStripMenuItem.Name = "openOnGithubcomToolStripMenuItem";
            openOnGithubcomToolStripMenuItem.Size = new Size(200, 22);
            openOnGithubcomToolStripMenuItem.Text = "Open on Github.com";
            // 
            // RepositoriesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(activeRepoPanel);
            Controls.Add(repositoriesGridView);
            Name = "RepositoriesControl";
            Size = new Size(1175, 675);
            ((System.ComponentModel.ISupportInitialize)repositoriesGridView).EndInit();
            remoteRepoContextMenuStrip.ResumeLayout(false);
            activeRepoPanel.ResumeLayout(false);
            activeRepoPanel.PerformLayout();
            ResumeLayout(false);
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


        }
        public DataGridView repositoriesGridView;
        private ContextMenuStrip remoteRepoContextMenuStrip;
        private ToolStripMenuItem makeActiveWorkspaceToolStripMenuItem;
        private ToolStripMenuItem cloneToLocalRepoToolStripMenuItem;
        private DataGridViewTextBoxColumn localReposColumn;
        private DataGridViewTextBoxColumn remoteReposColumn;
        private Panel activeRepoPanel;
        private Label activeRepoHeader;
        private ToolStripMenuItem openOnGithubcomToolStripMenuItem;
    }
}
