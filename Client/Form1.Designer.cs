﻿namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地址设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新时间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.预警线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.手机号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtip = new System.Windows.Forms.TextBox();
            this.txtport = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblmsg = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据库ToolStripMenuItem,
            this.地址设置ToolStripMenuItem,
            this.更新时间ToolStripMenuItem,
            this.预警线ToolStripMenuItem,
            this.手机号ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(407, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.数据库ToolStripMenuItem.Text = "数据库";
            this.数据库ToolStripMenuItem.Click += new System.EventHandler(this.数据库ToolStripMenuItem_Click);
            // 
            // 地址设置ToolStripMenuItem
            // 
            this.地址设置ToolStripMenuItem.Name = "地址设置ToolStripMenuItem";
            this.地址设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.地址设置ToolStripMenuItem.Text = "地址设置";
            this.地址设置ToolStripMenuItem.Click += new System.EventHandler(this.地址设置ToolStripMenuItem_Click);
            // 
            // 更新时间ToolStripMenuItem
            // 
            this.更新时间ToolStripMenuItem.Name = "更新时间ToolStripMenuItem";
            this.更新时间ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.更新时间ToolStripMenuItem.Text = "更新时间";
            this.更新时间ToolStripMenuItem.Click += new System.EventHandler(this.更新时间ToolStripMenuItem_Click);
            // 
            // 预警线ToolStripMenuItem
            // 
            this.预警线ToolStripMenuItem.Name = "预警线ToolStripMenuItem";
            this.预警线ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.预警线ToolStripMenuItem.Text = "预警线";
            this.预警线ToolStripMenuItem.Click += new System.EventHandler(this.预警线ToolStripMenuItem_Click);
            // 
            // 手机号ToolStripMenuItem
            // 
            this.手机号ToolStripMenuItem.Name = "手机号ToolStripMenuItem";
            this.手机号ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.手机号ToolStripMenuItem.Text = "手机号";
            this.手机号ToolStripMenuItem.Click += new System.EventHandler(this.手机号ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "地址:";
            // 
            // txtip
            // 
            this.txtip.Location = new System.Drawing.Point(139, 79);
            this.txtip.Name = "txtip";
            this.txtip.Size = new System.Drawing.Size(136, 21);
            this.txtip.TabIndex = 3;
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(139, 106);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(66, 21);
            this.txtport.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "端口:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "上传";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.ForeColor = System.Drawing.Color.Red;
            this.lblmsg.Location = new System.Drawing.Point(100, 155);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(11, 12);
            this.lblmsg.TabIndex = 7;
            this.lblmsg.Text = "*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 267);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "流水数据自动上传-客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新时间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 预警线ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 手机号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtip;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 地址设置ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblmsg;
    }
}

