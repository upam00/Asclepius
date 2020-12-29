using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_App
{
    static class Program
    {
        public static string con="";
        public static SqlConnection sqlConnection;
        public static int done = 0;
        public static TabControl tabControl1;
        public static int login = 0;
        public static string strConnectionUserName = "";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            while(done==0)
            {
                //wait for conection string
            }
            if(done==1)
                Application.Run(new Home2());


        }
    }
}
