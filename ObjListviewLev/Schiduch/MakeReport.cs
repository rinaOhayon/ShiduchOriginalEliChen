using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Collections;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;
namespace Schiduch
{
    class MakeReport
    {
        Random rnd = new Random();
        Dictionary<Log.ActionType, KeyValueClass> sw=null;
        Dictionary<string, KeyValueClass> user = null;
        Dictionary<string, KeyValueClass> client = null;
        private ArrayList chadcan_action = new ArrayList();
        public enum ReportClientType { All, WhoCallMe, WhoIsOpenMe, MyDates };
        private string path=Application.StartupPath +"\\RepV1.rpt";
        private const string START_TABLE_ROW = "<tr>";
        private const string END_TABLE_ROW = "<tr>";
        private int count_openclient = 0;
        private int count_opentel = 0;
        private int count_failcall = 0;
        private int count_datecall = 0;
        private int count_startdate = 0;
        private int count_callnoanswer = 0;
        public enum ReportType{Client,User,SW,Dates };
        ReportType rep_type;
        private string clientlog_open= "<div ><table class='table table-bordered'><caption" +
            " style='text-align:right'>פתחו כרטיס לקוח</caption><thead><tr><th style='text-align:right;width:50%'" + 
            ">שדכן</th><th style='text-align:right;width:50%'>בתאריך</th></tr></thead><tbody>";
        private string clientlog_callfail= "<div ><table class='table table-bordered'><caption" +
            " style='text-align:right'>התקשרו הציעו ולא יצא</caption><thead><tr><th style='text-align:right;width:50%'" +
            ">שדכן</th><th style='text-align:right;width:50%'>בתאריך</th></tr></thead><tbody>";
        private string clientlog_datecall= "<div ><table class='table table-bordered'><caption" +
            " style='text-align:right'>התקשרו הציעו</caption><thead><tr><th style='text-align:right;width:50%'" +
            ">שדכן</th><th style='text-align:right;width:50%'>בתאריך</th></tr></thead><tbody>";
        private string clientlog_callnoanswer= "<div ><table class='table table-bordered'><caption" +
            " style='text-align:right'>התקשרו ולא ענו</caption><thead><tr><th style='text-align:right;width:50%'" +
            ">שדכן</th><th style='text-align:right;width:50%'>בתאריך</th></tr></thead><tbody>";
        private string clientlog_telopen= "<div ><table class='table table-bordered'><caption" +
            " style='text-align:right'>בדקו מה הטלפון</caption><thead><tr><th style='text-align:right;width:50%'" +
            ">שדכן</th><th style='text-align:right;width:50%'>בתאריך</th></tr></thead><tbody>";
        private string clientlog_startdate= "<div ><table class='table table-bordered'><caption" +
            " style='text-align:right'>התקשרו לפגישה</caption><thead><tr><th style='text-align:right;width:50%'" +
            ">שדכן</th><th style='text-align:right;width:50%'>בתאריך</th></tr></thead><tbody>";
        public MakeReport(ReportType type)
        {
            rep_type = type;
            
        }
        public string CreateClientReport(string clientname,int userid,DateTime dt_start,DateTime dt_end)
        {
            
            string clienttableheader = global::Schiduch.Properties.Resources.ClientTableHeader;
            string html = "";
            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = new SqlParameter("dt_start", dt_start);
            prms[1] = new SqlParameter("dt_end", dt_end);

            string moreinfo ="לקוח " + clientname +  " מזהה לקוח " + userid.ToString();
           
               
            string sql = "select name,users.id as xid,info,action,userid,date,level from log LEFT JOIN USERS ON users.id=log.userid where log.info like '%" + userid.ToString() + "'";
           
            if (dt_start != null && dt_end != null) { 
                sql += " and date between @dt_start and @dt_end";
                moreinfo = " מתאריך " + dt_start.ToShortDateString() + " עד לתאריך " + dt_end.ToShortDateString();
            }
            sql += " order BY log.ACTION ";
            
            html += CreateHtmlReport("לקוח", moreinfo);
            
            html += RegisterDateToReport(userid);
            SqlDataReader reader = DBFunction.ExecuteReader(sql,prms);
            
            html += "<u><h2>פירוט</h2></u><div class='row' style='width:80%'>";
            while (reader.Read())
            {
                Log.ActionType a_type=(Log.ActionType)int.Parse(reader["ACTION"].ToString());
               
                switch (a_type) {
                    case Log.ActionType.ClientOpen:
                        clientlog_open += START_TABLE_ROW + CreateCol("",reader["name"]) + CreateCol(null, reader["date"]) + END_TABLE_ROW;
                        InsertUserAction(reader["name"].ToString(), (int)reader["userid"], Log.ActionType.ClientOpen);
                        count_openclient++;
                        break;
                    case Log.ActionType.FailDateCall:
                        clientlog_callfail += START_TABLE_ROW + CreateCol("",reader["name"]) + CreateCol(null, reader["date"]) + END_TABLE_ROW;
                        InsertUserAction(reader["name"].ToString(), (int)reader["userid"], Log.ActionType.FailDateCall);
                        count_failcall++;
                        break;
                    case Log.ActionType.FailCall:
                        clientlog_callnoanswer += START_TABLE_ROW + CreateCol("",reader["name"]) + CreateCol(null, reader["date"]) + END_TABLE_ROW;
                        InsertUserAction(reader["name"].ToString(), (int)reader["userid"], Log.ActionType.FailCall);
                        count_callnoanswer++;
                        break;
                    case Log.ActionType.GoodDateCall:
                        clientlog_datecall += START_TABLE_ROW + CreateCol(null,reader["name"]) + CreateCol(null, reader["date"]) + END_TABLE_ROW;
                        InsertUserAction(reader["name"].ToString(), (int)reader["userid"], Log.ActionType.GoodDateCall);
                        count_datecall++;
                        break;
                    case Log.ActionType.PhoneFormOpen:
                        clientlog_telopen += START_TABLE_ROW + CreateCol(null,reader["name"]) + CreateCol(null, reader["date"]) + END_TABLE_ROW;
                        InsertUserAction(reader["name"].ToString(), (int)reader["userid"], Log.ActionType.PhoneFormOpen);
                        count_opentel++;
                        break;
                    case Log.ActionType.StartDate:
                        clientlog_startdate += START_TABLE_ROW + CreateCol(null,reader["name"]) + CreateCol(null, reader["date"]) + END_TABLE_ROW;
                        InsertUserAction(reader["name"].ToString(), (int)reader["userid"], Log.ActionType.StartDate);
                        count_opentel++;
                        break;
                }
            }
            reader.Close();
            clientlog_open += "</tbody></table></div>";
            clientlog_callfail += "</tbody></table></div>";
            clientlog_callnoanswer += "</tbody></table></div>";
            clientlog_datecall += "</tbody></table></div>";
            clientlog_startdate += "</tbody></table></div>";
            clientlog_telopen += "</tbody></table></div>";
            html += clientlog_open + clientlog_telopen + clientlog_callfail + clientlog_callnoanswer + clientlog_datecall + clientlog_startdate;
            html += "</div><hr>"; // end div of all info tables and create hr
            html += Schiduch.Properties.Resources.ClientSumTableHeaders;
            html += SumClientsTableList();
            html += "</tbody></table><hr><u><h2>סך הכל</h2></u>";
            html += SumClientsData();
            html += global::Schiduch.Properties.Resources.ReportEnd;
            using (TextWriter txtwrite = File.CreateText(path)) {
                txtwrite.Write(html);
            }
            return path;    
        }

