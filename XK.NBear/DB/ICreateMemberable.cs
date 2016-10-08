using System;
using System.Data.Common;
using System.Data;

namespace XK.NBear.DB
{
    /// <summary>
    /// 摘要: 提供基础的Ado.Net需要的操作对象.
    /// </summary>
    public interface ICreateMemberable
    {
        /// <summary>
        /// 摘要: 提供基础的Ado.Net需要的 DbDataAdapter 对象
        /// </summary>
        /// <returns>DbDataAdapter</returns>
        DbDataAdapter CreateAdapter();
        /// <summary>
        /// 摘要: 提供基础的Ado.Net需要的 IDataParameter 对象
        /// </summary>
        /// <returns>IDataParameter</returns>
        DbCommand CreateCommand();
        /// <summary>
        /// 摘要: 提供基础的Ado.Net需要的 DbConnection 对象
        /// </summary>
        /// <returns>DbConnection</returns>
        DbConnection CreateConnection();
        /// <summary>
        /// 摘要: 提供基础的Ado.Net需要的 DbParameter 对象
        /// </summary>
        /// <returns>DbParameter</returns>
        IDataParameter CreateParameter();
        /// <summary>
        /// 摘要: 提供基础的Ado.Net需要的 DbTransaction 对象
        /// </summary>
        /// <returns>DbTransaction</returns>
        DbTransaction CreateTransaction();
    }
}
