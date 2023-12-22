using GitVisualizer.UI;
using SkiaSharp;

namespace GitVisualizer
{
    /// <summary>
    /// Setup page Designer code for app, which handles logging into Github, granting user codes, and linking to Github site
    /// before allowing manipulation of Repos. Stores all components for the window form, and includes functionality for
    /// directly modifying page components such as color theme.
    /// </summary>
    partial class SetupForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            label1 = new Label();
            label2 = new Label();
            githubLoginButton = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            localWorkspaceButton = new Button();
            notifyIcon1 = new NotifyIcon(components);
            label3 = new Label();
            label4 = new Label();
            userCodeLabelHeader = new Label();
            userCodeLabel = new Label();
            rememberMeCheckbox = new CheckBox();
            rememberMeLabel = new Label();
            authorizationPanel = new Panel();
            showCodeCheckBox = new CheckBox();
            authorizationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 32.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(456, 72);
            label1.TabIndex = 0;
            label1.Text = "Workspace Setup";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(26, 74);
            label2.Name = "label2";
            label2.Size = new Size(459, 122);
            label2.TabIndex = 1;
            label2.Text = resources.GetString("label2.Text");
            // 
            // githubLoginButton
            // 
            githubLoginButton.FlatStyle = FlatStyle.Flat;
            githubLoginButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            githubLoginButton.Location = new Point(26, 199);
            githubLoginButton.Name = "githubLoginButton";
            githubLoginButton.Size = new Size(236, 98);
            githubLoginButton.TabIndex = 2;
            githubLoginButton.Text = "Login Using Github.com";
            githubLoginButton.UseVisualStyleBackColor = true;
            githubLoginButton.Click += LoadMainAppFormRemote;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(30, 436);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(371, 24);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.Text = "Joining or hosting a collaborative project on Github";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.Click += HighlightLoginButton;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(30, 474);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(355, 24);
            radioButton2.TabIndex = 4;
            radioButton2.TabStop = true;
            radioButton2.Text = "Creating or cloning a project on the Github cloud";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.Click += HighlightLoginButton;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(30, 511);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(452, 24);
            radioButton3.TabIndex = 5;
            radioButton3.TabStop = true;
            radioButton3.Text = "Using a local folder to handle version control on my own device\r\n";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            radioButton3.Click += HighlightLocalButton;
            // 
            // localWorkspaceButton
            // 
            localWorkspaceButton.FlatStyle = FlatStyle.Flat;
            localWorkspaceButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            localWorkspaceButton.Location = new Point(268, 199);
            localWorkspaceButton.Name = "localWorkspaceButton";
            localWorkspaceButton.Size = new Size(251, 98);
            localWorkspaceButton.TabIndex = 6;
            localWorkspaceButton.Text = "Use Local Workspace";
            localWorkspaceButton.UseVisualStyleBackColor = true;
            localWorkspaceButton.Click += LoadMainAppFormLocal;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "This will send you to an external site, proceed?";
            notifyIcon1.Visible = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(16, 340);
            label3.Name = "label3";
            label3.Size = new Size(233, 54);
            label3.TabIndex = 7;
            label3.Text = "Need Help?";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(26, 385);
            label4.Name = "label4";
            label4.Size = new Size(459, 48);
            label4.TabIndex = 8;
            label4.Text = "Select the use case that applies to you, and the appropriate button will be highlighted.";
            // 
            // userCodeLabelHeader
            // 
            userCodeLabelHeader.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            userCodeLabelHeader.Location = new Point(12, 9);
            userCodeLabelHeader.Name = "userCodeLabelHeader";
            userCodeLabelHeader.Size = new Size(375, 187);
            userCodeLabelHeader.TabIndex = 9;
            userCodeLabelHeader.Text = resources.GetString("userCodeLabelHeader.Text");
            userCodeLabelHeader.Click += userCodeLabelHeader_Click;
            // 
            // userCodeLabel
            // 
            userCodeLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            userCodeLabel.Location = new Point(33, 199);
            userCodeLabel.Name = "userCodeLabel";
            userCodeLabel.Size = new Size(343, 86);
            userCodeLabel.TabIndex = 10;
            userCodeLabel.Text = "1234-5678";
            userCodeLabel.TextAlign = ContentAlignment.MiddleCenter;
            userCodeLabel.Visible = false;
            userCodeLabel.Click += userCodeLabel_Click;
            // 
            // rememberMeCheckbox
            // 
            rememberMeCheckbox.AutoSize = true;
            rememberMeCheckbox.Checked = true;
            rememberMeCheckbox.CheckState = CheckState.Checked;
            rememberMeCheckbox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            rememberMeCheckbox.Location = new Point(12, 351);
            rememberMeCheckbox.Name = "rememberMeCheckbox";
            rememberMeCheckbox.Size = new Size(212, 41);
            rememberMeCheckbox.TabIndex = 11;
            rememberMeCheckbox.Text = "Remember Me";
            rememberMeCheckbox.UseVisualStyleBackColor = true;
            rememberMeCheckbox.CheckedChanged += RememberMeCheckboxChanged;
            // 
            // rememberMeLabel
            // 
            rememberMeLabel.Location = new Point(12, 390);
            rememberMeLabel.Name = "rememberMeLabel";
            rememberMeLabel.Size = new Size(391, 100);
            rememberMeLabel.TabIndex = 12;
            rememberMeLabel.Text = "If checked, your authorization code will be remembered so you will not have to authorize again each time you open the app.\r\n\r\nLeave unchecked to revoke access to your account when exiting the app. ";
            rememberMeLabel.Click += rememberMeLabel_Click_1;
            // 
            // authorizationPanel
            // 
            authorizationPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            authorizationPanel.Controls.Add(showCodeCheckBox);
            authorizationPanel.Controls.Add(userCodeLabelHeader);
            authorizationPanel.Controls.Add(rememberMeCheckbox);
            authorizationPanel.Controls.Add(rememberMeLabel);
            authorizationPanel.Controls.Add(userCodeLabel);
            authorizationPanel.Dock = DockStyle.Right;
            authorizationPanel.Location = new Point(529, 0);
            authorizationPanel.MinimumSize = new Size(300, 0);
            authorizationPanel.Name = "authorizationPanel";
            authorizationPanel.Size = new Size(418, 559);
            authorizationPanel.TabIndex = 13;
            authorizationPanel.Visible = false;
            // 
            // showCodeCheckBox
            // 
            showCodeCheckBox.AutoSize = true;
            showCodeCheckBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            showCodeCheckBox.Location = new Point(62, 288);
            showCodeCheckBox.Name = "showCodeCheckBox";
            showCodeCheckBox.Size = new Size(266, 32);
            showCodeCheckBox.TabIndex = 13;
            showCodeCheckBox.Text = "Show Code (Sensitive Info)";
            showCodeCheckBox.UseVisualStyleBackColor = true;
            showCodeCheckBox.CheckedChanged += ShowCodeCheckboxChanged;
            // 
            // SetupForm
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(947, 559);
            Controls.Add(authorizationPanel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(localWorkspaceButton);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(githubLoginButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SetupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GitHelper Login";
            Load += Form1_Load;
            authorizationPanel.ResumeLayout(false);
            authorizationPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private void ApplyColorTheme(UITheme.AppTheme theme)
        {
            BackColor = theme.AppBackground;
            ForeColor = theme.TextSoft;

            label1.ForeColor = theme.TextHeader;
            label2.ForeColor = theme.TextNormal;

            userCodeLabelHeader.ForeColor = theme.TextBright;
            userCodeLabel.ForeColor = theme.TextSelectable;


            /// Apply themes to all buttons
            IEnumerable<Control> buttons = this.Controls.OfType<Control>().Where(x => x is Button);
            foreach (Button button in buttons)
            {
                button.BackColor = theme.ElementBackground;
                button.ForeColor = theme.TextSelectable;
            }
            /// Apply themes to all radio buttons
            IEnumerable<Control> radios = this.Controls.OfType<RadioButton>().Where(x => x is RadioButton);
            foreach (RadioButton radio in radios)
            {
                radio.ForeColor = theme.TextNormal;
            }

            authorizationPanel.BackColor = theme.PanelBackground;
            rememberMeCheckbox.ForeColor = theme.TextSelectable;
            rememberMeLabel.ForeColor = theme.TextNormal;
        }

        private Label label1;
        private Label label2;
        private Button githubLoginButton;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Button localWorkspaceButton;
        private NotifyIcon notifyIcon1;
        private Label label3;
        private Label label4;
        private Label userCodeLabelHeader;
        private Label userCodeLabel;
        private CheckBox rememberMeCheckbox;
        private Label rememberMeLabel;
        private Panel authorizationPanel;
        private CheckBox showCodeCheckBox;
    }
}