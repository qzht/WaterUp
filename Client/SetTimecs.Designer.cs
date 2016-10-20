namespace Client
{
    partial class SetTimecs
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpone = new System.Windows.Forms.DateTimePicker();
            this.dtptwo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpthree = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "第一次上传时间:";
            // 
            // dtpone
            // 
            this.dtpone.CustomFormat = "HH:mm:ss";
            this.dtpone.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpone.Location = new System.Drawing.Point(164, 58);
            this.dtpone.Name = "dtpone";
            this.dtpone.Size = new System.Drawing.Size(87, 21);
            this.dtpone.TabIndex = 1;
            // 
            // dtptwo
            // 
            this.dtptwo.CustomFormat = "HH:mm:ss";
            this.dtptwo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptwo.Location = new System.Drawing.Point(164, 92);
            this.dtptwo.Name = "dtptwo";
            this.dtptwo.Size = new System.Drawing.Size(87, 21);
            this.dtptwo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "第二次上传时间:";
            // 
            // dtpthree
            // 
            this.dtpthree.CustomFormat = "HH:mm:ss";
            this.dtpthree.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpthree.Location = new System.Drawing.Point(164, 124);
            this.dtpthree.Name = "dtpthree";
            this.dtpthree.Size = new System.Drawing.Size(87, 21);
            this.dtpthree.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "第三次上传时间:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(75, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "* 修改完成后,软件自动重启。";
            // 
            // SetTimecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 262);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtpthree);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtptwo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpone);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SetTimecs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置时间";
            this.Load += new System.EventHandler(this.SetTimecs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpone;
        private System.Windows.Forms.DateTimePicker dtptwo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpthree;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}