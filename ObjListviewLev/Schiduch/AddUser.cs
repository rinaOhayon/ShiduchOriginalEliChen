using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace Schiduch
{
    public partial class AddUser : Form
    {
        public int userid;
        public AddUser()
        {
            InitializeComponent();
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            this.CancelButton = btnclose;
            this.AcceptButton = btnconfirm;
            if (GLOBALVARS.MyUser.Control == User.TypeControl.Admin)
            {
                txttype.Enabled=true;
            }
            if (!GLOBALVARS.OpenDetailsForAdd)
            {
                User LookUser= User.GetUser(userid);
                txtmail.Text = LookUser.Email;
                txtusername.Text = LookUser.UserName;
                txttype.SelectedIndex = (int)LookUser.Control;
                txttel.Text = LookUser.Tel;
                txtname.Text = LookUser.Name;
                if (GLOBALVARS.MyUser.Control == User.TypeControl.Admin) { 
                    txtpassword.Text = LookUser.Password;
                }
                else
                {
                    txtpassword.Enabled = false;
                    txtusername.Enabled = false;
                    txtusername.PasswordChar = '*';
                    txtpassword.PasswordChar = '*';
                    txtpassword.Text = LookUser.Password;
                    chkcontract.Checked = LookUser.SignOk;
                }
             }
            
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            if (GLOBALVARS.OpenDetailsForAdd) { 
                Add();
            }
            else {
                GLOBALVARS.LastUserChangeDB = DateTime.Now;
                UpdateManager.UpdateLastTimeCheckToDb();
                UpdateUser();
            }
        }
        private void Add()
        {
            int level = 0;
            if (DBFunction.CheckExist(txtusername.Text, "USERS", "username")) { 
                MessageBox.Show("המשתמש קיים כבר במערכת","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (GLOBALVARS.MyUser.Control == User.TypeControl.Admin)
            {
                level = txttype.SelectedIndex;
            }
            SqlParameter[] prms = new SqlParameter[7];
            string sql = "insert into users(signok,username,password,control,email,dateadded,name,tel) values(0," +
                BuildSql.InsertSql(out prms[0], txtusername.Text) +
                BuildSql.InsertSql(out prms[1], txtpassword.Text) +
                BuildSql.InsertSql(out prms[2], level) +
                BuildSql.InsertSql(out prms[3], txtmail.Text) +
                BuildSql.InsertSql(out prms[4], DateTime.Now) +
                BuildSql.InsertSql(out prms[5], txtname.Text) +
                BuildSql.InsertSql(out prms[6], txttel.Text, true) +
                ");";
            if (DBFunction.Execute(sql, prms))
                MessageBox.Show("נוסף בהצלחה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("אירעה שגיאה", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void UpdateUser()
        {
            int level = 0;
            if (GLOBALVARS.MyUser.Control == User.TypeControl.Admin)
            {
                level = txttype.SelectedIndex;
            }
            SqlParameter[] prms = new SqlParameter[7];
            string sql = "update users set signok=" + chkcontract.Checked + " ," +
                BuildSql.UpdateSql(out prms[0], txtusername.Text,"username") +
                BuildSql.UpdateSql(out prms[1], txtpassword.Text,"password") +
                BuildSql.UpdateSql(out prms[2], level,"control") +
                BuildSql.UpdateSql(out prms[3], txtmail.Text,"email") +
                BuildSql.UpdateSql(out prms[4], DateTime.Now,"dateadded") +
                BuildSql.UpdateSql(out prms[5], txtname.Text,"name") +
                BuildSql.UpdateSql(out prms[6], txttel.Text,"tel", true) +
                " where id=" + userid +";";
            if (DBFunction.Execute(sql, prms))
                MessageBox.Show("עודכן בהצלחה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("אירעה שגיאה", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool ChangeUserNameAndPassword(string uname,string psw,int userid)
        {
            
            SqlParameter[] prms = new SqlParameter[7];
            string sql = "update users set " +
                BuildSql.UpdateSql(out prms[0], uname, "username") +
                BuildSql.UpdateSql(out prms[1], psw, "password", true) +
                " where id=" + userid + ";";
            if (DBFunction.Execute(sql, prms))
                return true;
            return false;
        }
    }
}
