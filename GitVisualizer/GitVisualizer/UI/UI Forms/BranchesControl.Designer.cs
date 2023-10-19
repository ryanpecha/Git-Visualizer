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

        
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "main", "" }, -1);
            ListViewItem listViewItem2 = new ListViewItem("main");
            ListViewItem listViewItem3 = new ListViewItem("development");
            branchesListView = new ListView();
            branchColumn = new ColumnHeader();
            userColumn = new ColumnHeader();
            commentColumn = new ColumnHeader();
            dateColumn = new ColumnHeader();
            branchGraphColumn = new ColumnHeader();
            SuspendLayout();
            // 
            // branchesListView
            // 
            branchesListView.BorderStyle = BorderStyle.FixedSingle;
            branchesListView.Columns.AddRange(new ColumnHeader[] { branchGraphColumn, branchColumn, userColumn, commentColumn, dateColumn });
            branchesListView.Dock = DockStyle.Fill;
            branchesListView.GridLines = true;
            branchesListView.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3 });
            branchesListView.Location = new Point(0, 0);
            branchesListView.Name = "branchesListView";
            branchesListView.Size = new Size(1175, 675);
            branchesListView.TabIndex = 0;
            branchesListView.UseCompatibleStateImageBehavior = false;
            branchesListView.View = View.Details;
            branchesListView.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // branchColumn
            // 
            branchColumn.Text = "Branch";
            branchColumn.Width = 90;
            // 
            // userColumn
            // 
            userColumn.Text = "User";
            userColumn.Width = 90;
            // 
            // commentColumn
            // 
            commentColumn.Text = "Comment";
            commentColumn.Width = 360;
            // 
            // dateColumn
            // 
            dateColumn.Text = "Date";
            dateColumn.Width = 90;
            // 
            // branchGraphColumn
            // 
            branchGraphColumn.Text = "Local Root";
            branchGraphColumn.Width = 120;
            // 
            // BranchesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(branchesListView);
            Name = "BranchesControl";
            Size = new Size(1175, 675);
            ResumeLayout(false);
        }

        #endregion

        private ListView branchesListView;
        private ColumnHeader branchColumn;
        private ColumnHeader userColumn;
        private ColumnHeader commentColumn;
        private ColumnHeader dateColumn;
        private ColumnHeader branchGraphColumn;
    }
}
