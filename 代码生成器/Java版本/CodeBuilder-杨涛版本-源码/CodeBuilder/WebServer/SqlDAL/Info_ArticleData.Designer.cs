using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Esint.Common.Data;
using Esint.CodeSite.IDAL;
using Esint.CodeSite.Model;
using System.Data.SqlClient;

namespace Esint.CodeSite.SqlDAL
{
    /// <summary>
    /// 模块名称： 数据访问层
    /// 作    者：刘伟通
    /// 生成日期：2012年09月18日
    /// 生成模板: Esint.Template.SqlDAL.SqlDAL_11 版
    /// 特别说明：本文件由代码生成工具自动生成，请勿轻易修改！
    /// </summary>
    public partial class Info_ArticleData  : BaseData, IInfo_ArticleData
    {
        #region 插入数据 

        /// <summary>
        /// 插入数据
        /// </summary>
        public void Insert(Info_ArticleInfo info_Article)
        {
            //建立SQL语句对象
            OperateObject operateObject = CreateInsertObject(info_Article);
            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 插入数据(事务版)
        /// </summary>
        public void Insert(Info_ArticleInfo info_Article,IDbTransaction trans)
        {
            //建立SQL语句对象
            OperateObject operateObject = CreateInsertObject(info_Article);
            base.ExecuteNonQuery(operateObject,trans);
        }

        #region 构建插入SQL语句 

        /// <summary>
        /// 构建插入SQL语句
        /// </summary>
        /// <param name="info_Article"></param>
        /// <returns></returns>
        private OperateObject CreateInsertObject(Info_ArticleInfo info_Article)
        {
             BasicDataAccess basicDataAccess = new BasicDataAccess();
            //建立插入的SQL语句,判断是否为空拼串
            StringBuilder         strSql     = new StringBuilder();
            List<IDataParameter> parameters = new List<IDataParameter>();
            SqlParameter para;
            strSql.Append("INSERT INTO T_Info_Article (");
            if(info_Article.AritcleID ==Guid.Empty)
                info_Article.AritcleID = Guid.NewGuid();

            if (info_Article.AritcleID != Guid.Empty)
            {
                //文章编号
                para = new SqlParameter("@AritcleID",SqlDbType.UniqueIdentifier);
                para.Value = info_Article.AritcleID;
                parameters.Add(para);
                strSql.Append("AritcleID,");
            }

            if (info_Article.Title != null)
            {
                //标题
                para = new SqlParameter("@Title",SqlDbType.NVarChar,1000);
                para.Value = info_Article.Title;
                parameters.Add(para);
                strSql.Append("Title,");
            }

            if (info_Article.Category != Guid.Empty)
            {
                //类别编号
                para = new SqlParameter("@Category",SqlDbType.UniqueIdentifier);
                para.Value = info_Article.Category;
                parameters.Add(para);
                strSql.Append("Category,");
            }

            if (info_Article.InfoBody != null)
            {
                //内容
                para = new SqlParameter("@InfoBody",SqlDbType.Text);
                para.Value = info_Article.InfoBody;
                parameters.Add(para);
                strSql.Append("InfoBody,");
            }

            if (info_Article.OpName != null)
            {
                //添加人
                para = new SqlParameter("@OpName",SqlDbType.NVarChar,100);
                para.Value = info_Article.OpName;
                parameters.Add(para);
                strSql.Append("OpName,");
            }

            if (info_Article.OPTime != null)
            {
                //添加时间
                para = new SqlParameter("@OPTime",SqlDbType.DateTime);
                para.Value = info_Article.OPTime;
                parameters.Add(para);
                strSql.Append("OPTime,");
            }
             if (strSql.ToString().Substring(strSql.Length - 1, 1) == ",")
                 strSql.Remove(strSql.Length - 1,1);

            strSql.Append(") values (");
            if (info_Article.AritcleID != Guid.Empty)
            {
                strSql.Append("@AritcleID,");
            }
            if (info_Article.Title != null)
            {
                strSql.Append("@Title,");
            }
            if (info_Article.Category != Guid.Empty)
            {
                strSql.Append("@Category,");
            }
            if (info_Article.InfoBody != null)
            {
                strSql.Append("@InfoBody,");
            }
            if (info_Article.OpName != null)
            {
                strSql.Append("@OpName,");
            }
            if (info_Article.OPTime != null)
            {
                strSql.Append("@OPTime,");
            }
             if (strSql.ToString().Substring(strSql.Length - 1, 1) == ",")
                 strSql.Remove(strSql.Length - 1,1);
            strSql.Append(")");

             //构建日志对象
             OperateObject operObj = new OperateObject();
             operObj.Parameters = parameters;
             operObj.SqlText = strSql.ToString();
             
             return operObj;
        }

        #endregion

        #endregion

        #region 修改数据方法集

        /// <summary>
        /// 修改数据，根据主键修改数据
        /// </summary>
        public void Update(Info_ArticleInfo info_Article)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (info_Article.AritcleID == null)
                throw new ArgumentException("根据主键更新表(T_Info_Article),主键(AritcleID)不能为空!");

            whereParaList.Add(new WhereParameter("And AritcleID = @AritcleID", "@AritcleID", info_Article.AritcleID));

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(info_Article, whereParaList);

                base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 修改数据，根据主键修改数据(事务版)
        /// </summary>
        public void Update(Info_ArticleInfo info_Article,IDbTransaction trans)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (info_Article.AritcleID == null)
                throw new ArgumentException("根据主键更新表(T_Info_Article),主键(AritcleID)不能为空!");

            whereParaList.Add(new WhereParameter("And AritcleID = @AritcleID", "@AritcleID", info_Article.AritcleID));

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(info_Article, whereParaList);

            base.ExecuteNonQuery(operateObject,trans);
        }

