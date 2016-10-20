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
    public partial class SetPhoneNum : Form
    {
        public SetPhoneNum()
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
            string Phone = txtPhone.Text;
            IniClass ini = new IniClass(AppDomain.CurrentDomain.BaseDirectory + "Config.inf");
            ini.IniWriteValue("设置", "手机号", Phone);
            MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Application.ExitThread();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetPhoneNum_Load(object sender, EventArgs e)
        {
            IniClass ini = new IniClass(AppDomain.CurrentDomain.BaseDirectory + "Config.inf");
            string Phone = ini.IniReadValue("设置", "手机号");
            txtPhone.Text = Phone;
        }
    }
}
