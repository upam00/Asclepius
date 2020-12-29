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

namespace DBMS_App.Panels.Department
{
    public partial class panelDept_Main : UserControl
    {

        String ID = "";
        String PID = "";
        public panelDept_Main(string ID)
        {
            this.ID = ID;
            InitializeComponent();
            Program.sqlConnection.Open();
            string docQuery = "Select Dept_no from Pharmachist where Pharmachist_ID = " + ID + ";";
            SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
            SqlDataReader docReader = docComnd.ExecuteReader();
            docReader.Read();
            lblId.Text = Convert.ToString(docReader.GetInt32(0));
            
            docReader.Close();
            Program.sqlConnection.Close();



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tResult = richTextBox2.Text;

            Program.sqlConnection.Open();
            string docQuery = "UPDATE Medical_Report SET Test_results = '"+tResult+"' Where Patient_ID = " + PID + ";";
            SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
            SqlDataReader docReader = docComnd.ExecuteReader();
            docReader.Close();
            Program.sqlConnection.Close();
            MessageBox.Show("Done");
            textBox1.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PID = textBox1.Text;

            Program.sqlConnection.Open();
            string docQuery = "SELECT Report FROM Medical_Report where Patient_ID = " + PID+ ";";
            SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
            SqlDataReader docReader = docComnd.ExecuteReader();
            docReader.Read();
            richTextBox1.Text = docReader.GetString(0);

            docReader.Close();
            Program.sqlConnection.Close();


        }
    }
}
