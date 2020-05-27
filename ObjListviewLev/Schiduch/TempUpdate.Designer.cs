namespace Schiduch
{
    partial class TempUpdate
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
            this.btnconfirm = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.txtnotes = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnconfirm
            // 
            this.btnconfirm.ImageKey = "(none)";
            this.btnconfirm.Location = new System.Drawing.Point(86, 230);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(91, 37);
            this.btnconfirm.TabIndex = 4;
            this.btnconfirm.Text = "אישור";
            this.btnconfirm.UseVisualStyleBackColor = true;
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // btnexit
            // 
            this.btnexit.ImageKey = "(none)";
            this.btnexit.Location = new System.Drawing.Point(183, 230);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(91, 37);
            this.btnexit.TabIndex = 5;
            this.btnexit.Text = "סגור";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // txtnotes
            // 
            this.txtnotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnotes.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtnotes.Location = new System.Drawing.Point(39, 61);
            this.txtnotes.Multiline = true;
            this.txtnotes.Name = "txtnotes";
            this.txtnotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtnotes.Size = new System.Drawing.Size(293, 151);
            this.txtnotes.TabIndex = 66;
            this.txtnotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label46.Location = new System.Drawing.Point(149, 9);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(78, 18);
            this.label46.TabIndex = 67;
            this.label46.Text = "עדכן פרטים";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 16);
            this.label1.TabIndex = 68;
            this.label1.Text = "כתוב בהערה כאן פרטים נוספים שתרצה לעדכן";
            // 
            // TempUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(360, 279);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtnotes);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnconfirm);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TempUpdate";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "עדכון";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label label46;
        public System.Windows.Forms.Button btnconfirm;
        public System.Windows.Forms.TextBox txtnotes;
        public System.Windows.Forms.Label label1;
    }
}