/*
-----------------------------------------------INFORMATION ABOUT THIS CLASS-------------------------------------------------------
this mainform exetend class will go over all loading data from db we need to do
*/
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;

namespace Schiduch
{
    public partial class MainForm:Form
    {
        public static ArrayList Shadchanim;
        public ArrayList Clients;

        
        public void LoadShadchanHandlers(int chadchanid=0,ListView lstvw=null,bool mkcolor=false)
        {
            if (lstvw == null) lstvw = lstshadchanhandle;
            string addsql = "";
            if(chadchanid!=0)
                addsql = " and chadchan =" + chadchanid;
            lstvw.Items.Clear();
            SqlDataReader reader=DBFunction.ExecuteReader("select users.name,peopledetails.chadchan,peoples.firstname,peoples.id as pid,peoples.lastname,users.id,relatedid from peoples" +
                "  inner join peopledetails on ID=relatedid inner join users on peopledetails.chadchan=users.id  where chadchan <> 0" + addsql);
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(new string[] {
                    reader["firstname"].ToString(),
                    reader["lastname"].ToString(),
                    "שדכן מטפל : " + reader["name"].ToString(),
                    reader["pid"].ToString(),
                    reader["id"].ToString()
                }, 4);
                if (mkcolor) item.ForeColor = Color.Blue;
                lstvw.Items.Add(item);
            }
            reader.Close();     
        }

        public void LoadShadcanim()
        {
            string sql;
        //    string txt="";
            int controlhide = 1;
            Shadchanim = new ArrayList();
           
            if (GLOBALVARS.MyUser.Control == User.TypeControl.Admin)
                controlhide = 100;
            sql = "select name,tel,email,id from users where control < " + controlhide;
            SqlDataReader reader;
            reader = DBFunction.ExecuteReader(sql);
            while (reader != null && reader.Read())
            {
                KeyValueClass temp = new KeyValueClass((string)reader["name"],(int)reader["ID"]);

                Shadchanim.Add(temp);
                  cmbusers.Items.Add(temp);
                  lstchadcan.Items.Add(new ListViewItem(new string[] { (string)reader["name"],
                          (string)reader["tel"],(string)reader["email"],reader["ID"].ToString()
                  }, 2));
            }
            reader.Close();
            DBFunction.CloseConnections();
           
        }
        private void LoadClients()
        {
            string sql;           
            Clients = new ArrayList();
            sql = "select firstname + ' ' + lastname as allname,id from peoples where show=0 order by firstname ";
            SqlDataReader reader;
            reader = DBFunction.ExecuteReader(sql);
            cmb_subreport.Items.Clear();
            while (reader != null && reader.Read())
            {
                KeyValueClass temp = new KeyValueClass((string)reader["allname"], (int)reader["ID"]);
                Clients.Add(temp);
                cmb_subreport.Items.Add(temp);
                
            }
            reader.Close();
        }
        private bool LoadData(bool reset=false)
        {
            int tempload = 0;
            if (GLOBALVARS.MyPeople == null)
                GLOBALVARS.MyPeople = new People();
            
            List<People> lst = new List<People>();
     
                SqlDataReader myreader;

                myreader = People.ReadAll(0, true,true);
                olstpeople.BeginUpdate();

                while (myreader.Read())
                {
                    tempload++;
                    if (formloadmsg != null)
                        formloadmsg.progressBar1.Value = tempload;
                    People p = new People();

                    PeopleManipulations.ReaderToPeople(ref p, ref myreader, PeopleManipulations.RtpFor.ForSearch);

                    lst.Add(p);
                }
                olstpeople.SetObjects(lst);
                olstpeople.EndUpdate();
                lblresult.Text = "מציג את ה 50 האחרונים שנוספו לתוכנה";
                myreader.Close();
            DBFunction.CloseConnections();

            LoadLabelsToTxts();

            formloadmsg.Close();
                return true;
            
            
        }

        private string[] LoadDataFromFile()
        {
            if (File.Exists("People.bin"))
            {
                return File.ReadAllLines("People.bin");
            }
            return null;
        }

        private void WriteDataToFile(string speople)
        {

            if (!File.Exists("People.bin"))
                File.Create("People.bin").Close();
            File.WriteAllText("People.bin", speople);
            return;
        }
        private void LoadTempData(int chadchanid = 0, ListView lstvw = null)
        {
            ListViewItem item;
            if (lstvw == null) lstvw = lsttemppeople;
            if (GLOBALVARS.MyPeople == null)
                GLOBALVARS.MyPeople = new People();
            People p = new People();
            SqlDataReader reader;
            if(chadchanid==0)
            reader = DBFunction.ExecuteReader("select users.name as uname,noteid,reason,notes.peopleid,notes.chadchan,notes.notes,peoples.firstname,peoples.lastname,peoples.id " +
                "from notes inner join peoples on peopleid=id inner join users on chadchan=users.id");
            else
                reader = DBFunction.ExecuteReader("select users.name as uname,noteid,reason,notes.peopleid,notes.chadchan,notes.notes,peoples.firstname,peoples.lastname,peoples.id " +
                "from notes inner join peoples on peopleid=id where notes.chadchan=" + chadchanid + " inner join users on chadchan=users.id");
            lsttemppeople.BeginUpdate();
            string checkchar="";
            while (reader.Read())
            {
                checkchar = (string)reader["notes"];
                if (checkchar.Contains("|"))
                    checkchar = checkchar.Substring(checkchar.LastIndexOf('|')+1);
                if(chadchanid!=0)
                    checkchar="עדכנתי פרטים על הלקוח הזה";
                item = new ListViewItem(new string[] {
                    (string)reader["firstname"],
                    (string)reader["lastname"],
                    checkchar,
                    reader["noteid"].ToString(),
                    reader["chadchan"].ToString(),reader["uname"].ToString()
                });
                item.Tag = reader["peopleid"].ToString();
                switch ((int)reader["reason"])
                {
                    case (int)People.ReasonType.Wedding:
                        item.ForeColor = Color.Red;
                        break;
                    case (int)People.ReasonType.ShadChan:
                        item.ForeColor = Color.Blue;
                        break;
                    case (int)People.ReasonType.AllowLimited:
                        item.ForeColor = Color.Green;
                        break;
                }
                item.ImageIndex = 3;
                lstvw.Items.Add(item);
            }
            lsttemppeople.EndUpdate();
            reader.Close();

        }

       

        private void CheckUserPhone()
        {
            if (string.IsNullOrEmpty(GLOBALVARS.MyUser.Tel))
            {
                MessageBox.Show("שדכן יקר\n אנחנו מעדכנים כרגע נתונים במערכת לגבי השדכנים ושמנו לב שהטלפון שלך לא קיים במערכת", "", MessageBoxButtons.OK, MessageBoxIcon.Information,MessageBoxDefaultButton.Button1,MessageBoxOptions.RightAlign);
                string tel = Microsoft.VisualBasic.Interaction.InputBox("הקלד את מספר הטלפון שלך, יש למלא רק מספרים", "עדכון", "", -1, -1);
                if (!string.IsNullOrEmpty(tel))
                {
                    int n;
                    bool isNumeric = int.TryParse(tel, out n);
                    if (isNumeric && DBFunction.UpdateColumn("tel='" + tel + "'", " ID=" + GLOBALVARS.MyUser.ID, "USERS")) { 
                        MessageBox.Show("עודכן בהצלחה", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    
                }
                CheckUserPhone();
            }
            
        }
    }
}
