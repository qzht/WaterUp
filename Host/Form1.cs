using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;

namespace Host
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void 数据库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDatabase y = new SetDatabase();
            y.Owner = this;
            y.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            IniClass ini = new IniClass(AppDomain.CurrentDomain.BaseDirectory + "Config.inf");
            string IP = ini.IniReadValue("服务地址", "IP");
            string Port = ini.IniReadValue("服务地址", "Port");
            txtip.Text = IP;
            txtport.Text = Port;

        }
        /// <summary>
        /// 中心服务对象
        /// </summary>
        static ServiceHost hostCenter;

        /// <summary>
        /// 开启服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "开启")
                button1.Text = "关闭";
            else
                button1.Text = "开启";

            if (hostCenter == null)
            {
                Thread threadRead = new Thread(new ThreadStart(ServerStart));
                threadRead.Start();

            }
            else
            {
                hostCenter.Close();
                hostCenter = null;
                Log.Write("停止服务");
                tsmsg.Text = "服务已经停止";
            }
        }
        void ServerStart()
        {
            try
            {
                hostCenter = new ServiceHost(typeof(Services.CenterService));
                string ip = txtip.Text.Trim();
                string port = txtport.Text.Trim();
                Uri tcp = new Uri("net.tcp://" + ip + ":" + port + "/CenterService");

                //设置wcf连接数据量
                ServiceThrottlingBehavior throttle = hostCenter.Description.Behaviors.Find<ServiceThrottlingBehavior>();
                if (throttle == null)
                {
                    throttle = new ServiceThrottlingBehavior();
                    throttle.MaxConcurrentCalls = 2000;
                    throttle.MaxConcurrentSessions = 2000;
                    throttle.MaxConcurrentInstances = 2000;
                    hostCenter.Description.Behaviors.Add(throttle);
                }

                NetTcpBinding tcpb = new NetTcpBinding();
                tcpb.Security.Mode = SecurityMode.None;
                tcpb.TransferMode = TransferMode.Streamed;
                tcpb.MaxBufferSize = 2147483647;
                tcpb.MaxReceivedMessageSize = 2147483647;

                hostCenter.AddServiceEndpoint(typeof(Contracts.ICenterService), tcpb, tcp);
                hostCenter.Open();
                tsmsg.Text = "服务已开启";
                Log.Write("服务启动成功");
            }
            catch (Exception ex)
            {
                tsmsg.Text = "服务开启失败";
                Log.Write("服务启动失败:" + ex.Message);
            }

        }

        private void 地址设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetIP s = new SetIP();
            s.Owner = this;
            s.ShowDialog();
        }
    }
}
