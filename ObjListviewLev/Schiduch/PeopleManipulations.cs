using System;
using System.Collections.Generic;

using System.Text;

using System.Data.SqlClient;

namespace Schiduch
{
    class PeopleManipulations
    {
        public enum RtpFor { ForSearch = 1,ForTempData=2 };
        public static bool ReaderToPeople(ref People peopleobj,ref SqlDataReader reader,bool register=false, bool detail=false)
        {

            peopleobj.Age = float.Parse(reader["Age"].ToString());
            peopleobj.Background = (string)reader["Background"];
            peopleobj.Beard = (string)reader["Beard"];
            peopleobj.City = (string)reader["city"];
            peopleobj.CoverHead = (string)reader["CoverHead"];
            peopleobj.DadWork = (string)reader["DadWork"];
            peopleobj.Eda = (string)reader["Eda"];
            peopleobj.FaceColor = (string)reader["FaceColor"];
            peopleobj.FirstName = (string)reader["FirstName"];
            peopleobj.FutureLearn = (bool)reader["FutureLearn"];
            peopleobj.GorTorN = (string)reader["GorTorN"];
            peopleobj.ID = (int)reader["relatedid"];
            peopleobj.Lasname = (string)reader["Lastname"];
            peopleobj.Looks = (string)reader["Looks"];
            peopleobj.OpenHead = (string)reader["OpenHead"];
            peopleobj.WorkPlace = (string)reader["WorkPlace"];
            peopleobj.Sexs = (string)reader["Sexs"];
            peopleobj.Show = int.Parse(reader["Show"].ToString());
            peopleobj.StakeM = (string)reader["StakeM"];
            peopleobj.Status = (string)reader["Status"];
            peopleobj.Details.OwnChildrenCount = int.Parse((string)reader["OwnChildrenCount"].ToString());
            peopleobj.Tall = float.Parse(reader["Tall"].ToString()) ;
            peopleobj.TneedE = (string)reader["TneedE"];
            peopleobj.Weight = reader["fat"].ToString();
            peopleobj.Zerem = (string)reader["Zerem"];
            peopleobj.LearnStaus = (string)reader["LearnStatus"] ;
            peopleobj.Details.MoneyToShadchan = (string)reader["MoneyToShadchan"];



            if (register)
            {
                peopleobj.Register.ID = (int)reader["ID"];
                peopleobj.Register.Notes = (string)reader["regnotes"];
                peopleobj.Register.Paid = (bool)reader["paid"];
                peopleobj.Register.PaidCount = float.Parse(reader["PaidCount"].ToString());
                peopleobj.Register.PayDate = DateTime.Parse(reader["paydate"].ToString());
                peopleobj.Register.RegDate = DateTime.Parse(reader["regdate"].ToString());
                peopleobj.Register.PayWay = reader["payway"].ToString();
                //peopleobj.Register.RegType=(RegisterInfo.RegTypeE)reader["type"];
                peopleobj.Register.RelatedId = (int)reader["relatedid"];
                peopleobj.Register.Subscription = (bool)reader["Subscription"];
                peopleobj.Register.LastUpdate = DateTime.Parse(reader["lastupdate"].ToString());
            }

            if (detail)
            {
                //need to addd chadcan
                try
                {
                    peopleobj.Details.Chadchan =reader["chadchan"].ToString();
                }
                catch(Exception e) { };
                peopleobj.Details.ChildrenCount = (int)reader["ChildrenCount"];
                peopleobj.Details.DadName = (string)reader["DadName"];
                peopleobj.Details.Faileds = (string)reader["Faileds"];
                peopleobj.Details.FriendsInfo = (string)reader["FriendsInfo"];
                peopleobj.Details.HomeRav = (string)reader["HomeRav"];
                peopleobj.Details.MechutanimNames = (string)reader["MechutanimNames"];
                peopleobj.Details.MomLname = (string)reader["MomLname"];
                peopleobj.Details.MomName = (string)reader["MomName"];
                peopleobj.Details.MomWork = (string)reader["MomWork"];
                peopleobj.Details.MoneyGives = float.Parse(reader["MoneyGives"].ToString());
                peopleobj.Details.MoneyRequired = float.Parse(reader["MoneyRequired"].ToString());
                peopleobj.Details.MoneyNotes = (string)reader["MoneyNotes"];
               // peopleobj.Details.Pic = (string)reader["Pic"];
                peopleobj.Details.RelatedId = (int)reader["relatedid"];
                peopleobj.Details.Schools = (string)reader["Schools"];
                peopleobj.Details.SiblingsSchools = (string)reader["SiblingsSchools"];
                peopleobj.Details.Street = (string)reader["street"];
                peopleobj.Details.Tel1 = (string)reader["tel1"];
                peopleobj.Details.Tel2 = (string)reader["tel2"];
                peopleobj.Details.WhoAmI = (string)reader["whoami"];
                peopleobj.Details.Notes = (string)reader["notes"];
                peopleobj.Details.WhoIWant = (string)reader["WhoIWant"];
                peopleobj.Details.WithRavIn = (string)reader["WithRavIn"];
                peopleobj.Details.ZevetInfo = (string)reader["ZevetInfo"];
            }
            
            if (GLOBALVARS.MyUser.Control > User.TypeControl.User && DBFunction.ColumnExists(reader, "Reason"))
            {
                peopleobj.Reason = (int)reader["reason"];
                peopleobj.RealId = int.Parse(reader["mrelatedID"].ToString());
                peopleobj.TempId = (int)reader["TID"];
                peopleobj.ByUser = (int)reader["ByUser"];
            }

            return true;
        }
        public static bool ReaderToPeople(ref People peopleobj, ref SqlDataReader reader,RtpFor WhatFor)
        {
            if (WhatFor == RtpFor.ForSearch)
            {
                peopleobj.Age = float.Parse(reader["Age"].ToString());
                peopleobj.Lasname = (string)reader["lastname"];
                peopleobj.Sexs = (string)reader["sexs"];
                peopleobj.FirstName = (string)reader["firstname"];
                peopleobj.Details.Chadchan = (string)reader["Chadchan"];
                peopleobj.Details.Schools = (string)reader["schools"];
                peopleobj.Tall = float.Parse(reader["tall"].ToString());
                peopleobj.Details.Notes = (string)reader["notes"];
                peopleobj.Show = (int)reader["show"];
                peopleobj.Details.MoneyToShadchan = (string)reader["MoneyToShadchan"];
                peopleobj.ID = int.Parse(reader["id"].ToString());
                try
                {
                    //peopleobj.Register.LastUpdate = (DateTime)reader["lastupdate"];
                    if (GLOBALVARS.MyUser.Control > User.TypeControl.User && DBFunction.ColumnExists(reader, "Reason"))
                    {
                        peopleobj.Reason = (int)reader["reason"];
                        peopleobj.ByUser = (int)reader["byuser"];
                        peopleobj.RealId = int.Parse(reader["mrelatedID"].ToString());
                        peopleobj.TempId = (int)reader["TID"];

                    }
                }
                catch { };
                

            }
            return true;
        }
        public static People ReaderToPeopleCopy(ref People peopleobj, ref SqlDataReader reader, RtpFor WhatFor)
        {
            
            if (WhatFor == RtpFor.ForSearch)
            {
                peopleobj.Age = float.Parse(reader["Age"].ToString());
                peopleobj.Lasname = (string)reader["lastname"];
                peopleobj.Sexs = (string)reader["sexs"];
                peopleobj.FirstName = (string)reader["firstname"];
                peopleobj.Details.Chadchan = (string)reader["Chadchan"];
                peopleobj.Details.Schools = (string)reader["schools"];
                peopleobj.Tall = float.Parse(reader["tall"].ToString());
                peopleobj.Details.Notes = (string)reader["notes"];
                peopleobj.Show = (int)reader["show"];
                peopleobj.ID = int.Parse(reader["id"].ToString());
                try
                {
                    //peopleobj.Register.LastUpdate = (DateTime)reader["lastupdate"];
                    if (GLOBALVARS.MyUser.Control > User.TypeControl.User && DBFunction.ColumnExists(reader, "Reason"))
                    {
                        peopleobj.Reason = (int)reader["reason"];
                        peopleobj.ByUser = (int)reader["byuser"];
                        peopleobj.RealId = int.Parse(reader["mrelatedID"].ToString());
                        peopleobj.TempId = (int)reader["TID"];

                    }
                }
                catch { };


            }
            return peopleobj;
        }
        public static bool TempToSet(People p,int realid)
        {
            string sql = "";
            string where = " WHERE ID=" + realid;
            string Rwhere = " WHERE RELATEDID=" + realid;
            string tblpeople = "Peoples";
            string tbldetails = "Peopledetails";
            bool PlusTblReg = false;
            SqlParameter[] prms = new SqlParameter[70];

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
                BuildSql.UpdateSql(out prms[15], p.Sexs, "Sexs") +
                BuildSql.UpdateSql(out prms[16], p.Show, "show") +
                BuildSql.UpdateSql(out prms[17], p.StakeM, "StakeM") +
                BuildSql.UpdateSql(out prms[18], p.Status, "Status") +
                BuildSql.UpdateSql(out prms[19], p.Tall, "Tall") +
                BuildSql.UpdateSql(out prms[20], p.TneedE, "TneedE") +
                BuildSql.UpdateSql(out prms[59], p.LearnStaus, "LearnStatus") +
                BuildSql.UpdateSql(out prms[21], p.Zerem, "Zerem") +
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
                BuildSql.UpdateSql(out prms[38], realid, "RelatedId") +
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
                BuildSql.UpdateSql(out prms[60], p.Details.MoneyToShadchan, "MoneyToShadchan", true)+
                Rwhere + ";";
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
        }

