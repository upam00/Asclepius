using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBMS_App.Panels.Admin
{
    public partial class panelAdmin_Main : UserControl
    {
        public String ID;
        public panelAdmin_Main(String ID_No)
        {
            this.ID = ID_No;
            InitializeComponent();
            lblID.Text = "ID: " + ID;
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            panelAdmin_Add add = new panelAdmin_Add(ID);
            add.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(add);
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //panelAdmin_Remove rm = new panelAdmin_Remove();
            //rm.Dock = DockStyle.Fill;
            //this.Parent.Controls.Add(rm);
            //this.Dispose();

            //SQL Query
            string type = "";
            string ID = txtEnterID.Text;
            string query = "SELECT Job_Type from Employee where Emp_ID = " + ID + ";";
            SqlCommand command = new SqlCommand(query, Program.sqlConnection);
            Program.sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                reader.Read();
                type = reader.GetString(0);
                reader.Close();
            }
            catch(Exception ex) { }
            
            if(type=="Receptionist")
            {
                query = "UPDATE Patient SET Check_in_Receptionist_ID = NULL WHERE Check_in_Receptionist_ID = " + ID + ";";
                command = new SqlCommand(query, Program.sqlConnection);
                reader = command.ExecuteReader();
                reader.Close();

            }

            query = "DELETE FROM Employee where Emp_ID = " + ID + ";";
            command = new SqlCommand(query, Program.sqlConnection);
            reader = command.ExecuteReader();

            Program.sqlConnection.Close();
            MessageBox.Show("Employee Deleted");
            clear();
            

        }

        public void clear()
        {
            txtAdittional.Text = txtDob.Text = txtID.Text = txtJobType.Text = txtName.Text = txtSex.Text = lblAdittional.Text = "";
            rtbPTable.Text = "";
            panel2.Visible = false;

        }

        int pressed = 0;
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if(pressed == 1)
            {
                clear();
                pressed = 0;
            }
            string ID = txtEnterID.Text;
            string query = "SELECT * FROM Employee where Emp_ID = "+ID+";";

            SqlCommand command = new SqlCommand(query,Program.sqlConnection);
            Program.sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txtID.Text = Convert.ToString(reader.GetInt32(0));
                    if (reader.IsDBNull(2))
                    {
                        txtName.Text = reader.GetString(1) + " " + reader.GetString(3);
                    }
                    else
                    {
                        txtName.Text = reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3);
                    }

                    txtDob.Text = Convert.ToString(reader.GetDateTime(4));
                    txtSex.Text = reader.GetString(5);
                    txtJobType.Text = reader.GetString(6);

                }    
                 
            }
            else
            {
                //Console.WriteLine("No rows found.");
            }
            reader.Close();

                if (txtJobType.Text == "Doctor")
                {
                    lblAdittional.Text = "Specialization";
                    string docQuery = "SELECT * FROM Doctor where Doctor_ID = " + ID + ";";
                    SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
                    SqlDataReader docReader = docComnd.ExecuteReader();
                    docReader.Read();
                    txtAdittional.Text = docReader.GetString(1);
                    txtAdittional.Visible = true;
                    lblAdittional.Visible = true;
                    docReader.Close();


                    docQuery = "SELECT Patient_ID FROM Patient where Assigned_Doc_ID = " + ID + ";";
                    docComnd = new SqlCommand(docQuery, Program.sqlConnection);
                    docReader = docComnd.ExecuteReader();
                    panel2.Visible = true;
                    while (docReader.Read())
                    {
                        rtbPTable.Text += Convert.ToString(docReader.GetInt32(0)) + "\n";
                    }
                    docReader.Close();


                }
                else if (txtJobType.Text == "Receptionist")
                {
                lblAdittional.Text = "Entrance No";
                string docQuery = "SELECT Entrance_No FROM Receptionist where Receptionist_ID = " + ID + ";";
                SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
                SqlDataReader docReader = docComnd.ExecuteReader();
                docReader.Read();
                txtAdittional.Text = Convert.ToString(docReader.GetInt32(0));
                txtAdittional.Visible = true;
                lblAdittional.Visible = true;
                docReader.Close();

            }
                else if (txtJobType.Text == "Pharmacist")
                {
                lblAdittional.Text = "Deptartment No";
                string docQuery = "SELECT Dept_No FROM Pharmachist where Pharmachist_ID = " + ID + ";";
                SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
                SqlDataReader docReader = docComnd.ExecuteReader();
                docReader.Read();
                txtAdittional.Text = Convert.ToString(docReader.GetInt32(0));
                txtAdittional.Visible = true;
                lblAdittional.Visible = true;
                docReader.Close();

            }

        Program.sqlConnection.Close();

            pressed = 1;

        }

        private void txtEnterID_Enter(object sender, EventArgs e)
        {
            txtEnterID.Text = "";
            txtEnterID.TextAlign = HorizontalAlignment.Left;
        }

        private void Admin_Main_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
