using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_App.Panels.Doctor;
using System.Data.SqlClient;

namespace DBMS_App.Panels.Receiptionist
{
    public partial class pnlRecp_Main : UserControl
    {
        string ID="";
        public pnlRecp_Main(String ID)
        {
            InitializeComponent();
            this.ID = ID;
            lblID.Text = "ID: "+ID;

            Program.sqlConnection.Open();
            string docQuery = "SELECT Doctor_ID, Specialization from Doctor";
            SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
            SqlDataReader docReader = docComnd.ExecuteReader();
            while (docReader.Read())
            {
                richTextBox1.Text += Convert.ToString(docReader.GetInt32(0)) +"  "+ docReader.GetString(1) + "\n";
            }
            docReader.Close();
            Program.sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           pnlRecp_view add = new pnlRecp_view(ID);
            add.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(add);
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlRecp_Del rm = new pnlRecp_Del(ID);
            rm.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(rm);
            this.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            txtPID.Text = "";
            txtPID.TextAlign = HorizontalAlignment.Left;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String Fame = txtFame.Text;
            String Mame = txtMame.Text;
            String Lame = txtLame.Text;
            String Sex = txtSex.Text;
            String Age = txtAge.Text;
            String asn = txtADoctor.Text;
            
            
            Program.sqlConnection.Open();
            string docQuery = "SELECT TOP 1 Patient_ID FROM Patient ORDER BY Patient_ID DESC;";
            SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
            SqlDataReader docReader = docComnd.ExecuteReader();
            docReader.Read();
            int P_Id = docReader.GetInt32(0);
            P_Id++;
            docReader.Close();

            if (Mame == "")
            {
                Mame = "NULL";
            }

            docQuery = "INSERT INTO Patient(Patient_ID, F_Name, M_Name, L_Name, Age, Sex, Patient_Type, Check_in_Receptionist_ID, Assigned_Doc_ID) VALUES(" + Convert.ToString(P_Id) + ", '" + Fame + "', '" + Mame + "', '" + Lame + "', " + Age + ", '" + Sex + "', NULL, " + ID + ", " + asn + ");";
            docComnd = new SqlCommand(docQuery, Program.sqlConnection);
            docReader = docComnd.ExecuteReader();
            //docReader.Read();
            docReader.Close();

            Program.sqlConnection.Close();

           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String P_Id = txtPID.Text;

            Program.sqlConnection.Open();
            string docQuery = "DELETE FROM Patient where Patient_ID = "+P_Id+";";
            SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
            SqlDataReader docReader = docComnd.ExecuteReader();
            docReader.Close();
            Program.sqlConnection.Close();
            MessageBox.Show("Patient Deleted");
        }
    }
}
