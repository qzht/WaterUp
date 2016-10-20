using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Data;
using System.ServiceModel.Channels;

namespace Contracts
{
    [ServiceContract]
    public interface ICenterService : IChannel
    {

        /// <summary>
        /// 普通查询 返回DataTable
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        [OperationContract]
        [ServiceKnownType(typeof(System.Data.DataTable))]
        DataTable ExecuteQueryToTable(string cmdText);

        [OperationContract]
        string GetServerCount(string date);

        [OperationContract]
        string GetClientCount();

        [OperationContract]
        [ServiceKnownType(typeof(System.Data.DataTable))]
        string UPDate(DataTable dt, string TableName, string date);
    }
}
