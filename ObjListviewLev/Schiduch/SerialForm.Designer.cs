namespace Schiduch
{
    partial class SerialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialForm));
            this.labels = new System.Windows.Forms.Label();
            this.txtserial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblserial = new System.Windows.Forms.TextBox();
            this.btnhelpserialnumber = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnconfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labels
            // 
            this.labels.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labels.Location = new System.Drawing.Point(255, 30);
            this.labels.Name = "labels";
            this.labels.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labels.Size = new System.Drawing.Size(137, 31);
            this.labels.TabIndex = 3;
            this.labels.Text = "מספר סידורי :";
            this.labels.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtserial
            // 
            this.txtserial.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtserial.Location = new System.Drawing.Point(29, 86);
            this.txtserial.Name = "txtserial";
            this.txtserial.PasswordChar = '*';
            this.txtserial.Size = new System.Drawing.Size(220, 26);
            this.txtserial.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Narkisim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(255, 88);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(121, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "קוד פתיחה :";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "App-voice-support-headset-icon.png");
            this.imageList1.Images.SetKeyName(1, "close-icon-29.png");
            this.imageList1.Images.SetKeyName(2, "Icon_13-512.png");
            // 
            // lblserial
            // 
            this.lblserial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblserial.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblserial.Location = new System.Drawing.Point(29, 13);
            this.lblserial.Multiline = true;
            this.lblserial.Name = "lblserial";
            this.lblserial.ReadOnly = true;
            this.lblserial.Size = new System.Drawing.Size(219, 67);
            this.lblserial.TabIndex = 8;
            // 
            // btnhelpserialnumber
            // 
            this.btnhelpserialnumber.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnhelpserialnumber.ImageKey = "App-voice-support-headset-icon.png";
            this.btnhelpserialnumber.ImageList = this.imageList1;
            this.btnhelpserialnumber.Location = new System.Drawing.Point(116, 135);
            this.btnhelpserialnumber.Name = "btnhelpserialnumber";
            this.btnhelpserialnumber.Size = new System.Drawing.Size(186, 33);
            this.btnhelpserialnumber.TabIndex = 9;
            this.btnhelpserialnumber.Text = "עזרו לי לפתוח את התוכנה";
            this.btnhelpserialnumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnhelpserialnumber.UseVisualStyleBackColor = true;
            this.btnhelpserialnumber.Click += new System.EventHandler(this.btnhelpserialnumber_Click);
            // 
            // btnexit
            // 
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.ImageKey = "close-icon-29.png";
            this.btnexit.ImageList = this.imageList1;
            this.btnexit.Location = new System.Drawing.Point(308, 135);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(80, 33);
            this.btnexit.TabIndex = 7;
            this.btnexit.Text = "יציאה";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnconfirm
            // 
            this.btnconfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnconfirm.ImageIndex = 2;
            this.btnconfirm.ImageList = this.imageList1;
            this.btnconfirm.Location = new System.Drawing.Point(29, 135);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(81, 33);
            this.btnconfirm.TabIndex = 6;
            this.btnconfirm.Text = "אישור";
            this.btnconfirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnconfirm.UseVisualStyleBackColor = true;
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // SerialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(404, 180);
            this.Controls.Add(this.btnhelpserialnumber);
            this.Controls.Add(this.lblserial);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnconfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtserial);
            this.Controls.Add(this.labels);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "הרשמה";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SerialForm_FormClosed);
            this.Load += new System.EventHandler(this.SerialForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labels;
        private System.Windows.Forms.TextBox txtserial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnconfirm;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.TextBox lblserial;
        private System.Windows.Forms.Button btnhelpserialnumber;
    }
}