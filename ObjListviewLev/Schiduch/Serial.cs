using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using System.Text;
using System.Net.NetworkInformation;
using System.Data.SqlClient;


namespace Schiduch
{
    public static class Serial
    {
        
        public static bool CheckSecurity()
        {
            const string userRoot = "HKEY_CURRENT_USER\\Control Panel\\Keyboard";
            const string subkey = "KeyBoardId";

            string keyName = "Control Panel\\Keyboard";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key.GetValue("KeyboardId")!=null)
                {
                    try {
                        FixSerial();
                        key.DeleteValue("KeyBoardId");
                    }
                    catch  { }
                }
            }

            
            
            
            string reg = (string)Registry.GetValue(userRoot, "LogicId", null);
            if (reg != null)
            {
                if (reg == UniqueId())
                {
                    return true;
                }
            }

            return false;

        }

        public static void FixSerial()
        {
            string reg = (string)Registry.GetValue("HKEY_CURRENT_USER\\Control Panel\\Keyboard", "KeyBoardId", null);
            Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Keyboard", "LogicId", reg);
            Log.AddAction(Log.ActionType.FixSerialToLogicId);
        }
        public static string UniqueId()
        {

            
            string code = "";
            int index =0;
            string name = "";

                string machime = CreateCode();
                for (int i = 0; i < machime.Length - 1; i += 3)
                {
                    int x = int.Parse(machime.Substring(i, 3));
                if ((x - 102 - index) > 30)
                {
                    char t = (char)(x - 102 - index);
                    name += new string(t, 1);
                }
                index++;
                }
                foreach (char c in name.ToCharArray())
                {
                    int num = ((int)c) / 2;
                    num += num;
                    code += num.ToString();
                    //l++;
                }
           

            return code;
        }

        public static string CreateCode()
        {
            string machime = Environment.MachineName;
            string code = "";
            int l = 0;
            
            foreach (char c in machime.ToCharArray())
            {
                int num = (int)c;
                num += 102 + l;
                code += num.ToString();
                l++;
            }
            return code;
        }

        
        public static string UniqueId(string pwd)
        {

            string machime = pwd;
            string code = "";
            int index = 0;
            string name = "";

            for (int i = 0; i < machime.Length - 1; i += 3)
            {
                int x = int.Parse(machime.Substring(i, 3));
                if((x - 102 - index) > 30) { 
                char t = (char)(x - 102 - index);
                name += new string(t, 1);
                }
                index++;
            }
            foreach (char c in name.ToCharArray())
            {
                int num = ((int)c) / 2;
                num += num;
                code += num.ToString();
                //l++;
            }


            return code;
        }
        public static void RestartComputer(bool with_alert)
        {
            if (with_alert)
            {
                if (System.Windows.Forms.MessageBox.Show("בכדי ששינוים של התוכנה יכנסו לתופף יש להפעיל מחדש את המחשב, האם ברצונך שהתוכנה תפעיל את המחשב מחדש", "", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    return;
            }
            System.Diagnostics.Process.Start("shutdown", " -r -t 5");
        }

        public static string CheckForCode()
        {
            string retcode = "";
            SqlDataReader reader= DBFunction.ExecuteReader("select * from serials where ownerkey='" +CreateCode() +"' and serial <> '' and serial is not null");
            while (reader.Read())
            {
                retcode = reader["serial"].ToString();
            }
            reader.Close();
            return retcode;
        }

        public static void CallForHelp(string info)
        {
            SqlParameter[] prms = new SqlParameter[2];
            prms[1] = new SqlParameter("@data", info);
           DBFunction.Execute("insert into serials values('" + CreateCode() + "','',@data)", prms); 
        }
    }
}
