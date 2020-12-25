using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_App
{
    public partial class Home2 : Form
    {
        public Home2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            Program.tabControl1 = new TabControl();
            Program.tabControl1.Dock = DockStyle.Fill;
            Program.tabControl1.SizeMode = TabSizeMode.Fixed;
            this.Controls.Add(Program.tabControl1);

            //Login Poping Up
            TabPage tb = new TabPage();
            tb.Text = "New Tab(" + Convert.ToString(Program.tabControl1.TabPages.Count + 1) + ")";
            tb.Controls.Add(new panelLog());
            Program.tabControl1.TabPages.Add(tb);
            Program.tabControl1.SelectedIndex = Program.tabControl1.TabPages.Count - 1;

        }

        private void Home2_Load(object sender, EventArgs e)
        {
            
        }

      
      
    }
}