        public string CreateClientReport(string clientname,int clientid, DateTime dt_start, DateTime dt_end,ReportClientType type)
        {
          //  string clienttableheader = global::Schiduch.Properties.Resources.ClientTableHeader;
          //  string html = "";
           // SqlParameter[] prms = new SqlParameter[2];
          //  prms[0] = new SqlParameter("dt_start", dt_start);
           // prms[1] = new SqlParameter("dt_end", dt_end);

            return null;
        }
        public string CreateUserReport(string username,int userid,DateTime dt_start,DateTime dt_end) {
            string html = "";
           
            
            return html;
        }

        public string CreateDatesReport(DateTime dt_start,DateTime dt_end)
        {
            string html = "";
            int dates = 0;
            int dates_unpaid = 0;

            SqlParameter[] prms = new SqlParameter[2];
            prms[0] = new SqlParameter("dt_start", dt_start);
            prms[1] = new SqlParameter("dt_end", dt_end);
            string moreinfo = "";
            bool paid = false;
            string nopay = "<span class='label label-danger'> לא שילם </span>";
            string lbl = "";
            string sql = "select paid,date,info,action,userid,name,replace(left(info,CHARINDEX(N'^',info,0)),'^','') as clientname" +
                " from Log left join users on userid = users.id left" +
                " join RegisterInfo on relatedid = replace(substring(info, CHARINDEX('^', info), 6), '^', '')" +
                " where (action = 13 or action = 10) and replace(substring(info, CHARINDEX('^', info), 6), '^', '') > 2750 ";

            if (dt_start != null && dt_end != null)
            {
                sql += " and date between @dt_start and @dt_end";
                moreinfo = " מתאריך " + dt_start.ToShortDateString() + " עד לתאריך " + dt_end.ToShortDateString();
            }
            sql += " order by action,date desc";
            html += CreateHtmlReport("פגישות", moreinfo);
            html += Properties.Resources.ShadchanStartDatesHeader;
            SqlDataReader reader = DBFunction.ExecuteReader(sql, prms);
            while (reader.Read())
            {
                Log.ActionType a_type = (Log.ActionType)int.Parse(reader["ACTION"].ToString());
                paid =reader["paid"] as bool? ?? false;
                if (!paid) { lbl = nopay;dates_unpaid++; }
                else lbl = "";
                switch (a_type)
                {
                    case Log.ActionType.GoodDateCall:
                        
                            html += START_TABLE_ROW + "<td class='success'>" +  reader["clientname"] + " " + lbl + "</td>" +
                              CreateCol("class='success'", reader["name"])
                            + CreateCol("class='success'", reader["date"]) + END_TABLE_ROW;
                       
                        dates++;
                        break;
                    case Log.ActionType.StartDate:
                        html += START_TABLE_ROW + "<td class='active'>" + reader["clientname"] + " " + lbl + "</td>" +
                              CreateCol("class='active'", reader["name"])
                            + CreateCol("class='active'", reader["date"]) + END_TABLE_ROW;
                        dates++;
                        break;  
                }
            }
            reader.Close();
            html += Schiduch.Properties.Resources.ShadchanStartDatesFooter;
            html += "<h1>הפגישות שנעשו בזמן הזה : <label class='label label-default'>" + dates.ToString() + "</label></h1>";
            html += "<h1>פגישות לכאלה שלא שילמו : <label class='label label-default'>" + dates_unpaid.ToString() + "</label></h1>";
            html += "</div></div></body></html>";
            using (TextWriter txtwrite = File.CreateText(path))
            {
                txtwrite.Write(html);
            }
            return path;
        }

