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
    public partial class panelAdmin_Remove : UserControl
    {
        public panelAdmin_Remove()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            panelAdmin_Main main = new panelAdmin_Main();
            main.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(main);
            this.Dispose();
        }
    }
}
