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
using System.Data.SqlClient;

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

            string Id = textBox1.Text;
            string pwd = textBox2.Text;
            string type = "";
            String query = "Select Pword from Employee where Emp_ID =" + Id + ";";
            SqlCommand command = new SqlCommand(query, Program.sqlConnection);
            Program.sqlConnection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                if(pwd==reader.GetString(0))
                {
                    reader.Close();
                    string newQuery = "Select Job_Type from Employee where Emp_ID =" + Id + ";";
                    SqlCommand newCommand = new SqlCommand(newQuery, Program.sqlConnection);
                    reader = newCommand.ExecuteReader();
                    reader.Read();
                    type = reader.GetString(0);
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }
                reader.Close();
            }
            catch(Exception ex)
            {
               
               MessageBox.Show("Invalid ID or Password");
              
                

            }


            Program.sqlConnection.Close();

            if (type=="Admin")
            {
                panelAdmin newPanel = new panelAdmin(Id);
                this.Parent.Controls.Add(newPanel);
                this.Dispose();
                Program.login++;
            }
            else if(type=="Doctor")
            {
                this.Parent.Controls.Add(new panelDoctor(Id));
                this.Dispose();
                Program.login++;
            }
            else if(type == "Receptionist")
            {
                this.Parent.Controls.Add(new panelReceptionist(Id));
                this.Dispose();
                Program.login++;
            }
            else if(type=="Pharmacist")
            {
                this.Parent.Controls.Add(new panelDept(Id));
                this.Dispose();
                Program.login++;
            }
            //this.Visible = false;
            //this.Parent.Controls.Remove(Parent.Controls[1]);

        }
    }
}
