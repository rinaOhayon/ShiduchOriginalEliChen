using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Text;

using System.Windows.Forms;

namespace Schiduch
{
    public partial class DetailForm : Form
    {
        private bool Tab4Firsttime = true;
        private bool Tab5Firsttime = true;
        private bool personaluser = false;
        public DetailForm()
        {
            InitializeComponent();
        }
        private void LoadPeopleToTxts()
        {
            txtage.Text = GLOBALVARS.MyPeople.Age.ToString();
            txtbeard.Text = GLOBALVARS.MyPeople.Beard;
            txtbg.Text = GLOBALVARS.MyPeople.Background;
            txtcity.Text = GLOBALVARS.MyPeople.Details.Street;
            txtrealcity.Text = GLOBALVARS.MyPeople.City;
            txtcoverhead.Text = GLOBALVARS.MyPeople.CoverHead;
            txteda.Text = GLOBALVARS.MyPeople.Eda;
            txtfacecolor.Text = GLOBALVARS.MyPeople.FaceColor;
            txtfat.Text = GLOBALVARS.MyPeople.Weight;
            txtsexs.Text = GLOBALVARS.MyPeople.Sexs;
            txtfname.Text = GLOBALVARS.MyPeople.FirstName;
            txtfuturelearn.Checked = GLOBALVARS.MyPeople.FutureLearn;
            txtGorTorN.Text = GLOBALVARS.MyPeople.GorTorN;
            txtlearnstatus.Text= GLOBALVARS.MyPeople.LearnStaus;
            txtstatus.Text = GLOBALVARS.MyPeople.Status;

            txtheight.Text = GLOBALVARS.MyPeople.Tall.ToString();
            txtlname.Text = GLOBALVARS.MyPeople.Lasname;
            txtlooks.Text = GLOBALVARS.MyPeople.Looks;
            txtnotes.Text = GLOBALVARS.MyPeople.Details.Notes;
            txtpetichut.Text = GLOBALVARS.MyPeople.OpenHead;
            txtStakeM.Text = GLOBALVARS.MyPeople.StakeM;
            txtTneedM.Text = GLOBALVARS.MyPeople.TneedE;
            txtwhoami.Text = GLOBALVARS.MyPeople.Details.WhoAmI;
            txtwhoiwant.Text = GLOBALVARS.MyPeople.Details.WhoIWant;
            txtzerem.Text = GLOBALVARS.MyPeople.Zerem;
            txtbeard.Text = GLOBALVARS.MyPeople.Beard;
            txtmoneytoschadchan.Text = GLOBALVARS.MyPeople.Details.MoneyToShadchan;


            txtwithravin.Text = GLOBALVARS.MyPeople.Details.WithRavIn;
            txtstatus.Text = GLOBALVARS.MyPeople.Status;
            txtownchildren.Text = GLOBALVARS.MyPeople.Details.OwnChildrenCount.ToString();


            txtschools.Text= GLOBALVARS.MyPeople.Details.Schools;
            txtdadname.Text = GLOBALVARS.MyPeople.Details.DadName;
            txtmomname.Text = GLOBALVARS.MyPeople.Details.MomName;
            txtmomlname.Text = GLOBALVARS.MyPeople.Details.MomLname;
            txtdadwork.Text = GLOBALVARS.MyPeople.DadWork;
            
            txtfailds.Text = GLOBALVARS.MyPeople.Details.Faileds;
            txtfriends.Text = GLOBALVARS.MyPeople.Details.FriendsInfo;
            txtzevet.Text = GLOBALVARS.MyPeople.Details.ZevetInfo;
            if(!GLOBALVARS.OpenForTempPeople)
            txtchadhan.Text = GLOBALVARS.MyPeople.Details.Chadchan.ToString();
            
            
            txtchildern.Text = GLOBALVARS.MyPeople.Details.ChildrenCount.ToString();
            txtsibilngschool.Text = GLOBALVARS.MyPeople.Details.SiblingsSchools;
            txtmoneygives.Text = GLOBALVARS.MyPeople.Details.MoneyGives.ToString();
            txtmoneynotes.Text = GLOBALVARS.MyPeople.Details.MoneyNotes;
            txtmoneyrequired.Text = GLOBALVARS.MyPeople.Details.MoneyRequired.ToString();
            txttel1.Text = GLOBALVARS.MyPeople.Details.Tel1;
            txttel2.Text = GLOBALVARS.MyPeople.Details.Tel2;
            txtmecuthanim.Text = GLOBALVARS.MyPeople.Details.MechutanimNames;
            txtsubscribie.Checked = GLOBALVARS.MyPeople.Register.Subscription;
            txthomerav.Text = GLOBALVARS.MyPeople.Details.HomeRav;
            txtworkplace.Text = GLOBALVARS.MyPeople.WorkPlace;
            txtmomwork.Text= GLOBALVARS.MyPeople.Details.MomWork;
            lbllastupdate.Text += GLOBALVARS.MyPeople.Register.LastUpdate.ToString();
            
            if (GLOBALVARS.MyPeople.Show == (int)People.ShowTypes.HideDetails && GLOBALVARS.MyUser.Control==User.TypeControl.User) { 
                chkhidepersonal.Checked = true;
                btnshowhide.Visible = true;
                txtfname.PasswordChar = '*';
                txtfname.Enabled=false;
                txtlname.PasswordChar = '*';
                txtlname.Enabled = false;
                txttel1.PasswordChar='*';
                txttel1.Enabled = false;
            }
            if (GLOBALVARS.MyPeople.Show == (int)People.ShowTypes.VIP)
                rbtn_showto.Checked = true;

            if (GLOBALVARS.MyPeople.Show == (int)People.ShowTypes.HideDetails)
                chkhidepersonal.Checked = true;

            if (GLOBALVARS.MyPeople.Show == (int)People.ShowTypes.HideFromUsers)
                chkhidefromshadchan.Checked = true;


            if (!GLOBALVARS.OpenForTempPeople)
                txtdateadd.Value = GLOBALVARS.MyPeople.Register.RegDate;
            if (GLOBALVARS.MyUser.Control > User.TypeControl.User && GLOBALVARS.MyUser.Control != User.TypeControl.Lock &&
                !GLOBALVARS.OpenForTempPeople)
            {
                txtregnotes.Text=GLOBALVARS.MyPeople.Register.Notes;
                txtpaid.Checked=GLOBALVARS.MyPeople.Register.Paid;
                txtpaidcount.Text=GLOBALVARS.MyPeople.Register.PaidCount.ToString();
                txtpaydate.Value=GLOBALVARS.MyPeople.Register.PayDate;
                txtpayway.Text=GLOBALVARS.MyPeople.Register.PayWay;
                txtdateadd.Value=GLOBALVARS.MyPeople.Register.RegDate;
                GLOBALVARS.MyPeople.Register.RegType = (RegisterInfo.RegTypeE)1;
            }
        }
        private void LoadTxtsToPeople()
        {
            GLOBALVARS.MyPeople.Details.Chadchan = "";
            


            GLOBALVARS.MyPeople.Age = (float)txtage.Value;
            GLOBALVARS.MyPeople.Beard = txtbeard.Text;
            GLOBALVARS.MyPeople.Background=txtbg.Text;
            GLOBALVARS.MyPeople.City = txtrealcity.Text;
            GLOBALVARS.MyPeople.CoverHead=txtcoverhead.Text;
            GLOBALVARS.MyPeople.Eda=txteda.Text;
            GLOBALVARS.MyPeople.Details.Schools = txtschools.Text;
            GLOBALVARS.MyPeople.FaceColor=txtfacecolor.Text;
            GLOBALVARS.MyPeople.Weight=txtfat.Text;
            GLOBALVARS.MyPeople.Sexs=txtsexs.Text;
            GLOBALVARS.MyPeople.FirstName=txtfname.Text;
            GLOBALVARS.MyPeople.FutureLearn=txtfuturelearn.Checked ;
            
            GLOBALVARS.MyPeople.GorTorN=txtGorTorN.Text;
            if (txtGorTorN.SelectedIndex == 0)
                GLOBALVARS.MyPeople.GorTorN = "";
            GLOBALVARS.MyPeople.LearnStaus =txtlearnstatus.Text;


            GLOBALVARS.MyPeople.Tall=(float)txtheight.Value;
            GLOBALVARS.MyPeople.Lasname=txtlname.Text;
            GLOBALVARS.MyPeople.Looks=txtlooks.Text;
            GLOBALVARS.MyPeople.Details.Notes=txtnotes.Text;
            GLOBALVARS.MyPeople.OpenHead=txtpetichut.Text;
            GLOBALVARS.MyPeople.StakeM=txtStakeM.Text;
            GLOBALVARS.MyPeople.TneedE=txtTneedM.Text;
            GLOBALVARS.MyPeople.Details.WhoAmI=txtwhoami.Text;
            GLOBALVARS.MyPeople.Details.WhoIWant=txtwhoiwant.Text;
            GLOBALVARS.MyPeople.Zerem=txtzerem.Text;
            GLOBALVARS.MyPeople.Beard=txtbeard.Text;

            GLOBALVARS.MyPeople.Details.OwnChildrenCount = (int)txtownchildren.Value;
            GLOBALVARS.MyPeople.Details.WithRavIn =txtwithravin.Text;
            GLOBALVARS.MyPeople.Status = txtstatus.Text;
            GLOBALVARS.MyPeople.Details.MomWork = txtmomwork.Text;
            GLOBALVARS.MyPeople.Details.MoneyToShadchan=txtmoneytoschadchan.Text;


            GLOBALVARS.MyPeople.Details.Street = txtcity.Text;
            GLOBALVARS.MyPeople.Details.DadName=txtdadname.Text;
            GLOBALVARS.MyPeople.Details.MomName=txtmomname.Text;
            GLOBALVARS.MyPeople.Details.MomLname=txtmomlname.Text;
            GLOBALVARS.MyPeople.DadWork=txtdadwork.Text;
            
            GLOBALVARS.MyPeople.Details.Faileds=txtfailds.Text;
            GLOBALVARS.MyPeople.Details.FriendsInfo=txtfriends.Text;
            GLOBALVARS.MyPeople.Details.ZevetInfo=txtzevet.Text;
            
            GLOBALVARS.MyPeople.Details.ChildrenCount=(int)txtchildern.Value;
            GLOBALVARS.MyPeople.Details.SiblingsSchools=txtsibilngschool.Text;
            GLOBALVARS.MyPeople.Details.MoneyGives= (float)txtmoneygives.Value;
            GLOBALVARS.MyPeople.Details.MoneyNotes=txtmoneynotes.Text;
            GLOBALVARS.MyPeople.Details.MoneyRequired=(float)txtmoneyrequired.Value;
            GLOBALVARS.MyPeople.Details.Tel1=txttel1.Text;
            GLOBALVARS.MyPeople.Details.Tel2=txttel2.Text;
            GLOBALVARS.MyPeople.Details.MechutanimNames=txtmecuthanim.Text;
            GLOBALVARS.MyPeople.Register.Subscription=txtsubscribie.Checked;
            GLOBALVARS.MyPeople.Details.HomeRav=txthomerav.Text;
            GLOBALVARS.MyPeople.WorkPlace=txtworkplace.Text;
            GLOBALVARS.MyPeople.Register.Notes = txtregnotes.Text;
            if (rbtn_everyone.Checked) { 
                GLOBALVARS.MyPeople.Show = (int)People.ShowTypes.Show;

            }
            else if (rbtn_showto.Checked)
            {
                GLOBALVARS.MyPeople.Show = (int)People.ShowTypes.VIP;
                string temp = "";
                foreach (KeyValueClass x in lstchadchanim.Items)
                {
                    temp += "{" + x.Value.ToString() + "}";
                }
                GLOBALVARS.MyPeople.Details.Chadchan = temp;
            }
                

            if (personaluser) { 
                GLOBALVARS.MyPeople.Show = (int)People.ShowTypes.Personal;
                GLOBALVARS.MyPeople.Details.Chadchan = "{" + GLOBALVARS.MyUser.ID + "}";
            }



            if (chkhidefromshadchan.Checked)
                GLOBALVARS.MyPeople.Show = (int)People.ShowTypes.HideFromUsers;
            else if(chkhidepersonal.Checked)
                GLOBALVARS.MyPeople.Show = (int)People.ShowTypes.HideDetails;
            

            if (!GLOBALVARS.OpenForTempPeople)
                GLOBALVARS.MyPeople.Register.RegDate = txtdateadd.Value;
            if (GLOBALVARS.MyUser.Control > User.TypeControl.User && GLOBALVARS.MyUser.Control != User.TypeControl.Lock && 
                !GLOBALVARS.OpenForTempPeople)
            {
                GLOBALVARS.MyPeople.Register.Notes = txtregnotes.Text;
                GLOBALVARS.MyPeople.Register.Paid = txtpaid.Checked;
                GLOBALVARS.MyPeople.Register.PaidCount = (float)txtpaidcount.Value;
                GLOBALVARS.MyPeople.Register.PayDate = txtpaydate.Value;
                GLOBALVARS.MyPeople.Register.PayWay = txtpayway.Text;
                GLOBALVARS.MyPeople.Register.RegDate = txtdateadd.Value;
                GLOBALVARS.MyPeople.Register.RegType = (RegisterInfo.RegTypeE)1;
            }
        }
       
