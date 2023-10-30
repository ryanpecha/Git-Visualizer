namespace GitVisualizer.UI.UI_Forms
{
    partial class BranchesControl
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
        private void ApplyColorTheme(UITheme.AppTheme theme)
        {
            BackColor = theme.AppBackground;
            ForeColor = theme.TextSoft;

            branchesGridView.BackColor = theme.ElementBackground;
            branchesGridView.ForeColor = theme.TextSelectable;

            branchesGridView.BackgroundColor = theme.ElementBackground;
            branchesGridView.ForeColor = theme.TextSelectable;
            branchesGridView.DefaultCellStyle.ForeColor = theme.TextSelectable;
            branchesGridView.DefaultCellStyle.BackColor = theme.ElementBackground;
            branchesGridView.ColumnHeadersDefaultCellStyle.ForeColor = theme.TextSelectable;
            branchesGridView.ColumnHeadersDefaultCellStyle.BackColor = theme.ElementBackground;
            branchesGridView.EnableHeadersVisualStyles = false;

            branchesControlPanel.BackColor = theme.PanelBackground;
            branchesControlPanel.ForeColor = theme.TextBright;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            branchesControlPanel = new Panel();
            titleLabel = new Label();
            branchesGridView = new DataGridView();
            graphColumn = new DataGridViewImageColumn();
            branchColumn = new DataGridViewTextBoxColumn();
            idColumn = new DataGridViewTextBoxColumn();
            userColumn = new DataGridViewTextBoxColumn();
            dateColumn = new DataGridViewTextBoxColumn();
            commentColumn = new DataGridViewTextBoxColumn();
            branchesControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)branchesGridView).BeginInit();
            SuspendLayout();
            // 
            // branchesControlPanel
            // 
            branchesControlPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            branchesControlPanel.BorderStyle = BorderStyle.FixedSingle;
            branchesControlPanel.Controls.Add(titleLabel);
            branchesControlPanel.Dock = DockStyle.Left;
            branchesControlPanel.Location = new Point(0, 0);
            branchesControlPanel.MinimumSize = new Size(280, 280);
            branchesControlPanel.Name = "branchesControlPanel";
            branchesControlPanel.Size = new Size(280, 675);
            branchesControlPanel.TabIndex = 2;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Margin = new Padding(0);
            titleLabel.MinimumSize = new Size(280, 50);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(280, 50);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Branches";
            titleLabel.Click += titleLabel_Click;
            // 
            // branchesGridView
            // 
            branchesGridView.AllowUserToDeleteRows = false;
            branchesGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            branchesGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            branchesGridView.Columns.AddRange(new DataGridViewColumn[] { graphColumn, branchColumn, idColumn, userColumn, dateColumn, commentColumn });
            branchesGridView.Dock = DockStyle.Fill;
            branchesGridView.ImeMode = ImeMode.Off;
            branchesGridView.Location = new Point(280, 0);
            branchesGridView.Margin = new Padding(6);
            branchesGridView.MultiSelect = false;
            branchesGridView.Name = "branchesGridView";
            branchesGridView.ReadOnly = true;
            branchesGridView.RowHeadersVisible = false;
            branchesGridView.RowTemplate.Height = 25;
            branchesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            branchesGridView.ShowEditingIcon = false;
            branchesGridView.Size = new Size(895, 675);
            branchesGridView.TabIndex = 3;
            // 
            // graphColumn
            // 
            graphColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            graphColumn.FillWeight = 50F;
            graphColumn.HeaderText = "Graph";
            graphColumn.Name = "graphColumn";
            graphColumn.ReadOnly = true;
            graphColumn.Resizable = DataGridViewTriState.True;
            graphColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // branchColumn
            // 
            branchColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            branchColumn.HeaderText = "Branch";
            branchColumn.Name = "branchColumn";
            branchColumn.ReadOnly = true;
            branchColumn.Width = 90;
            // 
            // idColumn
            // 
            idColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            idColumn.HeaderText = "ID";
            idColumn.Name = "idColumn";
            idColumn.ReadOnly = true;
            idColumn.Width = 90;
            // 
            // userColumn
            // 
            userColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            userColumn.HeaderText = "User";
            userColumn.Name = "userColumn";
            userColumn.ReadOnly = true;
            userColumn.Width = 90;
            // 
            // dateColumn
            // 
            dateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dateColumn.HeaderText = "Date";
            dateColumn.Name = "dateColumn";
            dateColumn.ReadOnly = true;
            dateColumn.Width = 90;
            // 
            // commentColumn
            // 
            commentColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            commentColumn.HeaderText = "Comment";
            commentColumn.Name = "commentColumn";
            commentColumn.ReadOnly = true;
            // 
            // BranchesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(branchesGridView);
            Controls.Add(branchesControlPanel);
            Name = "BranchesControl";
            Size = new Size(1175, 675);
            branchesControlPanel.ResumeLayout(false);
            branchesControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)branchesGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel branchesControlPanel;
        private Label titleLabel;
        public DataGridView branchesGridView;
        private DataGridViewImageColumn graphColumn;
        private DataGridViewTextBoxColumn branchColumn;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn userColumn;
        private DataGridViewTextBoxColumn dateColumn;
        private DataGridViewTextBoxColumn commentColumn;
    }
}
