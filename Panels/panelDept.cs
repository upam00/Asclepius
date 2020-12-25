using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_App
{
    public partial class panelDept : UserControl
    {
        public panelDept()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TabPage tb = new TabPage();
            tb.Text = "New Tab(" + Convert.ToString(Program.tabControl1.TabCount + 1) + ")";
            tb.Controls.Add(new panelLog());
            Program.tabControl1.TabPages.Add(tb);
            Program.tabControl1.SelectedIndex = Program.tabControl1.TabCount - 1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.tabControl1.TabPages.Count > 1)
            {
                Program.tabControl1.TabPages.Remove(Program.tabControl1.SelectedTab);
            }
        }
    }
}
