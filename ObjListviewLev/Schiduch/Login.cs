using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;
using System.Text;

using System.Windows.Forms;

namespace Schiduch
{

    public partial class Login : Form
    {
        private static bool Working = true;

        public MainForm frm;
        public Login()
        {
            InitializeComponent();

        }


        public void LoadMainForm(object x) { frm = new MainForm(); Working = false; }

        public static bool MakeTheLogin(string username, string password, bool remeber,Forms.SplachScreen splach=null)
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) { 
                User temp = General.GetSavedUser();
                if (temp != null)
                {
                    username = temp.UserName;
                    password = temp.Password;
                }
                else return false;
            }
            MainForm mainfrm;

            User myuser;
            myuser = User.GetUser(username, password);
            if (myuser == null)
                return false;
            else
            {
                GLOBALVARS.MyUser = myuser;
                switch (myuser.Control)
                {
                    case User.TypeControl.Lock:
                        MessageBox.Show("נחסמת על ידי המערכת", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.AddAction(Log.ActionType.LoginBlocked);
                        Environment.Exit(0);
                        return false;
                    case User.TypeControl.Delete:
                        if (File.Exists("Data.bin"))
                            File.Delete("Data.bin");
                        ProcessStartInfo Info = new ProcessStartInfo();
                        Info.Arguments = "/C choice /C Y /N /D Y /T 3 & Del " +
                                       Application.ExecutablePath;
                        Info.WindowStyle = ProcessWindowStyle.Hidden;
                        Info.CreateNoWindow = true;
                        Info.FileName = "cmd.exe";
                        Process.Start(Info);
                        Log.AddAction(Log.ActionType.DeleteSoftware);
                        Environment.Exit(0);
                        return false;
                    case User.TypeControl.WaitToCConfirm:
                        MessageBox.Show("ממתין לאישור המערכת על האשראי", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Environment.Exit(0);
                        return false;

                    default :
                        if (remeber)
                            General.RemeberUser(username, password);
                        
                        Log.AddAction(Log.ActionType.Login);

                        if (!StartUp.CheckSign(GLOBALVARS.MyUser.ID))
                            new Forms.Contract(GLOBALVARS.MyUser.Name).ShowDialog();

                   
                            mainfrm = new MainForm();
                            if (splach != null)
                                splach.Hide();
                            mainfrm.ShowDialog();
                        return true;
                        
                }
            }   
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            
            lblstatus.Text = "טוען תוכנה ...";
            if(!MakeTheLogin(txtun.Text,txtpass.Text,chkremeberme.Checked))
                MessageBox.Show("שם משתמש או סיסמא לא נכונים", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
       
       

        private void Login_Load(object sender, EventArgs e)
        {
            
            this.AcceptButton = btnlogin;
            this.CancelButton = btnexit;
           
            LoadMainForm(null);

            User temp = General.GetSavedUser();
            if (temp != null)
            {
                txtun.Text = temp.UserName;
                txtpass.Text = temp.Password;
                chkremeberme.Checked = true;
                btnlogin_Click(sender, e);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
    public static class GLOBALVARS
    {
        public static bool AllLoad = false;
        public static User MyUser;
        public static People MyPeople;
        public static bool OpenDetailsForAdd;
        public static bool OpenForTempPeople;
        public static float version;
        public static bool OpenForPersonalAdd;
        public static bool OpenForPersonalEdit;
        public static DateTime LastSwUpdateFile;
        public static DateTime LastPeopleCheckFile;
        public static DateTime LastAlertsCheckFile;
        public static DateTime LastSwUpdateDB;
        public static int StatusSw;
        public static DateTime LastPeopleCheckDB;
        public static DateTime LastUserChangeFile;
        public static DateTime LastUserChangeDB;
        public static DateTime LastChatChangeFile;
        public static DateTime LastChatChangeDB;
        public static DateTime LastAlertsCheckDB;

    }

}
