namespace GitVisualizer.UI.UI_Forms
{

    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabControl = new TabControl();
            tabPageRepositories = new TabPage();
            button1 = new Button();
            repositoriesGrid = new DataGridView();
            LocalReposColumn = new DataGridViewTextBoxColumn();
            RemoteReposColumn = new DataGridViewTextBoxColumn();
            tabPageBranches = new TabPage();
            tabPageMerging = new TabPage();
            tabPageFiles = new TabPage();
            githubBindingSource = new BindingSource(components);
            tabControl.SuspendLayout();
            tabPageRepositories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)repositoriesGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)githubBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageRepositories);
            tabControl.Controls.Add(tabPageBranches);
            tabControl.Controls.Add(tabPageMerging);
            tabControl.Controls.Add(tabPageFiles);
            tabControl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl.Location = new Point(-4, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1193, 725);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 0;
            // 
            // tabPageRepositories
            // 
            tabPageRepositories.BackColor = SystemColors.ControlDark;
            tabPageRepositories.Controls.Add(button1);
            tabPageRepositories.Controls.Add(repositoriesGrid);
            tabPageRepositories.Location = new Point(4, 30);
            tabPageRepositories.Name = "tabPageRepositories";
            tabPageRepositories.Padding = new Padding(3);
            tabPageRepositories.Size = new Size(1185, 691);
            tabPageRepositories.TabIndex = 0;
            tabPageRepositories.Text = "Repositories";
            tabPageRepositories.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(613, 26);
            button1.Name = "button1";
            button1.Size = new Size(171, 65);
            button1.TabIndex = 2;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // repositoriesGrid
            // 
            repositoriesGrid.AllowUserToAddRows = false;
            repositoriesGrid.AllowUserToDeleteRows = false;
            repositoriesGrid.AllowUserToOrderColumns = true;
            repositoriesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            repositoriesGrid.Columns.AddRange(new DataGridViewColumn[] { LocalReposColumn, RemoteReposColumn });
            repositoriesGrid.Location = new Point(12, 15);
            repositoriesGrid.Name = "repositoriesGrid";
            repositoriesGrid.ReadOnly = true;
            repositoriesGrid.RowTemplate.Height = 25;
            repositoriesGrid.Size = new Size(564, 596);
            repositoriesGrid.TabIndex = 1;
            repositoriesGrid.CellContentClick += dataGridView1_CellContentClick;
            // 
            // LocalReposColumn
            // 
            LocalReposColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            LocalReposColumn.HeaderText = "Local Repositories";
            LocalReposColumn.Name = "LocalReposColumn";
            LocalReposColumn.ReadOnly = true;
            // 
            // RemoteReposColumn
            // 
            RemoteReposColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RemoteReposColumn.HeaderText = "Remote Repositories";
            RemoteReposColumn.Name = "RemoteReposColumn";
            RemoteReposColumn.ReadOnly = true;
            // 
            // tabPageBranches
            // 
            tabPageBranches.Location = new Point(4, 30);
            tabPageBranches.Name = "tabPageBranches";
            tabPageBranches.Padding = new Padding(3);
            tabPageBranches.Size = new Size(1185, 691);
            tabPageBranches.TabIndex = 1;
            tabPageBranches.Text = "Branches";
            tabPageBranches.UseVisualStyleBackColor = true;
            // 
            // tabPageMerging
            // 
            tabPageMerging.Location = new Point(4, 30);
            tabPageMerging.Name = "tabPageMerging";
            tabPageMerging.Size = new Size(1185, 691);
            tabPageMerging.TabIndex = 2;
            tabPageMerging.Text = "Merging";
            tabPageMerging.UseVisualStyleBackColor = true;
            // 
            // tabPageFiles
            // 
            tabPageFiles.Location = new Point(4, 30);
            tabPageFiles.Name = "tabPageFiles";
            tabPageFiles.Size = new Size(1185, 691);
            tabPageFiles.TabIndex = 3;
            tabPageFiles.Text = "Files";
            tabPageFiles.UseVisualStyleBackColor = true;
            // 
            // githubBindingSource
            // 
            githubBindingSource.DataSource = typeof(Github);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 721);
            Controls.Add(tabControl);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GitHelper";
            tabControl.ResumeLayout(false);
            tabPageRepositories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)repositoriesGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)githubBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private void ApplyColorTheme(UITheme.AppTheme theme)
        {
            BackColor = theme.AppBackground;
            ForeColor = theme.TextSoft;

            tabControl.BackColor = theme.ElementBackground;
            tabControl.ForeColor = theme.TextHeader;
            /// Apply themes to all tab pages
            TabControl.TabPageCollection tabpages = tabControl.TabPages;
            foreach (TabPage page in tabpages)
            {
                page.ForeColor = theme.TextSelectable;
                page.BackColor = theme.AppBackground;
            }
        }
        private TabPage tabPageBranches;
        private TabPage tabPageMerging;
        private TabPage tabPageFiles;
        private DataGridViewTextBoxColumn LocalReposColumn;
        private DataGridViewTextBoxColumn RemoteReposColumn;
        public TabControl tabControl;
        public TabPage tabPageRepositories;
        private DataGridView repositoriesGrid;
        private BindingSource githubBindingSource;
        private Button button1;
    }
}