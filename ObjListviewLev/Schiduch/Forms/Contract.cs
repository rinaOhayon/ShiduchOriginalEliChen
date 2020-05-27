using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Schiduch.Forms
{
    public partial class Contract : Form
    {
        private bool goodexit=false;
        private string sfile = Application.StartupPath + "\\cont.pr";
        private int x, y;
        bool sign = false;
        bool tempopen = false;
        private Point? _Previous = null;
        private string sname;
        private Pen _Pen = new Pen(Color.Black);
        public Contract(string sname)
        {
            InitializeComponent();
            this.sname = sname;
            
        }
        public Contract(bool temp)
        {
            InitializeComponent();
            tempopen = temp;

        }

        private void Contract_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            if (tempopen)
            {
                picsign.Load(Application.StartupPath + "\\temp.png");
                return;
            }
            _Pen.Width = 3;
            string sql = "";
            if (File.Exists(sfile))
            {
                FileInfo finfo = new FileInfo(sfile);
                sql =" where createtime > " + finfo.CreationTime.ToShortDateString();
            }
            SqlDataReader reader = DBFunction.ExecuteReader("select signdata from contract " + sql);
                if (reader.Read())
                {
                byte[] data = (byte[])reader["signdata"];
                File.WriteAllBytes(sfile, data);
                }
            reader.Close();
            picsign.Load(sfile);
            Rectangle rect = picsign.ClientRectangle;
            Graphics g = Graphics.FromImage(picsign.Image);
            SolidBrush brush = new SolidBrush(Color.Black);
            Font f = new Font("Arial", 15);
            g.DrawString("חתום על החוזה : " + sname, f, brush, new PointF(10, 10));
            picsign.Refresh();
        }

        private void picsign_MouseDown(object sender, MouseEventArgs e)
        {
            _Previous = new Point(e.X, e.Y);
            picsign_MouseMove(sender, e);
        }

        private void picsign_MouseMove(object sender, MouseEventArgs e)
        {
            if (_Previous != null)
            {
                if (picsign.Image == null)
                {
                    Bitmap bmp = new Bitmap(picsign.Width, picsign.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                    }
                    picsign.Image = bmp;
                }
                using (Graphics g = Graphics.FromImage(picsign.Image))
                {
                    g.DrawLine(_Pen, _Previous.Value.X, _Previous.Value.Y, e.X, e.Y);
                    sign = true;
                }
                picsign.Invalidate();
                _Previous = new Point(e.X, e.Y);
            }
        }

        private void picsign_MouseUp(object sender, MouseEventArgs e)
        {
            _Previous = null;
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (!sign)
            {
                MessageBox.Show("יש לחתום על החוזה", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btn_confirm.Enabled = false;

            picsign.Image.Save(Application.StartupPath + "\\conf.bin", ImageFormat.Jpeg);
            SqlParameter[] prms = new SqlParameter[2];
            byte[] sfile = File.ReadAllBytes(Application.StartupPath + "\\conf.bin");
            prms[0] = new SqlParameter("@contract", sfile);
            
            bool good = DBFunction.Execute("update users set sign=@contract,signok=1 where id=" + GLOBALVARS.MyUser.ID, prms);
            if (good) {
                File.Delete("User");
                MessageBox.Show("חוזה עודכן בהצלחה\r\nיש להפעיל את התוכנה מחדש", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.AddAction(Log.ActionType.SignContract, new Log(Log.ActionType.SignContract));
                goodexit = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("התרחשה שגיאה בעדכון חוזה", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btn_confirm.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void picsign_Click(object sender, EventArgs e)
        {

        }

        private void btn_helpsign_Click(object sender, EventArgs e)
        {
            MessageBox.Show("הולכים עם העכבר אל מקום החתימה\nלוחצים על העכבר ומתחילים לחתום", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Contract_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!goodexit && !tempopen)
            Application.Exit();
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(this.Height+100 + x,this.Width-200+y);
            Cursor.Clip = new Rectangle(this.Location, this.Size);
            x = y++;
            if (x == 50)
                tmr1.Enabled = false;
        }
    }
}
