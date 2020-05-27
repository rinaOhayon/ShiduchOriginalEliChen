using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Data.SqlClient;

namespace Schiduch
{
    class Log
    {
        public enum ActionType {Register=0,Login,LoginBlocked,TempUpdate,Update,DeleteSoftware,IncorrectLogin,ClientOpen,ALL,FailCall,GoodDateCall,FailDateCall,PhoneFormOpen,StartDate,FixSerialToLogicId,UserChangePassword,FreeSearchLog,SignContract};
        
        public DateTime Date;
        public int UserId;
        public int ClientId=0;
        public ActionType Command;
        public string ActionString="";
        public string Info;
        public User.TypeControl Level;
        public int ID;
        public static void AddAction(ActionType action,Log idlog=null)
        {
            if (GLOBALVARS.MyUser == null)
                GLOBALVARS.MyUser = new User();
            if (idlog == null)
                idlog = new Log();
            if (idlog.Date == null)
                idlog.Date = DateTime.Now;
            if (action != ActionType.Register) { 
            idlog.UserId = GLOBALVARS.MyUser.ID;
            idlog.Level = GLOBALVARS.MyUser.Control;
            }
            else { 
                idlog.UserId = 0;
                idlog.Level = User.TypeControl.User;
            }
            SqlParameter[] dt = new SqlParameter[2];
                 dt[0]=new SqlParameter("@dt", DateTime.Now);
            if (idlog.Info == null)
                idlog.Info = "";
            dt[1] = new SqlParameter("@info",idlog.Info);
            
            DBFunction.Execute("INSERT INTO log VALUES(@dt," +
                (int)idlog.UserId + "," + 
                (int)action + "," +
                (int)idlog.Level + ",@info" +
                 ")",dt);
            

        }
        public static void DeleteAction(Log idlog)
        {
            if (idlog.Date == null)
                idlog.Date = DateTime.Now;
            idlog.UserId = GLOBALVARS.MyUser.ID;
            idlog.Level = GLOBALVARS.MyUser.Control;
            DBFunction.Execute("delete LOG where Id=" +
                idlog.ID);

        }
        public void Add(ActionType action)
        {
            Log.AddAction(action, this);
        }
        public void Add()
        {
            AddAction(this.Command, this);
        }
        public void Delete() { Log.DeleteAction(this); }
        public Log(ActionType action) {
            this.Date = DateTime.Now;
            this.UserId = GLOBALVARS.MyUser.ID;
            this.Level = GLOBALVARS.MyUser.Control;
            this.Command = action;
            this.Info = "";
        }
        public Log(ActionType action,string info)
        {
            this.Date = DateTime.Now;
            this.UserId = GLOBALVARS.MyUser.ID;
            this.Level = GLOBALVARS.MyUser.Control;
            this.Command = action;
            this.Info = info;
        }
        public Log(ActionType action, string info,string ClientId)
        {
            this.ClientId = int.Parse(ClientId);
            this.Date = DateTime.Now;
            this.UserId = GLOBALVARS.MyUser.ID;
            this.Level = GLOBALVARS.MyUser.Control;
            this.Command = action;
            this.Info = info;
        }
        public Log()
        {
            if (GLOBALVARS.MyUser !=null)
            {
                this.UserId = GLOBALVARS.MyUser.ID;
                this.Level = GLOBALVARS.MyUser.Control;
            }
            else
            {
                this.UserId = 0;
                this.Level = User.TypeControl.User;
            }
            this.Date = DateTime.Now;
           
        }
        public static SqlDataReader ReadAll(bool ReallyAll=false)
        {
            SqlDataReader reader;
            string top = "top 100";
            if (ReallyAll)
                top = "";
            reader = DBFunction.ExecuteReader("select " + top + " * from log order by Date desc");
            return reader;
        }
        public static Log ReadById(int id)
        {
            Log retlog = new Log();
            SqlDataReader reader;
            reader = DBFunction.ExecuteReader("select * from log where id=" +id);
            if (reader.Read())
            {
                ReaderToLog(ref reader, ref retlog);
            }
            reader.Close();
            return retlog;
        }
        public static SqlDataReader ReadSql(string sql,params SqlParameter[] prms)
        {
            return DBFunction.ExecuteReader(sql, prms);
        }
        public static void ReaderToLog(ref SqlDataReader reader,ref Log plog,bool translate=false)
        {
            
            plog.Date = (DateTime)reader["Date"];
            plog.UserId = (int)reader["UserId"];
            plog.Command = (ActionType)reader["Action"];
            if (translate)
                plog.ActionString = TranslateAction(plog.Command);
            else
                plog.ActionString = plog.Command.ToString();
            plog.Level = (User.TypeControl)reader["Level"];
            plog.ID = (int)reader["ID"];
            if(!reader.IsDBNull(5))
            plog.Info = (string)reader["Info"];
        }
        private static string TranslateAction(ActionType type)
        {
            string act = "";
            switch (type)
            {
                case ActionType.ClientOpen:
                    act = "פתח כרטיס לקוח";
                    break;
                case ActionType.DeleteSoftware:
                    act = "נמחק לו התוכנה";
                    break;
                case ActionType.FailCall:
                    act = "שיחה שלא נענתה";
                    break;
                case ActionType.FailDateCall:
                    act = "הציע הצעה וזה לא יצא";
                    break;
                case ActionType.FixSerialToLogicId:
                    act = "תיקון סריאל";
                    break;
                case ActionType.FreeSearchLog:
                    act = "חיפוש חופשי";
                    break;
                case ActionType.GoodDateCall:
                    act = "הציע הצעה ללקוח";
                    break;
                case ActionType.IncorrectLogin:
                    act = "התחברות לא תקינה";
                    break;
                case ActionType.Login:
                    act = "כניסה לתוכנה";
                    break;
                case ActionType.LoginBlocked:
                    act = "שדכן שנחסם וניסה להיכנס לתוכנה";
                    break;
                case ActionType.PhoneFormOpen:
                    act = "בדק מה הטלפון";
                    break;
                case ActionType.Register:
                    act = "רישום לתוכנה";
                    break;
                case ActionType.SignContract:
                    act = "חתם חוזה";
                    break;
                case ActionType.StartDate:
                    act = "הפגיש את הלקוח והתחיל פגישות";
                    break;
                case ActionType.TempUpdate:
                    act = "שלח עדכון לקוח";
                    break;
                case ActionType.Update:
                    act = "עדכון גירסת תוכנה";
                    break;
                case ActionType.UserChangePassword:
                    act = "שינה סיסמה";
                    break;
            }
            return act;
        }
    }
    
}
