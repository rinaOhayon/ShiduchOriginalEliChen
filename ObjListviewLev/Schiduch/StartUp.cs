using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Drawing;

namespace Schiduch
{
    public static class StartUp
    {
        //static Forms.Welcome alrtfrm;
        public static bool InternetConnected = false;
        public static bool IsRegistered = false;
        public static string Ver = "46";
        private static bool WaitForMe = false;

        public static Forms.SplachScreen splscreen;
        public static void ConnectToServer()
        {
            try
            {
                DBConnection db = new DBConnection();
                InternetConnected = true;
            }
            catch(Exception)
            {
                Forms.Help hlp = new Forms.Help("ככל הנראה ישנה בעיה עם החיבור לאינטרנט", " במידה ויש לכם אינטרנט מוגן נסו לשנות את רמת ההגנה ולראות אם הדבר עוזר, במידה וזה לא עזר נסו להפעיל את המחשב מחדש או לנסות בעוד כמה דקות");
                hlp.ShowDialog();
                Environment.Exit(0);
            }
        }
        public static void CheckRegisredSw()
        {
            try {
                if (Serial.CheckSecurity())
                {
                    IsRegistered = true;
                    
                }
                else
                {
    
                        splscreen.Hide();
                        SerialForm serial = new SerialForm();
                        serial.Show();
                }
            }
            catch(SecurityException)
            {
                Forms.Help hlp = new Forms.Help("קיימת בעיית הרשאות בתוכנה", "יש להפעיל את התוכנה מחדש עם הרשאות מנהל");
                hlp.ShowDialog();
                Environment.Exit(0);
            }
            catch(Exception ex)
            {
                Forms.Help hlp = new Forms.Help("התחרשה השגיאה הבאה \r\n" + ex.Message, "נסה להפעיל מחדש את המחשב ולבדוק שהמחשב מחובר לאינטרנט");
                hlp.ShowDialog();
                Environment.Exit(0);
            }
        }
      
        public static bool CheckUnderConstruct() {
            try { 
            if (General.Status() == General.SwStatus.Construct)
            {
                    splscreen.Invoke(new MethodInvoker(delegate() {
                    splscreen.Hide();
                    Construction frmconstruct = new Construction();
                    frmconstruct.ShowDialog();
                        Environment.Exit(0); 
                    }
                ));
                    return true;
                
            }
                return false;
            }
            catch(Exception ex)
            {
                Forms.Help hlp = new Forms.Help("התחרשה השגיאה הבאה \r\n" + ex.Message, "נסה להפעיל מחדש את המחשב ולבדוק שהמחשב מחובר לאינטרנט");
                hlp.ShowDialog();
                Environment.Exit(0);
                return false;
            }
        }
        public static void CheckUpdate()
        {
            while (WaitForMe) ;
            WaitForMe = true;
        //    try { 
            UpdateManager.CheckForUpdate();
          /*  }
            catch (Exception ex)
            {
                Forms.Help hlp = new Forms.Help("ישנה בעיה במערכת העידכון\r\n" + ex.Message, "כלל הנראה יש שיבוש בין הקבצים הישנים והחדשים נסו להפעיל את המחשב מחדש");
                hlp.ShowDialog();
            }*/
            WaitForMe = false;

        }

        public static void SetAppLocation()
        {
            try
            {
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Keyboard", "IntLoc", Application.StartupPath);
                Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Keyboard", "AppIntLoc", Application.ExecutablePath);
            }
            catch(SecurityException)
            {
                Forms.Help hlp = new Forms.Help("התוכנה דורשת הרשאות גבוהות יותר", "יש להפעיל את התוכנה מחדש כמנהל מערכת");
                hlp.ShowDialog();
                Environment.Exit(0);
            }
            catch(Exception ex)
            {
                Forms.Help hlp = new Forms.Help("התחרשה השגיאה הבאה \r\n" + ex.Message, "נסה להפעיל מחדש את המחשב ולבדוק שהמחשב מחובר לאינטרנט");
                hlp.ShowDialog();
                Environment.Exit(0);
            }
           
        }
        public static void RunAsAdmin()
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = Environment.CurrentDirectory;
            proc.FileName = Application.ExecutablePath;
            proc.Verb = "runas";
            try
            {
                Application.Exit();
                Process.Start(proc);

            }
            catch
            {

                return;
            }


        }

        public static void FixMyBrowser()
        {
         Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
         System.AppDomain.CurrentDomain.FriendlyName, 1, Microsoft.Win32.RegistryValueKind.DWord);
        }


        public static void CheckOldFiles()
        {
            if (File.Exists("old.del"))
            {
                try
                {
                    File.Delete("old.del");
                }
                catch(UnauthorizedAccessException) {
                    Forms.Help hlp = new Forms.Help("התוכנה דורשת הרשאות גבוהות יותר", "יש להפעיל את התוכנה מחדש כמנהל מערכת");
                    hlp.ShowDialog();
                }
                catch (Exception ex)
                {
                    Forms.Help hlp = new Forms.Help("התחרשה השגיאה הבאה \r\n" + ex.Message, "נסה להפעיל מחדש את המחשב");
                    hlp.ShowDialog();
                }
            }
        }
        public static bool CheckSign(int userid)
        {
            if (GLOBALVARS.MyUser.SignOk)
                return true;
          /*  SqlDataReader reader= DBFunction.ExecuteReader("select id from users where id=" + userid +" and signok=1");
            if (reader.Read()) {
                reader.Close();
                return true;
            }
            reader.Close();*/
            return false;
        }
        public static void CheckOs(int userid)
        {
            if (!File.Exists("OS")){
                DBFunction.Execute("update users set OS='" + Environment.OSVersion.VersionString + "' where id=" + userid + " and OS IS NULL");
                File.Create("OS").Close();
            }
        }
      
    }
    public class CustomExection : Exception
    {
        public CustomExection()
        {
        }
        public bool CloseSw=false;
        public CustomExection(string message)
            : base(message)
        {
        }
        public CustomExection(string message,bool IsCtritical)
            : base(message)
        {
            CloseSw = IsCtritical;
        }
    }
}
