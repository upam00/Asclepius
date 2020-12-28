using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_App.Panels.Admin
{
    public partial class panelAdmin_Main : UserControl
    {
        public panelAdmin_Main()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            panelAdmin_Add add = new panelAdmin_Add();
            add.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(add);
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelAdmin_Remove rm = new panelAdmin_Remove();
            rm.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(rm);
            this.Dispose();
        }
    }
}
