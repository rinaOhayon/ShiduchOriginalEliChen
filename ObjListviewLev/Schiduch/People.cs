using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

using System.Data.SqlClient;
using System.Drawing;

namespace Schiduch
{
    public class People
    {
        public string FindMatch = "מצא התאמה";
        public string OpenCard = "פרטים מלאים";
        public string AgeCorrect = "גיל מדויק";
        public Color Itemcolor = Color.Black;
        public enum SexsType { Male = 1, Female = 2 };
        public enum ShowTypes { Show=0,HideDetails=1,HideFromUsers,VIP=4,Personal=5,Delete=8}
        public enum ReasonType { Wedding = 1, Edtinging = 0,ShadChan=2,AllowLimited=3 };
        public string FirstName;
        public string Lasname;
        public int Reason;
        public int ByUser;
        public int TempId;
        public string Sexs;
        public float Age;
        public float Tall;
        public string Weight;
        public string FaceColor;
        public string Looks;
        public string WorkPlace; //added
        public string Beard;
        public string City;
        public string Zerem;
        public string Eda;
        public bool FutureLearn;
        public string LearnStaus;
        public string Background;
        public string DadWork;
        public string CoverHead;
        public string GorTorN;
        public string TneedE;
        public string StakeM;
        public string OpenHead;
        public string Status;
        public int RealId;
        public int Show=0;
        public RegisterInfo Register;
        public PeopleDetails Details;
        public string TempNotes;
        
