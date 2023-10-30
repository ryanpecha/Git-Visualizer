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
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
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
            // button4
            // 
            button4.Location = new Point(897, 10);
            button4.Margin = new Padding(1);
            button4.Name = "button4";
            button4.Size = new Size(79, 21);
            button4.TabIndex = 7;
            button4.Text = "Undo Change";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(815, 10);
            button3.Margin = new Padding(1);
            button3.Name = "button3";
            button3.Size = new Size(79, 21);
            button3.TabIndex = 6;
            button3.Text = "Fetch";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(733, 10);
            button2.Margin = new Padding(1);
            button2.Name = "button2";
            button2.Size = new Size(79, 21);
            button2.TabIndex = 5;
            button2.Text = "Pull";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(652, 10);
            button1.Margin = new Padding(1);
            button1.Name = "button1";
            button1.Size = new Size(79, 21);
            button1.TabIndex = 4;
            button1.Text = "Push";
            button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1001, 621);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}