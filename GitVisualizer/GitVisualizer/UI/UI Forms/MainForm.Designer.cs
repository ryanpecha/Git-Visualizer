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
            githubBindingSource = new BindingSource(components);
            repositoriesPageButton = new Button();
            branchesPageButton = new Button();
            mergingPageButton = new Button();
            mainPanel = new Panel();
            undoButton = new Button();
            fetchButton = new Button();
            pullButton = new Button();
            pushButton = new Button();
            ((System.ComponentModel.ISupportInitialize)githubBindingSource).BeginInit();
            SuspendLayout();
            // 
            // githubBindingSource
            // 
            githubBindingSource.DataSource = typeof(Github);
            // 
            // repositoriesPageButton
            // 
            repositoriesPageButton.FlatStyle = FlatStyle.Flat;
            repositoriesPageButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            repositoriesPageButton.Location = new Point(6, 6);
            repositoriesPageButton.Name = "repositoriesPageButton";
            repositoriesPageButton.Size = new Size(156, 32);
            repositoriesPageButton.TabIndex = 0;
            repositoriesPageButton.Text = "Repositories";
            repositoriesPageButton.UseVisualStyleBackColor = true;
            repositoriesPageButton.Click += OnRepositoriesButtonPress;
            // 
            // branchesPageButton
            // 
            branchesPageButton.FlatStyle = FlatStyle.Flat;
            branchesPageButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            branchesPageButton.Location = new Point(168, 6);
            branchesPageButton.Name = "branchesPageButton";
            branchesPageButton.Size = new Size(156, 32);
            branchesPageButton.TabIndex = 1;
            branchesPageButton.Text = "Branches";
            branchesPageButton.UseVisualStyleBackColor = true;
            branchesPageButton.Click += OnBranchesButtonPress;
            // 
            // mergingPageButton
            // 
            mergingPageButton.FlatStyle = FlatStyle.Flat;
            mergingPageButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mergingPageButton.Location = new Point(330, 6);
            mergingPageButton.Name = "mergingPageButton";
            mergingPageButton.Size = new Size(156, 32);
            mergingPageButton.TabIndex = 2;
            mergingPageButton.Text = "Merging";
            mergingPageButton.UseVisualStyleBackColor = true;
            mergingPageButton.Click += OnMergingButtonPress;
            // 
            // mainPanel
            // 
            mainPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainPanel.Location = new Point(0, 42);
            mainPanel.Margin = new Padding(6, 42, 6, 6);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(6);
            mainPanel.Size = new Size(1001, 579);
            mainPanel.TabIndex = 3;
            // 
            // undoButton
            // 
            undoButton.FlatStyle = FlatStyle.Flat;
            undoButton.Location = new Point(897, 10);
            undoButton.Margin = new Padding(1);
            undoButton.Name = "undoButton";
            undoButton.Size = new Size(79, 28);
            undoButton.TabIndex = 7;
            undoButton.Text = "Undo Change";
            undoButton.UseVisualStyleBackColor = true;
            // 
            // fetchButton
            // 
            fetchButton.FlatStyle = FlatStyle.Flat;
            fetchButton.Location = new Point(815, 10);
            fetchButton.Margin = new Padding(1);
            fetchButton.Name = "fetchButton";
            fetchButton.Size = new Size(79, 28);
            fetchButton.TabIndex = 6;
            fetchButton.Text = "Fetch";
            fetchButton.UseVisualStyleBackColor = true;
            // 
            // pullButton
            // 
            pullButton.FlatStyle = FlatStyle.Flat;
            pullButton.Location = new Point(733, 10);
            pullButton.Margin = new Padding(1);
            pullButton.Name = "pullButton";
            pullButton.Size = new Size(79, 28);
            pullButton.TabIndex = 5;
            pullButton.Text = "Pull";
            pullButton.UseVisualStyleBackColor = true;
            // 
            // pushButton
            // 
            pushButton.FlatStyle = FlatStyle.Flat;
            pushButton.Location = new Point(652, 10);
            pushButton.Margin = new Padding(1);
            pushButton.Name = "pushButton";
            pushButton.Size = new Size(79, 28);
            pushButton.TabIndex = 4;
            pushButton.Text = "Push";
            pushButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 621);
            Controls.Add(undoButton);
            Controls.Add(fetchButton);
            Controls.Add(pullButton);
            Controls.Add(pushButton);
            Controls.Add(mainPanel);
            Controls.Add(mergingPageButton);
            Controls.Add(branchesPageButton);
            Controls.Add(repositoriesPageButton);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GitHelper";
            Load += MainFormLoad;
            ((System.ComponentModel.ISupportInitialize)githubBindingSource).EndInit();
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
        private BindingSource githubBindingSource;
        private Button repositoriesPageButton;
        private Button branchesPageButton;
        private Button mergingPageButton;
        private Panel mainPanel;
        private Button undoButton;
        private Button fetchButton;
        private Button pullButton;
        private Button pushButton;
    }
}