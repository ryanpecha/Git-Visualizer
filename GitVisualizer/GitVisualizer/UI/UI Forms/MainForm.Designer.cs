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
            gitButtonsPanel = new Panel();
            pageButtonsPanel = new Panel();
            buttonsMenuPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)githubBindingSource).BeginInit();
            gitButtonsPanel.SuspendLayout();
            pageButtonsPanel.SuspendLayout();
            buttonsMenuPanel.SuspendLayout();
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
            repositoriesPageButton.Location = new Point(12, 7);
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
            branchesPageButton.Location = new Point(174, 7);
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
            mergingPageButton.Location = new Point(336, 7);
            mergingPageButton.Name = "mergingPageButton";
            mergingPageButton.Size = new Size(156, 32);
            mergingPageButton.TabIndex = 2;
            mergingPageButton.Text = "Merging";
            mergingPageButton.UseVisualStyleBackColor = true;
            mergingPageButton.Click += OnMergingButtonPress;
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 47);
            mainPanel.Margin = new Padding(6, 42, 6, 6);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(6);
            mainPanel.Size = new Size(1001, 574);
            mainPanel.TabIndex = 3;
            // 
            // undoButton
            // 
            undoButton.FlatStyle = FlatStyle.Flat;
            undoButton.Location = new Point(257, 7);
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
            fetchButton.Location = new Point(175, 7);
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
            pullButton.Location = new Point(93, 7);
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
            pushButton.Location = new Point(12, 7);
            pushButton.Margin = new Padding(1);
            pushButton.Name = "pushButton";
            pushButton.Size = new Size(79, 28);
            pushButton.TabIndex = 4;
            pushButton.Text = "Push";
            pushButton.UseVisualStyleBackColor = true;
            // 
            // gitButtonsPanel
            // 
            gitButtonsPanel.Controls.Add(undoButton);
            gitButtonsPanel.Controls.Add(fetchButton);
            gitButtonsPanel.Controls.Add(pullButton);
            gitButtonsPanel.Controls.Add(pushButton);
            gitButtonsPanel.Dock = DockStyle.Right;
            gitButtonsPanel.Location = new Point(662, 0);
            gitButtonsPanel.Name = "gitButtonsPanel";
            gitButtonsPanel.Size = new Size(339, 47);
            gitButtonsPanel.TabIndex = 8;
            // 
            // pageButtonsPanel
            // 
            pageButtonsPanel.Controls.Add(mergingPageButton);
            pageButtonsPanel.Controls.Add(branchesPageButton);
            pageButtonsPanel.Controls.Add(repositoriesPageButton);
            pageButtonsPanel.Dock = DockStyle.Left;
            pageButtonsPanel.Location = new Point(0, 0);
            pageButtonsPanel.Name = "pageButtonsPanel";
            pageButtonsPanel.Size = new Size(495, 47);
            pageButtonsPanel.TabIndex = 4;
            // 
            // buttonsMenuPanel
            // 
            buttonsMenuPanel.Controls.Add(pageButtonsPanel);
            buttonsMenuPanel.Controls.Add(gitButtonsPanel);
            buttonsMenuPanel.Dock = DockStyle.Top;
            buttonsMenuPanel.Location = new Point(0, 0);
            buttonsMenuPanel.Name = "buttonsMenuPanel";
            buttonsMenuPanel.Size = new Size(1001, 47);
            buttonsMenuPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 621);
            Controls.Add(mainPanel);
            Controls.Add(buttonsMenuPanel);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GitHelper";
            Load += MainFormLoad;
            ((System.ComponentModel.ISupportInitialize)githubBindingSource).EndInit();
            gitButtonsPanel.ResumeLayout(false);
            pageButtonsPanel.ResumeLayout(false);
            buttonsMenuPanel.ResumeLayout(false);
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
        private Panel gitButtonsPanel;
        private Panel pageButtonsPanel;
        private Panel buttonsMenuPanel;
    }
}