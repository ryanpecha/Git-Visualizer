using GitVisualizer.UI;
using SkiaSharp;

namespace GitVisualizer
{
    /// <summary>
    /// Login page for app, which handles logging into Github, granting user codes, and linking to Github site
    /// before allowing manipulation of Repos.
    /// </summary>
    partial class GitHelperLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GitHelperLogin));
            label1 = new Label();
            label2 = new Label();
            githubLoginButton = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            localWorkspaceButton = new Button();
            notifyIcon1 = new NotifyIcon(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 32.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(365, 59);
            label1.TabIndex = 0;
            label1.Text = "Workspace Setup";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(26, 78);
            label2.Name = "label2";
            label2.Size = new Size(515, 122);
            label2.TabIndex = 1;
            label2.Text = resources.GetString("label2.Text");
            // 
            // githubLoginButton
            // 
            githubLoginButton.FlatStyle = FlatStyle.Flat;
            githubLoginButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            githubLoginButton.Location = new Point(26, 226);
            githubLoginButton.Name = "githubLoginButton";
            githubLoginButton.Size = new Size(217, 41);
            githubLoginButton.TabIndex = 2;
            githubLoginButton.Text = "Login Using Github.com";
            githubLoginButton.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(12, 370);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(296, 19);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.Text = "Joining or hosting a collaborative project on Github";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(12, 395);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(285, 19);
            radioButton2.TabIndex = 4;
            radioButton2.TabStop = true;
            radioButton2.Text = "Creating or cloning a project on the Github cloud";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(12, 420);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(361, 19);
            radioButton3.TabIndex = 5;
            radioButton3.TabStop = true;
            radioButton3.Text = "Using a local folder to handle version control on my own device\r\n";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // localWorkspaceButton
            // 
            localWorkspaceButton.FlatStyle = FlatStyle.Flat;
            localWorkspaceButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            localWorkspaceButton.Location = new Point(26, 290);
            localWorkspaceButton.Name = "localWorkspaceButton";
            localWorkspaceButton.Size = new Size(217, 41);
            localWorkspaceButton.TabIndex = 6;
            localWorkspaceButton.Text = "Use Local Workspace";
            localWorkspaceButton.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "This will send you to an external site, proceed?";
            notifyIcon1.Visible = true;
            // 
            // GitHelperLogin
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(624, 601);
            Controls.Add(localWorkspaceButton);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(githubLoginButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "GitHelperLogin";
            Text = "GitHelper Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void ApplyColorTheme(UITheme.AppTheme theme)
        {
            BackColor = theme.AppBackground;
            ForeColor = theme.TextSoft;

            label1.ForeColor = theme.TextHeader;
            label2.ForeColor = theme.TextNormal;


            /// Apply themes to all buttons
            IEnumerable<Control> buttons = this.Controls.OfType<Control>().Where(x => x is Button);
            foreach (Button button in buttons)
            {
                button.BackColor = theme.ElementBackground;
                button.ForeColor = theme.TextSelectable;
            }


            

        }

        #endregion

        private Label label1;
        private Label label2;
        private Button githubLoginButton;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Button localWorkspaceButton;
        private NotifyIcon notifyIcon1;
    }
}