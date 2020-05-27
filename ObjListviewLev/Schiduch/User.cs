using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;

using System.Data.SqlClient;
using System.IO;
using Schiduch.Forms;

namespace Schiduch
{
   
    public class User
    {
        public enum TypeControl { Lock = 4, User = 0, Manger = 1, Admin = 2,Delete=5,WaitToCConfirm };
        public string UserName;
        public string Password;
        public string Email;
        public int ID;
        public string Name;
        public string Tel;
        public bool CanAdd;
        public bool CanEdit;
        public bool SignOk = false;
        public TypeControl Control;
        public static User GetUser(string suser,string spass){
            User retuser = null;
            if (!File.Exists("User") || GLOBALVARS.LastUserChangeDB > GLOBALVARS.LastUserChangeFile || !General.IsSaveUser || 1!=2) { 
                SqlDataReader reader;
               
                SqlParameter puser=new SqlParameter("@user",suser);
                SqlParameter ppass=new SqlParameter("@pass",spass);
                reader = DBFunction.ExecuteReader("SELECT name,username,password,email,id,tel,control,canedit,canadd,signok from users where username=@user and password=@pass", puser, ppass);
                if (reader != null && reader.Read())
                {
                        retuser = new User();
                    retuser.Name = (string)reader["name"];
                    retuser.UserName = (string)reader["username"];
                        retuser.Password = (string)reader["password"];
                        retuser.Email = (string)reader["email"];
                        retuser.ID = int.Parse(reader["id"].ToString());
                        retuser.Tel=(string)reader["tel"];
                        retuser.Control = (User.TypeControl)reader["control"];
                    retuser.SignOk = (bool)reader["signok"];
                    retuser.CanEdit= (bool)reader["CanEdit"];
                    retuser.CanAdd = (bool)reader["CanAdd"];
                   
                    WriteUserToFile(retuser);
                    GLOBALVARS.LastUserChangeFile = DateTime.Now;
                    UpdateManager.UpdateLastTimeCheck();
                }
                reader.Close();
                DBFunction.CloseConnections();


            }
            else
            {
                string[] fileuser=File.ReadAllLines("User");
                
                if(SplachScreen.Encrypt(suser) == fileuser[1] && SplachScreen.Encrypt(spass) == fileuser[2])
                {
                    retuser = new User();
                    retuser.Name = Encoding.UTF8.GetString(Convert.FromBase64String(fileuser[0]));
                    retuser.UserName = suser;
                    retuser.Password = spass;
                    retuser.Email= Encoding.UTF8.GetString(Convert.FromBase64String(fileuser[3]));
                    retuser.ID = int.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(fileuser[4])));
                    retuser.Tel = Encoding.UTF8.GetString(Convert.FromBase64String(fileuser[5]));
                    for(int i=0;i != 7; i++)
                    {
                        
                        if (SplachScreen.Encrypt(((User.TypeControl)i).ToString()) == fileuser[6])
                            retuser.Control = (User.TypeControl)i;
                    }
                    retuser.CanEdit = bool.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(fileuser[7])));
                    retuser.CanAdd = bool.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(fileuser[8])));
                    retuser.SignOk = bool.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(fileuser[9])));
                }
                
            }
            return retuser;
        }
        private static void WriteUserToFile(User u)
        {
            
            string user = "";
            byte[] forbase = Encoding.UTF8.GetBytes(u.Name);
            user = Convert.ToBase64String(forbase) + "\r\n";
            user += SplachScreen.Encrypt(u.UserName) + "\r\n" + SplachScreen.Encrypt(u.Password) + "\r\n";

            forbase = Encoding.UTF8.GetBytes(u.Email);
            user += Convert.ToBase64String(forbase) + "\r\n";
            forbase = Encoding.UTF8.GetBytes(u.ID.ToString());
            user += Convert.ToBase64String(forbase) + "\r\n";
            forbase = Encoding.UTF8.GetBytes(u.Tel);
            user += Convert.ToBase64String(forbase) + "\r\n";
           
            user += SplachScreen.Encrypt(u.Control.ToString()) + "\r\n";
            forbase = Encoding.UTF8.GetBytes(u.CanEdit.ToString());
            user += Convert.ToBase64String(forbase) + "\r\n";
            forbase = Encoding.UTF8.GetBytes(u.CanAdd.ToString());
            user += Convert.ToBase64String(forbase) + "\r\n";
            forbase = Encoding.UTF8.GetBytes(u.SignOk.ToString());
            user += Convert.ToBase64String(forbase);
            File.WriteAllText("User", user);
        }
        public static User GetUser(int id)
        {
            SqlDataReader reader;
            User retuser = null;
            SqlParameter pid = new SqlParameter("@id", id);
            reader = DBFunction.ExecuteReader("select name,username,password,email,id,tel,control from users where id=@id", pid);
            if (reader != null && reader.Read())
            {
                retuser = new User();
                retuser.Name= (string)reader["name"];
                retuser.UserName = (string)reader["username"];
                retuser.Password = (string)reader["password"];
                retuser.Email = (string)reader["email"];
                retuser.ID = int.Parse(reader["id"].ToString());
                retuser.Tel = (string)reader["tel"];
                retuser.Control = (User.TypeControl)reader["control"];
            }
            reader.Close();
            return retuser;
        }

        public static void RemoveHandler(int id)
        {
            try
            {
                if (id == 0)
                    return;
                DBFunction.Execute("update peopledetails set chadchan=0 where chadchan=" + id);
                MessageBox.Show("הוסר בהצלחה");
            }
            catch
            {
                MessageBox.Show("אירעה שגיאה בהסרת השדכן מטפל");
            }
        }
    }
}
