namespace Schiduch.Forms
{
    partial class Contract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contract));
            this.picsign = new System.Windows.Forms.PictureBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.btn_helpsign = new System.Windows.Forms.Button();
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picsign)).BeginInit();
            this.SuspendLayout();
            // 
            // picsign
            // 
            this.picsign.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picsign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picsign.Location = new System.Drawing.Point(12, 12);
            this.picsign.Name = "picsign";
            this.picsign.Size = new System.Drawing.Size(627, 370);
            this.picsign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picsign.TabIndex = 0;
            this.picsign.TabStop = false;
            this.picsign.Click += new System.EventHandler(this.picsign_Click);
            this.picsign.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picsign_MouseDown);
            this.picsign.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picsign_MouseMove);
            this.picsign.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picsign_MouseUp);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_confirm.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_confirm.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_confirm.ImageIndex = 1;
            this.btn_confirm.ImageList = this.imageList1;
            this.btn_confirm.Location = new System.Drawing.Point(12, 388);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(81, 32);
            this.btn_confirm.TabIndex = 1;
            this.btn_confirm.Text = "אישור";
            this.btn_confirm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Faq-icon.png");
            this.imageList1.Images.SetKeyName(1, "pencil-grey-icon.png");
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(243, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_helpsign
            // 
            this.btn_helpsign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_helpsign.Font = new System.Drawing.Font("Narkisim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_helpsign.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_helpsign.ImageIndex = 0;
            this.btn_helpsign.ImageList = this.imageList1;
            this.btn_helpsign.Location = new System.Drawing.Point(525, 388);
            this.btn_helpsign.Name = "btn_helpsign";
            this.btn_helpsign.Size = new System.Drawing.Size(114, 32);
            this.btn_helpsign.TabIndex = 3;
            this.btn_helpsign.Text = "איך חותמים";
            this.btn_helpsign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_helpsign.UseVisualStyleBackColor = true;
            this.btn_helpsign.Click += new System.EventHandler(this.btn_helpsign_Click);
            // 
            // tmr1
            // 
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // Contract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(651, 432);
            this.Controls.Add(this.btn_helpsign);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.picsign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Contract";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " חוזה";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Contract_FormClosed);
            this.Load += new System.EventHandler(this.Contract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picsign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picsign;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_helpsign;
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.ImageList imageList1;
    }
}