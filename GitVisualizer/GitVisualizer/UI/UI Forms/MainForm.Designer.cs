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
            tabControl = new TabControl();
            tabPageRepositories = new TabPage();
            tabPageBranches = new TabPage();
            tabPageMerging = new TabPage();
            tabPageFiles = new TabPage();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageRepositories);
            tabControl.Controls.Add(tabPageBranches);
            tabControl.Controls.Add(tabPageMerging);
            tabControl.Controls.Add(tabPageFiles);
            tabControl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl.Location = new Point(-4, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1193, 713);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabIndex = 0;
            // 
            // tabPageRepositories
            // 
            tabPageRepositories.BackColor = SystemColors.ControlDark;
            tabPageRepositories.Location = new Point(4, 30);
            tabPageRepositories.Name = "tabPageRepositories";
            tabPageRepositories.Padding = new Padding(3);
            tabPageRepositories.Size = new Size(1185, 679);
            tabPageRepositories.TabIndex = 0;
            tabPageRepositories.Text = "Repositories";
            tabPageRepositories.UseVisualStyleBackColor = true;
            // 
            // tabPageBranches
            // 
            tabPageBranches.Location = new Point(4, 30);
            tabPageBranches.Name = "tabPageBranches";
            tabPageBranches.Padding = new Padding(3);
            tabPageBranches.Size = new Size(1185, 679);
            tabPageBranches.TabIndex = 1;
            tabPageBranches.Text = "Branches";
            tabPageBranches.UseVisualStyleBackColor = true;
            // 
            // tabPageMerging
            // 
            tabPageMerging.Location = new Point(4, 30);
            tabPageMerging.Name = "tabPageMerging";
            tabPageMerging.Size = new Size(1185, 679);
            tabPageMerging.TabIndex = 2;
            tabPageMerging.Text = "Merging";
            tabPageMerging.UseVisualStyleBackColor = true;
            // 
            // tabPageFiles
            // 
            tabPageFiles.Location = new Point(4, 30);
            tabPageFiles.Name = "tabPageFiles";
            tabPageFiles.Size = new Size(1185, 679);
            tabPageFiles.TabIndex = 3;
            tabPageFiles.Text = "Files";
            tabPageFiles.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 721);
            Controls.Add(tabControl);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GitHelper";
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private void ApplyColorTheme(UITheme.AppTheme theme)
        {
            BackColor = theme.AppBackground;
            ForeColor = theme.TextSoft;

            tabControl.BackColor = theme.ElementBackground;
            tabControl.ForeColor = theme.TextHeader;
            /// Apply themes to all tab pages
            TabControl.TabPageCollection tabpages = tabControl.TabPages;
            foreach (TabPage page in tabpages)
            {
                page.ForeColor = theme.TextSelectable;
                page.BackColor = theme.AppBackground;
            }
        }

        private TabControl tabControl;
        private TabPage tabPageRepositories;
        private TabPage tabPageBranches;
        private TabPage tabPageMerging;
        private TabPage tabPageFiles;
    }
}