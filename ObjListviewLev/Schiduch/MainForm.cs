using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Drawing2D;
using System.Collections;
using BrightIdeasSoftware;

namespace Schiduch
{
    public partial class MainForm : Form
    {
        

        public Forms.LoadProgress formloadmsg=new Forms.LoadProgress();
        public static bool Showloadprocess = true;

        private bool Tab1, Tab2, Tab3, Tab4, Tab5, Tab6, Tab7, Tab8, Tab9,Tab10, Tab12;

      
        public MainForm()
        {
            InitializeComponent();
         
          

        }
        private void OpenReportForm(string titlestart,string titlemiddle,string titleend,Color titlem_color,string sfile)
        {
            new Forms.ReportForm(titlestart, titlemiddle, titleend, titlem_color, sfile).ShowDialog();
        }
        public object ChooseCoreectImageToObjLstPeople(object rowObject)
        {
            People p = (People)rowObject;
            if (IsVIPClient(p.Details.MoneyToShadchan)) return 10;
            if (p.Sexs =="זכר")
                return 1;
            else
                return 0;
        }
        public object MatchItemImage(object rowObject)
        {
           return 11;
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "מערכת שנתבשר " + StartUp.Ver;
            if (CRC.CRCP.CheckIsPremium() != CRC.CRCP.PremiumStatus.OK)
            {
                this.Visible = false;
                Forms.PaymentForm pay = new Forms.PaymentForm();
                pay.ShowDialog();
            }
            StartUp.CheckOs(GLOBALVARS.MyUser.ID);
            olvColumn1.ImageGetter = new BrightIdeasSoftware.ImageGetterDelegate(ChooseCoreectImageToObjLstPeople);
            olvColumn10.ImageGetter = new BrightIdeasSoftware.ImageGetterDelegate(ChooseCoreectImageToObjLstPeople);
            olvColumn8.ImageGetter = new ImageGetterDelegate(MatchItemImage);
            cmb_accuracy.SelectedIndex = 0;
            dtlogto.Value = DateTime.Now.AddDays(1);
            
           
            
            this.AcceptButton = btnfilter;
            CheckAccess();
            CheckForIllegalCrossThreadCalls = false;
            CheckUserPhone();

          
        }
        
       

      

