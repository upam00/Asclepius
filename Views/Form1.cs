using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DBMS_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition=FormStartPosition.CenterScreen;
        }

        

        private void conBtn_Click(object sender, EventArgs e)
        {
            Program.con = txtCon.Text;

           
            //try
            //{
                Program.sqlConnection = new SqlConnection(Program.con);
                Program.sqlConnection.Open();
                //string queryString = "INSERT INTO Employee (Emp_ID, F_Name, M_Name, L_Name, DOB, Sex, Job_Type) VALUES('DOC002', 'UpamA', NULL, 'Sarmah', '2001-01-01', 'M', 'Doctor');";
                //SqlCommand command = new SqlCommand(queryString, Program.sqlConnection);
                //command.Connection.Open();
               // command.ExecuteNonQuery();
                //command.Connection.Close();
                Program.sqlConnection.Close();
            //MessageBox.Show("Done");
            Program.strConnectionUserName = txtCon.Text;
            Program.done = 1;
            //server = collegedb\\sqlexpress; Initial catalog = online_form; User id = sa; pwd = collegeqwerty
            this.Dispose();
                
                

            //}
            //catch (Exception error)
            //{
               //MessageBox.Show("Connection can't be made. Please check the Connection String. Try using only one '\' after server name.");
            //}


        }

       
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.done = 3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
