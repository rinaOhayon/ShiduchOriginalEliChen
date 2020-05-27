namespace Schiduch.Forms
{
    partial class PaymentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rd_big = new System.Windows.Forms.RadioButton();
            this.rd_90 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtmonth = new System.Windows.Forms.TextBox();
            this.txtyear = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtnameholder = new System.Windows.Forms.TextBox();
            this.txtcvw = new System.Windows.Forms.TextBox();
            this.txtcardnum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnpay = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "שדכנים יקרים שלום רב";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rd_big);
            this.panel1.Controls.Add(this.rd_90);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtmonth);
            this.panel1.Controls.Add(this.txtyear);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtnameholder);
            this.panel1.Controls.Add(this.txtcvw);
            this.panel1.Controls.Add(this.txtcardnum);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnpay);
            this.panel1.Location = new System.Drawing.Point(161, 387);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 191);
            this.panel1.TabIndex = 2;
            // 
            // rd_big
            // 
            this.rd_big.AutoSize = true;
            this.rd_big.Location = new System.Drawing.Point(160, 161);
            this.rd_big.Name = "rd_big";
            this.rd_big.Size = new System.Drawing.Size(117, 17);
            this.rd_big.TabIndex = 14;
            this.rd_big.Text = "מסלול תשלום 250";
            this.rd_big.UseVisualStyleBackColor = true;
            this.rd_big.Visible = false;
            // 
            // rd_90
            // 
            this.rd_90.AutoSize = true;
            this.rd_90.Checked = true;
            this.rd_90.Location = new System.Drawing.Point(130, 138);
            this.rd_90.Name = "rd_90";
            this.rd_90.Size = new System.Drawing.Size(147, 17);
            this.rd_90.TabIndex = 13;
            this.rd_90.TabStop = true;
            this.rd_90.Text = "מסלול תשלום חודשי 90";
            this.rd_90.UseVisualStyleBackColor = true;
            this.rd_90.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "/";
            // 
            // txtmonth
            // 
            this.txtmonth.Location = new System.Drawing.Point(26, 99);
            this.txtmonth.Name = "txtmonth";
            this.txtmonth.Size = new System.Drawing.Size(44, 20);
            this.txtmonth.TabIndex = 4;
            this.txtmonth.TextChanged += new System.EventHandler(this.txtmonth_TextChanged);
            // 
            // txtyear
            // 
            this.txtyear.Location = new System.Drawing.Point(92, 99);
            this.txtyear.Name = "txtyear";
            this.txtyear.Size = new System.Drawing.Size(44, 20);
            this.txtyear.TabIndex = 3;
            this.txtyear.TextChanged += new System.EventHandler(this.txtyear_TextChanged);
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageKey = "close-icon-29.png";
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(339, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "יציאה";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Icon_13-512.png");
            this.imageList1.Images.SetKeyName(1, "close-icon-29.png");
            // 
            // txtnameholder
            // 
            this.txtnameholder.Location = new System.Drawing.Point(26, 59);
            this.txtnameholder.Name = "txtnameholder";
            this.txtnameholder.Size = new System.Drawing.Size(285, 20);
            this.txtnameholder.TabIndex = 1;
            // 
            // txtcvw
            // 
            this.txtcvw.Location = new System.Drawing.Point(192, 100);
            this.txtcvw.Name = "txtcvw";
            this.txtcvw.Size = new System.Drawing.Size(64, 20);
            this.txtcvw.TabIndex = 2;
            this.txtcvw.TextChanged += new System.EventHandler(this.txtcvw_TextChanged);
            // 
            // txtcardnum
            // 
            this.txtcardnum.Location = new System.Drawing.Point(26, 18);
            this.txtcardnum.Name = "txtcardnum";
            this.txtcardnum.Size = new System.Drawing.Size(285, 20);
            this.txtcardnum.TabIndex = 0;
            this.txtcardnum.TextChanged += new System.EventHandler(this.txtcardnum_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10.25F);
            this.label6.Location = new System.Drawing.Point(317, 59);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "שם בעל הכרטיס :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.25F);
            this.label5.Location = new System.Drawing.Point(142, 100);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "תוקף :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10.25F);
            this.label4.Location = new System.Drawing.Point(260, 101);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(180, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "3 ספרות אחרונות בגב הכרטיס :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.25F);
            this.label3.Location = new System.Drawing.Point(317, 18);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "מספר הכרטיס :";
            // 
            // btnpay
            // 
            this.btnpay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpay.ImageKey = "Icon_13-512.png";
            this.btnpay.ImageList = this.imageList1;
            this.btnpay.Location = new System.Drawing.Point(13, 137);
            this.btnpay.Name = "btnpay";
            this.btnpay.Size = new System.Drawing.Size(90, 41);
            this.btnpay.TabIndex = 5;
            this.btnpay.Text = "אישור";
            this.btnpay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnpay.UseVisualStyleBackColor = true;
            this.btnpay.Click += new System.EventHandler(this.btnpay_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(619, 401);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(29, 43);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(833, 338);
            this.webBrowser1.TabIndex = 4;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(874, 590);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "תשלום";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PaymentForm_FormClosing);
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtnameholder;
        private System.Windows.Forms.TextBox txtcvw;
        private System.Windows.Forms.TextBox txtcardnum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnpay;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtmonth;
        private System.Windows.Forms.TextBox txtyear;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.RadioButton rd_big;
        private System.Windows.Forms.RadioButton rd_90;
    }
}