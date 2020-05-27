namespace Schiduch.Forms
{
    partial class SplachScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplachScreen));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtstatus = new System.Windows.Forms.RichTextBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.picload = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picload)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Schiduch.Properties.Resources.לוגו_שנתבשר;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtstatus
            // 
            this.txtstatus.BackColor = System.Drawing.Color.Gainsboro;
            this.txtstatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtstatus.Enabled = false;
            this.txtstatus.Font = new System.Drawing.Font("Narkisim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtstatus.Location = new System.Drawing.Point(12, 142);
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtstatus.Size = new System.Drawing.Size(301, 205);
            this.txtstatus.TabIndex = 1;
            this.txtstatus.Text = "";
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Narkisim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.ImageIndex = 1;
            this.btnexit.ImageList = this.imageList1;
            this.btnexit.Location = new System.Drawing.Point(12, 353);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(86, 34);
            this.btnexit.TabIndex = 2;
            this.btnexit.Text = "יציאה";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "App-voice-support-headset-icon.png");
            this.imageList1.Images.SetKeyName(1, "Close-icon.png");
            // 
            // picload
            // 
            this.picload.Image = ((System.Drawing.Image)(resources.GetObject("picload.Image")));
            this.picload.Location = new System.Drawing.Point(132, 352);
            this.picload.Name = "picload";
            this.picload.Size = new System.Drawing.Size(36, 35);
            this.picload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picload.TabIndex = 4;
            this.picload.TabStop = false;
            // 
            // SplachScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(325, 391);
            this.ControlBox = false;
            this.Controls.Add(this.picload);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.txtstatus);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplachScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "טוען תוכנה";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SplachScreen_Load);
            this.Shown += new System.EventHandler(this.SplachScreen_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox txtstatus;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox picload;
    }
}