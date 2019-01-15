using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.Common.Data.SqlDAL;
using System.Data;
using Esint.Common.Data;
using System.Data.SqlClient;

namespace Esint.CodeSite.SqlDAL
{
   
       public class BaseData : RootSqlData
       { 
           internal BasicDataAccess basicDataAccess;

           public BaseData()
           { 
               basicDataAccess  = new BasicDataAccess();
           }

           public BaseData(string DBConn)
           {
               basicDataAccess = new BasicDataAccess(DBConn);
           }
           
           #region 全局操作方法

           #region 静态方法
           /// <summary>
           /// 查询DataTable 结果
           /// </summary>
           /// <param name="dataQuery"></param>
           /// <returns></returns>
           public static DataTable ExecuteDataTable(IDataQuery dataQuery)
           {
               BasicDataAccess basicDataAccess = new BasicDataAccess();
               DataTable dt = null;
               using (IDbConnection connect = basicDataAccess.GetConnection())
               {
                   bool isPageView = dataQuery.PageView.IsPageView;
                   if (isPageView)
                   { 
                       dataQuery.PageView.IsPageView = false;
                       dataQuery.PageView.RecordCount = basicDataAccess.GetRecordCount(connect, CommandType.Text, dataQuery, dataQuery.WhereParameters);
                       dataQuery.PageView.PageCount = Convert.ToInt32(dataQuery.PageView.RecordCount / dataQuery.PageView.PageSize) + 1;
                   }

                   dataQuery.PageView.IsPageView = isPageView;

                   if (dataQuery.PageView.PageCount < dataQuery.PageView.PageIndex)
                   {
                       dataQuery.PageView.PageIndex = dataQuery.PageView.PageCount;
                   }
                   dt = basicDataAccess.ExecuteDataset(connect, CommandType.Text, dataQuery, dataQuery.WhereParameters).Tables[0];
               }
               return dt;
           }

           /// <summary>
           /// 查询DataTable结果（事务版）
           /// </summary>
           /// <param name="dataQuery"></param>
           /// <param name="trans"></param>
           /// <returns></returns>
           public static DataTable ExecuteDataTable(IDataQuery dataQuery, IDbTransaction trans)
           {
               BasicDataAccess basicDataAccess = new BasicDataAccess();
               DataTable dt = null;
               bool isPageView = dataQuery.PageView.IsPageView;
             
               if (dataQuery.PageView.IsPageView)
               {
                   dataQuery.PageView.IsPageView = false;
                   dataQuery.PageView.RecordCount = basicDataAccess.GetRecordCount(trans, CommandType.Text, dataQuery, dataQuery.WhereParameters);
                   dataQuery.PageView.PageCount = Convert.ToInt32(dataQuery.PageView.RecordCount / dataQuery.PageView.PageSize) + 1;
               }
               dataQuery.PageView.IsPageView = isPageView;
               dt = basicDataAccess.ExecuteDataset(trans, CommandType.Text, dataQuery, dataQuery.WhereParameters).Tables[0];
               return dt;
           }

           public static void ExecuteProcture(IDataQuery dataQuery)
           {
               BasicDataAccess basicDataAccess = new BasicDataAccess();

               SqlParameter[] paras = basicDataAccess.GetDataParameters(dataQuery.WhereParameters);
               using (IDbConnection connect = basicDataAccess.GetConnection())
               {
                   basicDataAccess.ExecuteNonQuery(connect, CommandType.StoredProcedure, dataQuery.SQLText, paras);
                   foreach (IDataParameter para in paras)
                   {
                       if (para.Direction == ParameterDirection.Output || para.Direction == ParameterDirection.InputOutput)
                       {
                           foreach (WhereParameter p in dataQuery.WhereParameters)
                           {
                               if (p.ParameterName == para.ParameterName)
                               {
                                   p.Value = para.Value;
                               }
                           }
                       }
                   }
               }

           }
           public static void ExecuteProcture(IDataQuery dataQuery, IDbTransaction trans)
           {
               BasicDataAccess basicDataAccess = new BasicDataAccess();

               SqlParameter[] paras = basicDataAccess.GetDataParameters(dataQuery.WhereParameters);

               basicDataAccess.ExecuteNonQuery(trans, CommandType.StoredProcedure, dataQuery.SQLText, paras);
               foreach (IDataParameter para in paras)
               {
                   if (para.Direction == ParameterDirection.Output || para.Direction == ParameterDirection.InputOutput)
                   {
                       foreach (WhereParameter p in dataQuery.WhereParameters)
                       {
                           if (p.ParameterName == para.ParameterName)
                           {
                               p.Value = para.Value;
                           }
                       }
                   }
               }


           }

           #endregion

           #region 实例化方法

           private IDbConnection _connection;
           private IDbTransaction _trans;

           public IDbTransaction CreateTranstion()
           {
               _trans = basicDataAccess.GetTransaction();
               _connection = _trans.Connection;
               return _trans;
           }

           public void CloseTrans()
           {
               basicDataAccess.CloseTrans(_trans);
               basicDataAccess.CloseConn(_connection);

           }

           #endregion

           #endregion

           #region 内部使用方法

           /// <summary>
           /// 得到当前连接
           /// </summary>
           /// <returns></returns>
           internal IDbConnection GetConnection()
           {
               return basicDataAccess.GetConnection();
           }

           /// <summary>
           /// 执行无结果操作
           /// </summary>
           /// <param name="operaObj"></param>
           internal void ExecuteNonQuery(OperateObject operaObj)
           {
              // BasicDataAccess basicDataAccess = new BasicDataAccess();
               using (IDbConnection connect = basicDataAccess.GetConnection())
               {
                   basicDataAccess.ExecuteSQL(connect, operaObj.SqlText.ToString(), operaObj.Parameters);
               }
           }

           /// <summary>
           /// 执行无结果操作（事务版）
           /// </summary>
           /// <param name="operaObj"></param>
           /// <param name="trans"></param>
           internal void ExecuteNonQuery(OperateObject operaObj, IDbTransaction trans)
           {
              // BasicDataAccess basicDataAccess = new BasicDataAccess();
               basicDataAccess.ExecuteSQL(trans, operaObj.SqlText.ToString(), operaObj.Parameters);

           }

           internal object ExecuteScalar(OperateObject operaObj)
           {
              // BasicDataAccess basicDataAccess = new BasicDataAccess();
               using (IDbConnection connect = basicDataAccess.GetConnection())
               {
                 return   basicDataAccess.ExecuteScalar(connect, CommandType.Text, operaObj.SqlText, operaObj.Parameters);
               }

           }

           internal object ExecuteScalar(OperateObject operaObj, IDbTransaction trans)
           {
             //  BasicDataAccess basicDataAccess = new BasicDataAccess();
              return basicDataAccess.ExecuteScalar(trans, CommandType.Text, operaObj.SqlText, operaObj.Parameters);
           }
           #endregion

       }
    }
 