        public int ID;
        public People()
        {
            this.Register = new RegisterInfo();
            this.Details = new PeopleDetails();
        }
        public static bool InsretNew(People people)
        {
            SqlParameter[] prms = new SqlParameter[59];
            string sql, sqlpeoples, sqldetails, sqlregister;
            sqlpeoples = "INSERT INTO Peoples VALUES(" +
                BuildSql.InsertSql(out prms[0], people.FirstName) +
                BuildSql.InsertSql(out prms[1], people.Lasname) +
                BuildSql.InsertSql(out prms[2], people.Sexs) +
                BuildSql.InsertSql(out prms[3], people.Age) +
                BuildSql.InsertSql(out prms[4], people.Tall) +
                BuildSql.InsertSql(out prms[5], people.Weight) +
                BuildSql.InsertSql(out prms[6], people.FaceColor) +
                BuildSql.InsertSql(out prms[7], people.Looks) +
                BuildSql.InsertSql(out prms[8], people.Beard) +
                BuildSql.InsertSql(out prms[9], people.City) +
                BuildSql.InsertSql(out prms[10], people.Zerem) +
                BuildSql.InsertSql(out prms[11], people.Eda) +
                BuildSql.InsertSql(out prms[12], people.FutureLearn) +
                BuildSql.InsertSql(out prms[13], people.Background) +
                BuildSql.InsertSql(out prms[14], people.DadWork) +
                BuildSql.InsertSql(out prms[15], people.CoverHead) +
                BuildSql.InsertSql(out prms[16], people.GorTorN) +
                BuildSql.InsertSql(out prms[17], people.TneedE) +
                BuildSql.InsertSql(out prms[18], people.StakeM) +
                BuildSql.InsertSql(out prms[19], people.OpenHead) +
                BuildSql.InsertSql(out prms[20], people.Status) +
                people.Show + "," +
                 BuildSql.InsertSql(out prms[55], people.LearnStaus,true) +
                 ");";

            sqldetails = "INSERT INTO PeopleDetails VALUES(" +
            BuildSql.InsertSql(out prms[21], people.Details.Street) +
            BuildSql.InsertSql(out prms[23], people.Details.Schools) +
            BuildSql.InsertSql(out prms[24], people.Details.Tel1) +
            BuildSql.InsertSql(out prms[25], people.Details.Tel2) +
            BuildSql.InsertSql(out prms[26], people.Details.WhoAmI) +
            BuildSql.InsertSql(out prms[27], people.Details.WhoIWant) +
            BuildSql.InsertSql(out prms[28], people.Details.WithRavIn) +
            BuildSql.InsertSql(out prms[29], people.Details.DadName) +
            BuildSql.InsertSql(out prms[30], people.Details.MomName) +
            BuildSql.InsertSql(out prms[31], people.Details.ChildrenCount) +
            BuildSql.InsertSql(out prms[32], people.Details.SiblingsSchools) +
            BuildSql.InsertSql(out prms[33], people.Details.MomLname) +
            BuildSql.InsertSql(out prms[34], people.Details.MomWork) +
            BuildSql.InsertSql(out prms[35], people.Details.MoneyGives) +
            BuildSql.InsertSql(out prms[36], people.Details.MoneyRequired) +
            BuildSql.InsertSql(out prms[37], people.Details.MoneyNotes) +
            BuildSql.InsertSql(out prms[38], people.Details.HomeRav) +
            BuildSql.InsertSql(out prms[39], people.Details.MechutanimNames) + "@DataID," +
            BuildSql.InsertSql(out prms[40], people.Details.ZevetInfo) +
            BuildSql.InsertSql(out prms[41], people.Details.FriendsInfo) +
            BuildSql.InsertSql(out prms[42], people.Details.Chadchan) +
            BuildSql.InsertSql(out prms[43], people.Details.Faileds) +
            BuildSql.InsertSql(out prms[44], people.Details.Notes) +
            BuildSql.InsertSql(out prms[45], people.Details.OwnChildrenCount) +
            BuildSql.InsertSql(out prms[46], people.WorkPlace) +
            BuildSql.InsertSql(out prms[56], people.Details.MoneyToShadchan, true)+
            ");";


            sqlregister = "INSERT INTO RegisterInfo VALUES(" +
                 BuildSql.InsertSql(out prms[47], people.Register.Subscription) +
                 BuildSql.InsertSql(out prms[48], people.Register.PayWay) +
                 BuildSql.InsertSql(out prms[49], (int)people.Register.RegType) +
                 BuildSql.InsertSql(out prms[50], people.Register.Paid) +
                 BuildSql.InsertSql(out prms[51], people.Register.PaidCount) +
                 BuildSql.InsertSql(out prms[52], people.Register.RegDate.Date) +
                 BuildSql.InsertSql(out prms[53], people.Register.PayDate.Date) +
                 BuildSql.InsertSql(out prms[54], people.Register.Notes) + "@DataID" + "," + 
                 GLOBALVARS.MyUser.ID + "," +
                  BuildSql.InsertSql(out prms[57], DateTime.Now.Date,true) +");";

            sql = "BEGIN TRANSACTION " +
            "DECLARE @DataID int;" +
            sqlpeoples +
            "SELECT @DataID = scope_identity();" +
            sqldetails +
            sqlregister +
            "COMMIT";

            return DBFunction.Execute(sql, prms);
        }
        public static SqlDataReader ReadAll(int temp=0,bool notall=false,bool login=false,bool persnoal_vip=false,bool vip=false)
        {
            try
            {
                string show = " AND show <> 8 AND (show <2 or (show=5 and chadchan like '%{" + GLOBALVARS.MyUser.ID + "}%') or (show=4 and chadchan like '%{" + GLOBALVARS.MyUser.ID + "}%'))";
                if (persnoal_vip)
                    show = " where (show=5 and chadchan like '%{" + GLOBALVARS.MyUser.ID + "}%') or (show=4 and chadchan like '%{" + GLOBALVARS.MyUser.ID + "}%')";
                if (GLOBALVARS.MyUser.Control == User.TypeControl.Manger || GLOBALVARS.MyUser.Control == User.TypeControl.Admin) { 
                    show = "where show <> 8";
                    if(persnoal_vip)
                        show = " where show > 0 and show <> 8";
                }
                string sql = "select * from peoples p inner join peopledetails pd on p.ID=pd.relatedid inner join " +
                    "registerinfo r on pd.relatedid=r.relatedid " +show;
                if (temp == 1) { 
                    sql= "select * from temppeoples p left join temppeopledetails pd on p.TID=pd.relatedid " + show;
                }
                if (notall)
                    sql = "select top 100 * from peoples p inner join peopledetails pd on p.ID=pd.relatedid inner join " +
                   "registerinfo r on pd.relatedid=r.relatedid " + show + " order by pdid desc";
                if(login)
                    sql = "select top 50 MONEYTOSHADCHAN,chadchan,id,show,schools,sexs,firstname,lastname,tall,age,notes from peoples p inner join peopledetails pd on p.ID=pd.relatedid " + show +  " order by id desc";
                if (persnoal_vip)
                    sql = "select MONEYTOSHADCHAN,chadchan,id,show,schools,sexs,firstname,lastname,tall,age,notes from peoples p inner join peopledetails pd on p.ID=pd.relatedid " + show + " order by show desc";
                if(vip)
                    sql = "select MONEYTOSHADCHAN,chadchan,id,show,schools,sexs,firstname,lastname,tall,age,notes from peoples p inner join peopledetails pd on p.ID=pd.relatedid " + show + " order by show desc";
                SqlDataReader reader = DBFunction.ExecuteReader(sql);
                return reader;
            }
            catch(Exception)
            {
                return null;
            }
            
        }
       
