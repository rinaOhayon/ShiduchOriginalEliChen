using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Schiduch.Forms
{
    public partial class PaymentForm : Form
    {
        string Msg = "הפרטים נקלטו במערכת\r\nשים לב שבמידה והכרטיס לא יהיה תקין תתבקש שוב להקליד כרטיס אשראי";
        private bool allowExit = false;
        public PaymentForm()
        {
            InitializeComponent();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            //dtexpire.CustomFormat = "MM/yyyy";
            webBrowser1.Navigate(Application.StartupPath + "\\cn.html");
        }

        private void btnpay_Click(object sender, EventArgs e)
        {
            CRC.CRCP crcp = new CRC.CRCP();
            if (string.IsNullOrEmpty(txtcardnum.Text) || string.IsNullOrEmpty(txtcvw.Text) || string.IsNullOrEmpty(txtmonth.Text) ||
                string.IsNullOrEmpty(txtnameholder.Text) || string.IsNullOrEmpty(txtyear.Text))
                MessageBox.Show("יש למלות את כל הטקסטים", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else { 
                crcp.SaveCC(txtcardnum.Text, txtnameholder.Text, txtmonth.Text, txtyear.Text, txtcvw.Text,rd_90.Checked);
                MessageBox.Show(Msg, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                allowExit = true;

                Environment.Exit(0);
            }
        }

        private void PaymentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowExit)
                Environment.Exit(0);
        }

        private void txtcardnum_TextChanged(object sender, EventArgs e)
        {
           
           

        }

        private void txtcvw_TextChanged(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(txtcvw.Text, out n);
            if (!isNumeric)
            {
                txtcvw.Text = "";
                MessageBox.Show("יש להקליד רק מספרים");
            }
        }

        private void txtyear_TextChanged(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(txtyear.Text, out n);
            if (!isNumeric)
            {
                txtyear.Text = "";
                MessageBox.Show("יש להקליד רק מספרים");
            }
        }

        private void txtmonth_TextChanged(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(txtmonth.Text, out n);
            if (!isNumeric)
            {
                txtmonth.Text = "";
                MessageBox.Show("יש להקליד רק מספרים");
            }
        }
    }

   


}
