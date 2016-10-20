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
    public partial class SetIP : Form
    {
        public SetIP()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string IP= txtip.Text;
            string Port= txtport.Text;
            IniClass ini = new IniClass(AppDomain.CurrentDomain.BaseDirectory + "Config.inf");
            ini.IniWriteValue("服务地址", "IP", IP);
            ini.IniWriteValue("服务地址", "Port", Port);
            MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Application.ExitThread();
        }

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetIP_Load(object sender, EventArgs e)
        {
            IniClass ini = new IniClass(AppDomain.CurrentDomain.BaseDirectory + "Config.inf");
            string IP = ini.IniReadValue("服务地址", "IP");
            string Port = ini.IniReadValue("服务地址", "Port");
            txtip.Text = IP;
            txtport.Text = Port;
        }
    }
}