        public static SqlDataReader ReadById(int ID)
        {
            try
            {
                string sql= "select * from peoples p inner join peopledetails pd on p.ID = pd.relatedid inner join " +
                    "registerinfo r on pd.relatedid=r.relatedid where p.ID=" + ID;
                //if (TempPeople) {
              //      sql = "select* from temppeoples p inner join temppeopledetails pd on p.TID = pd.relatedid " +
               //     "where p.TID=" + ID;
               // }
                SqlDataReader reader = DBFunction.ExecuteReader(sql);
                return reader;
            }
            catch(Exception ex)
            {
                MessageBox.Show("השגיאה הבאה התרחשה \n" + ex.Message);
                return null;
            }

        }



        /* public static bool InsertNewToTemp(bool Wedding)
         {
             string sql = "";
             string reasonsql = "";
             string temprelatedid = "";
             string tblpeople = "";
             string tbldetails = "";
             SqlParameter[] prms = new SqlParameter[70];
             People p = GLOBALVARS.MyPeople;
             tbldetails = "TempPeopleDetails";
             tblpeople = "TempPeoples";
             temprelatedid = BuildSql.InsertSql(out prms[60], p.ID);
             if (Wedding)
                 p.Reason = (int)People.ReasonType.Wedding;
                 reasonsql = BuildSql.InsertSql(out prms[59], p.Reason);

             sql = "BEGIN TRANSACTION ";

             sql += "DECLARE @DataID int;";



             sql += " insert into " + tblpeople + " values(" +
                 BuildSql.InsertSql(out prms[0], p.FirstName) +
                 BuildSql.InsertSql(out prms[1], p.Lasname) +
                 BuildSql.InsertSql(out prms[2], p.Sexs) +
                 BuildSql.InsertSql(out prms[3], p.Age) +
                 BuildSql.InsertSql(out prms[4], p.Tall) +
                 BuildSql.InsertSql(out prms[5], p.Weight) +
                 BuildSql.InsertSql(out prms[6], p.FaceColor) +
                 BuildSql.InsertSql(out prms[7], p.Looks) +
                 BuildSql.InsertSql(out prms[8], p.Beard) +
                 BuildSql.InsertSql(out prms[9], p.City) +
                 BuildSql.InsertSql(out prms[10], p.Zerem) +
                 BuildSql.InsertSql(out prms[11], p.Eda) +
                 BuildSql.InsertSql(out prms[12], p.FutureLearn) +
                 BuildSql.InsertSql(out prms[13], p.Background) +

                 BuildSql.InsertSql(out prms[15], p.DadWork) +
                 BuildSql.InsertSql(out prms[16], p.CoverHead) +
                 BuildSql.InsertSql(out prms[17], p.GorTorN) +
                 BuildSql.InsertSql(out prms[18], p.TneedE) +
                 BuildSql.InsertSql(out prms[19], p.StakeM) +
                 BuildSql.InsertSql(out prms[20], p.OpenHead) +
                 BuildSql.InsertSql(out prms[21], p.Status) +
                 BuildSql.InsertSql(out prms[62], p.Show) +
                 reasonsql +
                 temprelatedid +
                 BuildSql.InsertSql(out prms[22], GLOBALVARS.MyUser.ID) +
                 BuildSql.InsertSql(out prms[50], p.LearnStaus,true) +
                 ");";

             sql += "SELECT @DataID = scope_identity(); ";

             sql += " insert into " + tbldetails + " values( " +
                 BuildSql.InsertSql(out prms[23], p.Details.Street) +
                 BuildSql.InsertSql(out prms[24], p.Details.Schools) +
                 BuildSql.InsertSql(out prms[25], p.Details.Tel1) +
                 BuildSql.InsertSql(out prms[26], p.Details.Tel2) +
                 BuildSql.InsertSql(out prms[27], p.Details.WhoAmI) +
                 BuildSql.InsertSql(out prms[28], p.Details.WhoIWant) +
                 BuildSql.InsertSql(out prms[29], p.Details.WithRavIn) +
                 BuildSql.InsertSql(out prms[30], p.Details.DadName) +
                 BuildSql.InsertSql(out prms[31], p.Details.MomName) +
                 BuildSql.InsertSql(out prms[32], p.Details.ChildrenCount) +
                 BuildSql.InsertSql(out prms[33], p.Details.SiblingsSchools) +
                 BuildSql.InsertSql(out prms[34], p.Details.MomLname) +
                 BuildSql.InsertSql(out prms[35], p.Details.MomWork) +
                 BuildSql.InsertSql(out prms[36], p.Details.MoneyGives) +
                 BuildSql.InsertSql(out prms[37], p.Details.MoneyRequired) +
                 BuildSql.InsertSql(out prms[38], p.Details.MoneyNotes) +
                 BuildSql.InsertSql(out prms[39], p.Details.HomeRav ) +
                 BuildSql.InsertSql(out prms[40], p.Details.MechutanimNames) +
                 "@DataID," +
                 BuildSql.InsertSql(out prms[42], p.Details.ZevetInfo) +
                 BuildSql.InsertSql(out prms[43], p.Details.FriendsInfo) +
                 BuildSql.InsertSql(out prms[44], p.Details.Chadchan) +
                 BuildSql.InsertSql(out prms[45], p.Details.Faileds) +
                 BuildSql.InsertSql(out prms[46], p.Details.Notes) +

                 BuildSql.InsertSql(out prms[48], p.Details.OwnChildrenCount) +
                 BuildSql.InsertSql(out prms[49], p.WorkPlace)  +
                 BuildSql.InsertSql(out prms[61], p.Details.MoneyToShadchan, true)+
                 ");";
             // ^ it right



             if (PlusTblReg)
             {
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
             sql += "COMMIT";
             return DBFunction.Execute(sql, prms);
         }*/
        public static bool UpdatePeople(bool Wedding, bool Shadchan = false, string Notes = null, bool PublishClient = false)
        {

            string sql = "";
            People p = GLOBALVARS.MyPeople;
            string where = " where id=" + p.ID + " ";
            string Rwhere = " where relatedid=" + p.ID + " ";
            bool PlusTblReg = true;
            SqlParameter[] prms = new SqlParameter[70];
            
           if(p.Show != 5) {  // check is not personal user 
              
            PlusTblReg = true; // for future use

           // if (Shadchan)
              //  return ShadchanUpdate();
            
            if (Wedding)
                return WeddingUpdate();

            if (!GLOBALVARS.MyUser.CanEdit)
                return UpdateTemp(Notes);
            }
            else
            {
                if(!PublishClient)
                    p.Show = 5;
                p.Details.Chadchan = "{" + GLOBALVARS.MyUser.ID.ToString() +"}";
            }
            sql = "BEGIN TRANSACTION ";
            
            sql += "update peoples SET " +
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
                BuildSql.UpdateSql(out prms[15], p.Sexs, "Sexs") +
                BuildSql.UpdateSql(out prms[16], p.Show, "show") +
                BuildSql.UpdateSql(out prms[17], p.StakeM, "StakeM") +
                BuildSql.UpdateSql(out prms[18], p.Status, "Status") +
                BuildSql.UpdateSql(out prms[19], p.Tall, "Tall") +
                BuildSql.UpdateSql(out prms[20], p.TneedE, "TneedE") +
                BuildSql.UpdateSql(out prms[59], p.LearnStaus, "LearnStatus") +
                BuildSql.UpdateSql(out prms[21], p.Zerem, "Zerem") +
                BuildSql.UpdateSql(out prms[22], p.Weight, "fat", true) + where + ";";
            
            sql += " update peopledetails SET " +
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
                BuildSql.UpdateSql(out prms[61], p.Details.MoneyToShadchan, "MoneyToShadchan", true)
                + Rwhere + ";";
            // ^ it right
            sql += " update RegisterInfo SET ";
            if (PlusTblReg)
            {
                sql += 
                     BuildSql.UpdateSql(out prms[50], p.Register.Notes, "regnotes") +
                     BuildSql.UpdateSql(out prms[51], p.Register.Paid, "paid") +
                     BuildSql.UpdateSql(out prms[52], p.Register.PaidCount, "PaidCount") +
                     BuildSql.UpdateSql(out prms[53], p.Register.PayDate, "PayDate") +
                     BuildSql.UpdateSql(out prms[54], p.Register.PayWay, "PayWay") +
                     BuildSql.UpdateSql(out prms[55], p.Register.RegDate, "regdate") +
                     BuildSql.UpdateSql(out prms[56], p.Register.RegType, "Type") +
                     BuildSql.UpdateSql(out prms[57], GLOBALVARS.MyUser.ID, "ByUser") +
                     BuildSql.UpdateSql(out prms[58], p.Register.Subscription, "Subscription");
            }
            sql+= BuildSql.UpdateSql(out prms[62],DateTime.Now.Date, "lastupdate",true) + Rwhere + "; ";
            sql += "COMMIT";

            DBFunction.Execute(sql, prms);
            
                PopUpMessage(false);
                return true;
            
            
        }

        
        private static bool WeddingUpdate()
        {
            bool ret = false;
            ret = DBFunction.Execute("insert into notes values (" + GLOBALVARS.MyUser.ID + "," + GLOBALVARS.MyPeople.ID + ",''," + (int)People.ReasonType.Wedding + ")");
            PopUpMessage(true);
            return ret;
        }

