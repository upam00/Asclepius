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
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Globalization;

namespace DBMS_App.Panels.Doctor
{
    public partial class pnlDoc_Main : UserControl
    {
        static SpeechSynthesizer ss = new SpeechSynthesizer();
        static CultureInfo ci = new CultureInfo("en-us");
        static SpeechRecognitionEngine sre;
        static bool done = false;
        static bool speechOn = true;    

        String ID = "";
        public pnlDoc_Main(String input)
        {

            InitializeComponent();
            this.ID = input;
            lblID.Text = "ID: " + ID;

            Program.sqlConnection.Open();
            string docQuery = "SELECT Patient_ID FROM Patient where Assigned_Doc_ID = " + ID + ";";
            SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
            SqlDataReader docReader = docComnd.ExecuteReader();
          
            while (docReader.Read())
            {
                rtbPTable.Text += Convert.ToString(docReader.GetInt32(0)) + "\n";
            }
            docReader.Close();
            Program.sqlConnection.Close();

            

           
            sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();
            sre.SpeechRecognized += sre_SpeechRecognized;

            Choices ch_StartStopCommands = new Choices();
            ch_StartStopCommands.Add("Hello!");
            ch_StartStopCommands.Add("Ok Done");
            ch_StartStopCommands.Add("Exit");
            ch_StartStopCommands.Add("Write");
            GrammarBuilder gb_StartStop = new GrammarBuilder();
            gb_StartStop.Append(ch_StartStopCommands);
            Grammar g_StartStop = new Grammar(gb_StartStop);


           

            GrammarBuilder gb_food = new GrammarBuilder();
            gb_food.Append("After Food");
            gb_food.Append("Before Food");
            Grammar g_food = new Grammar(gb_food);

            Choices ch_Medicine = new Choices();
            ch_Medicine.Add("Peracetamol");
            ch_Medicine.Add("Omez");
            ch_Medicine.Add("Polycrol");
            ch_Medicine.Add("Acid");

            Choices ch_Numbers = new Choices();
            ch_Numbers.Add("Twice Daily");
            ch_Numbers.Add("Once Daily");
        
            GrammarBuilder gb_WhatIsXplusY = new GrammarBuilder();
            gb_WhatIsXplusY.Append("Write");
            gb_WhatIsXplusY.Append(ch_Medicine);
            gb_WhatIsXplusY.Append(ch_Numbers);
            gb_WhatIsXplusY.Append("And");
            Grammar g_WhatIsXplusY = new Grammar(gb_WhatIsXplusY);


           
            sre.LoadGrammarAsync(g_food);
            sre.LoadGrammarAsync(g_StartStop);
            sre.LoadGrammarAsync(g_WhatIsXplusY);
            // sre.RecognizeAsync() 


        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlDoc_Read add = new pnlDoc_Read(ID);
            add.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(add);
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pnlDoc_Write rm = new pnlDoc_Write(ID);
            //rm.Dock = DockStyle.Fill;
            //this.Parent.Controls.Add(rm);
            //this.Dispose();

            String P_ID = txtPatientID.Text;
            string D_NO = txtDep_No.Text;
            string M_Report = rtbReport.Text;


            try
            {
                Program.sqlConnection.Open();
                string docQuery = "INSERT INTO Medical_Report (Patient_ID, Doc_ID, Report, Dept_No, Test_results) VALUES (" + P_ID + ", " + ID + ", '" + M_Report + "', " + D_NO + ", NULL);";
                SqlCommand docComnd = new SqlCommand(docQuery, Program.sqlConnection);
                SqlDataReader docReader = docComnd.ExecuteReader();
                docReader.Close();
                Program.sqlConnection.Close();
                MessageBox.Show("Medical Report written successfully");
                txtDep_No.Text = "";
                txtPatientID.Text = "";
                rtbReport.Text = "";

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error");

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {

        }

        private void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string txt = e.Result.Text;
            
            float confidence = e.Result.Confidence;
           
            if (confidence < 0.40) return;
            if (txt.IndexOf("Hello") >= 0)
            {
                
                speechOn = true;
                ss.Speak("Hello Doctor! How can I help you.");
                
            }
            else if (txt.IndexOf("Ok Done") >= 0)
            {
                ((SpeechRecognitionEngine)sender).RecognizeAsyncCancel();
                done = true;
                ss.Speak("Bye Doctor!");
                checkBox1.Checked = false;
            }
            else if (txt.IndexOf("Write") >= 0 && txt.IndexOf("And") >= 0)
            {
                string[] words = txt.Split(' ');
                for (int i = 1; i < words.Length-1; i++)
                {
                    rtbReport.Text += words[i]+" ";
                }
                rtbReport.Text += "\n";
             
            }

          

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                sre.RecognizeAsync(RecognizeMode.Multiple);
                ss.Speak("Listening");
            }
            else if (checkBox1.Checked == false) // Turn off
                sre.RecognizeAsyncCancel();
        }
    }
}
