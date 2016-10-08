using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;
using System.Xml;
using System.Windows.Forms;
using XK.NBear.Common;

[assembly: CLSCompliant(true)]
namespace XK.NBear.DB
{
    /// <summary>
    /// 摘要: 提供创建 Database 的工厂类.
    /// </summary>
    public static class DatabaseFactory
    {
        /// <summary>
        /// 摘要: 创建 IDataBaseOperation 用于提供操作数据库的接口.
        /// </summary>
        /// <param name="connectionName">connectionName</param>
        /// <returns>IDataBaseOperation</returns>
        public static IDO CreateOperation(string connectionName)
        {
            StringBuilder connectionString = new StringBuilder();
            string providerName = "System.Data.SqlClient";
                XmlDocument document = new XmlDocument();
                document.Load(Application.StartupPath + @"\DataParam.xml");
                XmlNodeList nodes = document.SelectNodes("Root/Database");
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["Name"].Value.ToUpper().Trim() == connectionName.ToUpper().Trim())
                    {
                        connectionString.Append("server=" + XinDES.Decrypt(node.Attributes["DataSource"].Value) + ";");
                        connectionString.Append("uid=" + XinDES.Decrypt(node.Attributes["User"].Value) + ";");
                        connectionString.Append("pwd=" + XinDES.Decrypt(node.Attributes["Password"].Value) + ";");
                        connectionString.Append("database=" + XinDES.Decrypt(node.Attributes["DataName"].Value) + ";");
                    }
                }
            return CreateOperation(connectionString.ToString(), providerName);
        }
        ///// <summary>
        ///// 摘要: 根据系统默认生成的 ProviderName 映射为自定义的 ProviderName.
        ///// </summary>
        ///// <param name="providerName">providerName</param>
        ///// <returns>XK.NBear.DB.providerName</returns>
        private static string ProviderFilter(string providerName)
        {
            switch (providerName)
            {
                case "System.Data.Odbc": providerName = "XK.NBear.DB.Odbc.OdbcClient"; break;
                case "System.Data.OleDb": providerName = "XK.NBear.DB.OleDb.OleDbClient"; break;
                case "System.Data.SqlClient": providerName = "XK.NBear.DB.SqlServer.SqlServerClient"; break;
                case "System.Data.OracleClient": providerName = "XK.NBear.DB.Oracle.OracleClient"; break;
                default: break;
            }
            return providerName;
        }
        /// <summary>
        /// 摘要: 创建 IDataBaseOperation 用于提供操作数据库的接口.
        /// </summary>
        /// <param name="connectionString">connectionString</param>
        /// <param name="providerName">providerName</param>
        /// <returns>IDataBaseOperation</returns>
        public static IDO CreateOperation(string connectionString, string providerName)
        {
            providerName = ProviderFilter(providerName);
            return (IDO)Assembly.Load((typeof(Database).Assembly.FullName)).CreateInstance(providerName, false, System.Reflection.BindingFlags.Default, null, new object[] { connectionString }, null, null);
        }
    }
}
