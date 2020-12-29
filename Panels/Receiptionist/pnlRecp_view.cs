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

namespace DBMS_App.Panels.Receiptionist
{
    public partial class pnlRecp_view : UserControl
    {
        string ID = "";
        private BindingSource bindingSource1 = new BindingSource();
        private BindingSource bindingSource2 = new BindingSource();
        private DataTable table_All = new DataTable();
        private DataSet dataSet = new DataSet();
        public static SqlDataAdapter adapter = new SqlDataAdapter();

        public pnlRecp_view(string ID)
        {
            InitializeComponent();
            this.ID = ID;
            lblID.Text = "ID: " + ID;

            this.in_PatientTableAdapter.Fill(this.hospitalDBDataSet.In_Patient);
            this.patientTableAdapter.Fill(this.hospitalDBDataSet1.Patient);


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

        private void button5_Click(object sender, EventArgs e)
        {
            this.in_PatientTableAdapter.Update(this.hospitalDBDataSet.In_Patient);
            this.patientTableAdapter.Update(this.hospitalDBDataSet1.Patient);
        }
    }
}