        public static bool ShowHide()
        {
            string Sql = "Userid=" + GLOBALVARS.MyUser.ID + " AND ALLOWID=" + GLOBALVARS.MyPeople.ID;
            if (DBFunction.CheckExist(Sql, "LimitedAllow"))
            {
                return true;
            }
            return false;
        }

        public static People ConvertNotesToPeople(string Note)
        {
            People ret = new People();
            string[] Spl = Note.Split('|');

            //fill people object
            ret.Age = float.Parse(Spl[0]);
            ret.Background = Spl[1];
            ret.Beard = Spl[2];
            ret.ByUser = int.Parse(Spl[3]);
            ret.City = Spl[4];
            ret.CoverHead = Spl[5];
            ret.DadWork = Spl[6];
            ret.Eda = Spl[7];
            ret.FaceColor = Spl[8];
            ret.FirstName = Spl[9];
            ret.FutureLearn = bool.Parse(Spl[10]);
            ret.GorTorN = Spl[11];
            ret.ID = int.Parse(Spl[12]);
            ret.Lasname = Spl[13];
            ret.LearnStaus = Spl[14];
            ret.Looks = Spl[15];
            ret.OpenHead = Spl[16];
            ret.RealId = ret.ID;
            ret.Reason = int.Parse(Spl[17]);
            ret.Sexs = Spl[18];
            ret.Show = int.Parse(Spl[19]);
            ret.StakeM = Spl[20];
            ret.Status = Spl[21];
            ret.Tall =float.Parse( Spl[22]);
            ret.TneedE = Spl[23];
            ret.Weight = Spl[24];
            ret.WorkPlace = Spl[25];
            ret.Zerem = Spl[26];

            //fill people.detailes object
           // ret.Details.Chadchan = int.Parse(Spl[27]);
            ret.Details.ChildrenCount = int.Parse(Spl[28]);
            ret.Details.DadName = Spl[29];
            ret.Details.Faileds = Spl[30];
            ret.Details.FriendsInfo = Spl[31];
            ret.Details.HomeRav = Spl[32];
            ret.Details.MechutanimNames = Spl[33];
            ret.Details.MomLname = Spl[34];
            ret.Details.MomName = Spl[35];
            ret.Details.MomWork = Spl[36];
            ret.Details.MoneyGives = float.Parse(Spl[37]);
            ret.Details.MoneyNotes = Spl[38];
            ret.Details.MoneyRequired = float.Parse(Spl[39]);
            ret.Details.MoneyToShadchan = Spl[40];
            ret.Details.Notes = Spl[41];
            ret.Details.OwnChildrenCount = int.Parse(Spl[42]);
            ret.Details.RelatedId = int.Parse(Spl[43]);
            ret.Details.Schools = Spl[44];
            ret.Details.SiblingsSchools = Spl[45];
            ret.Details.Street = Spl[46];
            ret.Details.Tel1 = Spl[47];
            ret.Details.Tel2 = Spl[48];
            ret.Details.WhoAmI = Spl[49];
            ret.Details.WhoIWant = Spl[50];
            ret.Details.WithRavIn = Spl[51];
            ret.Details.ZevetInfo = Spl[52];

            //fill people.register 
            ret.Register.ID = int.Parse(Spl[53]);
            ret.Register.Notes = Spl[54];
            ret.Register.Paid =bool.Parse( Spl[55]);
            ret.Register.PaidCount =float.Parse( Spl[56]);
            ret.Register.PayDate =DateTime.Parse( Spl[57]);
            ret.Register.PayWay = Spl[58];
            ret.Register.RegDate =DateTime.Parse( Spl[59]);
            ret.Register.RegType =(RegisterInfo.RegTypeE)int.Parse(Spl[60]);
            ret.Register.RelatedId = ret.Details.RelatedId;
            ret.Register.Subscription = bool.Parse(Spl[61]);


            //temp notes
            ret.TempNotes=Spl[62];

            
            return ret;
           
        }
        public static string ConvertPeopleToNote(People Note)
        {
            string ret = null;
            ret = Note.Age.ToString() + "|" +
                Note.Background + "|" +
                Note.Beard + "|" +
                Note.ByUser.ToString() + "|" +
                Note.City + "|" +
                Note.CoverHead + "|" +
                Note.DadWork + "|" +
                Note.Eda + "|" +
                Note.FaceColor + "|" +
                Note.FirstName + "|" +
                Note.FutureLearn.ToString() + "|" +
                Note.GorTorN + "|" +
                Note.ID.ToString() + "|" +
                Note.Lasname + "|" +
                Note.LearnStaus + "|" +
                Note.Looks + "|" +
                Note.OpenHead + "|" +
                Note.Reason.ToString() + "|" +
                Note.Sexs + "|" +
                Note.Show.ToString() + "|" +
                Note.StakeM + "|" +
                Note.Status + "|" +
                Note.Tall.ToString() + "|" +
                Note.TneedE + "|" +
                Note.Weight + "|" +
                Note.WorkPlace + "|" +
                Note.Zerem + "|" +

                Note.Details.Chadchan.ToString() + "|" +
                Note.Details.ChildrenCount.ToString() + "|" +
                Note.Details.DadName + "|" +
                Note.Details.Faileds + "|" +
                Note.Details.FriendsInfo + "|" +
                Note.Details.HomeRav + "|" +
                Note.Details.MechutanimNames + "|" +
                Note.Details.MomLname + "|" +
                Note.Details.MomName + "|" +
                Note.Details.MomWork + "|" +
                Note.Details.MoneyGives.ToString() + "|" +
                Note.Details.MoneyNotes + "|" +
                Note.Details.MoneyRequired.ToString() + "|" +
                Note.Details.MoneyToShadchan + "|" +
                Note.Details.Notes + "|" +
                Note.Details.OwnChildrenCount.ToString() + "|" +
                Note.Details.RelatedId.ToString() + "|" +
                Note.Details.Schools + "|" +
                Note.Details.SiblingsSchools + "|" +
                Note.Details.Street + "|" +
                Note.Details.Tel1 + "|" +
                Note.Details.Tel2 + "|" +
                Note.Details.WhoAmI + "|" +
                Note.Details.WhoIWant + "|" +
                Note.Details.WithRavIn + "|" +
                Note.Details.ZevetInfo + "|" +


                Note.Register.ID.ToString() + "|" +
                Note.Register.Notes + "|" +
                Note.Register.Paid.ToString() + "|" +
                Note.Register.PaidCount.ToString() + "|" +
                Note.Register.PayDate.ToString() + "|" +
                Note.Register.PayWay + "|" +
                Note.Register.RegDate.ToString() + "|" +
                ((int)Note.Register.RegType).ToString() + "|" +
                Note.Register.Subscription.ToString() + "|" +

                Note.TempNotes;
            return ret;
        }

        public static bool AllowHide(int id,int toid)
        {
            string Sql = "insert into LimitedAllow(UserId,AllowId) VALUES(" + id + "," + toid + ")";
            return DBFunction.Execute(Sql);
        }

    }
}