        /// <summary>
        /// 修改数据，根据条件修改数据(非事务版)
        /// </summary>
        public void Update(Info_ArticleInfo info_Article, List<IWhereParameter> whereParaList)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("根据条件更新,条件列表不能为空!");

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(info_Article, whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 修改数据，根据条件修改数据(事务版)
        /// </summary>
        public void Update(Info_ArticleInfo info_Article, List<IWhereParameter> whereParaList,IDbTransaction trans)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("根据条件更新,条件列表不能为空!");

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(info_Article, whereParaList);

                base.ExecuteNonQuery(operateObject,trans);
        }


        #region 构建更新SQL语句 

        /// <summary>
        /// 构建更新SQL语句
        /// </summary>
        /// <param name="info_Article"></param>
        /// <returns></returns>
        private OperateObject CreateUpdateObject(Info_ArticleInfo info_Article, List<IWhereParameter> whereList)
        {
            StringBuilder strSql = new StringBuilder();
            List<IDataParameter> parameters = new  List<IDataParameter>();
            SqlParameter para;
            strSql.Append("update T_Info_Article set ");
             if (!string.IsNullOrEmpty(info_Article.UpdateNullFields))
             {
                 foreach (string fieldsName in info_Article.UpdateNullFields.Split(','))
                 {
                     strSql.Append(fieldsName + "=NULL,");
                 }
             }

            if(info_Article.Title!=null)
            {
                //标题

                para =  new SqlParameter("@Title",SqlDbType.NVarChar,1000);
                para.Value = info_Article.Title;
                parameters.Add(para);
                strSql.Append("Title=@Title,");
            }
            if(info_Article.Category!=Guid.Empty)
            {
                //类别编号

                para =  new SqlParameter("@Category",SqlDbType.UniqueIdentifier);
                para.Value = info_Article.Category;
                parameters.Add(para);
                strSql.Append("Category=@Category,");
            }
            if(info_Article.InfoBody!=null)
            {
                //内容

                para =  new SqlParameter("@InfoBody",SqlDbType.Text);
                para.Value = info_Article.InfoBody;
                parameters.Add(para);
                strSql.Append("InfoBody=@InfoBody,");
            }
            if(info_Article.OpName!=null)
            {
                //添加人

                para =  new SqlParameter("@OpName",SqlDbType.NVarChar,100);
                para.Value = info_Article.OpName;
                parameters.Add(para);
                strSql.Append("OpName=@OpName,");
            }
            if(info_Article.OPTime!=null)
            {
                //添加时间

                para =  new SqlParameter("@OPTime",SqlDbType.DateTime);
                para.Value = info_Article.OPTime;
                parameters.Add(para);
                strSql.Append("OPTime=@OPTime,");
            }
            if (strSql.ToString().Substring(strSql.Length - 1) == ",")
                strSql.Remove(strSql.Length - 1, 1); 
 
             strSql.Append(" Where 1=1  ");
             
             // 如果条件不为空,则根据条件进行更新
             foreach (IWhereParameter wherePara in whereList)
             {
                 strSql.Append(" " + wherePara.WhereExpression);
                 parameters.Add(new SqlParameter(wherePara.ParameterName, wherePara.Value));
             }
             
             //构建日志对象
              OperateObject operObj = new OperateObject();
             operObj.Parameters = parameters;
             operObj.SqlText = strSql.ToString();
              //构建返回对象
             return operObj;
        }