        private void Search(object obj)
        {
            
            SqlDataReader reader;


            if (txtfreeserach.TextLength == 0)
            {
                SqlParameter[] prms = new SqlParameter[22];
                string Sql = "";
                string AgeSql = "";
                string whoami = "";
                string whoiwant = "";
                string sqlwhoiwant = "";
                string sqlwhoami = "";
                string noteswhoami = "";
                string noteswhoiwant = "";
                string LearnStatus = "";
                string Subscription = "";
                int fromage = (int)txtfromage.Value;
                int tillage = (int)txttillage.Value;
                string show = " AND SHOW <> 8 AND (show <2 or (show=5 and chadchan like '%{" + GLOBALVARS.MyUser.ID + "}%') or (show=4 and chadchan like '%{" + GLOBALVARS.MyUser.ID + "}%'))";
                string IdFilter = "";
                if (GLOBALVARS.MyUser.Control == User.TypeControl.Manger || GLOBALVARS.MyUser.Control == User.TypeControl.Admin)
                    show = " and show <> 8";

                if (txtlearnstatus.SelectedIndex != -1)
                    LearnStatus = BuildSql.GetSql(out prms[16], txtlearnstatus.Text, "LearnStatus", BuildSql.SqlKind.EQUAL);
                if (tillage > 0)
                    AgeSql = BuildSql.GetSql(out prms[0], fromage, "age", BuildSql.SqlKind.BETWEEN, true, tillage);
                // if(chksubscription.Checked)
                // Subscription= BuildSql.GetSql(out prms[17], chksubscription.Checked, "Subscription", BuildSql.SqlKind.EQUAL,false);
                if (txtid.Value != 0)
                    IdFilter = " peoples.ID=" + txtid.Value + " AND ";

                if (txtwhoami.TextLength > 0)
                {
                    noteswhoami = whoami = "(";
                    foreach (string s in splitwords(txtwhoami.Text))
                    {
                        if (s.Trim().Length > 0)
                        {
                            whoami += " whoami like N'%" + s + "%' and";
                            noteswhoami += " notes like N'%" + s + "%' and";
                        }
                    }
                    whoami = whoami.Remove(whoami.Length - 3, 3);
                    noteswhoami = noteswhoami.Remove(noteswhoami.Length - 3, 3);
                    noteswhoami += ")";
                    whoami += ")";
                    sqlwhoami = "(" + whoami + " or " + noteswhoami + ")";
                }
                if (txtwhoiwant.TextLength > 0)
                {
                    whoiwant = noteswhoiwant = "(";
                    foreach (string s in splitwords(txtwhoiwant.Text))
                    {
                        if (s.Trim().Length > 0)
                        {
                            whoiwant += " whoiwant like N'%" + s + "%' and";
                            noteswhoiwant += " notes like N'%" + s + "%' and";
                        }
                    }
                    whoiwant = whoiwant.Remove(whoiwant.Length - 3, 3);
                    noteswhoiwant = noteswhoiwant.Remove(noteswhoiwant.Length - 3, 3);
                    noteswhoiwant += ")";
                    whoiwant += ")";
                    sqlwhoiwant = "(" + whoiwant + " or " + noteswhoiwant + ")";
                }
                if (!string.IsNullOrEmpty(whoiwant) && !string.IsNullOrEmpty(whoami))
                    sqlwhoami += " and ";
                Sql = "select MoneyToShadchan,show,chadchan,[peopledetails].[relatedid],[Peoples].[ID],FirstName,sexs,Lastname,tall,schools,age,show,notes from peoples inner join peopledetails on ID=relatedid  where 1=1 AND " +
                BuildSql.GetSql(out prms[1], txtfname.Text, "FirstName", BuildSql.SqlKind.LIKE) +
                BuildSql.GetSql(out prms[2], txtlname.Text, "Lastname", BuildSql.SqlKind.LIKE) +
                BuildSql.GetSql(out prms[3], txtbeard.Text, "beard", BuildSql.SqlKind.LIKE) +
                BuildSql.GetSql(out prms[4], txtbg.Text, "background", BuildSql.SqlKind.LIKE) +
                BuildSql.GetSql(out prms[5], txtcoverhead.Text, "coverhead", BuildSql.SqlKind.LIKE) +
                BuildSql.GetSql(out prms[6], txtdadwork.Text, "dadwork", BuildSql.SqlKind.LIKE) +
                BuildSql.GetSql(out prms[7], txtfacecolor.Text, "facecolor", BuildSql.SqlKind.LIKE) +
                IdFilter +
                BuildSql.GetSql(out prms[8], txtfat.Text, "fat", BuildSql.SqlKind.LIKE) +
                AgeSql +
                BuildSql.GetSql(out prms[9], txtlooks.Text, "looks", BuildSql.SqlKind.LIKE) +
                BuildSql.GetSql(out prms[10], txtpeticut.Text, "openhead", BuildSql.SqlKind.LIKE) +
                BuildSql.GetSql(out prms[11], txtschool.Text, "schools", BuildSql.SqlKind.LIKE) +
                BuildSql.GetSql(out prms[12], txtsexs.Text, "sexs", BuildSql.SqlKind.EQUAL) +
                BuildSql.GetSql(out prms[13], txtzerem.Text, "(eda", BuildSql.SqlKind.LIKE, false, null, true) +
                BuildSql.GetSql(out prms[14], txtzerem.Text, "zerem", BuildSql.SqlKind.LIKE, false, null, false, ") AND ") +
                BuildSql.GetSql(out prms[15], txtstatus.Text, "Status", BuildSql.SqlKind.EQUAL) +
                sqlwhoami + sqlwhoiwant +
                LearnStatus +
                Subscription;
                Sql = BuildSql.CheckForLastAnd(ref Sql);
                Sql += show;
                Sql += " ORDER BY ID DESC";
                reader = DBFunction.ExecuteReader(Sql, prms);
            }
            else
            {

                reader = null;// fs.Search(txtfreeserach.Text, (FreeSearch.accuracy)cmb_accuracy.SelectedIndex);
            }
            List<People> lst = new List<People>();
            
            
            while (reader.Read())
            {
                People p = new People();
             
                PeopleManipulations.ReaderToPeople(ref p, ref reader, PeopleManipulations.RtpFor.ForSearch);
                lst.Add(p);
              
            }

            
            olstpeople.BeginUpdate();
            olstpeople.SetObjects(lst);
            olstpeople.EndUpdate();
            
            reader.Close();
            DBFunction.CloseConnections();
            picload.Visible = false;    
            btnfilter.Enabled = true;
            lblresult.Text = "נמצאו : " + lst.Count.ToString() + " במאגר";
        }
        private void btnfilter_Click(object sender, EventArgs e)
        {
            picload.Visible = true;
            btnfilter.Enabled = false;
            ThreadPool.QueueUserWorkItem(new WaitCallback(Search));
            
            
        }

        private string[] splitwords(string str)
        {
            str = str.Replace("'", "").Replace(";", "");
            string[] starray=str.Split(' ');
            int x = 0;
            foreach(string s in starray)
            {
                if (s.StartsWith("ו"))
                    starray[x] = str.Remove(0, 1);
                x++;
            }
            return starray;
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBFunction.CloseConnections();

            Environment.Exit(0);
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtfreeserach.Text = "";
            txtbeard.Text = "";
            txtbg.Text = "";
            txtcoverhead.Text = "";
            txtdadwork.Text = "";
            txtfacecolor.Text = "";
            txtfat.Text = "";
            txtfname.Text = "";
            txtfromage.Value = 0;
            txtlname.Text = "";
            txtwhoiwant.Text = "";
            txtwhoiwant.Text = "";
            txtlooks.Text = "";
            txtpeticut.Text = "";
            txtschool.Text = "";
            txtsexs.Text = "";
            txttillage.Value = 0;
            txtzerem.Text = "";
            txtstatus.Text = "";
            txtlearnstatus.Text = "";
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            GLOBALVARS.OpenDetailsForAdd = true;
            DetailForm df = new DetailForm();
            df.Show();
        }

        public void MainForm_Shown(object sender, EventArgs e)
        {

              ThreadPool.QueueUserWorkItem(new WaitCallback(load));
           LoadData();
            LoadShadcanim();
            if (Showloadprocess)
                formloadmsg.Close();
            GLOBALVARS.AllLoad = true;
                
        }

   
       
        

