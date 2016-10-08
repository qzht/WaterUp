using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("是否退出程序", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == res)
            {
                Application.ExitThread();
            }
            else 
            {
                e.Cancel = true;
            }
        }

        private void 数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDatabase y = new SetDatabase();
            y.Owner = this;
            y.ShowDialog();
        }

        private void 更新时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 预警线ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 手机号ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