        private static bool UpdateTemp(string Notes)
        {
            SqlParameter[] prms = new SqlParameter[2];
            prms[1] = new SqlParameter("@notes", Notes);
            bool ret = false;
            ret = DBFunction.Execute("insert into notes values (" + GLOBALVARS.MyUser.ID + "," + GLOBALVARS.MyPeople.ID + ",@notes," + (int)People.ReasonType.Edtinging + ")",prms);
            PopUpMessage(true);
            return ret;
        }

        public static bool AllowLimited()
        {
            bool ret = false;
            ret = DBFunction.Execute("insert into notes values (" + GLOBALVARS.MyUser.ID + "," + GLOBALVARS.MyPeople.ID + ",'אפשר לי לראות את החסוי הזה'," + (int)People.ReasonType.AllowLimited + ")");
            PopUpMessage(true);
            return ret;
        }

        private static void PopUpMessage(bool temp=false)
        {
            if (temp)
                MessageBox.Show("השינוי נשלח למערכת \n המערכת תאשר את השינוי בקרוב", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("שונה בהצלחה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool DeletePeople(int peopleid,bool ask=true,bool perment=false)
        {
            try
            {
                int id = peopleid;
                DialogResult yesno = DialogResult.Yes;
                if (ask)
                 yesno = MessageBox.Show("האם אתה בטוח שברצונך למחוק", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (yesno == DialogResult.Yes)
                {
                    string sql = "";
                    if (!perment)
                    {
                        sql = "update peoples set show=8 where ID=" + id;
                    }
                    else { 
                        sql = "BEGIN TRANSACTION delete from peoples where ID=" + id + "; " +
                        "delete from peopledetails where relatedid=" + id + "; " +
                        "delete from registerinfo where relatedid=" + id + "; COMMIT";
                    }
                    if (DBFunction.Execute(sql))
                    {
                        MessageBox.Show("נמחק בהצלחה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                        
                    }
                    else
                        MessageBox.Show("אירעה שגיאה", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch { MessageBox.Show("אירעה שגיאה", "", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
        }
    }
}
