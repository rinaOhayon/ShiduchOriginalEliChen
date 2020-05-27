using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Schiduch
{
    public partial class Construction : Form
    {
        public Construction()
        {
            InitializeComponent();
        }

        private void Construction_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Construction_Load(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}