        private void lstchadcan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstchadcan.SelectedItems.Count <= 0)
                return;
            lblchadchaninfo.Text = "יופעל בקרוב";
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try {
                People p = olstpeople.SelectedObject as People;
                if (p == null) return;
                int id = p.ID;
                
                if (GLOBALVARS.MyUser.Control != User.TypeControl.Admin)
                {
                    if (p.Show != (int)People.ShowTypes.Personal)
                    {
                        MessageBox.Show("אין לך הרשאה למחוק את הלקוח הזה", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                People.DeletePeople(id,true,false);
                olstpeople.SelectedItem.Remove();
                }
            
            catch  { }

        }

        private void btnaddschadcan_Click(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            GLOBALVARS.OpenDetailsForAdd = true;
            //user.userid = int.Parse(lstchadcan.SelectedItems[0].SubItems[3].Text);
            user.Show();
        }

        private void lstchadcan_DoubleClick(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            GLOBALVARS.OpenDetailsForAdd = false;
            user.userid = int.Parse(lstchadcan.SelectedItems[0].SubItems[3].Text);
            user.ShowDialog();
        }

        private void btnuserdel_Click(object sender, EventArgs e)
        {
            if (lstchadcan.SelectedItems.Count <= 0 )
                return;
            if(MessageBox.Show("האם אתה בטוח שברצונך למחוק", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { 
            int userid = int.Parse(lstchadcan.SelectedItems[0].SubItems[3].Text);
            string sql = "delete from users where id=" + userid;
            if (DBFunction.Execute(sql)) { 
                MessageBox.Show("נמחק בהצלחה");
                    lstchadcan.Items.Remove(lstchadcan.SelectedItems[0]);
                }
                else
                MessageBox.Show("אירעה שגיאה");
        }
        }

        private void btnuserblock_Click(object sender, EventArgs e)
        {
            if (lstchadcan.SelectedItems.Count <= 0)
                return;
            if (MessageBox.Show("האם אתה בטוח שברצונך לחסום", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int userid = int.Parse(lstchadcan.SelectedItems[0].SubItems[3].Text);
                string sql = "update users set control=4 where id=" + userid;
                if (DBFunction.Execute(sql))
                {
                    MessageBox.Show("נחסם בהצלחה");
                    
                }
                else
                    MessageBox.Show("אירעה שגיאה");
            }
        }

        private void btnunblockuser_Click(object sender, EventArgs e)
        {
            if (lstchadcan.SelectedItems.Count <= 0)
                return;
            if (MessageBox.Show("האם אתה בטוח שברצונך לבטל את החסימה", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int userid = int.Parse(lstchadcan.SelectedItems[0].SubItems[3].Text);
                string sql = "update users set control=0 where id=" + userid;
                if (DBFunction.Execute(sql))
                {
                    MessageBox.Show("נפתח בהצלחה");

                }
                else
                    MessageBox.Show("אירעה שגיאה");
            }
        }

        private void btndelsw_Click(object sender, EventArgs e)
        {
            if (lstchadcan.SelectedItems.Count <= 0)
                return;
            if (MessageBox.Show("האם אתה בטוח שברצונך למחוק לו את התוכנה", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int userid = int.Parse(lstchadcan.SelectedItems[0].SubItems[3].Text);
                string sql = "update users set control=" + (int)User.TypeControl.Delete + " where id=" + userid;
                if (DBFunction.Execute(sql))
                {
                    MessageBox.Show("התוכנה תמחק בפעם הבאה שהמשתמש ינסה להתחבר");

                }
                else
                    MessageBox.Show("אירעה שגיאה");
            }
        }

        

        private void btnnointernet_Click(object sender, EventArgs e)
        {
            DBFunction.NoInternet();
        }

        private void lsttemppeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lsttemppeople_DoubleClick(object sender, EventArgs e)
        {
            if (lsttemppeople.SelectedItems.Count != 0) {
                //OpenDetails(int.Parse(lsttemppeople.SelectedItems[0].Tag.ToString()));
                int id = int.Parse(lsttemppeople.SelectedItems[0].SubItems[3].Text);
                DetailForm dform = new DetailForm();

                GLOBALVARS.MyPeople= PeopleManipulations.ConvertNotesToPeople(Notes.ReadNotesById(id).Note);
                GLOBALVARS.OpenForTempPeople = true;
                dform.ShowDialog();
                GLOBALVARS.OpenForTempPeople = false;
            }
        }
        private void OpenDetails(int id,bool show=true)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm is DetailForm)
                {
                    ((DetailForm)frm).btnceratehtml.Enabled = false;
                    ((DetailForm)frm).btnchadchanupdate.Enabled = false;
                    ((DetailForm)frm).btnconfirm.Enabled = false;
                    ((DetailForm)frm).btnrewnewpeople.Enabled = false;
                    ((DetailForm)frm).btnshadcanupdate.Enabled = false;
                    ((DetailForm)frm).btnshowhide.Enabled = false;
                    ((DetailForm)frm).btnshowinfo.Enabled = false;
                    ((DetailForm)frm).btnstatuschg.Enabled = false;
                }
            }
            if (id == 0) return;
                SqlDataReader reader;
                GLOBALVARS.OpenDetailsForAdd = false;
                GLOBALVARS.OpenForTempPeople = false;
                GLOBALVARS.MyPeople.ID = id;
                DetailForm detail = new DetailForm();
                reader = People.ReadById(GLOBALVARS.MyPeople.ID);
                while (reader.Read())
                {
                    PeopleManipulations.ReaderToPeople(ref GLOBALVARS.MyPeople, ref reader, true, true);
                }
                reader.Close();
            DBFunction.CloseConnections();
            if(show)
                detail.Show(this);
           
        }
        private void btnlsteditsdel_Click(object sender, EventArgs e)
        {
            if (lsttemppeople.SelectedItems.Count <= 0)
                return;
            try
            {
                int id = int.Parse(lsttemppeople.SelectedItems[0].SubItems[3].Text);
                DBFunction.Execute("delete from notes where noteid=" + id);
                lsttemppeople.Items.Remove(lsttemppeople.SelectedItems[0]);
                if(MessageBox.Show(Lang.MsgAreYouSureDel,"",MessageBoxButtons.YesNo)==DialogResult.Yes)
                    MessageBox.Show("בוצע בהצלחה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { };
        }

        

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnloadlog_Click(object sender, EventArgs e)
        {
            SqlParameter date1 = new SqlParameter("@date1", dtlogfrom.Value);
            SqlParameter date2 = new SqlParameter("@date2", dtlogto.Value);

            SqlParameter[] prms = new SqlParameter[3];
            prms[1] = date1;
            prms[2] = date2;
            string sql = "SELECT Name,ID FROM USERS WHERE  NOT EXISTS (SELECT * FROM LOG WHERE  users.id = userid and";
            sql += " date between @date1 AND @date2)";
            SqlDataReader reader = DBFunction.ExecuteReader(sql,prms);
            lstlog.Items.Clear();
            while (reader.Read())
            {
                lstlog.Items.Add(new ListViewItem(new string[] {
                    reader["Name"].ToString(), 
            }, 3));
            }
            reader.Close();
        }

        private void btnlsteditsconfirm_Click(object sender, EventArgs e)
        {

            if (lsttemppeople.SelectedItems.Count <= 0)
                return;
            int reason;
            SqlDataReader reader;
            int tempid = int.Parse(lsttemppeople.SelectedItems[0].SubItems[7].Text);
            People p = new People();
            reader = People.ReadById(tempid);
            reason = int.Parse(lsttemppeople.SelectedItems[0].SubItems[8].Text);
            
            
            if (reader.Read())
            {
                PeopleManipulations.ReaderToPeople(ref p, ref reader, false, true);
                reader.Close();
                if (reason == (int)People.ReasonType.AllowLimited)
                {
                    PeopleManipulations.AllowHide(p.ByUser, p.RealId);
                    btnlsteditsdel_Click(sender, e);
                    return;
                }

                PeopleManipulations.TempToSet(p, p.RealId);
                 btnlsteditsdel_Click(sender, e);
                
                
            }
            else { 
                reader.Close();
                MessageBox.Show("התרחשה שגיאה", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlogfilter_Click(object sender, EventArgs e)
        {
            string mngrtoo = "";
            int login=0, clientsopen=0;
            SqlParameter date1 = new SqlParameter("@date1",dtlogfrom.Value);
            SqlParameter date2 = new SqlParameter("@date2",dtlogto.Value);
            int loguserid;
            string actionsql = "";
            SqlParameter[] prms = new SqlParameter[1];
            if (cmbusers.SelectedItem is KeyValueClass)
                loguserid = (int)(cmbusers.SelectedItem as KeyValueClass).Value;
            else
                loguserid = -1;
            if (cmbaction.SelectedIndex != -1 && cmbaction.SelectedIndex!=8)
                actionsql = " ACTION=" + cmbaction.SelectedIndex + " AND ";
            string info = "";
            string sql = "select users.name,users.id,info,action,userid,date,level from log inner join users on userid=USERS.ID  where ";
            if(loguserid!=-1)
            sql+=BuildSql.GetSql(out prms[0], loguserid, "UserId", BuildSql.SqlKind.EQUAL);
            sql += actionsql;
            if (!chk_mangertoo.Checked)
                mngrtoo = "and userid <> 1 and userid <> 38 and userid <> 54";
            sql +=" date between @date1 AND @date2 " + mngrtoo + " order by date desc";
            SqlDataReader reader = Log.ReadSql(sql, date1, date2,prms[0]);
            Log temp = new Log();
            lstlog.Items.Clear();
            lstlog.BeginUpdate();
            while (reader.Read())
            { 
                
                Log.ReaderToLog(ref reader, ref temp,chktranslate.Checked);
                if(temp.Info!=null)
                info = temp.Info.Replace('^', ' ');

                lstlog.Items.Add(new ListViewItem(new string[] {
                    reader["Name"].ToString(),
                    temp.Date.ToString(),
                    temp.ActionString,info
            }, 3));
                switch (temp.Command) {
                    case Log.ActionType.ClientOpen:
                        clientsopen++;
                        break;
                    case Log.ActionType.Login:
                        login++;
                        break;
                }
            }
            lblreportstatus.Text = "סך הכל כניסות לתוכנה : " + login + "\nסך הכל פתיחת תיקי לקוחות : " + clientsopen;
            reader.Close();
            lstlog.EndUpdate();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

     

        private void btnlsteditsrefresh_Click(object sender, EventArgs e)
        {
            lsttemppeople.Items.Clear();
            LoadTempData();
        }

        private void btnlstchadchanrefresh_Click(object sender, EventArgs e)
        {
            lstchadcan.Items.Clear();
            LoadShadcanim();
        }
        private void btnnewmsg_Click(object sender, EventArgs e)
        {
            Message newmsg = new Message();
            newmsg.ShowDialog();
        }

        private void txtfname_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnwhoisit_Click(object sender, EventArgs e)
        {
            if (lsttemppeople.SelectedItems.Count <= 0)
                return;
           
            int byuser = int.Parse(lsttemppeople.SelectedItems[0].SubItems[4].Text);
            
            SqlDataReader reader=DBFunction.ExecuteReader("select name from users where id=" + byuser);
            if (reader.Read()) {

                string msg = "הבקשה נשלחה על ידי השדכן : " +
                    (string)reader["name"];
                TempUpdate frmtemp = new TempUpdate();
                frmtemp.label1.Text = msg;
                frmtemp.txtnotes.Text = lsttemppeople.SelectedItems[0].SubItems[2].Text;
                frmtemp.btnconfirm.Visible = false;
                frmtemp.ShowDialog();
            }
            else
                MessageBox.Show("לא נמצא מידע שדכן","", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reader.Close();

            
        }

  
        private void btndelshadchanhandler_Click(object sender, EventArgs e)
        {
            if (lstshadchanhandle.SelectedItems.Count == 0)
                return;
            User.RemoveHandler(int.Parse(lstshadchanhandle.SelectedItems[0].SubItems[4].Text));
            lstshadchanhandle.SelectedItems[0].Remove();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btnshadchaninfo_Click(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            GLOBALVARS.OpenDetailsForAdd = false;
            user.userid = int.Parse(lstshadchanhandle.SelectedItems[0].SubItems[4].Text);
            user.ShowDialog();
        }

        private void lstlog_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lstlog.ListViewItemSorter = new ListViewItemComparer(e.Column);
            lstlog.Sort();
        }

     
        private void lstlog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_reporttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_reporttype.SelectedIndex)
            {
                case 0:
                    LoadClients();
                    break;
                case 1:
                    cmb_subreport.Items.Clear();
                    foreach (object item in cmbusers.Items) {cmb_subreport.Items.Add(item); }
                    break;
                case 4:
                    cmb_subreport.Items.Clear();
                    GLOBALLABELS.LoadGeneralReports(cmb_subreport);
                    break;
            }
        }

        private void sample_Click(object sender, EventArgs e)
        {
            
            
        }

       
        private void txtfreeserach_Click(object sender, EventArgs e)
        {
            
        }

        private void txtfreeserach_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void button1_Click(object sender, EventArgs e)
        {

        }

    

        private void lstshadchanfilter(object sender, EventArgs e)
        {
            int count = 0;
            if (!string.IsNullOrEmpty(txt_filtershadcanname.Text) || !string.IsNullOrEmpty(txt_filtershadcanname.Text)) { 
                for (int i = 0; i < lstchadcan.Items.Count; i++)
                {
                    if (lstchadcan.Items[i].Text.Contains(txt_filtershadcanname.Text) && lstchadcan.Items[i].SubItems[1].Text.Contains(txt_filtershadcantel.Text)) { 
                        lstchadcan.Items[i].BackColor = Color.Red;
                        count++;
                    }
                    else
                        lstchadcan.Items[i].BackColor = Color.White;
                }
            lbl_filterresult.Text = "נמצאו : " + count + " תוצאות";
            }
            else {
                lbl_filterresult.Text = "";
                for (int i = 0; i < lstchadcan.Items.Count; i++)
                    lstchadcan.Items[i].BackColor = Color.White;
            }
        }

        private void setlogdates(object sender, EventArgs e)
        {
            dtlogto.Value = DateTime.Now;
            switch ((string)((Button)sender).Tag){ 
            case "D":
                    dtlogfrom.Value = DateTime.Now.AddDays(-1);
                    break;
            case "W":
                    dtlogfrom.Value = DateTime.Now.AddDays(-7);
                    break;
            case "M":
                    dtlogfrom.Value = DateTime.Now.AddDays(-30);
                    break;
            case "E":
                    dtlogfrom.Value = DateTime.Now.AddYears(-4);
                    break;
            }
        }

        private void lstmyclients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstmyclients_DoubleClick(object sender, EventArgs e)
        {
            if (lstmyclients.SelectedItems.Count != 0)
            {
                Log.AddAction(Log.ActionType.ClientOpen, new Log(Log.ActionType.ClientOpen,
                    lstmyclients.SelectedItems[0].Text + " " +
                    lstmyclients.SelectedItems[0].SubItems[1].Text + "^" + lstmyclients.SelectedItems[0].SubItems[6].Text));
                OpenDetails(int.Parse(lstmyclients.SelectedItems[0].SubItems[6].Text));
            }
        }

        private void searchmyclients(object sender, EventArgs e)
        {
            int count = 0;
            if (!string.IsNullOrEmpty(txt_myclientfname.Text) || !string.IsNullOrEmpty(txt_myclientlname.Text))
            {
                for (int i = 0; i < lstmyclients.Items.Count; i++)
                {
                    if (lstmyclients.Items[i].Text.Contains(txt_myclientfname.Text) && lstchadcan.Items[i].SubItems[1].Text.Contains(txt_myclientlname.Text))
                    {
                        lstmyclients.Items[i].ForeColor = Color.Red;
                        count++;
                    }
                    else
                        lstmyclients.Items[i].ForeColor = Color.Black;
                }
                lblmyclientsresult.Text = "נמצאו : " + count + " תוצאות";
            }
            else
            {
                lblmyclientsresult.Text = "";
                for (int i = 0; i < lstmyclients.Items.Count; i++)
                    lstmyclients.Items[i].ForeColor = Color.Black;
            }
        }

        private void mnu_openclient_Click(object sender, EventArgs e)
        {
        }

        private void mnu_onewindow_Click(object sender, EventArgs e)
        {
            
            General.CreateReport();
            Report r = new Report();
            r.ShowDialog();
        }

        private void mnu_deleteclient_Click(object sender, EventArgs e)
        {

        }

        private void btn_openserial_Click(object sender, EventArgs e)
        {
            if(lstserials.SelectedItems.Count > 0)
            {
                DBFunction.Execute("update serials set serial='" + Serial.UniqueId(lstserials.SelectedItems[0].Text) +
                    "' where ownerkey='" + lstserials.SelectedItems[0].Text + "'");
                lstserials.SelectedItems[0].SubItems[1].Text = Serial.UniqueId(lstserials.SelectedItems[0].Text);
                MessageBox.Show("נפתח בהצלחה");
            }

        }

        private void btn_matchsetting_Click(object sender, EventArgs e)
        {
            Forms.MatchSettings frmmatcsetting = new Forms.MatchSettings();
            frmmatcsetting.ShowDialog();
        }

        private void btnreflstserials_Click(object sender, EventArgs e)
        {
            loadlstserials();
        }

        private void btnremovelstserials_Click(object sender, EventArgs e)
        {
            if (lstserials.SelectedItems.Count > 0)
            {
                DBFunction.Execute("delete from serials where ownerkey='" + lstserials.SelectedItems[0].Text + "'");
                lstserials.SelectedItems[0].Remove();
                MessageBox.Show("הוסר בהצלחה");
            }
        }

        private void chkhideserials_CheckedChanged(object sender, EventArgs e)
        {
            loadlstserials();
        }

     

        private void txttrashfilter(object sender, EventArgs e)
        {
            int count = 0;
            if (!string.IsNullOrEmpty(txttrashfname.Text) || !string.IsNullOrEmpty(txttrashlname.Text))
            {
                for (int i = 0; i < lsttrash.Items.Count; i++)
                {
                    if (lsttrash.Items[i].Text.Contains(txttrashfname.Text) && lsttrash.Items[i].SubItems[1].Text.Contains(txttrashlname.Text))
                    {
                        lsttrash.Items[i].BackColor = Color.Red;
                        count++;
                    }
                    else
                        lstchadcan.Items[i].BackColor = Color.White;
                }
                lbl_trashfilterresult.Text = "נמצאו : " + count + " תוצאות";
            }
            else
            {
                lbl_trashfilterresult.Text = "";
                for (int i = 0; i < lsttrash.Items.Count; i++)
                    lsttrash.Items[i].BackColor = Color.White;
            }
        }

        private void btn_contractupdate_Click(object sender, EventArgs e)
        {
            string sapp = "";
           
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Jpg files (*.jpg)|";
            file.ShowDialog();
            sapp = file.FileName;
            byte[] sfile = File.ReadAllBytes(sapp);
            

            SqlParameter[] prms = new SqlParameter[3];
            prms[0] = new SqlParameter("@contract", sfile);
            prms[1] = new SqlParameter("@date", DateTime.Now);

            bool good = DBFunction.Execute("BEGIN TRANSACTION update contract set signdata=@contract,createtime=@date;update users set signok=0; COMMIT", prms);
            if (good)
                MessageBox.Show("חוזה עודכן בהצלחה","",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
        }

        private void btn_showcontract_Click(object sender, EventArgs e)
        {
            string sfile = Application.StartupPath + "\\temp.png";
            if (lstchadcan.SelectedItems.Count <= 0)
                return;
                int userid = int.Parse(lstchadcan.SelectedItems[0].SubItems[3].Text);
                string sql = "select sign from users where id=" + userid;
                SqlDataReader reader = DBFunction.ExecuteReader(sql);
            if (reader.Read())
            {
                byte[] data = (byte[])reader["sign"];
                File.WriteAllBytes(sfile, data);
            }
            else
                MessageBox.Show("השדכן עדיין לא חתם על חוזה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            reader.Close();
            new Forms.Contract(true).ShowDialog();
        }

        

        private void btnfullscreen_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle != FormBorderStyle.None) { 
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;
            }
            else { 
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = false;
            }

        }

        private void btnpersonaladd_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("יופעל בקרוב", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
          //  return;
            MessageBox.Show("שים לב שהלקוח יוצג רק לך ושאר השדכנים לא יוכלו לראות אותו", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GLOBALVARS.OpenForPersonalAdd = true;
            new DetailForm().ShowDialog();

        }

        private void btnaddotherfiles_Click(object sender, EventArgs e)
        {
            string sapp = "";
            
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Jpg files (*.jpg)|";
            file.ShowDialog();
            sapp = file.FileName;
            byte[] sfile = File.ReadAllBytes(sapp);


            SqlParameter[] prms = new SqlParameter[3];
            prms[0] = new SqlParameter("@app", sfile);
            prms[1] = new SqlParameter("@str", Microsoft.VisualBasic.Interaction.InputBox("הקלד את שם הקובץ"));
            bool good = DBFunction.Execute("insert into otherfiles values(@app,@str)", prms);
            if (good)
                MessageBox.Show("קובץ נוסף בהצלחה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btntemp_Click(object sender, EventArgs e)
        {
            
        }

        private void btnshortreports_Click(object sender, EventArgs e)
        {
            cmenu_report.Show(btnshortreports, new Point(0, btnshortreports.Height));
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MakeReport rp = new MakeReport(MakeReport.ReportType.Client);
            File.WriteAllText(Application.StartupPath + "\\sr.html", rp.CreateGeneralReport(DateTime.Now.AddDays(-1),DateTime.Now.AddDays(1)));
            new Report((Application.StartupPath + "\\sr.html")).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartUp.FixMyBrowser();
        }

        private void tsmenu_showrweek_Click(object sender, EventArgs e)
        {
            MakeReport rp = new MakeReport(MakeReport.ReportType.Client);
            File.WriteAllText(Application.StartupPath + "\\sr.html", rp.CreateGeneralReport(DateTime.Now.AddDays(-7),DateTime.Now.AddDays(1)));
            new Report((Application.StartupPath + "\\sr.html")).ShowDialog();
        }

        private void tsmenu_showrmonth_Click(object sender, EventArgs e)
        {
            MakeReport rp = new MakeReport(MakeReport.ReportType.Client);
            File.WriteAllText(Application.StartupPath + "\\sr.html", rp.CreateGeneralReport(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(1)));
            new Report((Application.StartupPath + "\\sr.html")).ShowDialog();
        }

    
   

        


        private void tooltipinfo_Draw(object sender, DrawToolTipEventArgs e)
        {
          //  MessageBox.Show(e.AssociatedControl.Location.X);
          //  Point p = new Point(e.AssociatedControl.Location.X, e.AssociatedControl.Location.Y);
            Brush brsh = Brushes.Red;
            Font font = new Font("Arial", 12, FontStyle.Bold);
            Point p = new Point();
            Rectangle box = new Rectangle(new Point(0,0),new Size(100,250));
            
            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawRectangle(Pens.AliceBlue, box);
            e.DrawBorder();
         //   e.Graphics.DrawIcon(new Icon(Application.StartupPath + "\\logo.ico"),new Rectangle(new Point(1,1),new Size()));
         //   e.Graphics.DrawString("מידע", font, brsh, new PointF(40,0));
          //  e.Graphics.DrawString(e.ToolTipText, new Font("Arial", 12), br, new PointF(0,10));


            /*string[] spl = e.ToolTipText.Split('\n');
            foreach (string line in spl)
            {
                if (line.Length > len)
                    len = line.Length;
            }
            Rectangle rect = new Rectangle(len * 5 + 30, 0, 24, 24);
            e.Graphics.DrawIcon(new Icon(Application.StartupPath + "\\logo.ico"), rect);
            e.Graphics.DrawString(e.ToolTipText, new Font("Arial", 12), br, new PointF(20, 20));*/


        }

        private void btn_foundmatch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("תחת בנייה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            if (cmb_matchclient.SelectedIndex < 0) return;
            picmatch.Visible = true;
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunMatchSearch),-1);

        }
        private bool IsVIPClient(string MONEYTOSHADCHAN)
        {
            decimal result = 0;
            decimal.TryParse(Regex.Match(MONEYTOSHADCHAN, @"\d+").Value, out result);
            if ((MONEYTOSHADCHAN.Contains("דול") || MONEYTOSHADCHAN.Contains("$")) && result > 1200)
                return true;
            else if (result > 4000) return true;

            return false;
        }
        private void olstpeople_FormatRow(object sender, FormatRowEventArgs e)
        {
            
            People p = (People)e.Model;
            switch (p.Show) {
                case (int)People.ShowTypes.HideDetails:
                    e.Item.BackColor = Color.LightGreen;
                    if (GLOBALVARS.MyUser.Control == User.TypeControl.User)
                    {
                        (e.Model as People).FirstName = "חסוי";
                        (e.Model as People).Lasname = "חסוי";
                    }
                    break;
                case (int)People.ShowTypes.HideFromUsers:
                    e.Item.BackColor = Color.LightBlue;
                    break;
                case (int)People.ShowTypes.VIP:
                    e.Item.BackColor = Color.Gold;
                    break;
                case (int)People.ShowTypes.Personal:
                    e.Item.BackColor = Color.LightGreen;
                    break;
            }
            //e.Item.BackColor = Color.GreenYellow;
    }
        private void olstpeople_DoubleClick(object sender, EventArgs e)
        {
            if (olstpeople.SelectedObject != null)
            {
                People p = olstpeople.SelectedObject as People;
                bool show = true;
               
                    Log.AddAction(Log.ActionType.ClientOpen, new Log(Log.ActionType.ClientOpen,
                        p.FirstName + " " +
                        p.Lasname + "^" + p.ID.ToString()));
                    if (sender is bool && (bool)sender == false)
                        show = false;
                    if (GLOBALVARS.MyUser.Control == User.TypeControl.User && p.Show ==(int) People.ShowTypes.Personal)
                        GLOBALVARS.OpenForPersonalEdit = true;
                    OpenDetails(p.ID, show);
            }
        }

        private void RunMatchSearch(object obj)
        {
            
            KeyValueClass id=new KeyValueClass();
            if ((int)obj > 0)
                id.Value = (int)obj;
            else
                id = cmb_matchclient.SelectedItem as KeyValueClass;
            SqlDataReader read = People.ReadById((int)id.Value);
            read.Read();
            People p = new People();
            PeopleManipulations.ReaderToPeople(ref p, ref read, false, true);
            read.Close();
            ArrayList results = MatchesChecks.GetMatches(p);      
            olstmatch.SetObjects(results);
            olstmatch.Sort(olvColumn9);
            picmatch.Visible = false;
            lblmatchfound.Text = "נמצאו : " + olstmatch.Items.Count.ToString() + " התאמות";
        }

        private void olstpeople_ButtonClick(object sender, CellClickEventArgs e)
        {
            People p = e.Model as People;
            if (p == null) return;           
            cmb_matchclient.Items.Add(new KeyValueClass(p.FirstName + " " + p.Lasname , p.ID));            
            tabControl1.SelectedIndex = 3;
         //   tabControl1_Selected(sender,new TabControlEventArgs(tabPage9,3,TabControlAction.Selected));
            cmb_matchclient.Text = p.FirstName + " " + p.Lasname;
            picmatch.Visible = true;
            ThreadPool.QueueUserWorkItem(new WaitCallback(RunMatchSearch),p.ID);
        }

        private void olstmatch_Click(object sender, EventArgs e)
        {
            Match m = olstmatch.SelectedObject as Match;
           if (m != null)
                lblwhymatch.Text =MatchesChecks.CreateInfoString(m);
        }

        private void btmsample_Click(object sender, EventArgs e)
        {

        }

        private void olstmatch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
           
        }

        private void olstmatch_DoubleClick(object sender, EventArgs e)
        {
            if (olstmatch.SelectedObject != null)
            {
                Match p = olstmatch.SelectedObject as Match;
                bool show = true;
                Log.AddAction(Log.ActionType.ClientOpen, new Log(Log.ActionType.ClientOpen,
                    p.Name + "^" + p.ID.ToString()));
                if (sender is bool && (bool)sender == false)
                    show = false;               
                OpenDetails(p.ID, show);
            }
        }

        private void btn_createreport_Click(object sender, EventArgs e)
        {
            string path = "";
            MakeReport report;
            switch (cmb_reporttype.SelectedIndex) {
                case 0:
                    report = new MakeReport(MakeReport.ReportType.Client);
                    path = report.CreateClientReport(((KeyValueClass)cmb_subreport.SelectedItem).Text, (int)((KeyValueClass)cmb_subreport.SelectedItem).Value, dt_reportfrom.Value, dt_reportto.Value);
                    webBrowser1.Navigate(path);
                    break;
                case 1:
                    report = new MakeReport(MakeReport.ReportType.User);
                    path = report.CreateClientReport(((KeyValueClass)cmb_subreport.SelectedItem).Text, (int)((KeyValueClass)cmb_subreport.SelectedItem).Value, dt_reportfrom.Value, dt_reportto.Value);
                    webBrowser1.Navigate(path);
                    break;
                case 4:
                    report = new MakeReport(MakeReport.ReportType.Dates);
                    path = report.CreateDatesReport(dt_reportfrom.Value, dt_reportto.Value);
                    webBrowser1.Navigate(path);
                    break;
            }

            
        }

        private void lstshadchanhandle_DoubleClick(object sender, EventArgs e)
        {
            if (lstshadchanhandle.SelectedItems.Count != 0)
                OpenDetails(int.Parse(lstshadchanhandle.SelectedItems[0].SubItems[3].Text));
        }

      
        private void btndelpeople_Click(object sender, EventArgs e)
        {
            if (People.DeletePeople(int.Parse(lsttemppeople.SelectedItems[0].Tag.ToString())))
                lsttemppeople.SelectedItems[0].Remove();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            
           
           if (e.TabPage == tabPage8 && Tab8 == false)
            {

                
            }
            else if (e.TabPage == tabPage3 && Tab3 == false)
            {
                Tab3 = true;
                People p = new People();
                SqlDataReader reader;
                reader = People.ReadAll(0, false, false, true);
                lstmyclients.BeginUpdate();
                while (reader.Read())
                {
                    PeopleManipulations.ReaderToPeople(ref p, ref reader, PeopleManipulations.RtpFor.ForSearch);
                    LoadResultToList(ref p, lstmyclients);
                }
                lstmyclients.EndUpdate();
                reader.Close();
                
            }
            else if (e.TabPage == tabPage4 && Tab4 == false)
            {
                LoadTempData();
                Tab4 = true;
            }
            else if (e.TabPage == tabPage9 && Tab9 == false)
            {
                if (cmb_matchclient.Items.Count == 1)
                {
                    cmb_matchclient.Items.Add(new KeyValueClass("", 1000));
                    return;
                }
                cmb_matchclient.Items.Clear();
                picmatch.Visible = true;
                ThreadPool.QueueUserWorkItem(new WaitCallback(LoadTab9));
            }
          
            else if (e.TabPage == tabPage10 && Tab10 == false)
            {
                People p = new People();
                SqlDataReader reader;
                reader = DBFunction.ExecuteReader("select id,firstname,lastname from peoples where show=8");
                lsttrash.BeginUpdate();
                while (reader.Read())
                {
                    ListViewItem item= new ListViewItem(new string[] { reader["firstname"].ToString(), reader["lastname"].ToString()},9);
                    item.Tag = reader["id"].ToString();
                    lsttrash.Items.Add(item);
                }
                lsttrash.EndUpdate();
                reader.Close();
                Tab10 = true;
            }
            else if (e.TabPage == tabPage12 && Tab12==false)
            {
                List<People> lst = new List<People>();
                SqlDataReader reader= People.ReadAll(0,false,false,false,true);
                while (reader.Read())
                {
                    People p = new People();
                    PeopleManipulations.ReaderToPeople(ref p, ref reader, PeopleManipulations.RtpFor.ForSearch);
                    if (IsVIPClient(p.Details.MoneyToShadchan))
                        lst.Add(p);
                }
                lstvip.SetObjects(lst);
                reader.Close();
            }

        }
        private void LoadTab9(object objd)
        {
            
            Tab9 = true;
            LoadClients();
            DictinorayRow.LoadDictonary();

            foreach (object obj in Clients)
            {
                cmb_matchclient.Items.Add(obj);
            }
            picmatch.Visible = false;
            
            
        }
        private void loadlstserials(bool hideopened = true)
        {
            string tempown = "";
            lstserials.Items.Clear();
            int pic = 6;
            string hdopen = "where serial = ''";
            if (!hideopened || chkhideserials.Checked)
                hdopen = "";
            SqlDataReader reader = DBFunction.ExecuteReader("SELECT OWNERKEY,info,serial FROM SERIALS " + hdopen + " order by serial");
            while (reader.Read())
            {
                if (string.IsNullOrEmpty(reader["serial"].ToString()))
                    pic = 7;
                else
                    pic = 6;
                if (tempown != reader["ownerkey"].ToString())
                {
                    tempown = reader["ownerkey"].ToString();
                    ListViewItem tempitem = new ListViewItem(new string[] { tempown, reader["serial"].ToString(), reader["info"].ToString() }, pic);
                    lstserials.Items.Add(tempitem);
                }
            }
            reader.Close();
        }
    }
}
