using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_App.Panels;
using DBMS_App.Panels.Department;

namespace DBMS_App
{
    public partial class panelDept : UserControl
    {
        string Id = "";
        public panelDept(string ID)
        {
            this.Id = ID;
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

        private void panelDept_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            panelDept_Main main = new panelDept_Main(Id);
            main.Dock = DockStyle.Fill;
            this.Controls.Add(main);
        }
    }
}
