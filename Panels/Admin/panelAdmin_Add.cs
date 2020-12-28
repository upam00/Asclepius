using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_App.Panels.Admin;

namespace DBMS_App
{
    public partial class panelAdmin_Add : UserControl
    {
        public panelAdmin_Add()
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
