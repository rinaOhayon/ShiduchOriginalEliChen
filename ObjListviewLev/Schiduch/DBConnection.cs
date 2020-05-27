using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Schiduch
{
    class DBConnection
    {
        public  SqlConnection connect;
        
        public DBConnection()
        {
            /*
            "Server=tcp:rmc42eiyzk.database.windows.net,1433;" +
                "Database=shiduch;User ID=levone@rmc42eiyzk;Encrypt=True;Password=NeF987&#*vtJ9%5S;" +
                "Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                */
            string con = "U2VydmVyPXRjcDpybWM0MmVpeXprLmRhdGFiYXNlLndpbmRvd3MubmV0LDE0MzM7RGF0YWJhc2U9bGV2b25lO1VzZXIgSUQ9ZWxpY2hlbkBybWM0MmVpeXprO0VuY3J5cHQ9RmFsc2U7UGFzc3dvcmQ9RUxJNDcyMTNlbGk7Q29ubmVjdGlvbiBUaW1lb3V0PTMwOw==";
           // string con = "U2VydmVyPXRjcDpybWM0MmVpeXprLmRhdGFiYXNlLndpbmRvd3MubmV0LDE0MzM7RGF0YWJhc2U9c2hpZHVjaDtVc2VyIElEPWVsaWNoZW5Acm1jNDJlaXl6aztFbmNyeXB0PUZhbHNlO1Bhc3N3b3JkPUVMSTQ3MjEzZWxpO0Nvbm5lY3Rpb24gVGltZW91dD0zMDs=";
            connect = new SqlConnection(Encoding.UTF8.GetString(Convert.FromBase64String(con)));
            
            connect.Open();
            connect.StateChange += Connect_StateChange;
            connect.Close();
          
        }

        private void Connect_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            //if (e.CurrentState == System.Data.ConnectionState.Closed)
            //    ConnectAgain();
        }

       
        public static void ConnectAgain()
        {
            
            if (MessageBox.Show("החיבור נותק, האם תרצה שהתוכנה תנסה להתחבר שוב", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                DBFunction.dbcon = null;
                DBFunction.dbcon = new DBConnection();
            }
        }
    
       


    }
}
