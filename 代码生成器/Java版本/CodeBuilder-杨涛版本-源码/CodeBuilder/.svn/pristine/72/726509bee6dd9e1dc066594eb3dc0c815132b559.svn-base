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
    /// 模块名称：人员基本信息 数据访问层
    /// 作    者：刘伟通
    /// 生成日期：2012年09月14日
    /// 生成模板: Esint.Template.SqlDAL.SqlDAL_11 版
    /// 特别说明：本文件由代码生成工具自动生成，请勿轻易修改！
    /// </summary>
    public partial class Sys_UsersData  : BaseData, ISys_UsersData
    {
        #region 插入数据 

        /// <summary>
        /// 插入数据
        /// </summary>
        public void Insert(Sys_UsersInfo sys_Users)
        {
            //建立SQL语句对象
            OperateObject operateObject = CreateInsertObject(sys_Users);
            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 插入数据(事务版)
        /// </summary>
        public void Insert(Sys_UsersInfo sys_Users,IDbTransaction trans)
        {
            //建立SQL语句对象
            OperateObject operateObject = CreateInsertObject(sys_Users);
            base.ExecuteNonQuery(operateObject,trans);
        }

        #region 构建插入SQL语句 

        /// <summary>
        /// 构建插入SQL语句
        /// </summary>
        /// <param name="sys_Users"></param>
        /// <returns></returns>
        private OperateObject CreateInsertObject(Sys_UsersInfo sys_Users)
        {
             BasicDataAccess basicDataAccess = new BasicDataAccess();
            //建立插入的SQL语句,判断是否为空拼串
            StringBuilder         strSql     = new StringBuilder();
            List<IDataParameter> parameters = new List<IDataParameter>();
            SqlParameter para;
            strSql.Append("INSERT INTO T_Sys_Users (");
            if(sys_Users.UserID ==Guid.Empty)
                sys_Users.UserID = Guid.NewGuid();

            if (sys_Users.UserID != Guid.Empty)
            {
                //用户ID
                para = new SqlParameter("@UserID",SqlDbType.UniqueIdentifier);
                para.Value = sys_Users.UserID;
                parameters.Add(para);
                strSql.Append("UserID,");
            }

            if (sys_Users.DepartmentID != Guid.Empty)
            {
                //部门编号
                para = new SqlParameter("@DepartmentID",SqlDbType.UniqueIdentifier);
                para.Value = sys_Users.DepartmentID;
                parameters.Add(para);
                strSql.Append("DepartmentID,");
            }

            if (sys_Users.UserName != null)
            {
                //用户名
                para = new SqlParameter("@UserName",SqlDbType.VarChar,20);
                para.Value = sys_Users.UserName;
                parameters.Add(para);
                strSql.Append("UserName,");
            }

            if (sys_Users.RealName != null)
            {
                //真实姓名
                para = new SqlParameter("@RealName",SqlDbType.NVarChar,40);
                para.Value = sys_Users.RealName;
                parameters.Add(para);
                strSql.Append("RealName,");
            }

            if (sys_Users.Password != null)
            {
                //登陆密码
                para = new SqlParameter("@Password",SqlDbType.VarChar,50);
                para.Value = sys_Users.Password;
                parameters.Add(para);
                strSql.Append("Password,");
            }

            if (sys_Users.IsEffective != null)
            {
                //是否有效(0:有效,1:禁用)
                para = new SqlParameter("@IsEffective",SqlDbType.Char,1);
                para.Value = sys_Users.IsEffective;
                parameters.Add(para);
                strSql.Append("IsEffective,");
            }

            if (sys_Users.Sex != null)
            {
                //性别
                para = new SqlParameter("@Sex",SqlDbType.Char,1);
                para.Value = sys_Users.Sex;
                parameters.Add(para);
                strSql.Append("Sex,");
            }

            if (sys_Users.Tel != null)
            {
                //联系电话
                para = new SqlParameter("@Tel",SqlDbType.NVarChar,40);
                para.Value = sys_Users.Tel;
                parameters.Add(para);
                strSql.Append("Tel,");
            }

            if (sys_Users.LastLoginTime != null)
            {
                //最后登录时间
                para = new SqlParameter("@LastLoginTime",SqlDbType.DateTime);
                para.Value = sys_Users.LastLoginTime;
                parameters.Add(para);
                strSql.Append("LastLoginTime,");
            }

            if (sys_Users.LastLoginIP != null)
            {
                //最后登录IP
                para = new SqlParameter("@LastLoginIP",SqlDbType.VarChar,20);
                para.Value = sys_Users.LastLoginIP;
                parameters.Add(para);
                strSql.Append("LastLoginIP,");
            }

            if (sys_Users.LoginTimes != null)
            {
                //登录资数
                para = new SqlParameter("@LoginTimes",SqlDbType.Int);
                para.Value = sys_Users.LoginTimes;
                parameters.Add(para);
                strSql.Append("LoginTimes,");
            }

            if (sys_Users.OpName != null)
            {
                //添加人
                para = new SqlParameter("@OpName",SqlDbType.NVarChar,40);
                para.Value = sys_Users.OpName;
                parameters.Add(para);
                strSql.Append("OpName,");
            }

            if (sys_Users.OpTime != null)
            {
                //添加时间
                para = new SqlParameter("@OpTime",SqlDbType.DateTime);
                para.Value = sys_Users.OpTime;
                parameters.Add(para);
                strSql.Append("OpTime,");
            }
             if (strSql.ToString().Substring(strSql.Length - 1, 1) == ",")
                 strSql.Remove(strSql.Length - 1,1);

            strSql.Append(") values (");
            if (sys_Users.UserID != Guid.Empty)
            {
                strSql.Append("@UserID,");
            }
            if (sys_Users.DepartmentID != Guid.Empty)
            {
                strSql.Append("@DepartmentID,");
            }
            if (sys_Users.UserName != null)
            {
                strSql.Append("@UserName,");
            }
            if (sys_Users.RealName != null)
            {
                strSql.Append("@RealName,");
            }
            if (sys_Users.Password != null)
            {
                strSql.Append("@Password,");
            }
            if (sys_Users.IsEffective != null)
            {
                strSql.Append("@IsEffective,");
            }
            if (sys_Users.Sex != null)
            {
                strSql.Append("@Sex,");
            }
            if (sys_Users.Tel != null)
            {
                strSql.Append("@Tel,");
            }
            if (sys_Users.LastLoginTime != null)
            {
                strSql.Append("@LastLoginTime,");
            }
            if (sys_Users.LastLoginIP != null)
            {
                strSql.Append("@LastLoginIP,");
            }
            if (sys_Users.LoginTimes != null)
            {
                strSql.Append("@LoginTimes,");
            }
            if (sys_Users.OpName != null)
            {
                strSql.Append("@OpName,");
            }
            if (sys_Users.OpTime != null)
            {
                strSql.Append("@OpTime,");
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
        public void Update(Sys_UsersInfo sys_Users)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (sys_Users.UserID == null)
                throw new ArgumentException("根据主键更新表(T_Sys_Users),主键(UserID)不能为空!");

            whereParaList.Add(new WhereParameter("And UserID = @UserID", "@UserID", sys_Users.UserID));

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(sys_Users, whereParaList);

                base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 修改数据，根据主键修改数据(事务版)
        /// </summary>
        public void Update(Sys_UsersInfo sys_Users,IDbTransaction trans)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (sys_Users.UserID == null)
                throw new ArgumentException("根据主键更新表(T_Sys_Users),主键(UserID)不能为空!");

            whereParaList.Add(new WhereParameter("And UserID = @UserID", "@UserID", sys_Users.UserID));

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(sys_Users, whereParaList);

            base.ExecuteNonQuery(operateObject,trans);
        }

        /// <summary>
        /// 修改数据，根据条件修改数据(非事务版)
        /// </summary>
        public void Update(Sys_UsersInfo sys_Users, List<IWhereParameter> whereParaList)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("根据条件更新,条件列表不能为空!");

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(sys_Users, whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 修改数据，根据条件修改数据(事务版)
        /// </summary>
        public void Update(Sys_UsersInfo sys_Users, List<IWhereParameter> whereParaList,IDbTransaction trans)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("根据条件更新,条件列表不能为空!");

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(sys_Users, whereParaList);

                base.ExecuteNonQuery(operateObject,trans);
        }


        #region 构建更新SQL语句 

        /// <summary>
        /// 构建更新SQL语句
        /// </summary>
        /// <param name="sys_Users"></param>
        /// <returns></returns>
        private OperateObject CreateUpdateObject(Sys_UsersInfo sys_Users, List<IWhereParameter> whereList)
        {
            StringBuilder strSql = new StringBuilder();
            List<IDataParameter> parameters = new  List<IDataParameter>();
            SqlParameter para;
            strSql.Append("update T_Sys_Users set ");
             if (!string.IsNullOrEmpty(sys_Users.UpdateNullFields))
             {
                 foreach (string fieldsName in sys_Users.UpdateNullFields.Split(','))
                 {
                     strSql.Append(fieldsName + "=NULL,");
                 }
             }

            if(sys_Users.DepartmentID!=Guid.Empty)
            {
                //部门编号

                para =  new SqlParameter("@DepartmentID",SqlDbType.UniqueIdentifier);
                para.Value = sys_Users.DepartmentID;
                parameters.Add(para);
                strSql.Append("DepartmentID=@DepartmentID,");
            }
            if(sys_Users.UserName!=null)
            {
                //用户名

                para =  new SqlParameter("@UserName",SqlDbType.VarChar,20);
                para.Value = sys_Users.UserName;
                parameters.Add(para);
                strSql.Append("UserName=@UserName,");
            }
            if(sys_Users.RealName!=null)
            {
                //真实姓名

                para =  new SqlParameter("@RealName",SqlDbType.NVarChar,40);
                para.Value = sys_Users.RealName;
                parameters.Add(para);
                strSql.Append("RealName=@RealName,");
            }
            if(sys_Users.Password!=null)
            {
                //登陆密码

                para =  new SqlParameter("@Password",SqlDbType.VarChar,50);
                para.Value = sys_Users.Password;
                parameters.Add(para);
                strSql.Append("Password=@Password,");
            }
            if(sys_Users.IsEffective!=null)
            {
                //是否有效(0:有效,1:禁用)

                para =  new SqlParameter("@IsEffective",SqlDbType.Char,1);
                para.Value = sys_Users.IsEffective;
                parameters.Add(para);
                strSql.Append("IsEffective=@IsEffective,");
            }
            if(sys_Users.Sex!=null)
            {
                //性别

                para =  new SqlParameter("@Sex",SqlDbType.Char,1);
                para.Value = sys_Users.Sex;
                parameters.Add(para);
                strSql.Append("Sex=@Sex,");
            }
            if(sys_Users.Tel!=null)
            {
                //联系电话

                para =  new SqlParameter("@Tel",SqlDbType.NVarChar,40);
                para.Value = sys_Users.Tel;
                parameters.Add(para);
                strSql.Append("Tel=@Tel,");
            }
            if(sys_Users.LastLoginTime!=null)
            {
                //最后登录时间

                para =  new SqlParameter("@LastLoginTime",SqlDbType.DateTime);
                para.Value = sys_Users.LastLoginTime;
                parameters.Add(para);
                strSql.Append("LastLoginTime=@LastLoginTime,");
            }
            if(sys_Users.LastLoginIP!=null)
            {
                //最后登录IP

                para =  new SqlParameter("@LastLoginIP",SqlDbType.VarChar,20);
                para.Value = sys_Users.LastLoginIP;
                parameters.Add(para);
                strSql.Append("LastLoginIP=@LastLoginIP,");
            }
            if(sys_Users.LoginTimes!=null)
            {
                //登录资数

                para =  new SqlParameter("@LoginTimes",SqlDbType.Int);
                para.Value = sys_Users.LoginTimes;
                parameters.Add(para);
                strSql.Append("LoginTimes=@LoginTimes,");
            }
            if(sys_Users.OpName!=null)
            {
                //添加人

                para =  new SqlParameter("@OpName",SqlDbType.NVarChar,40);
                para.Value = sys_Users.OpName;
                parameters.Add(para);
                strSql.Append("OpName=@OpName,");
            }
            if(sys_Users.OpTime!=null)
            {
                //添加时间

                para =  new SqlParameter("@OpTime",SqlDbType.DateTime);
                para.Value = sys_Users.OpTime;
                parameters.Add(para);
                strSql.Append("OpTime=@OpTime,");
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
        public void Delete(Guid userID)
        {
            if (userID == null)
                throw new ArgumentException("根据主键,删除表(T_Sys_Users)中记录,主键(UserID)不能为空!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And UserID = @UserID ", "@UserID", userID));
            //建立SQL语句对象
            OperateObject operateObject = CreateDeleteObject(whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 根据主键删除(事务版)
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        public void Delete(Guid userID,IDbTransaction trans)
        {
            if (userID == null)
                throw new ArgumentException("根据主键,删除表(T_Sys_Users)中记录,主键(UserID)不能为空!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And UserID = @UserID ", "@UserID", userID));
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

            strSql.Append("DELETE FROM T_Sys_Users "); 
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
        public Sys_UsersInfo GetSys_UsersInfo(Guid userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,DepartmentID,UserName,RealName,Password,IsEffective,Sex,Tel,LastLoginTime,LastLoginIP,LoginTimes,OpName,OpTime from T_Sys_Users");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And UserID = @UserID");
            SqlParameter[] parameters = {

                                              //用户ID
                                                new SqlParameter("@UserID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = userID;//用户ID
            Sys_UsersInfo sys_Users=null;
            using (IDbConnection connect = GetConnection())
            {
                using (IDataReader dr = basicDataAccess.ExecuteReader(connect, CommandType.Text, strSql.ToString(), parameters))
                {
                    if (dr.Read())
                    {
                        sys_Users = CreateSys_UsersInfoByReader(dr);
                    }
                }
            }
            return sys_Users;
        }


        /// <summary>
        /// 根据主键得到一个实体
        /// </summary>
        /// <returns></returns>
        public Sys_UsersInfo GetSys_UsersInfo(Guid userID,IDbTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,DepartmentID,UserName,RealName,Password,IsEffective,Sex,Tel,LastLoginTime,LastLoginIP,LoginTimes,OpName,OpTime from T_Sys_Users");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And UserID = @UserID");
            SqlParameter[] parameters = {

                                              //用户ID
                                                new SqlParameter("@UserID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = userID;//用户ID
            Sys_UsersInfo sys_Users=null;
            using (IDataReader dr = basicDataAccess.ExecuteReader(trans, CommandType.Text, strSql.ToString(), parameters))
            {
                if (dr.Read())
                {
                    sys_Users = CreateSys_UsersInfoByReader(dr);
                }
            }
            return sys_Users;
        }

        #endregion

        #region  根据查询参数，得到LIST对象列表

        /// <summary>
        /// 根据查询参数，得到人员基本信息 LIST对象列表
        /// </summary>
        /// <param name="DataQuery">查询参数</param>
        /// <returns>List<></returns>
        public List<Sys_UsersInfo> GetSys_UsersList(IDataQuery dataQuery)
        {

            List<Sys_UsersInfo> returnList = new List<Sys_UsersInfo>();
            dataQuery.TableName = "T_Sys_Users";
            using (IDbConnection connection = GetConnection())
            {
                using (IDataReader dr = basicDataAccess.ExecuteReader(connection,CommandType.Text,dataQuery, dataQuery.WhereParameters))
                {
                    while (dr.Read())
                    {
                        returnList.Add(CreateSys_UsersInfoByReader(dr));
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
        /// 根据查询参数，得到人员基本信息 LIST对象列表
        /// </summary>
        /// <param name="DataQuery">查询参数</param>
        /// <returns>List<></returns>
        public List<Sys_UsersInfo> GetSys_UsersList(IDataQuery dataQuery,IDbTransaction trans)
        {

            List<Sys_UsersInfo> returnList = new List<Sys_UsersInfo>();
            dataQuery.TableName = "T_Sys_Users";
            using (IDataReader dr = basicDataAccess.ExecuteReader(trans,CommandType.Text,dataQuery, dataQuery.WhereParameters))
            {
                while (dr.Read())
                {
                    returnList.Add(CreateSys_UsersInfoByReader(dr));
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
        private Sys_UsersInfo CreateSys_UsersInfoByReader(IDataReader dr)
        {
            Sys_UsersInfo sys_Users = new Sys_UsersInfo();
            //用户ID
            if (!Convert.IsDBNull(dr["UserID"]))
                sys_Users.UserID = (Guid)(dr["UserID"]);
 
            //部门编号
            if (!Convert.IsDBNull(dr["DepartmentID"]))
                sys_Users.DepartmentID = (Guid)(dr["DepartmentID"]);
 
            //用户名
            if (!Convert.IsDBNull(dr["UserName"]))
                sys_Users.UserName = Convert.ToString(dr["UserName"]);
 
            //真实姓名
            if (!Convert.IsDBNull(dr["RealName"]))
                sys_Users.RealName = Convert.ToString(dr["RealName"]);
 
            //登陆密码
            if (!Convert.IsDBNull(dr["Password"]))
                sys_Users.Password = Convert.ToString(dr["Password"]);
 
            //是否有效(0:有效,1:禁用)
            if (!Convert.IsDBNull(dr["IsEffective"]))
                sys_Users.IsEffective = Convert.ToString(dr["IsEffective"]);
 
            //性别
            if (!Convert.IsDBNull(dr["Sex"]))
                sys_Users.Sex = Convert.ToString(dr["Sex"]);
 
            //联系电话
            if (!Convert.IsDBNull(dr["Tel"]))
                sys_Users.Tel = Convert.ToString(dr["Tel"]);
 
            //最后登录时间
            if (!Convert.IsDBNull(dr["LastLoginTime"]))
                sys_Users.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
 
            //最后登录IP
            if (!Convert.IsDBNull(dr["LastLoginIP"]))
                sys_Users.LastLoginIP = Convert.ToString(dr["LastLoginIP"]);
 
            //登录资数
            if (!Convert.IsDBNull(dr["LoginTimes"]))
                sys_Users.LoginTimes = Convert.ToInt32(dr["LoginTimes"]);
 
            //添加人
            if (!Convert.IsDBNull(dr["OpName"]))
                sys_Users.OpName = Convert.ToString(dr["OpName"]);
 
            //添加时间
            if (!Convert.IsDBNull(dr["OpTime"]))
                sys_Users.OpTime = Convert.ToDateTime(dr["OpTime"]);
 
            return sys_Users;
        }

        #endregion

        #endregion

        #region 判断是否己存在
        
        /// <summary> 
        /// 根据主键，判断对象是否己存在 
        /// </summary> 
        /// <returns></returns> 
        public bool IsExist(Guid userID)
        {
            Sys_UsersInfo sys_UsersInfo = GetSys_UsersInfo(userID);
            if (sys_UsersInfo == null)
                return false;
            else
                return true;
        }

        #endregion 

    }
} 
