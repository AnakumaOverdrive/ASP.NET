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
    /// 模块名称：代码表 数据访问层
    /// 作    者：刘伟通
    /// 生成日期：2012年09月09日
    /// 生成模板: Esint.Template.SqlDAL.SqlDAL_11 版
    /// 特别说明：本文件由代码生成工具自动生成，请勿轻易修改！
    /// </summary>
    public partial class Sys_CodeData  : BaseData, ISys_CodeData
    {
        #region 插入数据 

        /// <summary>
        /// 插入数据
        /// </summary>
        public void Insert(Sys_CodeInfo sys_Code)
        {
            //建立SQL语句对象
            OperateObject operateObject = CreateInsertObject(sys_Code);
            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 插入数据(事务版)
        /// </summary>
        public void Insert(Sys_CodeInfo sys_Code,IDbTransaction trans)
        {
            //建立SQL语句对象
            OperateObject operateObject = CreateInsertObject(sys_Code);
            base.ExecuteNonQuery(operateObject,trans);
        }

        #region 构建插入SQL语句 

        /// <summary>
        /// 构建插入SQL语句
        /// </summary>
        /// <param name="sys_Code"></param>
        /// <returns></returns>
        private OperateObject CreateInsertObject(Sys_CodeInfo sys_Code)
        {
             BasicDataAccess basicDataAccess = new BasicDataAccess();
            //建立插入的SQL语句,判断是否为空拼串
            StringBuilder         strSql     = new StringBuilder();
            List<IDataParameter> parameters = new List<IDataParameter>();
            SqlParameter para;
            strSql.Append("INSERT INTO T_Sys_Code (");

            if (sys_Code.Flag != null)
            {
                //代码类别
                para = new SqlParameter("@Flag",SqlDbType.Char,3);
                para.Value = sys_Code.Flag;
                parameters.Add(para);
                strSql.Append("FLAG,");
            }

            if (sys_Code.Code != null)
            {
                //代码
                para = new SqlParameter("@Code",SqlDbType.VarChar,30);
                para.Value = sys_Code.Code;
                parameters.Add(para);
                strSql.Append("CODE,");
            }

            if (sys_Code.Meaning != null)
            {
                //代码含义
                para = new SqlParameter("@Meaning",SqlDbType.VarChar,100);
                para.Value = sys_Code.Meaning;
                parameters.Add(para);
                strSql.Append("Meaning,");
            }

            if (sys_Code.Is_enable != null)
            {
                //是否有效(0 无效；1 有效)
                para = new SqlParameter("@Is_enable",SqlDbType.Char,1);
                para.Value = sys_Code.Is_enable;
                parameters.Add(para);
                strSql.Append("IS_ENABLE,");
            }

            if (sys_Code.Filter != null)
            {
                //过滤字段
                para = new SqlParameter("@Filter",SqlDbType.VarChar,10);
                para.Value = sys_Code.Filter;
                parameters.Add(para);
                strSql.Append("Filter,");
            }

            if (sys_Code.Code_order != null)
            {
                //排序字段
                para = new SqlParameter("@Code_order",SqlDbType.Int);
                para.Value = sys_Code.Code_order;
                parameters.Add(para);
                strSql.Append("CODE_ORDER,");
            }

            if (sys_Code.Remark != null)
            {
                //备注
                para = new SqlParameter("@Remark",SqlDbType.VarChar,300);
                para.Value = sys_Code.Remark;
                parameters.Add(para);
                strSql.Append("Remark,");
            }

            if (sys_Code.Parent_code != null)
            {
                //父代码
                para = new SqlParameter("@Parent_code",SqlDbType.VarChar,30);
                para.Value = sys_Code.Parent_code;
                parameters.Add(para);
                strSql.Append("PARENT_CODE,");
            }

            if (sys_Code.Spell_code != null)
            {
                //
                para = new SqlParameter("@Spell_code",SqlDbType.NChar,40);
                para.Value = sys_Code.Spell_code;
                parameters.Add(para);
                strSql.Append("SPELL_CODE,");
            }
             if (strSql.ToString().Substring(strSql.Length - 1, 1) == ",")
                 strSql.Remove(strSql.Length - 1,1);

            strSql.Append(") values (");
            if (sys_Code.Flag != null)
            {
                strSql.Append("@Flag,");
            }
            if (sys_Code.Code != null)
            {
                strSql.Append("@Code,");
            }
            if (sys_Code.Meaning != null)
            {
                strSql.Append("@Meaning,");
            }
            if (sys_Code.Is_enable != null)
            {
                strSql.Append("@Is_enable,");
            }
            if (sys_Code.Filter != null)
            {
                strSql.Append("@Filter,");
            }
            if (sys_Code.Code_order != null)
            {
                strSql.Append("@Code_order,");
            }
            if (sys_Code.Remark != null)
            {
                strSql.Append("@Remark,");
            }
            if (sys_Code.Parent_code != null)
            {
                strSql.Append("@Parent_code,");
            }
            if (sys_Code.Spell_code != null)
            {
                strSql.Append("@Spell_code,");
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
        public void Update(Sys_CodeInfo sys_Code)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (sys_Code.Flag == null)
                throw new ArgumentException("根据主键更新表(T_Sys_Code),主键(Flag)不能为空!");

            if (sys_Code.Code == null)
                throw new ArgumentException("根据主键更新表(T_Sys_Code),主键(Code)不能为空!");

            whereParaList.Add(new WhereParameter("And FLAG = @Flag", "@Flag", sys_Code.Flag));
            whereParaList.Add(new WhereParameter("And CODE = @Code", "@Code", sys_Code.Code));

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(sys_Code, whereParaList);

                base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 修改数据，根据主键修改数据(事务版)
        /// </summary>
        public void Update(Sys_CodeInfo sys_Code,IDbTransaction trans)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (sys_Code.Flag == null)
                throw new ArgumentException("根据主键更新表(T_Sys_Code),主键(Flag)不能为空!");

            if (sys_Code.Code == null)
                throw new ArgumentException("根据主键更新表(T_Sys_Code),主键(Code)不能为空!");

            whereParaList.Add(new WhereParameter("And FLAG = @Flag", "@Flag", sys_Code.Flag));
            whereParaList.Add(new WhereParameter("And CODE = @Code", "@Code", sys_Code.Code));

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(sys_Code, whereParaList);

            base.ExecuteNonQuery(operateObject,trans);
        }

        /// <summary>
        /// 修改数据，根据条件修改数据(非事务版)
        /// </summary>
        public void Update(Sys_CodeInfo sys_Code, List<IWhereParameter> whereParaList)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("根据条件更新,条件列表不能为空!");

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(sys_Code, whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 修改数据，根据条件修改数据(事务版)
        /// </summary>
        public void Update(Sys_CodeInfo sys_Code, List<IWhereParameter> whereParaList,IDbTransaction trans)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("根据条件更新,条件列表不能为空!");

            //建立SQL语句对象
            OperateObject operateObject = CreateUpdateObject(sys_Code, whereParaList);

                base.ExecuteNonQuery(operateObject,trans);
        }


        #region 构建更新SQL语句 

        /// <summary>
        /// 构建更新SQL语句
        /// </summary>
        /// <param name="sys_Code"></param>
        /// <returns></returns>
        private OperateObject CreateUpdateObject(Sys_CodeInfo sys_Code, List<IWhereParameter> whereList)
        {
            StringBuilder strSql = new StringBuilder();
            List<IDataParameter> parameters = new  List<IDataParameter>();
            SqlParameter para;
            strSql.Append("update T_Sys_Code set ");
             if (!string.IsNullOrEmpty(sys_Code.UpdateNullFields))
             {
                 foreach (string fieldsName in sys_Code.UpdateNullFields.Split(','))
                 {
                     strSql.Append(fieldsName + "=NULL,");
                 }
             }

            if(sys_Code.Meaning!=null)
            {
                //代码含义

                para =  new SqlParameter("@Meaning",SqlDbType.VarChar,100);
                para.Value = sys_Code.Meaning;
                parameters.Add(para);
                strSql.Append("Meaning=@Meaning,");
            }
            if(sys_Code.Is_enable!=null)
            {
                //是否有效(0 无效；1 有效)

                para =  new SqlParameter("@Is_enable",SqlDbType.Char,1);
                para.Value = sys_Code.Is_enable;
                parameters.Add(para);
                strSql.Append("IS_ENABLE=@Is_enable,");
            }
            if(sys_Code.Filter!=null)
            {
                //过滤字段

                para =  new SqlParameter("@Filter",SqlDbType.VarChar,10);
                para.Value = sys_Code.Filter;
                parameters.Add(para);
                strSql.Append("Filter=@Filter,");
            }
            if(sys_Code.Code_order!=null)
            {
                //排序字段

                para =  new SqlParameter("@Code_order",SqlDbType.Int);
                para.Value = sys_Code.Code_order;
                parameters.Add(para);
                strSql.Append("CODE_ORDER=@Code_order,");
            }
            if(sys_Code.Remark!=null)
            {
                //备注

                para =  new SqlParameter("@Remark",SqlDbType.VarChar,300);
                para.Value = sys_Code.Remark;
                parameters.Add(para);
                strSql.Append("Remark=@Remark,");
            }
            if(sys_Code.Parent_code!=null)
            {
                //父代码

                para =  new SqlParameter("@Parent_code",SqlDbType.VarChar,30);
                para.Value = sys_Code.Parent_code;
                parameters.Add(para);
                strSql.Append("PARENT_CODE=@Parent_code,");
            }
            if(sys_Code.Spell_code!=null)
            {
                //

                para =  new SqlParameter("@Spell_code",SqlDbType.NChar,40);
                para.Value = sys_Code.Spell_code;
                parameters.Add(para);
                strSql.Append("SPELL_CODE=@Spell_code,");
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
        public void Delete(string flag,string code)
        {
            if (flag == null)
                throw new ArgumentException("根据主键,删除表(T_Sys_Code)中记录,主键(Flag)不能为空!");
            if (code == null)
                throw new ArgumentException("根据主键,删除表(T_Sys_Code)中记录,主键(Code)不能为空!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And FLAG = @Flag ", "@Flag", flag));
            whereParaList.Add(new WhereParameter(" And CODE = @Code ", "@Code", code));
            //建立SQL语句对象
            OperateObject operateObject = CreateDeleteObject(whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// 根据主键删除(事务版)
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        public void Delete(string flag,string code,IDbTransaction trans)
        {
            if (flag == null)
                throw new ArgumentException("根据主键,删除表(T_Sys_Code)中记录,主键(Flag)不能为空!");
            if (code == null)
                throw new ArgumentException("根据主键,删除表(T_Sys_Code)中记录,主键(Code)不能为空!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And FLAG = @Flag ", "@Flag", flag));
            whereParaList.Add(new WhereParameter(" And CODE = @Code ", "@Code", code));
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

            strSql.Append("DELETE FROM T_Sys_Code "); 
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
        public Sys_CodeInfo GetSys_CodeInfo(string flag,string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FLAG,CODE,Meaning,IS_ENABLE,Filter,CODE_ORDER,Remark,PARENT_CODE,SPELL_CODE from T_Sys_Code");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And FLAG = @Flag");
            strSql.Append(" And CODE = @Code");
            SqlParameter[] parameters = {

                                              //代码类别
                                                new SqlParameter("@Flag",SqlDbType.Char,3),
                                              //代码
                                                new SqlParameter("@Code",SqlDbType.VarChar,30)
                                             };
            parameters[0].Value = flag;//代码类别
            parameters[1].Value = code;//代码
            Sys_CodeInfo sys_Code=null;
            using (IDbConnection connect = GetConnection())
            {
                using (IDataReader dr = basicDataAccess.ExecuteReader(connect, CommandType.Text, strSql.ToString(), parameters))
                {
                    if (dr.Read())
                    {
                        sys_Code = CreateSys_CodeInfoByReader(dr);
                    }
                }
            }
            return sys_Code;
        }


        /// <summary>
        /// 根据主键得到一个实体
        /// </summary>
        /// <returns></returns>
        public Sys_CodeInfo GetSys_CodeInfo(string flag,string code,IDbTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FLAG,CODE,Meaning,IS_ENABLE,Filter,CODE_ORDER,Remark,PARENT_CODE,SPELL_CODE from T_Sys_Code");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And Flag = @Flag");
            strSql.Append(" And Code = @Code");
            SqlParameter[] parameters = {

                                              //代码类别
                                                new SqlParameter("@Flag",SqlDbType.Char,3),
                                              //代码
                                                new SqlParameter("@Code",SqlDbType.VarChar,30)
                                             };
            parameters[0].Value = flag;//代码类别
            parameters[1].Value = code;//代码
            Sys_CodeInfo sys_Code=null;
            using (IDataReader dr = basicDataAccess.ExecuteReader(trans, CommandType.Text, strSql.ToString(), parameters))
            {
                if (dr.Read())
                {
                    sys_Code = CreateSys_CodeInfoByReader(dr);
                }
            }
            return sys_Code;
        }

        #endregion

        #region  根据查询参数，得到LIST对象列表

        /// <summary>
        /// 根据查询参数，得到代码表 LIST对象列表
        /// </summary>
        /// <param name="DataQuery">查询参数</param>
        /// <returns>List<></returns>
        public List<Sys_CodeInfo> GetSys_CodeList(IDataQuery dataQuery)
        {

            List<Sys_CodeInfo> returnList = new List<Sys_CodeInfo>();
            dataQuery.TableName = "T_Sys_Code";
            using (IDbConnection connection = GetConnection())
            {
                using (IDataReader dr = basicDataAccess.ExecuteReader(connection,CommandType.Text,dataQuery, dataQuery.WhereParameters))
                {
                    while (dr.Read())
                    {
                        returnList.Add(CreateSys_CodeInfoByReader(dr));
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
        /// 根据查询参数，得到代码表 LIST对象列表
        /// </summary>
        /// <param name="DataQuery">查询参数</param>
        /// <returns>List<></returns>
        public List<Sys_CodeInfo> GetSys_CodeList(IDataQuery dataQuery,IDbTransaction trans)
        {

            List<Sys_CodeInfo> returnList = new List<Sys_CodeInfo>();
            dataQuery.TableName = "T_Sys_Code";
            using (IDataReader dr = basicDataAccess.ExecuteReader(trans,CommandType.Text,dataQuery, dataQuery.WhereParameters))
            {
                while (dr.Read())
                {
                    returnList.Add(CreateSys_CodeInfoByReader(dr));
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
        private Sys_CodeInfo CreateSys_CodeInfoByReader(IDataReader dr)
        {
            Sys_CodeInfo sys_Code = new Sys_CodeInfo();
            //代码类别
            if (!Convert.IsDBNull(dr["FLAG"]))
                sys_Code.Flag = Convert.ToString(dr["FLAG"]);
 
            //代码
            if (!Convert.IsDBNull(dr["CODE"]))
                sys_Code.Code = Convert.ToString(dr["CODE"]);
 
            //代码含义
            if (!Convert.IsDBNull(dr["Meaning"]))
                sys_Code.Meaning = Convert.ToString(dr["Meaning"]);
 
            //是否有效(0 无效；1 有效)
            if (!Convert.IsDBNull(dr["IS_ENABLE"]))
                sys_Code.Is_enable = Convert.ToString(dr["IS_ENABLE"]);
 
            //过滤字段
            if (!Convert.IsDBNull(dr["Filter"]))
                sys_Code.Filter = Convert.ToString(dr["Filter"]);
 
            //排序字段
            if (!Convert.IsDBNull(dr["CODE_ORDER"]))
                sys_Code.Code_order = Convert.ToInt32(dr["CODE_ORDER"]);
 
            //备注
            if (!Convert.IsDBNull(dr["Remark"]))
                sys_Code.Remark = Convert.ToString(dr["Remark"]);
 
            //父代码
            if (!Convert.IsDBNull(dr["PARENT_CODE"]))
                sys_Code.Parent_code = Convert.ToString(dr["PARENT_CODE"]);
 
            //
            if (!Convert.IsDBNull(dr["SPELL_CODE"]))
                sys_Code.Spell_code = Convert.ToString(dr["SPELL_CODE"]);
 
            return sys_Code;
        }

        #endregion

        #endregion

        #region 判断是否己存在
        
        /// <summary> 
        /// 根据主键，判断对象是否己存在 
        /// </summary> 
        /// <returns></returns> 
        public bool IsExist(string flag,string code)
        {
            Sys_CodeInfo sys_CodeInfo = GetSys_CodeInfo(flag,code);
            if (sys_CodeInfo == null)
                return false;
            else
                return true;
        }

        #endregion 

    }
} 
