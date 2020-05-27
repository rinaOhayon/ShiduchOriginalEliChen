using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;
using System.Data.SqlClient;

namespace Schiduch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeopleDetails detail = new PeopleDetails();
            //detail.Chadchan = "meni";
            detail.ChildrenCount = 3;
            detail.DadName = "avi";
            detail.Faileds = "with rar";
            detail.FriendsInfo = "ari 012";
            detail.HomeRav = "stinaman";
            detail.MechutanimNames = "alul";
            detail.Notes = "notetets";
            detail.MomLname = "svisa";
            detail.MomName = "viva";
            detail.MomWork = "mora";
            detail.MoneyGives = 100f;
            detail.MoneyRequired = 200f;
            detail.MoneyNotes = "riri";
            detail.Pic = "non";
            detail.Schools = "ssssss";
            detail.SiblingsSchools = "sdsdsdsd";
            detail.Street = "avvvvv 1";
            detail.Tel1 = "1";
            detail.Tel2 = "2";
            detail.WhoAmI = "lklklk";
            detail.WhoIWant = "sssssdrrtt";
            detail.WithRavIn = "lokas";
            detail.ZevetInfo = "zevet";


            RegisterInfo reg = new RegisterInfo();
            reg.Subscription = true;
            reg.RegType = RegisterInfo.RegTypeE.Always;
            //reg.PayWay = RegisterInfo.PayTypeE.CreditCard;
            reg.Notes = "none";
            reg.Paid = true ;
            reg.PaidCount = 100;
            reg.PayDate = DateTime.Now;
            reg.RegDate = DateTime.Now;


            People people = new People();
            people.Age = 12;
            people.Background = "bg";
            people.Beard = "y";
            people.City = "b";
            people.CoverHead = "ch";
            people.DadWork = "work";
            people.Eda = "sefardi";
            people.FaceColor = "red";
            people.FirstName = "noone";
            people.FutureLearn = true;
            people.GorTorN = "g";
            people.Lasname = "chen";
            people.Looks = "good";
            people.OpenHead = "openhead";
            people.Sexs = "z";
            people.Show = 1;
            people.StakeM = "yes";
            people.Status = "dd";
            people.Tall = 12.56f;
            people.TneedE = "yes";
            people.Weight = "nice man";
            people.Zerem = "hh";
            people.Details = detail;
            people.Register = reg;
            People.InsretNew(people);// (people);
            MessageBox.Show("Added");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataReader reader;
            reader=People.ReadAll(0);
            if (reader != null)
            {
                People p = new People();
                

                reader.Read();
                
                PeopleManipulations.ReaderToPeople(ref p,ref reader,true,true);
                MessageBox.Show(p.Details.RelatedId.ToString());
                reader.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
