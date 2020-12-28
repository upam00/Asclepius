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

namespace DBMS_App
{
    public partial class panelLog : UserControl
    {
        public panelLog()
        {
            InitializeComponent();
        }

        private void loginPanel_Load(object sender, EventArgs e)
        {
           this.Dock = DockStyle.Fill;
           this.Location = new Point(
           this.ClientSize.Width / 2 - this.Size.Width / 2,
           this.ClientSize.Height / 2 - this.Size.Height / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Program.login%4 == 0)
            {
                this.Parent.Controls.Add(new panelAdmin());
                this.Dispose();
                Program.login++;
            }
            else if(Program.login%4 == 1)
            {
                this.Parent.Controls.Add(new panelDoctor());
                this.Dispose();
                Program.login++;
            }
            else if(Program.login%4 == 2)
            {
                this.Parent.Controls.Add(new panelReceptionist());
                this.Dispose();
                Program.login++;
            }
            else if(Program.login%4 == 3)
            {
                this.Parent.Controls.Add(new panelDept());
                this.Dispose();
                Program.login++;
            }
            //this.Visible = false;
            //this.Parent.Controls.Remove(Parent.Controls[1]);

        }
    }
}