        private string CreateHtmlReport(string title,string moreinfo)
        {
            string rep="";
            rep += global::Schiduch.Properties.Resources.ReportHeader;
            rep +="<h1>דו\"ח " + title +"</h1><p>" + moreinfo + "</p></div>";
            return rep;
        }
        private string RegisterDateToReport(int id)
        {
            string sql = "";
            string rep = ""; 
            switch (rep_type)
            {
                case ReportType.Client:
                    sql = "select regdate from registerinfo where relatedid=" + id;
                    break;
                case ReportType.User:
                    sql = "select dateadded from users where id=" + id;
                    break;
            }
            if (string.IsNullOrEmpty(sql)) return rep;
            SqlDataReader reader= DBFunction.ExecuteReader(sql);
            if (reader.Read()) { 
             rep = "<h3>קיים במאגר מ  <span class='label label-default'>" + reader.GetDateTime(0).ToShortDateString() + "</span></h3><hr>";
            }
            reader.Close();
            return rep;
        }
        private void InsertUserAction(string name,int id,Log.ActionType action)
        {
            for(int i = 0; i <= chadcan_action.Count -1; i++)
            {
                if (((TempData)chadcan_action[i]).id == id)
                {
                    switch (action)
                    {
                        case Log.ActionType.ClientOpen:
                            ((TempData)chadcan_action[i]).openclient++;
                            break;
                        case Log.ActionType.FailCall:
                            ((TempData)chadcan_action[i]).callnoanswer++;
                            break;
                        case Log.ActionType.FailDateCall:
                            ((TempData)chadcan_action[i]).callfail++;
                            break;
                        case Log.ActionType.GoodDateCall:
                            ((TempData)chadcan_action[i]).datecall++;
                            break;
                        case Log.ActionType.PhoneFormOpen:
                            ((TempData)chadcan_action[i]).opentel++;
                            break;
                        case Log.ActionType.StartDate:
                            ((TempData)chadcan_action[i]).startdate++;
                            break;
                    }
                    return;
                }   
            }
            TempData temp = new TempData();
            temp.name = name;
            temp.id = id;
            switch (action)
            {
                case Log.ActionType.ClientOpen:
                    temp.openclient++;
                    break;
                case Log.ActionType.FailCall:
                    temp.callnoanswer++;
                    break;
                case Log.ActionType.FailDateCall:
                    temp.callfail++;
                    break;
                case Log.ActionType.GoodDateCall:
                    temp.datecall++;
                    break;
                case Log.ActionType.PhoneFormOpen:
                    temp.opentel++;
                    break;
                case Log.ActionType.StartDate:
                    temp.startdate++;
                    break;
            }
            chadcan_action.Add(temp);
        }
        private string SumClientsTableList()
        {
            string ret = "";
            foreach (TempData temp in chadcan_action)
            {
                ret += "<tr><td>" + temp.name +"</td>";
                ret += "<td>" + temp.openclient + "</td>";
                ret += "<td>" + temp.opentel + "</td>";
                ret += "<td>" + temp.callnoanswer + "</td>";
                ret += "<td>" + temp.datecall + "</td>";
                ret += "<td>" + temp.callfail + "</td>";
                ret+= "<td>" + temp.startdate + "</td>";
            }
            return ret;
        }
        private string SumClientsData()
        {
            string ret = "<h4>פתחו את הכרטיס<b><i> " + count_openclient + "</i></b></h4>" +
                "<h4>בדקו מה הטלפון<b><i> " + count_opentel + "</i></b></h4></h4>" +
                "<h4>התקשרו ולא ענו  <b><i>" + count_callnoanswer + "</i></b></h4></h4>" +
                "<h4>התקשרו והציעו הצעה  <b><i>" + count_datecall + "</i></b></h4></h4>" +
                "<h4>התקשרו הציעו ולא יצא <b><i>" + count_failcall + "</i></b></h4></h4>" +
                "<h4>התקשרו לפגישה <b><i>" + count_startdate + "</i></b></h4></h4>";
            return ret;
        }

