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
    public partial class pnlDoc_Write : UserControl
    {
        public pnlDoc_Write()
        {
            InitializeComponent();
        }

        private void pnlDoc_Write_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlDoc_Main main = new pnlDoc_Main();
            main.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(main);
            this.Dispose();
        }
    }
}
