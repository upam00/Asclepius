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
using System.Data.SqlClient;
using System.Security.Policy;

namespace DBMS_App
{
    public partial class panelAdmin_Add : UserControl
    {
        string ID;
        public panelAdmin_Add(string ID)
        {
            this.ID = ID;
            InitializeComponent();
            lblID.Text = "ID: " + ID;
        }



        private void button1_Click(object sender, EventArgs e)
        {
           
            panelAdmin_Main main = new panelAdmin_Main(ID);
            main.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(main);
            this.Dispose();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString()=="Doctor")
            {
                lblAdittional.Text = "Specialization";
            }
            else if(comboBox1.SelectedItem.ToString()=="Receptionist")
            {
                lblAdittional.Text = "Entrance No";
            }
            else if(comboBox1.SelectedItem.ToString()=="Pharmacist")
            {
                lblAdittional.Text = "Department no";
            }
            lblAdittional.Visible = true;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            string incoming = "SELECT TOP 1 Emp_ID FROM Employee ORDER BY Emp_ID DESC";
            SqlCommand command = new SqlCommand(incoming, Program.sqlConnection);
            Program.sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int empID = reader.GetInt32(0);
            reader.Close();
            empID++;
            string Fame = txtFname.Text;
            string Mame = txtMName.Text;
            if (Mame == "")
            {
                Mame = "NULL";
            }
            else
            {
                Mame = "'" + Mame + "'";
            }
            string Lame = txtLName.Text;

            string DOB = datetimePick.Value.Date.ToString("yyyy-MM-dd");
            DOB.Replace("/", "-");

            string sex = txtSex.Text;
            string password = txtPassword.Text;
            string empType = Convert.ToString(comboBox1.SelectedItem);

            string query = "INSERT INTO Employee(Emp_ID, F_Name, M_Name, L_Name, DOB, Sex, Job_Type, Pword)VALUES(" + Convert.ToString(empID) + ", '" + Fame + "', " + Mame + ", '" + Lame + "', '" + DOB + "', '" + sex + "', '" + empType + "', '" + password + "');";
            command = new SqlCommand(query, Program.sqlConnection);
            command.ExecuteNonQuery();

            if (lblAdittional.Text == "Specialization")
            {
                string spec = txtAditional.Text;
                string query2 = "INSERT INTO Doctor(Doctor_ID, Specialization) VALUES (" + Convert.ToString(empID) + ", '" + spec + "');";
                command = new SqlCommand(query2, Program.sqlConnection);
                command.ExecuteNonQuery();

            }
            else if (lblAdittional.Text == "Entrance No")
            {
                string eno = txtAditional.Text;
                string spec = txtAditional.Text;
                string query2 = "INSERT INTO Receptionist(Receptionist_ID, Entrance_No) VALUES(" + Convert.ToString(empID) + ", " + eno + "); ";
                command = new SqlCommand(query2, Program.sqlConnection);
                command.ExecuteNonQuery();

            }
            else if (lblAdittional.Text == "Department no")
            {
                string dno = txtAditional.Text;
                string spec = txtAditional.Text;
                string query2 = "INSERT INTO Pharmachist(Pharmachist_ID, Dept_No) VALUES(" + Convert.ToString(empID) + ", " + dno + "); ";
                command = new SqlCommand(query2, Program.sqlConnection);
                command.ExecuteNonQuery();

            }

            Program.sqlConnection.Close();
            MessageBox.Show("Employee Added Succesfully with ID: " + Convert.ToString(empID));
            panelAdmin_Main main = new panelAdmin_Main(ID);
            main.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(main);
            this.Dispose();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
