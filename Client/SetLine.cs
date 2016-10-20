using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;

namespace Client
{
    public partial class SetLine : Form
    {
        public SetLine()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetLine_Load(object sender, EventArgs e)
        {
            IniClass ini = new IniClass(AppDomain.CurrentDomain.BaseDirectory + "Config.inf");
            string Line = ini.IniReadValue("设置", "预警线");
            txtLine.Text = Line;
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string Line = txtLine.Text;
            IniClass ini = new IniClass(AppDomain.CurrentDomain.BaseDirectory + "Config.inf");
            ini.IniWriteValue("设置", "预警线", Line);
            MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Application.ExitThread();
        }
    }
}
