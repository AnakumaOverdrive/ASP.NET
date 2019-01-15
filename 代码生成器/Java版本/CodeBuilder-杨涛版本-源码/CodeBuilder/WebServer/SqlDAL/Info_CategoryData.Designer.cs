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
    /// 生成日期：2012年09月17日
    /// 生成模板: Esint.Template.SqlDAL.SqlDAL_11 版
    /// 特别说明：本文件由代码生成工具自动生成，请勿轻易修改！
    /// </summary>
    public partial class Info_CategoryData  : BaseData, IInfo_CategoryData
    {
        #region 插入数据 

        /// <summary>
        /// 插入数据
        /// </summary>
        public void Insert(Info_CategoryInfo info_Category)
        {
            //建立SQL语句对象
            OperateObject operateObject = CreateInsertObject(info_Category);
            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 插入数据(事务版)
        /// </summary>
        public void Insert(Info_CategoryInfo info_Category,IDbTransaction trans)
        {
            //建立SQL语句对象
            OperateObject operateObject = CreateInsertObject(info_Category);
            base.ExecuteNonQuery(operateObject,trans);
        }

        #region 构建插入SQL语句 

        /// <summary>
        /// 构建插入SQL语句
        /// </summary>
        /// <param name="info_Category"></param>
        /// <returns></returns>
        private OperateObject CreateInsertObject(Info_CategoryInfo info_Category)
        {
             BasicDataAccess basicDataAccess = new BasicDataAccess();
            //建立插入的SQL语句,判断是否为空拼串
            StringBuilder         strSql     = new StringBuilder();
            List<IDataParameter> parameters = new List<IDataParameter>();
            SqlParameter para;
            strSql.Append("INSERT INTO T_Info_Category (");
            if(info_Category.CategoryID ==Guid.Empty)
                info_Category.CategoryID = Guid.NewGuid();

            if (info_Category.CategoryID != Guid.Empty)
            {
                //类别编号
                para = new SqlParameter("@CategoryID",SqlDbType.UniqueIdentifier);
                para.Value = info_Category.CategoryID;
                parameters.Add(para);
                strSql.Append("CategoryID,");
            }

            if (info_Category.CategoryName != null)
            {
                //类别名称
                para = new SqlParameter("@CategoryName",SqlDbType.NVarChar,200);
                para.Value = info_Category.CategoryName;
                parameters.Add(para);
                strSql.Append("CategoryName,");
            }

            if (info_Category.CategoryType != null)
            {
                //类型(1公开，2 私有)
                para = new SqlParameter("@CategoryType",SqlDbType.Char,1);
                para.Value = info_Category.CategoryType;
                parameters.Add(para);
                strSql.Append("CategoryType,");
            }

            if (info_Category.ParentCategory != Guid.Empty)
            {
                //父类别编号
                para = new SqlParameter("@ParentCategory",SqlDbType.UniqueIdentifier);
                para.Value = info_Category.ParentCategory;
                parameters.Add(para);
                strSql.Append("ParentCategory,");
            }

            if (info_Category.UserID != Guid.Empty)
            {
                //用户编号
                para = new SqlParameter("@UserID",SqlDbType.UniqueIdentifier);
                para.Value = info_Category.UserID;
                parameters.Add(para);
                strSql.Append("UserID,");
            }
             if (strSql.ToString().Substring(strSql.Length - 1, 1) == ",")
                 strSql.Remove(strSql.Length - 1,1);

            strSql.Append(") values (");
            if (info_Category.CategoryID != Guid.Empty)
            {
                strSql.Append("@CategoryID,");
            }
            if (info_Category.CategoryName != null)
            {
                strSql.Append("@CategoryName,");
            }
            if (info_Category.CategoryType != null)
            {
                strSql.Append("@CategoryType,");
            }
            if (info_Category.ParentCategory != Guid.Empty)
            {
                strSql.Append("@ParentCategory,");
            }
            if (info_Category.UserID != Guid.Empty)
            {
                strSql.Append("@UserID,");
            }
            if (info_Category.OrderNum != null)
            {
                strSql.Append("@OrderNum,");
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
        public void Update(Info_CategoryInfo info_Category)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (info_Category.CategoryID == null)
                throw new ArgumentException("根据主键更新表(T_Info_Category),主键(CategoryID)不能为空!");

            whereParaList.Add(new WhereParameter("And CategoryID = @CategoryID", "@CategoryID", info_Category.CategoryID));

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(info_Category, whereParaList);

                base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 修改数据，根据主键修改数据(事务版)
        /// </summary>
        public void Update(Info_CategoryInfo info_Category,IDbTransaction trans)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (info_Category.CategoryID == null)
                throw new ArgumentException("根据主键更新表(T_Info_Category),主键(CategoryID)不能为空!");

            whereParaList.Add(new WhereParameter("And CategoryID = @CategoryID", "@CategoryID", info_Category.CategoryID));

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(info_Category, whereParaList);

            base.ExecuteNonQuery(operateObject,trans);
        }

        /// <summary>
        /// 修改数据，根据条件修改数据(非事务版)
        /// </summary>
        public void Update(Info_CategoryInfo info_Category, List<IWhereParameter> whereParaList)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("根据条件更新,条件列表不能为空!");

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(info_Category, whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 修改数据，根据条件修改数据(事务版)
        /// </summary>
        public void Update(Info_CategoryInfo info_Category, List<IWhereParameter> whereParaList,IDbTransaction trans)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("根据条件更新,条件列表不能为空!");

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(info_Category, whereParaList);

                base.ExecuteNonQuery(operateObject,trans);
        }


        #region 构建更新SQL语句 

        /// <summary>
        /// 构建更新SQL语句
        /// </summary>
        /// <param name="info_Category"></param>
        /// <returns></returns>
        private OperateObject CreateUpdateObject(Info_CategoryInfo info_Category, List<IWhereParameter> whereList)
        {
            StringBuilder strSql = new StringBuilder();
            List<IDataParameter> parameters = new  List<IDataParameter>();
            SqlParameter para;
            strSql.Append("update T_Info_Category set ");
             if (!string.IsNullOrEmpty(info_Category.UpdateNullFields))
             {
                 foreach (string fieldsName in info_Category.UpdateNullFields.Split(','))
                 {
                     strSql.Append(fieldsName + "=NULL,");
                 }
             }

            if(info_Category.CategoryName!=null)
            {
                //类别名称

                para =  new SqlParameter("@CategoryName",SqlDbType.NVarChar,200);
                para.Value = info_Category.CategoryName;
                parameters.Add(para);
                strSql.Append("CategoryName=@CategoryName,");
            }
            if(info_Category.CategoryType!=null)
            {
                //类型(1公开，2 私有)

                para =  new SqlParameter("@CategoryType",SqlDbType.Char,1);
                para.Value = info_Category.CategoryType;
                parameters.Add(para);
                strSql.Append("CategoryType=@CategoryType,");
            }
            if(info_Category.ParentCategory!=Guid.Empty)
            {
                //父类别编号

                para =  new SqlParameter("@ParentCategory",SqlDbType.UniqueIdentifier);
                para.Value = info_Category.ParentCategory;
                parameters.Add(para);
                strSql.Append("ParentCategory=@ParentCategory,");
            }
            if(info_Category.UserID!=Guid.Empty)
            {
                //用户编号

                para =  new SqlParameter("@UserID",SqlDbType.UniqueIdentifier);
                para.Value = info_Category.UserID;
                parameters.Add(para);
                strSql.Append("UserID=@UserID,");
            }
            if(info_Category.OrderNum!=null)
            {
                //排序号

                para =  new SqlParameter("@OrderNum",SqlDbType.Int);
                para.Value = info_Category.OrderNum;
                parameters.Add(para);
                strSql.Append("OrderNum=@OrderNum,");
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
        public void Delete(Guid categoryID)
        {
            if (categoryID == null)
                throw new ArgumentException("根据主键,删除表(T_Info_Category)中记录,主键(CategoryID)不能为空!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And CategoryID = @CategoryID ", "@CategoryID", categoryID));
            //建立SQL语句对象
            OperateObject operateObject = CreateDeleteObject(whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 根据主键删除(事务版)
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        public void Delete(Guid categoryID,IDbTransaction trans)
        {
            if (categoryID == null)
                throw new ArgumentException("根据主键,删除表(T_Info_Category)中记录,主键(CategoryID)不能为空!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And CategoryID = @CategoryID ", "@CategoryID", categoryID));
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

            strSql.Append("DELETE FROM T_Info_Category "); 
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
        public Info_CategoryInfo GetInfo_CategoryInfo(Guid categoryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CategoryID,CategoryName,CategoryType,ParentCategory,UserID,OrderNum from T_Info_Category");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And CategoryID = @CategoryID");
            SqlParameter[] parameters = {

                                              //类别编号
                                                new SqlParameter("@CategoryID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = categoryID;//类别编号
            Info_CategoryInfo info_Category=null;
            using (IDbConnection connect = GetConnection())
            {
                using (IDataReader dr = basicDataAccess.ExecuteReader(connect, CommandType.Text, strSql.ToString(), parameters))
                {
                    if (dr.Read())
                    {
                        info_Category = CreateInfo_CategoryInfoByReader(dr);
                    }
                }
            }
            return info_Category;
        }


        /// <summary>
        /// 根据主键得到一个实体
        /// </summary>
        /// <returns></returns>
        public Info_CategoryInfo GetInfo_CategoryInfo(Guid categoryID,IDbTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CategoryID,CategoryName,CategoryType,ParentCategory,UserID,OrderNum from T_Info_Category");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And CategoryID = @CategoryID");
            SqlParameter[] parameters = {

                                              //类别编号
                                                new SqlParameter("@CategoryID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = categoryID;//类别编号
            Info_CategoryInfo info_Category=null;
            using (IDataReader dr = basicDataAccess.ExecuteReader(trans, CommandType.Text, strSql.ToString(), parameters))
            {
                if (dr.Read())
                {
                    info_Category = CreateInfo_CategoryInfoByReader(dr);
                }
            }
            return info_Category;
        }

        #endregion

        #region  根据查询参数，得到LIST对象列表

        /// <summary>
        /// 根据查询参数，得到 LIST对象列表
        /// </summary>
        /// <param name="DataQuery">查询参数</param>
        /// <returns>List<></returns>
        public List<Info_CategoryInfo> GetInfo_CategoryList(IDataQuery dataQuery)
        {

            List<Info_CategoryInfo> returnList = new List<Info_CategoryInfo>();
            dataQuery.TableName = "T_Info_Category";
            using (IDbConnection connection = GetConnection())
            {
                using (IDataReader dr = basicDataAccess.ExecuteReader(connection,CommandType.Text,dataQuery, dataQuery.WhereParameters))
                {
                    while (dr.Read())
                    {
                        returnList.Add(CreateInfo_CategoryInfoByReader(dr));
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
        public List<Info_CategoryInfo> GetInfo_CategoryList(IDataQuery dataQuery,IDbTransaction trans)
        {

            List<Info_CategoryInfo> returnList = new List<Info_CategoryInfo>();
            dataQuery.TableName = "T_Info_Category";
            using (IDataReader dr = basicDataAccess.ExecuteReader(trans,CommandType.Text,dataQuery, dataQuery.WhereParameters))
            {
                while (dr.Read())
                {
                    returnList.Add(CreateInfo_CategoryInfoByReader(dr));
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
        private Info_CategoryInfo CreateInfo_CategoryInfoByReader(IDataReader dr)
        {
            Info_CategoryInfo info_Category = new Info_CategoryInfo();
            //类别编号
            if (!Convert.IsDBNull(dr["CategoryID"]))
                info_Category.CategoryID = (Guid)(dr["CategoryID"]);
 
            //类别名称
            if (!Convert.IsDBNull(dr["CategoryName"]))
                info_Category.CategoryName = Convert.ToString(dr["CategoryName"]);
 
            //类型(1公开，2 私有)
            if (!Convert.IsDBNull(dr["CategoryType"]))
                info_Category.CategoryType = Convert.ToString(dr["CategoryType"]);
 
            //父类别编号
            if (!Convert.IsDBNull(dr["ParentCategory"]))
                info_Category.ParentCategory = (Guid)(dr["ParentCategory"]);
 
            //用户编号
            if (!Convert.IsDBNull(dr["UserID"]))
                info_Category.UserID = (Guid)(dr["UserID"]);
 
            //排序号
            if (!Convert.IsDBNull(dr["OrderNum"]))
                info_Category.OrderNum = Convert.ToInt32(dr["OrderNum"]);
 
            return info_Category;
        }

        #endregion

        #endregion

        #region 判断是否己存在
        
        /// <summary> 
        /// 根据主键，判断对象是否己存在 
        /// </summary> 
        /// <returns></returns> 
        public bool IsExist(Guid categoryID)
        {
            Info_CategoryInfo info_CategoryInfo = GetInfo_CategoryInfo(categoryID);
            if (info_CategoryInfo == null)
                return false;
            else
                return true;
        }

        #endregion 

    }
} 
