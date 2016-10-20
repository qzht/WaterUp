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
    public partial class SetTimecs : Form
    {
        public SetTimecs()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetTimecs_Load(object sender, EventArgs e)
        {
            IniClass ini = new IniClass(AppDomain.CurrentDomain.BaseDirectory + "Config.inf");
            string one = ini.IniReadValue("时间", "第一次更新");
            string two = ini.IniReadValue("时间", "第二次更新");
            string three = ini.IniReadValue("时间", "第三次更新");
            dtpone.Value =DateTime.Parse(one);
            dtptwo.Value = DateTime.Parse(two);
            dtpthree.Value = DateTime.Parse(three);
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string one=dtpone.Value.ToString("HH:mm:ss");
            string two = dtptwo.Value.ToString("HH:mm:ss");
            string three = dtpthree.Value.ToString("HH:mm:ss");
            IniClass ini = new IniClass(AppDomain.CurrentDomain.BaseDirectory + "Config.inf");
            ini.IniWriteValue("时间", "第一次更新", one);
            ini.IniWriteValue("时间", "第二次更新", two);
            ini.IniWriteValue("时间", "第三次更新", three);
            MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Application.ExitThread();
        }
    }
}
