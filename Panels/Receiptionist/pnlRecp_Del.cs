using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_App.Panels.Receiptionist
{
    public partial class pnlRecp_Del : UserControl
    {
        String ID = "";
        public pnlRecp_Del(String ID)
        {
            InitializeComponent();
            this.ID = ID;
            lblID.Text = "ID: " + ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlRecp_Main main = new pnlRecp_Main(ID);
            main.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(main);
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
