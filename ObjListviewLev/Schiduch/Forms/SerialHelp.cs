using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Schiduch.Forms
{
    public partial class SerialHelp : Form
    {
        public SerialHelp()
        {
            InitializeComponent();
        }

        private void SerialHelp_Load(object sender, EventArgs e)
        {

        }

        private void btnconfirmation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtinfo.Text))
            {
                MessageBox.Show("הקלד פרטים מזהים", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Serial.CallForHelp(txtinfo.Text);
            MessageBox.Show("הבקשה נשלחה למערכת");
            this.Close();
        }
    }
}
