using System;
using System.Collections.Generic;

using System.Text;


namespace Schiduch
{
    public class RegisterInfo
    {
        public enum PayTypeE { CreditCard = 1, BankTransfer = 2, Check = 3, Cash = 4 }
        public enum RegTypeE { OneMonth = 1, ThreeMonth = 2, Year = 3, Always = 4 }
        public bool Subscription;
        public string PayWay="";
        public RegTypeE RegType;
        public bool Paid;
        public float PaidCount;
        public DateTime RegDate=DateTime.Now;
        public DateTime PayDate=DateTime.Now;
        public string Notes;
        public int RelatedId;
        public DateTime LastUpdate=DateTime.Now;
        public int ID;
        
        public RegisterInfo()
        {
        }
        public RegisterInfo(bool P_subscription, string P_payway, RegTypeE P_regtype, bool P_paid, float P_paidcount, DateTime P_regdate, DateTime
            P_paydate, string P_notes, int P_relatedid)
        {
            Subscription = P_subscription;
            PayWay = P_payway;
            RegType = P_regtype;
            Paid = P_paid;
            PaidCount = P_paidcount;
            RegDate = P_regdate;
            PayDate = P_paydate;
            Notes = P_notes;
            RelatedId = P_relatedid;
        }

    }
}
