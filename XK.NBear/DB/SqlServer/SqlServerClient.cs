﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;

namespace XK.NBear.DB.SqlServer
{
    /// <summary>
    ///  摘要: 根据 providerName 提供 System.Data.SqlClient 操作对象.
    /// </summary>
    class SqlServerClient : Database
    {
        /// <summary>
        ///  摘要: 根据 connectionString 提供 System.Data.OracleClient 操作对象.
        /// </summary>
        /// <param name="connectionString">connectionString</param>
        public SqlServerClient(string connectionString)
            : base(connectionString, SqlClientFactory.Instance)
        {

        }
        /// <summary>
        /// 摘要: 根据 key,pageSize,pageIndex,sql,orderBy 分页返回 DataTable 值
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="sql">sql</param>
        /// <param name="count">count</param>
        /// <param name="orderBy">orderBy</param>
        /// <returns>DataTable</returns>
        public override DataTable Pager(string key, int pageSize, int pageIndex, string sql, out int count, string orderBy)
        {
            count = (int)Scalar(string.Format(CultureInfo.InvariantCulture, "SELECT COUNT(*) FROM ({0}) AS T", sql));
            string sqlString = "SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY {0}) AS ROWINDEX,* FROM ({1}) AS A) AS B WHERE ROWINDEX>{2} and ROWINDEX<={3}";
            int endIndex = pageSize * pageIndex;
            int startIndex = pageSize * (pageIndex - 1);
            string orderByOrKey = string.IsNullOrEmpty(orderBy.Trim()) ? key : orderBy + "," + key;
            return this.ExecuteDataTable(string.Format(CultureInfo.InvariantCulture, sqlString, orderByOrKey, sql, startIndex, endIndex));
        }
        /// <summary>
        /// 摘要: 根据 key,pageSize,pageIndex,sql,orderBy,ParameterCollection 分页返回 DataTable 值
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="sql">sql</param>
        /// <param name="count">count</param>
        /// <param name="orderBy">orderBy</param>
        /// <param name="parameters">ParameterCollection</param>
        /// <returns>DataTable</returns>
        public override DataTable Pager(string key, int pageSize, int pageIndex, string sql, out int count, string orderBy, ParameterCollection parameters)
        {
            count = (int)Scalar(string.Format(CultureInfo.InvariantCulture, "SELECT COUNT(*) FROM ({0}) AS T", sql));
            string sqlString = "SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY {0}) AS ROWINDEX,* FROM ({1}) AS A) AS B WHERE ROWINDEX>{2} and ROWINDEX<={3}";
            int endIndex = pageSize * pageIndex;
            int startIndex = pageSize * (pageIndex - 1);
            string orderByOrKey = string.IsNullOrEmpty(orderBy.Trim()) ? key : orderBy + "," + key;
            return this.ExecuteDataTable(string.Format(CultureInfo.InvariantCulture, sqlString, orderByOrKey, sql, startIndex, endIndex), parameters);
        }
        public override DataTable Pager2(string key, int pageSize, int pageIndex, string sql, out int count, string orderBy)
        {
            count = (int)Scalar(string.Format(CultureInfo.InvariantCulture, "SELECT COUNT(*) FROM ({0}) AS T", sql));
            string limitsql = "select top " + pageSize + " " + sql.Substring(sql.ToLower().IndexOf("select") + 6) + "  and (" + key + " not in (select top " + pageSize * (pageIndex - 1) + " " + key + " " + sql.Substring(sql.ToLower().IndexOf("from")) + " order by " + orderBy + ")) order by " + orderBy + "";
            return this.ExecuteDataTable(limitsql);
        }

        public override bool InsertBlockData(DataTable sourceTab, string TableName)
        {
            bool flag = false;
            try
            {

                SqlBulkCopy _bulkCopy = new SqlBulkCopy(this.connectionString, SqlBulkCopyOptions.FireTriggers);
                _bulkCopy.BulkCopyTimeout = 60000;
                _bulkCopy.BatchSize = 5000;//5000次插提交一次
                _bulkCopy.DestinationTableName = TableName;
                _bulkCopy.WriteToServer(sourceTab);
                flag = true;

            }
            catch (Exception)
            {
                return false;
            }

            finally
            {

            }
            return flag;
        }
    }
}
