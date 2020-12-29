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
        String ID = "";
        public pnlDoc_Write(String ID)
        {
            this.ID = ID;
            InitializeComponent();
            lblID.Text = "ID: " + ID;
        }

        private void pnlDoc_Write_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlDoc_Main main = new pnlDoc_Main(ID);
            main.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(main);
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
