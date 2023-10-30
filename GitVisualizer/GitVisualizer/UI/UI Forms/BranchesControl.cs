using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GitVisualizer.UI.UI_Forms
{
    public partial class BranchesControl : UserControl
    {
        public BranchesControl()
        {
            InitializeComponent();
            ApplyColorTheme(MainForm.AppTheme);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
