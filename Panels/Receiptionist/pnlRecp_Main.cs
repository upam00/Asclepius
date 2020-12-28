using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_App.Panels.Doctor;

namespace DBMS_App.Panels.Receiptionist
{
    public partial class pnlRecp_Main : UserControl
    {
        public pnlRecp_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           pnlRecp_view add = new pnlRecp_view();
            add.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(add);
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlRecp_Del rm = new pnlRecp_Del();
            rm.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(rm);
            this.Dispose();
        }
    }
}
