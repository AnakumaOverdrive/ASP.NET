using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Esint.Common.Data.OracleDAL
{
    public class OracleTrans:IDbTransaction
    {
        private IDbTransaction trans;
        private IDbConnection conn;
        private RootOracleDataAccess rootAccess;
        public OracleTrans()
        {
            rootAccess = new RootOracleDataAccess();
            trans = rootAccess.GetTransaction();
            conn = trans.Connection;
            
        }
        #region IDbTransaction 成员
       
        public void Commit()
        {
            try
            {
                trans.Commit();
            }
            catch (System.Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                rootAccess.CloseTrans(trans);
                rootAccess.CloseConn(conn);
            }
        }
      
        #endregion

        #region IDbTransaction 成员


        public IDbConnection Connection
        {
            get { return conn; }
        }

        public IsolationLevel IsolationLevel
        {
            get { return IsolationLevel.ReadCommitted; }
        }

        public void Rollback()
        {
            trans.Rollback();
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
           trans.Dispose();
        }

        #endregion
    }
}
