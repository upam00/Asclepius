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
        public static bool done = false;
        public static TabControl tabControl1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            while(done==false)
            {
                //wait for conection string
            }
            Application.Run(new Home2());


        }
    }
}
