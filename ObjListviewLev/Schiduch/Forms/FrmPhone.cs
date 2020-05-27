using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Schiduch.Forms
{
    public partial class FrmPhone : Form
    {
        private bool AllowCancel = false;
        private string clnt_n_usr;
        private string clnt_id;
        private void AddLog(Log.ActionType action)
        {
            Log.AddAction(action, new Log(action,
                    clnt_n_usr));
        }
        public FrmPhone(string info,string client_n_user,string clientid)
        {
            InitializeComponent();
            lblinfo.Text = info;
            clnt_n_usr = client_n_user;
            clnt_id = clientid;
        }

        private void FrmPhone_Load(object sender, EventArgs e)
        {

        }

        private void btngooddate_Click(object sender, EventArgs e)
        {
            AllowCancel = true;
           AddLog(Log.ActionType.GoodDateCall);
            this.Hide();
        }

        private void btnfailcall_Click(object sender, EventArgs e)
        {
            AllowCancel = true;
            AddLog(Log.ActionType.FailCall);
            this.Hide();
        }

        private void btnfaildate_Click(object sender, EventArgs e)
        {
            AllowCancel = true;
            AddLog(Log.ActionType.FailDateCall);
            this.Hide();
        }

        private void FrmPhone_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AllowCancel)
                e.Cancel = true;
        }

        private void btn_makedate_Click(object sender, EventArgs e)
        {
            string msg = "";
            msg = "שים לב : בחירה באפשרות זאת אומרת שאתה מפגיש את הבחור/ה \n האם אתה בטוח ?";
            if (MessageBox.Show(msg,"",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) { 
            AllowCancel = true;
            AddLog(Log.ActionType.StartDate);
            this.Hide();
            }
        }
    }
}
