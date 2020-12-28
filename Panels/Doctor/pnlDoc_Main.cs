using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_App.Panels.Doctor
{
    public partial class pnlDoc_Main : UserControl
    {
        public pnlDoc_Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlDoc_Read add = new pnlDoc_Read();
            add.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(add);
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlDoc_Write rm = new pnlDoc_Write();
            rm.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(rm);
            this.Dispose();
        }

      
    }
}
