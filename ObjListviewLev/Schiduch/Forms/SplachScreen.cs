using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;



namespace Schiduch.Forms
{
    public partial class SplachScreen : Form
    {
        public static bool Dev = true;
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";
     
        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
        public SplachScreen()
        {
            InitializeComponent();
            
        }

        public void AppendText(string text, Color txtcolor)
            {
            
            RichTextBox box = txtstatus;
            box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;

                box.SelectionColor = txtcolor;
                box.AppendText(text);
                box.SelectionColor = box.ForeColor;
            }
       


        private void SplachScreen_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
        }
        

        private void StartUpLoad()
        {
         
                StartUp.splscreen = this;
                
                AppendText(Lang.MsgSetStartupConfig, Color.Black);
                StartUp.SetAppLocation();
                StartUp.CheckOldFiles();



                AppendText("\n" + Lang.MsgInternetConnectionLabel,Color.Black);
                StartUp.ConnectToServer();
                AppendText(Lang.MsgCorrect, Color.Green);

            /*    AppendText("\n" + Lang.MsgCheckForUpdate, Color.Black);


                if (File.Exists("Update.exe")) { 
                    Process pupd=Process.Start("Update.exe",Application.ExecutablePath);
                    pupd.WaitForExit();
                    int ext=pupd.ExitCode;
                    if (ext != 5 && ext!=6)
                    {
                        MessageBox.Show("אירעה שגיאה במערכת העדכון", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                    if (ext == 5)
                    {
                        string sfilename = Process.GetCurrentProcess().Modules[0].FileName;
                        File.Move(sfilename, "old.del");
                        File.Move("n.exe", sfilename);
                        Process.Start(sfilename);
                        Environment.Exit(Environment.ExitCode);
                    }
                }
                else
                {
                    MessageBox.Show("אירעה שגיאה במערכת העדכון", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }


            AppendText(Lang.MsgUpdated, Color.Green);
           
            AppendText("\n" + Lang.MsgCheckRegistredSw, Color.Black);
                StartUp.CheckRegisredSw();
            AppendText(Lang.MsgCorrect, Color.Green); */


            AppendText("\n" + Lang.MsgCheckUnderConstruct, Color.Black);
                bool x = StartUp.CheckUnderConstruct();

                while (x) { }

            AppendText(Lang.MsgAvailable, Color.Green);


            AppendText("\n" + Lang.MsgLoadServices, Color.Black);

            AppendText(Lang.MsgAvailable, Color.Green);


            AppendText("\n" + Lang.MsgOpenLogin, Color.Black);
  

        }

        private void SplachScreen_Shown(object sender, EventArgs e)
        {
            
            BackgroundWorker thr = new BackgroundWorker();
            thr.DoWork += Thr_DoWork;
            thr.RunWorkerAsync();
            thr.RunWorkerCompleted += Thr_RunWorkerCompleted;
          //  ThreadPool.QueueUserWorkItem(new WaitCallback(StartUpLoad));
        }

        private void Thr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StartUp.CheckRegisredSw();
            if (StartUp.IsRegistered)
            {

                bool ret = Login.MakeTheLogin(null, null, true, this);
                if (!ret)
                {
                    this.Hide();
                    Login log = new Login();
                    log.Show();
                }
            }
        }

        private void Thr_DoWork(object sender, DoWorkEventArgs e)
        {
            StartUpLoad();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            try
            {
                Environment.Exit(Environment.ExitCode);
            }
            catch { };
        }

      
    }
}
