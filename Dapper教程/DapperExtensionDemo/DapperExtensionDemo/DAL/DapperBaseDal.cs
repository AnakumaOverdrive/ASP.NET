using Dapper;
using Dapper.Contrib.Extensions;
using DapperExtensionDemo.Common;
using DapperExtensionDemo.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DapperExtensionDemo.DAL
{
    public class BaseDal
    {
        #region Dapper.Contrib 的基础 CURD

        public T Get<T>(int id) where T : BaseModel
        {
            T entity;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                entity = conn.Get<T>(id);
            }
            return entity;
        }
        
        public IEnumerable<T> GetList<T>() where T : BaseModel
        {
            IEnumerable<T> results;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                results = conn.GetAll<T>();
            }
            return results;
        }
        public bool Insert<T>(T obj) where T : BaseModel
        {
            long results;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                results = conn.Insert(obj);
            }
            return results > 0;
        }

        public bool Insert<T>(IEnumerable<T> objs) where T : BaseModel
        {
            long results;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                results = conn.Insert(objs);
            }
            return results > 0;
        }

        public bool Update<T>(T obj) where T : BaseModel
        {
            bool results;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                results = conn.Update(obj);
            }
            return results;
        }


        public bool Update<T>(IEnumerable<T> obj) where T : BaseModel
        {
            bool results;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                results = conn.Update(obj);
            }
            return results;
        }

        public bool Delete<T>(T obj) where T : BaseModel
        {
            bool results;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                results = conn.Delete(obj);
            }
            return results;
        }

        public bool Delete<T>(IEnumerable<T> obj) where T : BaseModel
        {
            bool results;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                results = conn.Delete(obj);
            }
            return results;
        }

        public bool DeleteAll<T>() where T : BaseModel
        {
            bool results;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                results = conn.DeleteAll<T>();
            }
            return results;
        }
        #endregion

        #region 原生Dapper 返回 Enumerable<IDictionary> 结果的查询
        public IEnumerable<IDictionary> QuerySql(string strSql)
        {
            using (IDbConnection conn = ConnectionFactory.Creator(ConnectionType.ChaiQianMap))
            {
                var result = conn.Query(strSql, null, null, true, 120) as IEnumerable<IDictionary<string, object>>;
                if (result != null)
                    return result.Select(r => r.Distinct().ToDictionary(d => d.Key, d => d.Value));
                return null;
            }
        }

        public IEnumerable<IDictionary> QuerySql(string strSql, object argSet)
        {
            using (IDbConnection conn = ConnectionFactory.Creator(ConnectionType.ChaiQianMap))
            {
                var result = conn.Query(strSql, argSet, null, true, 120) as IEnumerable<IDictionary<string, object>>;
                if (result != null)
                    return result.Select(r => r.Distinct().ToDictionary(d => d.Key, d => d.Value));
                return null;
            }
        }

        public IEnumerable<IDictionary> QuerySql(string strSql, DynamicParameters argSet)
        {
            using (IDbConnection conn = ConnectionFactory.Creator(ConnectionType.ChaiQianMap))
            {
                var result = conn.Query(strSql, argSet, null, true, 120) as IEnumerable<IDictionary<string, object>>;
                if (result != null)
                    return result.Select(r => r.Distinct().ToDictionary(d => d.Key, d => d.Value));
                return null;
            }
        }
        #endregion

        #region 封装的查询

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataQuery"></param>
        /// <returns></returns>
        public PageResults<T> ExecuteQuery<T>(DataQuery dataQuery) where T : BaseModel
        {
            IEnumerable<T> results;
            
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                bool isPageView = dataQuery.PageView.IsPageView;
                if (isPageView)
                {
                    dataQuery.PageView.RecordCount = GetDataQueryCount(dataQuery);
                    dataQuery.PageView.PageCount = Convert.ToInt32(dataQuery.PageView.RecordCount / dataQuery.PageView.PageSize) + (dataQuery.PageView.RecordCount % dataQuery.PageView.PageSize != 0 ? 1 : 0);

                    string sql = string.Format("select * from ({0}) {1} LIMIT @pageIndex,@pageSize;",
                        dataQuery.SqlText, dataQuery.Alias);
                    var index = dataQuery.PageView.PageIndex * dataQuery.PageView.PageSize - dataQuery.PageView.PageSize;
                    dataQuery.WhereParameters.Add("pageIndex", index);
                    dataQuery.WhereParameters.Add("pageSize", dataQuery.PageView.PageSize);


                    results = conn.Query<T>(sql, dataQuery.WhereParameters, null, true, 120);
                }
                else
                {
                    results = conn.Query<T>(dataQuery.SqlText, dataQuery.WhereParameters, null, true, 120);
                }

            }
            return new PageResults<T>() { Results = results , PageView = dataQuery.PageView };
        }
        

        public int GetDataQueryCount(DataQuery dataQuery)
        {
            var sqlText = dataQuery.SqlText;
            
            int startx = sqlText.ToUpper().Replace(" ", "").IndexOf("SELECTDISTINCT");
            if (startx != -1)
            {
                sqlText = sqlText.Substring(0, startx) + "SELECT distinct " + sqlText.Substring(startx + 15);
            }
            else
            {
                int startx1 = sqlText.ToUpper().Replace(" ", "").IndexOf("SELECT");
                if (startx1 != -1)
                {
                    sqlText = sqlText.Substring(0, startx1) + "SELECT " + sqlText.Substring(startx1 + 6);
                }
            }
            string sql = "select count(*) As RecordCount from (" + sqlText + ") " + dataQuery.Alias;

            int result = 0;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                result = conn.QueryFirstOrDefault<int>(sql, dataQuery.WhereParameters, null, 120);
            }
            return result;
        }


        #endregion

        #region 参数处理

        /// <summary>
        /// 处理Like参数
        /// </summary>
        /// <param name="likeParam"></param>
        /// <returns></returns>
        protected string handleLikeParam(string likeParam)
        {
            likeParam = likeParam.Replace("[", "[[]").Replace("%", "[%]");
            likeParam = "%" + likeParam + "%";

            return likeParam;
        }

        #endregion
    }
}
