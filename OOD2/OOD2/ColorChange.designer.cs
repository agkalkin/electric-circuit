namespace OOD2
{
    partial class ColorChange
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
            this.okBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.unkwCb = new System.Windows.Forms.ComboBox();
            this.oneCb = new System.Windows.Forms.ComboBox();
            this.zeroCb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(52, 100);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 13;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Unknown";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "1(5V)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "0 (0V)";
            // 
            // unkwCb
            // 
            this.unkwCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.unkwCb.FormattingEnabled = true;
            this.unkwCb.Location = new System.Drawing.Point(63, 60);
            this.unkwCb.Name = "unkwCb";
            this.unkwCb.Size = new System.Drawing.Size(121, 21);
            this.unkwCb.TabIndex = 9;
            this.unkwCb.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.unkwCb_DrawItem);
            // 
            // oneCb
            // 
            this.oneCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.oneCb.FormattingEnabled = true;
            this.oneCb.Location = new System.Drawing.Point(63, 33);
            this.oneCb.Name = "oneCb";
            this.oneCb.Size = new System.Drawing.Size(121, 21);
            this.oneCb.TabIndex = 8;
            this.oneCb.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.oneCb_DrawItem);
            // 
            // zeroCb
            // 
            this.zeroCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.zeroCb.FormattingEnabled = true;
            this.zeroCb.Location = new System.Drawing.Point(63, 6);
            this.zeroCb.Name = "zeroCb";
            this.zeroCb.Size = new System.Drawing.Size(121, 21);
            this.zeroCb.TabIndex = 7;
            this.zeroCb.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.zeroCb_DrawItem);
            // 
            // ColorChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 144);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unkwCb);
            this.Controls.Add(this.oneCb);
            this.Controls.Add(this.zeroCb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ColorChange";
            this.Text = "ColorChange";
            this.Load += new System.EventHandler(this.ColorChange_Load);
            this.Click += new System.EventHandler(this.okBtn_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox unkwCb;
        private System.Windows.Forms.ComboBox oneCb;
        private System.Windows.Forms.ComboBox zeroCb;
    }
}