        private string CreateCol(string tdstyle="",params object[] data) {
            
            string temp = "";
            foreach (object obj in data) {
                temp += "<td + "+ tdstyle + ">" + obj.ToString() +"</td>";
            }
            return temp;
        }

        public string CreateGeneralReport(DateTime? dtstart=null,DateTime? dtend=null)
        {
            int temp = 0;
            SqlParameter date1 = new SqlParameter("@dtstart", dtstart.Value);
            SqlParameter date2 = new SqlParameter("@dtend", dtend.Value);
            string sfilter = " CAST(CURRENT_TIMESTAMP AS DATE) = CAST(date AS DATE) ";
            if (dtstart != null && dtend != null) { 
                sfilter = " (date between @dtstart and @dtend) ";
            }
            string uglysql = "REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(info, '0', '')," +
"'1', ''),'2', ''),'3', ''),'4', ''),'5', ''),'6', ''),'7', ''),'8', ''),'9', ''),'^', '') as clientname";
            SqlDataReader reader = DBFunction.ExecuteReader("select name,users.id as uid," + uglysql + ",action,userid,date,level from log LEFT JOIN USERS ON users.id=log.userid where " +sfilter + " and (action=" + (int)Log.ActionType.ClientOpen +
                " or action=" + (int)Log.ActionType.Login +
                " or action=" + (int)Log.ActionType.PhoneFormOpen + " or action=" + (int)Log.ActionType.GoodDateCall +
                " or action=" + (int)Log.ActionType.StartDate + " or action=" + (int)Log.ActionType.FailCall +
                " or action=" + (int)Log.ActionType.FailDateCall + ")",date1,date2);
            sw = new Dictionary<Log.ActionType, KeyValueClass>();
            sw.Add(Log.ActionType.ClientOpen, new KeyValueClass("", 0));
            sw.Add(Log.ActionType.Login, new KeyValueClass("", 0));
            sw.Add(Log.ActionType.PhoneFormOpen, new KeyValueClass("", 0));
            sw.Add(Log.ActionType.GoodDateCall, new KeyValueClass("", 0));
            sw.Add(Log.ActionType.StartDate, new KeyValueClass("", 0));
            sw.Add(Log.ActionType.FailCall, new KeyValueClass("", 0));
            sw.Add(Log.ActionType.FailDateCall, new KeyValueClass("", 0));
            user = new Dictionary<string, KeyValueClass>();
            client = new Dictionary<string, KeyValueClass>();
            while (reader.Read())
            {
                switch ((Log.ActionType)reader["action"])
                {
                    case Log.ActionType.Login:
                        if (sw.ContainsKey(Log.ActionType.Login))
                        {
                            temp = (int)sw[Log.ActionType.Login].Value;
                            sw[Log.ActionType.Login].Value = ++temp;
                            sw[Log.ActionType.Login].Text+="<tr><td>" + reader["name"].ToString()  +"</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                        }
                       // else      //////// need to create default value for all types of action
                      //  {

                       //     sw.Add(Log.ActionType.Login, new KeyValueClass("<tr><td>" + reader["name"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>",
                       //         1));
                      //  }
                        if (user.ContainsKey(reader["name"].ToString()))
                        {
                            TempData tobj = new TempData();
                            tobj = (TempData)user[reader["name"].ToString()].Value;
                            tobj.opensw++;
                            tobj.openswdata += "<tr><td>" + reader["name"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user[reader["name"].ToString()].Value = tobj;
                        }
                        else
                        {
                            TempData tobj = new TempData();
                            tobj.opensw++;
                            tobj.openswdata += "<tr><td>" + reader["name"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user.Add(reader["name"].ToString(), new KeyValueClass("",
                                tobj));
                        }
                        break;
                    case Log.ActionType.PhoneFormOpen:
                        temp = (int)sw[Log.ActionType.PhoneFormOpen].Value;
                        sw[Log.ActionType.PhoneFormOpen].Value = ++temp;
                        sw[Log.ActionType.PhoneFormOpen].Text += "<tr><td>" + reader["name"].ToString() + "<td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                        if (user.ContainsKey(reader["name"].ToString()))
                        {
                            TempData tobj = new TempData();
                            tobj = (TempData)user[reader["name"].ToString()].Value;
                            tobj.opentel++;
                            tobj.openteldata += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user[reader["name"].ToString()].Value = tobj;
                        }
                        else
                        {
                            TempData tobj = new TempData();
                            tobj.opentel++;
                            tobj.openteldata += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user.Add(reader["name"].ToString(), new KeyValueClass("",
                                tobj));
                        }
                        break;
                    case Log.ActionType.ClientOpen:
                        temp = (int)sw[Log.ActionType.ClientOpen].Value;
                        sw[Log.ActionType.ClientOpen].Value = ++temp;
                        sw[Log.ActionType.ClientOpen].Text += "<tr><td>" + reader["name"].ToString() + "<td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                        if (user.ContainsKey(reader["name"].ToString()))
                        {
                            TempData tobj = new TempData();
                            tobj = (TempData)user[reader["name"].ToString()].Value;
                            tobj.openclient++;
                            tobj.openclientdata += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user[reader["name"].ToString()].Value = tobj;
                        }
                        else
                        {
                            TempData tobj = new TempData();
                            tobj.openclient++;
                            tobj.openclientdata += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user.Add(reader["name"].ToString(), new KeyValueClass("",
                                tobj));
                        }
                        break;
                    case Log.ActionType.GoodDateCall:
                        temp = (int)sw[Log.ActionType.GoodDateCall].Value;
                        sw[Log.ActionType.GoodDateCall].Value = ++temp;
                        sw[Log.ActionType.GoodDateCall].Text += "<tr><td>" + reader["name"].ToString() + "<td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                        if (user.ContainsKey(reader["name"].ToString()))
                        {
                            TempData tobj = new TempData();
                            tobj = (TempData)user[reader["name"].ToString()].Value;
                            tobj.datecall++;
                            tobj.datecalldatat += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user[reader["name"].ToString()].Value = tobj;
                        }
                        else
                        {
                            TempData tobj = new TempData();
                            tobj.datecall++;
                            tobj.datecalldatat += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user.Add(reader["name"].ToString(), new KeyValueClass("",
                                tobj));
                        }
                        break;
                    case Log.ActionType.StartDate:
                        temp = (int)sw[Log.ActionType.StartDate].Value;
                        sw[Log.ActionType.StartDate].Value = ++temp;
                        sw[Log.ActionType.StartDate].Text += "<tr><td>" + reader["name"].ToString() + "<td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                        if (user.ContainsKey(reader["name"].ToString()))
                        {
                            TempData tobj = new TempData();
                            tobj = (TempData)user[reader["name"].ToString()].Value;
                            tobj.startdate++;
                            tobj.startdatedata += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user[reader["name"].ToString()].Value = tobj;
                        }
                        else
                        {
                            TempData tobj = new TempData();
                            tobj.startdate++;
                            tobj.startdatedata += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user.Add(reader["name"].ToString(), new KeyValueClass("",
                                tobj));
                        }
                        break;
                    case Log.ActionType.FailDateCall:
                        temp = (int)sw[Log.ActionType.StartDate].Value;
                        sw[Log.ActionType.FailDateCall].Value = ++temp;
                        sw[Log.ActionType.FailDateCall].Text += "<tr><td>" + reader["name"].ToString() + "<td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                        if (user.ContainsKey(reader["name"].ToString()))
                        {
                            TempData tobj = new TempData();
                            tobj = (TempData)user[reader["name"].ToString()].Value;
                            tobj.callfail++;
                            tobj.callfaildata += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user[reader["name"].ToString()].Value = tobj;
                        }
                        else
                        {
                            TempData tobj = new TempData();
                            tobj.callfail++;
                            tobj.callfaildata += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user.Add(reader["name"].ToString(), new KeyValueClass("",
                                tobj));
                        }
                        break;
                    case Log.ActionType.FailCall:
                        temp = (int)sw[Log.ActionType.StartDate].Value;
                        sw[Log.ActionType.FailDateCall].Value = ++temp;
                        sw[Log.ActionType.FailDateCall].Text += "<tr><td>" + reader["name"].ToString() + "<td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                        if (user.ContainsKey(reader["name"].ToString()))
                        {
                            TempData tobj = new TempData();
                            tobj = (TempData)user[reader["name"].ToString()].Value;
                            tobj.callnoanswer++;
                            tobj.callnoanswerdata += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user[reader["name"].ToString()].Value = tobj;
                        }
                        else
                        {
                            TempData tobj = new TempData();
                            tobj.callnoanswer++;
                            tobj.callnoanswerdata += "<tr><td>" + reader["clientname"].ToString() + "</td>" + "<td>" + reader["date"].ToString() + "</td></tr>";
                            user.Add(reader["name"].ToString(), new KeyValueClass("",
                                tobj));
                        }
                        break;

                }
            }
            reader.Close();
            
            return AnalyzeData();
        }
        private string CreateModal(string id,string data,int type)
        {
            string txt = "<div  id='" + id + "' class='modal fade' role='dialog'><div class='modal-dialog'><div class='modal-content'><div class='modal-header'>";
            txt += " <button style='float:left' type='button' class='close' data-dismiss='modal'>&times;</button><h4 class='modal-title'>פירוט</h4>";
            txt += "</div><div class='modal-body'><div><table class='table table-striped' dir='rtl'><tbody>";
            if (type == 0)
                txt += "<th align='right'>שדכן</th><th>ב</th>";
            else if(type == 1)
                txt += "<th align='right'>שדכן</th><th>ללקוח</th><th>ב</th>";
            else if (type == 2)
                txt += "<th align='right'>לקוח</th><th>ב</th>";
            txt += data;
            txt += "</tbody> </table></div> </div><div class='modal-footer'><button type='button' class='btn btn-default' data-dismiss='modal'>סגור</button></div></div></div></div>";
            return txt;

        }
        private string AnalyzeData()
        {
            int temp = rnd.Next(10000);
            string dialogs = "";
            string txt = Schiduch.Properties.Resources.AnotherReportHeader;
            txt += "<style>th{text-align:right}caption{    text-align: right;}</style>";
            txt += "<body dir=rtl><div class='container'><div class='col-sm-4'><table class='table table-striped' dir='rtl'><tbody><caption><h3>דוח תוכנה</h3></caption>";
            txt+= "<tr data-toggle='modal' data-target='#" + temp +  "'>" + "<th align='right'> מספר הפעמים שנפתחה התוכנה</th>" + "<td>" +
            ((int)sw[Log.ActionType.Login].Value).ToString() + "</td></tr>";
            dialogs += CreateModal(temp.ToString(), sw[Log.ActionType.Login].Text, 0);

            temp = rnd.Next(10000);
            txt += "<tr data-toggle='modal' data-target='#" + temp + "'>" + "<th align='right'>מספר הפעמים שנבדקו טלפונים</th>" + "<td>" +
            ((int)sw[Log.ActionType.PhoneFormOpen].Value).ToString() + "</td></tr>";
            dialogs += CreateModal(temp.ToString(), sw[Log.ActionType.PhoneFormOpen].Text, 1);

            temp = rnd.Next(10000);
            txt += "<tr data-toggle='modal' data-target='#" + temp + "'>" + "<th align='right'> מספר הפעמים שנפתחו כרטיסי לקוח</th>" + "<td>" +
            ((int)sw[Log.ActionType.ClientOpen].Value).ToString() + "</td></tr>";
            dialogs += CreateModal(temp.ToString(), sw[Log.ActionType.ClientOpen].Text, 1);

            temp = rnd.Next(10000);
            txt += "<tr data-toggle='modal' data-target='#" + temp + "'>" + "<th align='right'> מספר הפעמים שהתקשרו והציעו הצעה</th>" + "<td>" +
            ((int)sw[Log.ActionType.GoodDateCall].Value).ToString() + "</td></tr>";
            dialogs += CreateModal(temp.ToString(), sw[Log.ActionType.GoodDateCall].Text, 1);

            temp = rnd.Next(10000);
            txt += "<tr data-toggle='modal' data-target='#" + temp + "'>" + "<th align='right'> מספר הפעמים שהוציאו לפגישה</th>" + "<td>" +
            ((int)sw[Log.ActionType.StartDate].Value).ToString() + "</td></tr>";
            dialogs += CreateModal(temp.ToString(), sw[Log.ActionType.StartDate].Text, 1);

            temp = rnd.Next(10000);
            txt += "<tr data-toggle='modal' data-target='#" + temp + "'>" + "<th align='right'> מספר הפעמים שהתקשרו הציעו ולא יצא</th>" + "<td>" +
            ((int)sw[Log.ActionType.FailDateCall].Value).ToString() + "</td></tr>";
            dialogs += CreateModal(temp.ToString(), sw[Log.ActionType.FailDateCall].Text, 1);

            temp = rnd.Next(10000);
            txt += "<tr data-toggle='modal' data-target='#" + temp + "'>" + "<th align='right'> מספר הפעמים שהתקשרו ולא ענו</th>" + "<td>" +
            ((int)sw[Log.ActionType.FailCall].Value).ToString() + "</td></tr>";
            dialogs += CreateModal(temp.ToString(), sw[Log.ActionType.FailCall].Text, 1);

            txt += "</tbody></table></div>"; // end of table sw report

            txt += "<div class='col-sm-6'>"; // start of user report
            txt += "<table class='table table-striped' dir='rtl'><tbody><caption><h3>דו'ח שדכנים</h3></caption><th align='right'>השדכן</th><th>פתח תוכנה</th><th>פתח כרטיס לקוח</th><th>בדק מה הטלפון</th>";
            txt += "<th>התחיל פגישות</th><th>הציע ויצא</th>";

            foreach(string it in user.Keys)
            {
                temp = rnd.Next(10000);
                txt += "<tr><td>" +
                it + "</td><td data-toggle='modal' data-target='#a" + temp + "'>" +
                ((TempData)user[it].Value).opensw.ToString() + "</td><td data-toggle='modal' data-target='#b" + temp + "'>" +
                ((TempData)user[it].Value).openclient.ToString() + "</td><td data-toggle='modal' data-target='#c" + temp + "'>" +
                ((TempData)user[it].Value).opentel.ToString() + "</td><td data-toggle='modal' data-target='#d" + temp + "'>" +
                ((TempData)user[it].Value).startdate.ToString() + "</td><td data-toggle='modal' data-target='#e" + temp + "'>" +
                ((TempData)user[it].Value).datecall.ToString() + "</td>";



                dialogs += CreateModal("a" + temp.ToString(), ((TempData)user[it].Value).openswdata, 2);
                dialogs += CreateModal("b" + temp.ToString(), ((TempData)user[it].Value).openclientdata, 2);
                dialogs += CreateModal("c" + temp.ToString(), ((TempData)user[it].Value).openteldata, 2);
                dialogs += CreateModal("d" + temp.ToString(), ((TempData)user[it].Value).startdatedata, 2);
                dialogs += CreateModal("e" + temp.ToString(), ((TempData)user[it].Value).datecalldatat, 2);
                
            }
            

            txt += "</tbody></table></div>"; // end of table user report

            txt += dialogs;
            txt += Schiduch.Properties.Resources.ReportEnd;
            return txt;
        }
        private string CreateTH(string thstyle = "", params object[] data)
        {

            string temp = "";
            foreach (object obj in data)
            {
                temp += "<th + " + thstyle + ">" + obj.ToString() + "</th>";
            }
            return temp;
        }
    }

    class TempData
    {
        public string name;
        public int id=0;
        public int opensw = 0;
        public string openswdata = "";
        public string openteldata = "";
        public string openclientdata = "";
        public int openclient=0;
        public int opentel=0;
        public int datecall=0;
        public string datecalldatat = "";
        public int callfail=0;
        public string callfaildata = "";
        public int callnoanswer=0;
        public string callnoanswerdata = "";
        public int startdate = 0;
        public string startdatedata = "";
    }


}
