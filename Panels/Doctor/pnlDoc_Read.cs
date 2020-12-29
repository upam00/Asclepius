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

namespace DBMS_App.Panels.Doctor
{
    public partial class pnlDoc_Read : UserControl
    {
        String ID = "";
        public pnlDoc_Read(String ID)
        {
            this.ID = ID;
            InitializeComponent();
            lblID.Text = "ID: " + ID;
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

        private void txtEnterID_Enter(object sender, EventArgs e)
        {
            txtEnterID.Text = "";
            txtEnterID.TextAlign = HorizontalAlignment.Left;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string P_ID = txtEnterID.Text;

            Program.sqlConnection.Open();
            string docQuery = "SELECT F_Name, M_Name, L_Name, Age, Sex From Patient where Patient_ID = "+P_ID+"; ";
            SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
            SqlDataReader docReader = docComnd.ExecuteReader();
            docReader.Read();
            if (docReader.IsDBNull(1))
            {
                txtName.Text = docReader.GetString(0) + " " + docReader.GetString(2);
            }
            else
            {
                txtName.Text = docReader.GetString(0) + " " + docReader.GetString(1) + " " + docReader.GetString(2);
            }
            txtAge.Text = Convert.ToString(docReader.GetInt32(3));
            txtSex.Text = docReader.GetString(4);
            docReader.Close();

            docQuery = "SELECT Report, Test_results From Medical_Report where Patient_ID = " + P_ID + "; ";
            docComnd = new SqlCommand(docQuery, Program.sqlConnection);
            docReader = docComnd.ExecuteReader();
            docReader.Read();

            try
            {
                rtbReport.Text = docReader.GetString(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show("No Report Written yet");
            }
            if (docReader.IsDBNull(1))
            {
                MessageBox.Show("Test Results awaiting");
            }
            else
            {
                rtbTest.Text = docReader.GetString(1);
            }
            docReader.Close();

            Program.sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string P_ID = txtEnterID.Text;

            string type = comboBox1.SelectedItem.ToString();

            Program.sqlConnection.Open();
            string docQuery = "UPDATE Patient SET Patient_Type = '"+type+"' where Patient_ID = " + P_ID + "; ";
            SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
            SqlDataReader docReader = docComnd.ExecuteReader();
            Program.sqlConnection.Close();

            if(type=="In Patient")
            {
                string DOB = DateTime.Today.Date.ToString("yyyy-MM-dd");
                DOB.Replace("/", "-");
                Program.sqlConnection.Open();
                string docQuery2 = "INSERT INTO In_Patient (Patient_ID, Date_of_admission, Room_no, Assigned_receptionist_ID) VALUES ("+P_ID+", '"+DOB+"', NULL , NULL);";
                SqlCommand docComnd2 = new SqlCommand(docQuery2, Program.sqlConnection);
                SqlDataReader docReader2 = docComnd2.ExecuteReader();
                Program.sqlConnection.Close();
            }
            else if(type == "Out Patient")
            {
                Program.sqlConnection.Open();
                string docQuery3 = "INSERT INTO Out_Patient (Patient_ID) VALUES ("+P_ID+");";
                SqlCommand docComnd3 = new SqlCommand(docQuery3, Program.sqlConnection);
                SqlDataReader docReader3 = docComnd3.ExecuteReader();
                Program.sqlConnection.Close();
            }

            MessageBox.Show("Done");
            txtAge.Text = "";
            txtEnterID.Text = "";
            txtName.Text = "";
            txtSex.Text = "";
            rtbReport.Text = "";
            rtbTest.Text = "";

        }
    }
}
