namespace Schiduch.Forms
{
    partial class FrmPhone
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhone));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblinfo = new System.Windows.Forms.Label();
            this.btngooddate = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnfailcall = new System.Windows.Forms.Button();
            this.btnfaildate = new System.Windows.Forms.Button();
            this.btn_makedate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(229, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "פרטים ליצירת קשר";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(178, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "בחרו מאחת האפשרויות הבאות";
            // 
            // lblinfo
            // 
            this.lblinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblinfo.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblinfo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblinfo.Location = new System.Drawing.Point(96, 77);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(477, 67);
            this.lblinfo.TabIndex = 2;
            this.lblinfo.Text = "פרטים ליצירת קשר";
            this.lblinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btngooddate
            // 
            this.btngooddate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btngooddate.ImageIndex = 2;
            this.btngooddate.ImageList = this.imageList1;
            this.btngooddate.Location = new System.Drawing.Point(342, 230);
            this.btngooddate.Name = "btngooddate";
            this.btngooddate.Size = new System.Drawing.Size(147, 47);
            this.btngooddate.TabIndex = 3;
            this.btngooddate.Text = "הצעתי להם שידוך";
            this.btngooddate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngooddate.UseVisualStyleBackColor = true;
            this.btngooddate.Click += new System.EventHandler(this.btngooddate_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "call-failed-icon.png");
            this.imageList1.Images.SetKeyName(1, "call-ringing-icon.png");
            this.imageList1.Images.SetKeyName(2, "call-successful-icon.png");
            // 
            // btnfailcall
            // 
            this.btnfailcall.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfailcall.ImageIndex = 1;
            this.btnfailcall.ImageList = this.imageList1;
            this.btnfailcall.Location = new System.Drawing.Point(156, 230);
            this.btnfailcall.Name = "btnfailcall";
            this.btnfailcall.Size = new System.Drawing.Size(175, 47);
            this.btnfailcall.TabIndex = 4;
            this.btnfailcall.Text = "התקשרתי להציע ולא ענו";
            this.btnfailcall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfailcall.UseVisualStyleBackColor = true;
            this.btnfailcall.Click += new System.EventHandler(this.btnfailcall_Click);
            // 
            // btnfaildate
            // 
            this.btnfaildate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfaildate.ImageIndex = 0;
            this.btnfaildate.ImageList = this.imageList1;
            this.btnfaildate.Location = new System.Drawing.Point(12, 230);
            this.btnfaildate.Name = "btnfaildate";
            this.btnfaildate.Size = new System.Drawing.Size(128, 47);
            this.btnfaildate.TabIndex = 5;
            this.btnfaildate.Text = "הצעתי ולא יצא";
            this.btnfaildate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfaildate.UseVisualStyleBackColor = true;
            this.btnfaildate.Click += new System.EventHandler(this.btnfaildate_Click);
            // 
            // btn_makedate
            // 
            this.btn_makedate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_makedate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_makedate.ImageIndex = 2;
            this.btn_makedate.ImageList = this.imageList1;
            this.btn_makedate.Location = new System.Drawing.Point(502, 230);
            this.btn_makedate.Name = "btn_makedate";
            this.btn_makedate.Size = new System.Drawing.Size(155, 47);
            this.btn_makedate.TabIndex = 6;
            this.btn_makedate.Text = "תיאום בנושא פגישה";
            this.btn_makedate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_makedate.UseVisualStyleBackColor = false;
            this.btn_makedate.Click += new System.EventHandler(this.btn_makedate_Click);
            // 
            // FrmPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 289);
            this.ControlBox = false;
            this.Controls.Add(this.btn_makedate);
            this.Controls.Add(this.btnfaildate);
            this.Controls.Add(this.btnfailcall);
            this.Controls.Add(this.btngooddate);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmPhone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "מידע יצירת קשר";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPhone_FormClosing);
            this.Load += new System.EventHandler(this.FrmPhone_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.Button btngooddate;
        private System.Windows.Forms.Button btnfailcall;
        private System.Windows.Forms.Button btnfaildate;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_makedate;
    }
}