using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using Contracts;
using System.ServiceModel;
using System.ServiceModel.Channels;
using XK.NBear.DB;
using System.Threading;
using System.Diagnostics;
using System.Web;
using System.Net;
using System.IO;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private IDO db = DatabaseFactory.CreateOperation("SYSTEM");
        static ICenterService client = null;
        public delegate void ShowMsg(string msg);
        public void ShowMsgFun(string msg)
        {
            lblmsg.Text = msg;
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
            SetTimecs y = new SetTimecs();
            y.Owner = this;
            y.ShowDialog();
        }

        private void 预警线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetLine y = new SetLine();
            y.Owner = this;
            y.ShowDialog();
        }

        private void 手机号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetPhoneNum y = new SetPhoneNum();
            y.Owner = this;
            y.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
        bool IsBig = false;
        /// <summary>
        /// 上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            IsBig = true;
            Thread th = new Thread(new ThreadStart(CreateChannel));
            th.Start();
        }
        void CreateChannel()
        {
            //if (ipInfo == null)
            //    InitParam();
            //if (ipInfo == null)
            //    return;
            IniClass ini = new IniClass(AppDomain.CurrentDomain.BaseDirectory + "Config.inf");
            string Line = ini.IniReadValue("设置", "预警线");
            string Phone = ini.IniReadValue("设置", "手机号");
            string SchoolName = ini.IniReadValue("设置", "学校");
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                this.Invoke(new ShowMsg(ShowMsgFun), new object[] { "等待连接" });
                if (client != null)
                    client.Close();
                string ip = txtip.Text.Trim();
                string port = txtport.Text.Trim();

                NetTcpBinding tcpb = new NetTcpBinding();//NetTcpBinding
                tcpb.Security.Mode = SecurityMode.None;
                tcpb.TransferMode = TransferMode.Streamed;
                tcpb.ReceiveTimeout = new TimeSpan(1, 0, 0);
                tcpb.SendTimeout = new TimeSpan(1, 0, 0);
                tcpb.MaxBufferSize = 2147483647;
                tcpb.MaxReceivedMessageSize = 2147483647;
                
                ChannelFactory<ICenterService> channelFactory = new ChannelFactory<ICenterService>(tcpb);
                Uri url = new Uri("net.tcp://" + ip+":"+port + "/CenterService");

                EndpointAddress ea = new EndpointAddress(url);

                client = channelFactory.CreateChannel(ea);
                this.Invoke(new ShowMsg(ShowMsgFun), new object[] { "连接成功" });
                string date = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
                this.Invoke(new ShowMsg(ShowMsgFun), new object[] { "获取数据" });
                DataTable dt = db.ExecuteDataTable("select * from  dbo.ykt_water where dateimport='"+date+"'");
          
                if (dt.Rows.Count < int.Parse(Line)&&!IsBig)
                {
                    this.Invoke(new ShowMsg(ShowMsgFun), new object[] { "数据异常，已发送短信" });
                    YDSendMessageNewByTL(Phone,SchoolName+"流水数量(" + dt.Rows.Count + ")小于警戒线(" + Line+")");
                    Log.Write("流水数量(" + dt.Rows.Count + ")小于警戒线" + Line);
                }
                else
                {
                    IsBig = false;
                    this.Invoke(new ShowMsg(ShowMsgFun), new object[] { "正在对比" });
                    string GetCount = client.GetServerCount(date);
                    if (dt.Rows.Count != int.Parse(GetCount))
                    {
                        dt.TableName = "ykt_water";
                        this.Invoke(new ShowMsg(ShowMsgFun), new object[] { "开始上传" });
                        client.UPDate(dt, "ykt_water", date);
                        this.Invoke(new ShowMsg(ShowMsgFun), new object[] { "上传成功" + dt.Rows.Count + "条数据,耗时" + stopwatch.Elapsed.TotalSeconds + "秒" });
                        Log.Write("上传成功" + dt.Rows.Count + "条数据,耗时" + stopwatch.Elapsed.TotalSeconds + "秒");
                        stopwatch.Stop();
                    }
                    else
                    {
                        this.Invoke(new ShowMsg(ShowMsgFun), new object[] { "无上传数据" });
                    }
                }
               // client.ExecuteQueryToTable("select * from dbo.ykt_water");
             
            }
            catch(Exception ex)
            {
                client = null;
                this.Invoke(new ShowMsg(ShowMsgFun), new object[] { "上传失败,请查看服务是否开启" });
                YDSendMessageNewByTL(Phone, SchoolName + "上传失败,请查看服务是否开启");
                Log.Write("上传失败:"+ex.Message);
            }
        }
        public void InsertPhone(string msg,string phone) { 
        
        }

        private void 地址设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetIP s = new SetIP();
            s.Owner = this;
            s.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IniClass ini = new IniClass(AppDomain.CurrentDomain.BaseDirectory + "Config.inf");
            string one = ini.IniReadValue("时间", "第一次更新");
            string two = ini.IniReadValue("时间", "第二次更新");
            string three = ini.IniReadValue("时间", "第三次更新");
            string current = DateTime.Now.ToString("HH:mm:ss");
            if (current == one || current == two || current == three)
            {
                Thread th = new Thread(new ThreadStart(CreateChannel));
                th.Start();
            }
        }

        /// <summary>
        /// 移动号发送短信(通联)
        /// </summary>
        /// <param name="telNumber"></param>
        /// <param name="shortMessage"></param>
        /// <returns></returns>
        public static string YDSendMessageNewByTL(string telNumber, string shortMessage)
        {
            try
            {
                string user = "aaaaaa";
                string pass = "aaaaaa";

                string url = "http://cf.51welink.com/submitdata/service.asmx/g_Submit?sname=" + user + "&spwd=" + pass + "&scorpid=&sprdid=1012808&sdst=" + telNumber + "&smsg=";


                string content = shortMessage + "【家校互联】";

                //System.Text.Encoding encode = System.Text.Encoding.GetEncoding("UTF8");
                content = HttpUtility.UrlEncode(content, Encoding.UTF8);
                url += content;
                //url += "&expid=0";


                //System.Web.HttpContext.Current.Response.Write(url);
                string result = GetHtmlFromUrl(url);

                //XmlDocument xd = new XmlDocument();
                //xd.LoadXml(result);

                //System.Xml.XmlNode node = xd.SelectSingleNode("CSubmitState/State");

                string str = "0";

                if (result.Contains("<State>0</State>"))
                {
                    str = "1";
                }
                if (str == "1")
                {
                    return "1";
                }
                else
                {
                 Log.Write("新移动号发送短信异常(通联)-返回状态码:" + result.ToString());
                    return "0";

                }
            }
            catch (Exception ex)
            {
                Log.Write("新移动号发送短信异常(通联)-" + ex.ToString());
                return "0";
            }
        }

        public static string GetHtmlFromUrl(string url)
        {
            string strRet = null;

            if (url == null || url.Trim().ToString() == "")
            {
                return strRet;
            }
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, System.Text.Encoding.Default);
                string result = ser.ReadToEnd().Trim();
                return result;
            }
            catch (Exception ex)
            {
             Log.Write("新移动号发送短信异常(上海移动)-" + ex.ToString());
                return "-1000";
            }
        }
    }
}