        #endregion

        #endregion

        #region 删除方法集

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        public void Delete(Guid aritcleID)
        {
            if (aritcleID == null)
                throw new ArgumentException("根据主键,删除表(T_Info_Article)中记录,主键(AritcleID)不能为空!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And AritcleID = @AritcleID ", "@AritcleID", aritcleID));
            //建立SQL语句对象
            OperateObject operateObject = CreateDeleteObject(whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 根据主键删除(事务版)
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        public void Delete(Guid aritcleID,IDbTransaction trans)
        {
            if (aritcleID == null)
                throw new ArgumentException("根据主键,删除表(T_Info_Article)中记录,主键(AritcleID)不能为空!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And AritcleID = @AritcleID ", "@AritcleID", aritcleID));
            //建立SQL语句对象
            OperateObject operateObject = CreateDeleteObject(whereParaList);
            base.ExecuteNonQuery(operateObject,trans);
        }

        /// <summary>
        /// 根据条件删除数据，
        /// </summary>
        public void Delete(List<IWhereParameter> whereParaList)
        {
            //建立SQL语句对象
            OperateObject operateObject = CreateDeleteObject(whereParaList);
            base.ExecuteNonQuery(operateObject);
        }
        /// <summary>
        /// 根据条件删除数据，
        /// </summary>
        public void Delete(List<IWhereParameter> whereParaList,IDbTransaction trans)
        {
           //建立SQL语句对象
            OperateObject operateObject = CreateDeleteObject(whereParaList);
            base.ExecuteNonQuery(operateObject,trans);
        }


        #region 建立删除SQL对象 
        
        /// <summary>  
        /// 建立删除SQL对象  
        /// </summary>  
        /// <param name="whereParaList"></param>  
        /// <param name="config"></param>  
        /// <returns></returns>  
        private OperateObject CreateDeleteObject(List<IWhereParameter> whereParaList) 
        { 
            StringBuilder strSql = new StringBuilder(); 
            List<IDataParameter> parameters = new List<IDataParameter>(); 

            strSql.Append("DELETE FROM T_Info_Article "); 
            strSql.Append(" Where 1=1 "); 

            foreach (WhereParameter wherepara in whereParaList) 
            { 
                parameters.Add(new SqlParameter(wherepara.ParameterName, wherepara.Value)); 
                strSql.Append(wherepara.WhereExpression); 
            } 

            //构建日志对象  
            OperateObject opereObj = new OperateObject(); 
            opereObj.SqlText = strSql.ToString(); 
            opereObj.Parameters = parameters; 

            //构建返回对象  
            return opereObj; 
        } 

        #endregion 

        #endregion

        #region 根据主键查询得到实体

