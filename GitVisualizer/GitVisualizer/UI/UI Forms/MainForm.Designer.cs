using GithubSpace;

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
            pageButtonsPanel = new Panel();
            buttonsMenuPanel = new Panel();
            revokeAccessButton = new Button();
            navigationTooltip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)githubBindingSource).BeginInit();
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
            navigationTooltip.SetToolTip(repositoriesPageButton, "For managing, creating, and viewing local and remote repositories\r\n");
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
            navigationTooltip.SetToolTip(branchesPageButton, "Shows history, changesets, and branches and allows checking into commits or branches");
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
            mergingPageButton.Text = "Changes";
            navigationTooltip.SetToolTip(mergingPageButton, "Allows for staging and syncing changes with repository, and shows differences\r\n");
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
            mainPanel.Size = new Size(1184, 594);
            mainPanel.TabIndex = 3;
            // 
            // pageButtonsPanel
            // 
            pageButtonsPanel.Controls.Add(revokeAccessButton);
            pageButtonsPanel.Controls.Add(mergingPageButton);
            pageButtonsPanel.Controls.Add(branchesPageButton);
            pageButtonsPanel.Controls.Add(repositoriesPageButton);
            pageButtonsPanel.Dock = DockStyle.Fill;
            pageButtonsPanel.Location = new Point(0, 0);
            pageButtonsPanel.Name = "pageButtonsPanel";
            pageButtonsPanel.Size = new Size(1184, 47);
            pageButtonsPanel.TabIndex = 4;
            // 
            // buttonsMenuPanel
            // 
            buttonsMenuPanel.Controls.Add(pageButtonsPanel);
            buttonsMenuPanel.Dock = DockStyle.Top;
            buttonsMenuPanel.Location = new Point(0, 0);
            buttonsMenuPanel.Name = "buttonsMenuPanel";
            buttonsMenuPanel.Size = new Size(1184, 47);
            buttonsMenuPanel.TabIndex = 5;
            // 
            // revokeAccessButton
            // 
            revokeAccessButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            revokeAccessButton.Enabled = false;
            revokeAccessButton.FlatStyle = FlatStyle.Flat;
            revokeAccessButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            revokeAccessButton.Location = new Point(1015, 9);
            revokeAccessButton.Name = "revokeAccessButton";
            revokeAccessButton.Size = new Size(157, 30);
            revokeAccessButton.TabIndex = 9;
            revokeAccessButton.Text = "Revoke Github Access";
            navigationTooltip.SetToolTip(revokeAccessButton, "Revoke access of your credentials to Github, so you will need to login again next time");
            revokeAccessButton.UseVisualStyleBackColor = true;
            revokeAccessButton.Click += revokeAccessButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 641);
            Controls.Add(mainPanel);
            Controls.Add(buttonsMenuPanel);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GitVisualizer - No active repo selected";
            Load += MainFormLoad;
            ((System.ComponentModel.ISupportInitialize)githubBindingSource).EndInit();
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
        private Panel pageButtonsPanel;
        private Panel buttonsMenuPanel;
        private Button revokeAccessButton;
        private ToolTip navigationTooltip;
    }
}