        private void label11_Click(object sender, EventArgs e)
        {

        }
        private void LoadLbls()
        {
            foreach (Labels lbl in GLOBALLABELS.AllLabels)
            {
                if (lbl == null)
                    continue;
                switch (lbl.Catg)
                {
                    case "petichut":
                        txtpetichut.Items.Add(lbl.Label);
                        break;
                    case "zerem":
                        txteda.Items.Add(lbl.Label);
                        break;
                    case "fat":
                        txtfat.Items.Add(lbl.Label);
                        break;
                    case "facecolor":
                        txtfacecolor.Items.Add(lbl.Label);
                        break;
                    case "looks":
                        txtlooks.Items.Add(lbl.Label);
                        break;
                    case "bg":
                        txtbg.Items.Add(lbl.Label);
                        break;
                    case "beard":
                        txtbeard.Items.Add(lbl.Label);
                        break;
                    case "coverhead":
                        txtcoverhead.Items.Add(lbl.Label);
                        break;
                    case "sexs":
                        txtsexs.Items.Add(lbl.Label);
                        break;
                }
            }
            txtfat.SelectedIndex = 3;
            txtfacecolor.SelectedIndex = 2;
            txtlooks.SelectedIndex = 2;
            txtGorTorN.SelectedIndex = 0;
        }
        private void DetailForm_Load(object sender, EventArgs e)
        {
            
            LoadLbls();
            ShowWhatNeed();
            
            if (GLOBALVARS.OpenDetailsForAdd)
                return;
            if (GLOBALVARS.OpenForPersonalAdd) {
                txtdemotxt1.Visible = txtdemotxt2.Visible=personaluser = true;
                return;
            }
            if (GLOBALVARS.OpenForPersonalEdit || GLOBALVARS.OpenForPersonalAdd) { 
                personaluser = true;
                txtdemotxt1.Visible = txtdemotxt2.Visible=true;
            }

            LoadPeopleToTxts();

            
        }
        private void ShowWhatNeed()
        {
            switch (GLOBALVARS.MyUser.Control)
            {
                case User.TypeControl.User:
                    if((GLOBALVARS.MyUser.CanAdd && GLOBALVARS.OpenDetailsForAdd) || GLOBALVARS.OpenForTempPeople || GLOBALVARS.OpenForPersonalAdd || 
                        GLOBALVARS.OpenForPersonalEdit || GLOBALVARS.MyUser.CanEdit) 
                        btnconfirm.Visible = true;

                    tabControl1.TabPages.Remove(tabPage4);
                    tabControl1.TabPages.Remove(tabPage5);
                    btnrewnewpeople.Visible = false;
                    if (!GLOBALVARS.OpenDetailsForAdd)
                        btnshadcanupdate.Visible = true;
                    
                    btnstatuschg.Visible = true;
                    if (GLOBALVARS.OpenForTempPeople || GLOBALVARS.OpenForPersonalAdd || GLOBALVARS.OpenForPersonalEdit)
                    {
                        btnceratehtml.Visible = false;
                        btnrewnewpeople.Visible = false;
                        btnstatuschg.Visible = false;
                        btnchadchanupdate.Visible = false;
                        btnshowinfo.Visible = false;
                        btnshadcanupdate.Visible = false;  
                    }
                 //   CheckForUserMeetings();
                    break;
                case User.TypeControl.Admin:
                case User.TypeControl.Manger:
                    btnconfirm.Visible = true;
                    txtsubscribie.Enabled = true;
                    if(GLOBALVARS.OpenDetailsForAdd==false)
                        btnrewnewpeople.Visible = true;
                    txtdateadd.Enabled = true;
                    txtchadhan.Enabled = true;
                    gpreg.Visible = true;
                    btnshadcanupdate.Visible = false;
                    break;
                default:
                    btnconfirm.Visible = false;
                    btnshadcanupdate.Visible = false;
                    break;
            }
        }
        private void txtpetichut_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void txtfname_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void btnconfirm_Click(object sender, EventArgs e)
        {
            LoadTxtsToPeople();
            // try {
            GLOBALVARS.LastPeopleCheckDB = DateTime.Now;
            UpdateManager.UpdateLastTimeCheckToDb();
            if (GLOBALVARS.OpenDetailsForAdd || GLOBALVARS.OpenForPersonalAdd)
            {
                People p = GLOBALVARS.MyPeople;
                p.Details.Pic = "sample49";
                if (People.InsretNew(p)) { 
                    MessageBox.Show("נוסף בהצלחה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("אירעה שגיאה. אנא בדקו שכל הנתונים שהזנתם תקינים", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                People.UpdatePeople(false);
         //   }
         /*   catch
            {
                DBConnection.ConnectAgain();
            }*/
        }

        /*private void UpdatePeople(bool Wedding,bool Temp=false,bool Shadchan=false)
        {
            
            string sql = "";
            string reasonsql = "";
            string temprelatedid = "";
            string where = "";
            string Rwhere = "";
            string tblpeople = "";
            bool PlusTblReg = false;
            string tbldetails = "";
            SqlParameter[] prms = new SqlParameter[70];
            People p = GLOBALVARS.MyPeople;
            LoadTxtsToPeople();
            if (Shadchan)
                p.Details.Chadchan = GLOBALVARS.MyUser.ID;
            switch (GLOBALVARS.MyUser.Control)
            {
                case User.TypeControl.User:
                    tbldetails = "TempPeopleDetails";
                    tblpeople = "TempPeoples";
                    temprelatedid = BuildSql.UpdateSql(out prms[60], p.ID, "MRELATEDID");
                    break;
                case User.TypeControl.Admin:
                case User.TypeControl.Manger:
                    tbldetails = "PeopleDetails";
                    tblpeople = "Peoples";
                    PlusTblReg = true;
                    where=" where id=" + p.ID + " ";
                    Rwhere = " where relatedid=" + p.ID + " ";
                    break;
            }
            if (Wedding)
            {
                reasonsql += BuildSql.UpdateSql(out prms[59],1, "reason");
            }
            sql = "BEGIN TRANSACTION ";
           
            

            sql += "update " + tblpeople + " SET " +
                BuildSql.UpdateSql(out prms[0], p.Age, "age") +
                BuildSql.UpdateSql(out prms[1], p.Background, "background") +
                BuildSql.UpdateSql(out prms[2], p.Beard, "Beard") +
                BuildSql.UpdateSql(out prms[3], p.City, "City") +
                BuildSql.UpdateSql(out prms[4], p.CoverHead, "CoverHead") +
                BuildSql.UpdateSql(out prms[5], p.DadWork, "DadWork") +
                BuildSql.UpdateSql(out prms[6], p.Eda, "eda") +
                BuildSql.UpdateSql(out prms[7], p.FaceColor, "FaceColor") +
                BuildSql.UpdateSql(out prms[8], p.FirstName, "FirstName") +
                BuildSql.UpdateSql(out prms[9], p.FutureLearn, "FutureLearn") +
                BuildSql.UpdateSql(out prms[10], p.GorTorN, "GorTorN") +
                BuildSql.UpdateSql(out prms[11], p.Lasname, "Lastname") +
                BuildSql.UpdateSql(out prms[12], p.Looks, "Looks") +
                BuildSql.UpdateSql(out prms[13], p.OpenHead, "OpenHead") +
                temprelatedid +
                BuildSql.UpdateSql(out prms[15], p.Sexs, "Sexs") +
                BuildSql.UpdateSql(out prms[16], p.Show, "show") +
                BuildSql.UpdateSql(out prms[17], p.StakeM, "StakeM") +
                BuildSql.UpdateSql(out prms[18], p.Status, "Status") +
                BuildSql.UpdateSql(out prms[19], p.Tall, "Tall") +
                BuildSql.UpdateSql(out prms[20], p.TneedE, "TneedE") +
                BuildSql.UpdateSql(out prms[59], p.LearnStaus, "LearnStatus") +
                BuildSql.UpdateSql(out prms[21], p.Zerem, "Zerem") +
                reasonsql+
                BuildSql.UpdateSql(out prms[22], p.Weight, "fat", true) + where + ";";

          

            sql += " update " + tbldetails + " SET " +
                BuildSql.UpdateSql(out prms[23], p.Details.Chadchan, "Chadchan") +
                BuildSql.UpdateSql(out prms[24], p.Details.ChildrenCount, "ChildrenCount") +
                BuildSql.UpdateSql(out prms[25], p.Details.DadName, "DadName") +
                BuildSql.UpdateSql(out prms[26], p.Details.Faileds, "Faileds") +
                BuildSql.UpdateSql(out prms[27], p.Details.FriendsInfo, "FriendsInfo") +
                BuildSql.UpdateSql(out prms[28], p.Details.HomeRav, "HomeRav") +
                BuildSql.UpdateSql(out prms[29], p.Details.MechutanimNames, "MechutanimNames") +
                BuildSql.UpdateSql(out prms[30], p.Details.MomLname, "MomLname") +
                BuildSql.UpdateSql(out prms[31], p.Details.MomName, "MomName") +
                BuildSql.UpdateSql(out prms[32], p.Details.MomWork, "MomWork") +
                BuildSql.UpdateSql(out prms[33], p.Details.MoneyGives, "MoneyGives") +
                BuildSql.UpdateSql(out prms[34], p.Details.MoneyNotes, "MoneyNotes") +
                BuildSql.UpdateSql(out prms[35], p.Details.MoneyRequired, "MoneyRequired") +
                BuildSql.UpdateSql(out prms[36], p.Details.Notes, "Notes") +
                BuildSql.UpdateSql(out prms[37], p.Details.OwnChildrenCount, "OwnChildrenCount") +
                BuildSql.UpdateSql(out prms[38], p.Details.RelatedId, "RelatedId") +
                BuildSql.UpdateSql(out prms[39], p.Details.Schools, "Schools") +
                BuildSql.UpdateSql(out prms[40], p.Details.SiblingsSchools, "SiblingsSchools") +
                BuildSql.UpdateSql(out prms[41], p.Details.Street, "Street") +
                BuildSql.UpdateSql(out prms[42], p.Details.Tel1, "Tel1") +
                BuildSql.UpdateSql(out prms[43], p.Details.Tel2, "Tel2") +
                BuildSql.UpdateSql(out prms[44], p.Details.WhoAmI, "WhoAmI") +
                BuildSql.UpdateSql(out prms[45], p.Details.WhoIWant, "WhoIWant") +
                BuildSql.UpdateSql(out prms[46], p.Details.WithRavIn, "WithRavIn") +
                
                BuildSql.UpdateSql(out prms[48], p.WorkPlace, "WorkPlace") +
                BuildSql.UpdateSql(out prms[49], p.Details.ZevetInfo, "ZevetInfo") +
                BuildSql.UpdateSql(out prms[61], p.Details.MoneyToShadchan, "MoneyToShadchan",true)
                + Rwhere + ";";
            // ^ it right



            if (PlusTblReg) { 
            sql += " update RegisterInfo SET " +
                 BuildSql.UpdateSql(out prms[50], p.Register.Notes, "regnotes") +
                 BuildSql.UpdateSql(out prms[51], p.Register.Paid, "paid") +
                 BuildSql.UpdateSql(out prms[52], p.Register.PaidCount, "PaidCount") +
                 BuildSql.UpdateSql(out prms[53], p.Register.PayDate, "PayDate") +
                 BuildSql.UpdateSql(out prms[54], p.Register.PayWay, "PayWay") +
                 BuildSql.UpdateSql(out prms[55], p.Register.RegDate, "regdate") +
                 BuildSql.UpdateSql(out prms[56], p.Register.RegType, "Type") +
                 BuildSql.UpdateSql(out prms[57], GLOBALVARS.MyUser.ID, "ByUser") +
                 BuildSql.UpdateSql(out prms[58], p.Register.Subscription, "Subscription", true) + Rwhere + "; ";
            }
            sql+= "COMMIT";
            if(DBFunction.Execute(sql, prms))
            {
                if(GLOBALVARS.MyUser.Control==User.TypeControl.User)
                    MessageBox.Show("השינוי נשלח למערכת \n המערכת תאשר את השינוי בקרוב", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("שונה בהצלחה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("אירעה שגיאה","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }*/

        private void btnshadcanupdate_Click(object sender, EventArgs e)
        {
            LoadTxtsToPeople();
            TempUpdate frmupdate = new TempUpdate();
            frmupdate.ShowDialog();
        }

        private void btnstatuschg_Click(object sender, EventArgs e)
        {
            if (GLOBALVARS.MyUser.Control == User.TypeControl.Admin)
                People.DeletePeople(GLOBALVARS.MyPeople.ID);
            else
                People.UpdatePeople(true, false);
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        

        private void txtsexs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void txtcoverhead_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void txtbeard_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void txtfuturelearn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnchadchanupdate_Click(object sender, EventArgs e)
        {
            //add date row in log table
            Log.AddAction(Log.ActionType.StartDate, new Log(Log.ActionType.StartDate,
                    GLOBALVARS.MyPeople.FirstName + ' ' +
                GLOBALVARS.MyPeople.Lasname + "^" + GLOBALVARS.MyPeople.ID));
          //  Log lg = new Log(Log.ActionType.StartDate, );
            People.UpdatePeople(false,true,"התחיל פגישות");

        }
       

        

        private void btnchadchanlist_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtStakeM_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkhidefromshadchan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkhidefromshadchan.Checked) {
                chkhidepersonal.Enabled = false;
              }
            else
            {
                chkhidepersonal.Enabled = true;
            }

        }

        private void btnshowhide_Click(object sender, EventArgs e)
        {
            if (PeopleManipulations.ShowHide()) {
                
                txtfname.PasswordChar = '\0';
                txtfname.Enabled = true;
                txtlname.PasswordChar = '\0';
                txtlname.Enabled = true;
                txttel1.PasswordChar = '\0';
                txttel1.Enabled = true;
            }
            else
            People.AllowLimited();
        }
     

        private void txtctrlplusa(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
            {
                ((TextBox)sender).SelectAll();
            }
            else if (e.Control & e.KeyCode == Keys.Back)
            {
                SendKeys.SendWait("^+{LEFT}{BACKSPACE}");
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                ((TextBox)sender).Text += (string)Clipboard.GetData("Text");
                e.Handled = true;
            }
        }

        private void txtfailds_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnotes_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnceratehtml_Click(object sender, EventArgs e)
        {
            General.CreateReport();
            Report r = new Report();
            r.ShowDialog();
        }

        private void btnewnewpeople_Click(object sender, EventArgs e)
        {
            LoadTxtsToPeople();
            int id = GLOBALVARS.MyPeople.ID;
            People.DeletePeople(id,false);
            People p = GLOBALVARS.MyPeople;
            People.InsretNew(p);
            MessageBox.Show("חודש בהצלחה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void txtstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtlooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtfacecolor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtfat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txteda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtlearnstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnshowinfo_Click(object sender, EventArgs e)
        {
            string info = "";
            info = txttel1.Text + "\n" + txttel2.Text;
            Forms.FrmPhone frmphone = new Forms.FrmPhone(info,txtfname.Text + " " + txtlname.Text +"^" + GLOBALVARS.MyPeople.ID.ToString(), GLOBALVARS.MyPeople.ID.ToString());
            Log.AddAction(Log.ActionType.PhoneFormOpen, new Log(Log.ActionType.PhoneFormOpen, txtfname.Text + " " + txtlname.Text + "^" + GLOBALVARS.MyPeople.ID.ToString()));
            frmphone.ShowDialog();
            
        }

        private void btn_calcage_Click(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now - txtdateadd.Value;
            double time = ts.TotalDays / 365;
            time += (double)txtage.Value;
           
            txtage.Value = (decimal)time;
            txtage.ForeColor = Color.Red;
        }

        private void rbtn_everyone_CheckedChanged(object sender, EventArgs e)
        {
            GLOBALVARS.MyPeople.Show = 0;
            cmb_shadchanim.Enabled = false;
            btn_addchadchan.Enabled = false;
            btn_removechadchan.Enabled = false;
            lstchadchanim.Enabled = false;
        }

        private void rbtn_showto_CheckedChanged(object sender, EventArgs e)
        {
            GLOBALVARS.MyPeople.Show = 4;
            cmb_shadchanim.Enabled = true;
            btn_addchadchan.Enabled = true;
            btn_removechadchan.Enabled = true;
            lstchadchanim.Enabled = true;
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedIndex == 3 && Tab4Firsttime)
            {
                if (GLOBALVARS.OpenForTempPeople)
                {
                    MessageBox.Show("לא זמין במצב עדכון שדכן", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                foreach (KeyValueClass x in MainForm.Shadchanim)
                {
                    cmb_shadchanim.Items.Add(x);
                    if (!GLOBALVARS.OpenDetailsForAdd && !GLOBALVARS.OpenForTempPeople && GLOBALVARS.MyPeople.Details.Chadchan.Contains("{" + x.Value + "}"))
                        lstchadchanim.Items.Add(x);
                }

                Tab4Firsttime = false; 
                
            }
            if (tabControl1.SelectedIndex == 4 && Tab5Firsttime)
            {
                MakeReport report = new MakeReport(MakeReport.ReportType.Client);
                string path = report.CreateClientReport(txtfname.Text + " " +txtlname.Text,GLOBALVARS.MyPeople.ID, new DateTime(2015,01,01), DateTime.Now);
                webBrowser1.Navigate(path);
                Tab5Firsttime = false;
            }
        }

        private void btn_addchadchan_Click(object sender, EventArgs e)
        {
            if(cmb_shadchanim.SelectedIndex != -1) {
                //KeyValueClass temp =(KeyValueClass) ;
                lstchadchanim.Items.Add(cmb_shadchanim.SelectedItem);
            }
            
        }

        private void btn_removechadchan_Click(object sender, EventArgs e)
        {
            if (lstchadchanim.SelectedIndex != -1)
                lstchadchanim.Items.RemoveAt(lstchadchanim.SelectedIndex);
        }

        private void DetailForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GLOBALVARS.OpenForPersonalEdit = GLOBALVARS.OpenForPersonalAdd = GLOBALVARS.OpenDetailsForAdd = GLOBALVARS.OpenForTempPeople = false;
        }

        private void txtdemotxt1_TextChanged(object sender, EventArgs e)
        {
            txttel1.Text = txtdemotxt1.Text;
        }

        private void txtdemotxt2_TextChanged(object sender, EventArgs e)
        {
            txttel2.Text = txtdemotxt2.Text;
        }

        private void txttel1_TextChanged(object sender, EventArgs e)
        {
            txtdemotxt1.Text = txttel1.Text;
        }

        private void txttel2_TextChanged(object sender, EventArgs e)
        {
            txtdemotxt2.Text = txttel2.Text;
        }
    }
}
