using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using XK.NBear.DB;
using System.Data;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Services
{
    public class CenterService : ICenterService
    {
        private IDO db = DatabaseFactory.CreateOperation("SYSTEM");
        public DataTable ExecuteQueryToTable(string cmdText)
        {
            return db.ExecuteDataTable(cmdText);
        }

        public string GetServerCount(string date)
        {
            return db.Scalar("select count(*) from dbo.ykt_water where dateimport='" + date + "' ").ToString();
        }
        public string GetClientCount()
        {
            return db.Scalar("select count(*) from dbo.ykt_water").ToString();
        }

        public string GetWaterDate()
        {
            return db.Scalar("select count(*) from dbo.ykt_water").ToString();
        }
        public string UPDate(DataTable dt, string TableName, string date)
        {
            db.NonQuery("delete from ykt_water where dateimport='"+date+"' ");
            db.NonQuery("insert into UPLog (DataCount) values('"+dt.Rows.Count+"')");
            db.InsertBlockData(dt, TableName);
            return "1";
        }

        #region//Channel 接口方法
        public T GetProperty<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void Abort()
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void Close(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void EndClose(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndOpen(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void Open(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public CommunicationState State
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler Closed;

        public event EventHandler Closing;

        public event EventHandler Faulted;

        public event EventHandler Opened;

        public event EventHandler Opening;
        #endregion
    }
}
