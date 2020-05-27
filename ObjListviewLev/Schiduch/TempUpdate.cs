using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Schiduch
{
    public partial class TempUpdate : Form
    {
        
        public TempUpdate()
        {
            InitializeComponent();
        }
   

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            GLOBALVARS.MyPeople.TempNotes = txtnotes.Text;
            People.UpdatePeople(false, false, PeopleManipulations.ConvertPeopleToNote(GLOBALVARS.MyPeople));
            this.Close();
        }
    }
}
