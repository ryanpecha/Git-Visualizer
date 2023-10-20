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
            ((System.ComponentModel.ISupportInitialize)repositoriesGridView).BeginInit();
            SuspendLayout();
            // 
            // repositoriesGridView
            // 
            repositoriesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            repositoriesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            repositoriesGridView.Columns.AddRange(new DataGridViewColumn[] { localReposColumn, remoteReposColumn });
            repositoriesGridView.Dock = DockStyle.Left;
            repositoriesGridView.Location = new Point(0, 0);
            repositoriesGridView.Name = "repositoriesGridView";
            repositoriesGridView.RowTemplate.Height = 25;
            repositoriesGridView.Size = new Size(453, 675);
            repositoriesGridView.TabIndex = 0;
            // 
            // localReposColumn
            // 
            localReposColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            localReposColumn.HeaderText = "Local Repositories";
            localReposColumn.Name = "localReposColumn";
            // 
            // remoteReposColumn
            // 
            remoteReposColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            remoteReposColumn.HeaderText = "Remote Repositories";
            remoteReposColumn.Name = "remoteReposColumn";
            // 
            // RepositoriesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(repositoriesGridView);
            Name = "RepositoriesControl";
            Size = new Size(1175, 675);
            ((System.ComponentModel.ISupportInitialize)repositoriesGridView).EndInit();
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
        }

        private DataGridView repositoriesGridView;
        private DataGridViewTextBoxColumn localReposColumn;
        private DataGridViewTextBoxColumn remoteReposColumn;
    }
}