        /// <summary>
        /// 根据主键得到一个实体
        /// </summary>
        /// <returns></returns>
        public Info_ArticleInfo GetInfo_ArticleInfo(Guid aritcleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AritcleID,Title,Category,InfoBody,OpName,OPTime from T_Info_Article");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And AritcleID = @AritcleID");
            SqlParameter[] parameters = {

                                              //文章编号
                                                new SqlParameter("@AritcleID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = aritcleID;//文章编号
            Info_ArticleInfo info_Article=null;
            using (IDbConnection connect = GetConnection())
            {
                using (IDataReader dr = basicDataAccess.ExecuteReader(connect, CommandType.Text, strSql.ToString(), parameters))
                {
                    if (dr.Read())
                    {
                        info_Article = CreateInfo_ArticleInfoByReader(dr);
                    }
                }
            }
            return info_Article;
        }


        /// <summary>
        /// 根据主键得到一个实体
        /// </summary>
        /// <returns></returns>
        public Info_ArticleInfo GetInfo_ArticleInfo(Guid aritcleID,IDbTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AritcleID,Title,Category,InfoBody,OpName,OPTime from T_Info_Article");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And AritcleID = @AritcleID");
            SqlParameter[] parameters = {

                                              //文章编号
                                                new SqlParameter("@AritcleID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = aritcleID;//文章编号
            Info_ArticleInfo info_Article=null;
            using (IDataReader dr = basicDataAccess.ExecuteReader(trans, CommandType.Text, strSql.ToString(), parameters))
            {
                if (dr.Read())
                {
                    info_Article = CreateInfo_ArticleInfoByReader(dr);
                }
            }
            return info_Article;
        }

        #endregion

        #region  根据查询参数，得到LIST对象列表

        /// <summary>
        /// 根据查询参数，得到 LIST对象列表
        /// </summary>
        /// <param name="DataQuery">查询参数</param>
        /// <returns>List<></returns>
        public List<Info_ArticleInfo> GetInfo_ArticleList(IDataQuery dataQuery)
        {

            List<Info_ArticleInfo> returnList = new List<Info_ArticleInfo>();
            dataQuery.TableName = "T_Info_Article";
            using (IDbConnection connection = GetConnection())
            {
                using (IDataReader dr = basicDataAccess.ExecuteReader(connection,CommandType.Text,dataQuery, dataQuery.WhereParameters))
                {
                    while (dr.Read())
                    {
                        returnList.Add(CreateInfo_ArticleInfoByReader(dr));
                    }
                }
                //读取记录数(Reading RecordCount)
                if (dataQuery.PageView.IsPageView)
                {
                    dataQuery.PageView.RecordCount = basicDataAccess.GetRecordCount(connection,CommandType.Text, dataQuery, dataQuery.WhereParameters);
                    dataQuery.PageView.PageCount = Convert.ToInt32(dataQuery.PageView.RecordCount / dataQuery.PageView.PageSize) + 1;
                }
            }
            return returnList;
        }

        /// <summary>
        /// 根据查询参数，得到 LIST对象列表
        /// </summary>
        /// <param name="DataQuery">查询参数</param>
        /// <returns>List<></returns>
        public List<Info_ArticleInfo> GetInfo_ArticleList(IDataQuery dataQuery,IDbTransaction trans)
        {

            List<Info_ArticleInfo> returnList = new List<Info_ArticleInfo>();
            dataQuery.TableName = "T_Info_Article";
            using (IDataReader dr = basicDataAccess.ExecuteReader(trans,CommandType.Text,dataQuery, dataQuery.WhereParameters))
            {
                while (dr.Read())
                {
                    returnList.Add(CreateInfo_ArticleInfoByReader(dr));
                }
            }
            //读取记录数(Reading RecordCount)
            if (dataQuery.PageView.IsPageView)
            {
                dataQuery.PageView.RecordCount = basicDataAccess.GetRecordCount(trans,CommandType.Text, dataQuery, dataQuery.WhereParameters);
                dataQuery.PageView.PageCount = Convert.ToInt32(dataQuery.PageView.RecordCount / dataQuery.PageView.PageSize) + 1;
            }
            return returnList;
        }


        #region 建立对象实体
        /// <summary>
        /// 建立对象实体
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Info_ArticleInfo CreateInfo_ArticleInfoByReader(IDataReader dr)
        {
            Info_ArticleInfo info_Article = new Info_ArticleInfo();
            //文章编号
            if (!Convert.IsDBNull(dr["AritcleID"]))
                info_Article.AritcleID = (Guid)(dr["AritcleID"]);
 
            //标题
            if (!Convert.IsDBNull(dr["Title"]))
                info_Article.Title = Convert.ToString(dr["Title"]);
 
            //类别编号
            if (!Convert.IsDBNull(dr["Category"]))
                info_Article.Category = (Guid)(dr["Category"]);
 
            //内容
            if (!Convert.IsDBNull(dr["InfoBody"]))
                info_Article.InfoBody = Convert.ToString(dr["InfoBody"]);
 
            //添加人
            if (!Convert.IsDBNull(dr["OpName"]))
                info_Article.OpName = Convert.ToString(dr["OpName"]);
 
            //添加时间
            if (!Convert.IsDBNull(dr["OPTime"]))
                info_Article.OPTime = Convert.ToDateTime(dr["OPTime"]);
 
            return info_Article;
        }

        #endregion

        #endregion

        #region 判断是否己存在
        
        /// <summary> 
        /// 根据主键，判断对象是否己存在 
        /// </summary> 
        /// <returns></returns> 
        public bool IsExist(Guid aritcleID)
        {
            Info_ArticleInfo info_ArticleInfo = GetInfo_ArticleInfo(aritcleID);
            if (info_ArticleInfo == null)
                return false;
            else
                return true;
        }

        #endregion 

    }
} 
