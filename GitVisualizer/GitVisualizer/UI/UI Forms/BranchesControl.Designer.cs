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

            branchesGridView.DefaultCellStyle.SelectionBackColor = theme.ElementSelected;
            branchesGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = branchesGridView.DefaultCellStyle.BackColor;


            activeRepoLabel.ForeColor = theme.TextNormal;
            branchCheckoutLabel.ForeColor = theme.TextNormal;
            checkedOutBranchLabel.ForeColor = theme.TextNormal;


            commitCommandPanel.BackColor = theme.ElementBackground;
            commitCommandPanel.ForeColor = theme.TextSelectable;

            selectedCommitTextLabel.ForeColor = theme.TextNormal;

            branchesControlPanel.BackColor = theme.PanelBackground;
            branchesControlPanel.ForeColor = theme.TextBright;


            activeRepositoryTextLabel.ForeColor = theme.TextSoft;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            checkoutBranchButton = new Button();
            deleteBranchButton = new Button();
            branchesControlPanel = new Panel();
            checkedOutBranchPanel = new Panel();
            checkedOutBranchTextLabel = new Label();
            checkedOutBranchLabel = new Label();
            commonBranchesButtonsPanel = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            branchCheckoutLabel = new Label();
            branchComboBox = new ComboBox();
            activeRepoPanel = new Panel();
            activeRepositoryTextLabel = new Label();
            activeRepoLabel = new Label();
            titleLabel = new Label();
            branchesGridView = new DataGridView();
            graphColumn = new DataGridViewImageColumn();
            branchColumn = new DataGridViewTextBoxColumn();
            idColumn = new DataGridViewTextBoxColumn();
            userColumn = new DataGridViewTextBoxColumn();
            dateColumn = new DataGridViewTextBoxColumn();
            commentColumn = new DataGridViewTextBoxColumn();
            commitCommandPanel = new Panel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            selectedCommitTextLabel = new Label();
            checkoutCommitButton = new Button();
            newBranchFromCommitTextBox = new TextBox();
            createBranchFromCurrentButton = new Button();
            createBranchFromSelectedButton = new Button();
            branchesTooltip = new ToolTip(components);
            branchesControlPanel.SuspendLayout();
            checkedOutBranchPanel.SuspendLayout();
            commonBranchesButtonsPanel.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            activeRepoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)branchesGridView).BeginInit();
            commitCommandPanel.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // checkoutBranchButton
            // 
            checkoutBranchButton.Dock = DockStyle.Top;
            checkoutBranchButton.FlatStyle = FlatStyle.Flat;
            checkoutBranchButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkoutBranchButton.Location = new Point(7, 57);
            checkoutBranchButton.Name = "checkoutBranchButton";
            checkoutBranchButton.Size = new Size(240, 38);
            checkoutBranchButton.TabIndex = 7;
            checkoutBranchButton.Text = "Checkout To Branch";
            checkoutBranchButton.UseVisualStyleBackColor = true;
            checkoutBranchButton.Click += OnCheckoutToBranchButton;
            // 
            // deleteBranchButton
            // 
            deleteBranchButton.Dock = DockStyle.Top;
            deleteBranchButton.FlatStyle = FlatStyle.Flat;
            deleteBranchButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            deleteBranchButton.Location = new Point(7, 101);
            deleteBranchButton.Name = "deleteBranchButton";
            deleteBranchButton.Size = new Size(240, 38);
            deleteBranchButton.TabIndex = 11;
            deleteBranchButton.Text = "Delete Branch";
            deleteBranchButton.UseVisualStyleBackColor = true;
            // 
            // branchesControlPanel
            // 
            branchesControlPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            branchesControlPanel.BorderStyle = BorderStyle.FixedSingle;
            branchesControlPanel.Controls.Add(checkedOutBranchPanel);
            branchesControlPanel.Controls.Add(commonBranchesButtonsPanel);
            branchesControlPanel.Controls.Add(activeRepoPanel);
            branchesControlPanel.Controls.Add(titleLabel);
            branchesControlPanel.Dock = DockStyle.Left;
            branchesControlPanel.Location = new Point(0, 0);
            branchesControlPanel.MinimumSize = new Size(280, 280);
            branchesControlPanel.Name = "branchesControlPanel";
            branchesControlPanel.Size = new Size(280, 675);
            branchesControlPanel.TabIndex = 2;
            // 
            // checkedOutBranchPanel
            // 
            checkedOutBranchPanel.Controls.Add(checkedOutBranchTextLabel);
            checkedOutBranchPanel.Controls.Add(checkedOutBranchLabel);
            checkedOutBranchPanel.Dock = DockStyle.Top;
            checkedOutBranchPanel.Location = new Point(0, 161);
            checkedOutBranchPanel.Name = "checkedOutBranchPanel";
            checkedOutBranchPanel.Size = new Size(278, 107);
            checkedOutBranchPanel.TabIndex = 9;
            // 
            // checkedOutBranchTextLabel
            // 
            checkedOutBranchTextLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            checkedOutBranchTextLabel.Location = new Point(3, 21);
            checkedOutBranchTextLabel.Name = "checkedOutBranchTextLabel";
            checkedOutBranchTextLabel.Padding = new Padding(12, 0, 0, 0);
            checkedOutBranchTextLabel.Size = new Size(267, 77);
            checkedOutBranchTextLabel.TabIndex = 4;
            // 
            // checkedOutBranchLabel
            // 
            checkedOutBranchLabel.AutoSize = true;
            checkedOutBranchLabel.Dock = DockStyle.Top;
            checkedOutBranchLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkedOutBranchLabel.Location = new Point(0, 0);
            checkedOutBranchLabel.Name = "checkedOutBranchLabel";
            checkedOutBranchLabel.Padding = new Padding(12, 0, 0, 0);
            checkedOutBranchLabel.Size = new Size(184, 21);
            checkedOutBranchLabel.TabIndex = 3;
            checkedOutBranchLabel.Text = "Checked Out to Branch:";
            checkedOutBranchLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // commonBranchesButtonsPanel
            // 
            commonBranchesButtonsPanel.Controls.Add(flowLayoutPanel2);
            commonBranchesButtonsPanel.Dock = DockStyle.Bottom;
            commonBranchesButtonsPanel.Location = new Point(0, 500);
            commonBranchesButtonsPanel.Name = "commonBranchesButtonsPanel";
            commonBranchesButtonsPanel.Padding = new Padding(8);
            commonBranchesButtonsPanel.Size = new Size(278, 173);
            commonBranchesButtonsPanel.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(branchCheckoutLabel);
            flowLayoutPanel2.Controls.Add(branchComboBox);
            flowLayoutPanel2.Controls.Add(checkoutBranchButton);
            flowLayoutPanel2.Controls.Add(deleteBranchButton);
            flowLayoutPanel2.Location = new Point(10, 12);
            flowLayoutPanel2.Margin = new Padding(4);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Padding = new Padding(4);
            flowLayoutPanel2.Size = new Size(256, 150);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // branchCheckoutLabel
            // 
            branchCheckoutLabel.AutoSize = true;
            branchCheckoutLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            branchCheckoutLabel.Location = new Point(7, 4);
            branchCheckoutLabel.Name = "branchCheckoutLabel";
            branchCheckoutLabel.Size = new Size(127, 21);
            branchCheckoutLabel.TabIndex = 12;
            branchCheckoutLabel.Text = "Branch Checkout";
            // 
            // branchComboBox
            // 
            branchComboBox.Dock = DockStyle.Top;
            branchComboBox.FormattingEnabled = true;
            branchComboBox.Location = new Point(7, 28);
            branchComboBox.Name = "branchComboBox";
            branchComboBox.Size = new Size(240, 23);
            branchComboBox.TabIndex = 10;
            branchComboBox.Text = "Branches";
            // 
            // activeRepoPanel
            // 
            activeRepoPanel.Controls.Add(activeRepositoryTextLabel);
            activeRepoPanel.Controls.Add(activeRepoLabel);
            activeRepoPanel.Dock = DockStyle.Top;
            activeRepoPanel.Location = new Point(0, 54);
            activeRepoPanel.Name = "activeRepoPanel";
            activeRepoPanel.Size = new Size(278, 107);
            activeRepoPanel.TabIndex = 5;
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
            branchesTooltip.SetToolTip(activeRepositoryTextLabel, "Your current working repository");
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
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Margin = new Padding(0);
            titleLabel.MinimumSize = new Size(280, 54);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(280, 54);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Branches";
            // 
            // branchesGridView
            // 
            branchesGridView.AllowUserToAddRows = false;
            branchesGridView.AllowUserToDeleteRows = false;
            branchesGridView.AllowUserToResizeRows = false;
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
            branchesGridView.Size = new Size(895, 521);
            branchesGridView.TabIndex = 3;
            branchesGridView.CellClick += branchesGridView_CellContentClick;
            branchesGridView.CellPainting += BranchesGridViewDrawCell;
            // 
            // graphColumn
            // 
            graphColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            graphColumn.FillWeight = 50F;
            graphColumn.HeaderText = "Graph";
            graphColumn.Name = "graphColumn";
            graphColumn.ReadOnly = true;
            graphColumn.Resizable = DataGridViewTriState.True;
            // 
            // branchColumn
            // 
            branchColumn.FillWeight = 25F;
            branchColumn.HeaderText = "Branch";
            branchColumn.Name = "branchColumn";
            branchColumn.ReadOnly = true;
            branchColumn.Resizable = DataGridViewTriState.True;
            branchColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // idColumn
            // 
            idColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            idColumn.HeaderText = "ID";
            idColumn.Name = "idColumn";
            idColumn.ReadOnly = true;
            idColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            idColumn.Width = 90;
            // 
            // userColumn
            // 
            userColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            userColumn.HeaderText = "User";
            userColumn.Name = "userColumn";
            userColumn.ReadOnly = true;
            userColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            userColumn.Width = 90;
            // 
            // dateColumn
            // 
            dateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dateColumn.HeaderText = "Date";
            dateColumn.Name = "dateColumn";
            dateColumn.ReadOnly = true;
            dateColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dateColumn.Width = 90;
            // 
            // commentColumn
            // 
            commentColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            commentColumn.HeaderText = "Comment";
            commentColumn.Name = "commentColumn";
            commentColumn.ReadOnly = true;
            commentColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // commitCommandPanel
            // 
            commitCommandPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            commitCommandPanel.Controls.Add(flowLayoutPanel3);
            commitCommandPanel.Dock = DockStyle.Bottom;
            commitCommandPanel.Location = new Point(280, 521);
            commitCommandPanel.Name = "commitCommandPanel";
            commitCommandPanel.Size = new Size(895, 154);
            commitCommandPanel.TabIndex = 6;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(selectedCommitTextLabel);
            flowLayoutPanel3.Controls.Add(checkoutCommitButton);
            flowLayoutPanel3.Controls.Add(newBranchFromCommitTextBox);
            flowLayoutPanel3.Controls.Add(createBranchFromCurrentButton);
            flowLayoutPanel3.Controls.Add(createBranchFromSelectedButton);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(0, 0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Padding = new Padding(8);
            flowLayoutPanel3.Size = new Size(895, 154);
            flowLayoutPanel3.TabIndex = 10;
            // 
            // selectedCommitTextLabel
            // 
            selectedCommitTextLabel.AutoSize = true;
            flowLayoutPanel3.SetFlowBreak(selectedCommitTextLabel, true);
            selectedCommitTextLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            selectedCommitTextLabel.Location = new Point(11, 8);
            selectedCommitTextLabel.Name = "selectedCommitTextLabel";
            selectedCommitTextLabel.Size = new Size(131, 21);
            selectedCommitTextLabel.TabIndex = 5;
            selectedCommitTextLabel.Text = "Selected Commit:";
            // 
            // checkoutCommitButton
            // 
            checkoutCommitButton.FlatStyle = FlatStyle.Flat;
            flowLayoutPanel3.SetFlowBreak(checkoutCommitButton, true);
            checkoutCommitButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            checkoutCommitButton.Location = new Point(11, 45);
            checkoutCommitButton.Name = "checkoutCommitButton";
            checkoutCommitButton.Size = new Size(200, 28);
            checkoutCommitButton.TabIndex = 7;
            checkoutCommitButton.Text = "Checkout to Selected Commit";
            checkoutCommitButton.UseVisualStyleBackColor = true;
            checkoutCommitButton.Visible = false;
            checkoutCommitButton.Click += OnCheckoutToSelectedCommitButton;
            // 
            // newBranchFromCommitTextBox
            // 
            flowLayoutPanel3.SetFlowBreak(newBranchFromCommitTextBox, true);
            newBranchFromCommitTextBox.Location = new Point(11, 79);
            newBranchFromCommitTextBox.Name = "newBranchFromCommitTextBox";
            newBranchFromCommitTextBox.PlaceholderText = "Enter name for new branch...";
            newBranchFromCommitTextBox.Size = new Size(200, 23);
            newBranchFromCommitTextBox.TabIndex = 14;
            newBranchFromCommitTextBox.Visible = false;
            // 
            // createBranchFromCurrentButton
            // 
            createBranchFromCurrentButton.FlatStyle = FlatStyle.Flat;
            createBranchFromCurrentButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            createBranchFromCurrentButton.Location = new Point(11, 113);
            createBranchFromCurrentButton.Name = "createBranchFromCurrentButton";
            createBranchFromCurrentButton.Size = new Size(250, 28);
            createBranchFromCurrentButton.TabIndex = 16;
            createBranchFromCurrentButton.Text = "Create Branch From Current Commit";
            createBranchFromCurrentButton.UseVisualStyleBackColor = true;
            createBranchFromCurrentButton.Visible = false;
            createBranchFromCurrentButton.Click += OnCreateBranchFromCurrentButton;
            // 
            // createBranchFromSelectedButton
            // 
            createBranchFromSelectedButton.FlatStyle = FlatStyle.Flat;
            createBranchFromSelectedButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            createBranchFromSelectedButton.Location = new Point(267, 113);
            createBranchFromSelectedButton.Name = "createBranchFromSelectedButton";
            createBranchFromSelectedButton.Size = new Size(200, 28);
            createBranchFromSelectedButton.TabIndex = 17;
            createBranchFromSelectedButton.Text = "Create Branch From Selected";
            createBranchFromSelectedButton.UseVisualStyleBackColor = true;
            createBranchFromSelectedButton.Visible = false;
            createBranchFromSelectedButton.Click += OnCreateBranchFromSelectedButton;
            // 
            // BranchesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(branchesGridView);
            Controls.Add(commitCommandPanel);
            Controls.Add(branchesControlPanel);
            Name = "BranchesControl";
            Size = new Size(1175, 675);
            branchesControlPanel.ResumeLayout(false);
            checkedOutBranchPanel.ResumeLayout(false);
            checkedOutBranchPanel.PerformLayout();
            commonBranchesButtonsPanel.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            activeRepoPanel.ResumeLayout(false);
            activeRepoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)branchesGridView).EndInit();
            commitCommandPanel.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel branchesControlPanel;
        private Label titleLabel;
        public DataGridView branchesGridView;
        private Panel activeRepoPanel;
        private Label activeRepositoryTextLabel;
        private Label activeRepoLabel;
        private Panel commonBranchesButtonsPanel;
        private Panel checkedOutBranchPanel;
        private Label checkedOutBranchTextLabel;
        private Label checkedOutBranchLabel;
        private Button checkoutBranchButton;
        private ComboBox branchComboBox;
        private Panel commitCommandPanel;
        private DataGridViewImageColumn graphColumn;
        private DataGridViewTextBoxColumn branchColumn;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn userColumn;
        private DataGridViewTextBoxColumn dateColumn;
        private DataGridViewTextBoxColumn commentColumn;
        private Button deleteBranchButton;
        private ToolTip branchesTooltip;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label branchCheckoutLabel;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label selectedCommitTextLabel;
        private Button checkoutCommitButton;
        private TextBox newBranchFromCommitTextBox;
        private Button createBranchFromCurrentButton;
        private Button createBranchFromSelectedButton;
    }
}
