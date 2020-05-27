using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.Win32;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Schiduch.Forms;
using System.Diagnostics;
using System.Security.Principal;

namespace Schiduch
{
    public partial class SerialForm : Form
    {
        public SerialForm()
        {
           // if(!IsAdministrator()) RunAsAdmin();
            InitializeComponent();
        }
        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }
        
        private void txtfname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SerialForm_Load(object sender, EventArgs e)
        {
            
            //General.LoadLogo();
            try { 
            DBConnection db = new DBConnection();
          //  General.CloseLogo();
            }
            catch(Exception ex)
            {
                MessageBox.Show("התוכנה דורשת חיבור לאינטרנט\nError : "+ ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
            this.CancelButton = btnexit;
            this.AcceptButton = btnconfirm;
            lblserial.Text = Serial.CreateCode();

            if (Serial.CheckSecurity()) // check if the client computer is registered
            {
                if (General.Status() == General.SwStatus.Construct)
                {
                    Construction frmconstruct = new Construction();
                    frmconstruct.Show();
                }
                else
                {
                    Login log = new Login();
                    log.Show();
                }
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.Hide();
            }
            else
                txtserial.Text = Serial.CheckForCode();
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (txtserial.Text == Serial.UniqueId()) { 
                MessageBox.Show("נרשמת בהצלחה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Keyboard", "LogicId",txtserial.Text);
                Log.AddAction(Log.ActionType.Register);
                Login log = new Login();
                log.Show();
            
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Hide();

        }
            else
                MessageBox.Show("קוד שגוי", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnhelpserialnumber_Click(object sender, EventArgs e)
        {
            SerialHelp help = new SerialHelp();
            help.ShowDialog();
        }

        private void SerialForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           // DBConnection.Close();
        }
    }


    }

