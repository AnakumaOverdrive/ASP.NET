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
    /// ģ�����ƣ������ ���ݷ��ʲ�
    /// ��    �ߣ���ΰͨ
    /// �������ڣ�2012��09��09��
    /// ����ģ��: Esint.Template.SqlDAL.SqlDAL_11 ��
    /// �ر�˵�������ļ��ɴ������ɹ����Զ����ɣ����������޸ģ�
    /// </summary>
    public partial class Sys_CodeData  : BaseData, ISys_CodeData
    {
        #region �������� 

        /// <summary>
        /// ��������
        /// </summary>
        public void Insert(Sys_CodeInfo sys_Code)
        {
            //����SQL������
            OperateObject operateObject = CreateInsertObject(sys_Code);
            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// ��������(�����)
        /// </summary>
        public void Insert(Sys_CodeInfo sys_Code,IDbTransaction trans)
        {
            //����SQL������
            OperateObject operateObject = CreateInsertObject(sys_Code);
            base.ExecuteNonQuery(operateObject,trans);
        }

        #region ��������SQL��� 

        /// <summary>
        /// ��������SQL���
        /// </summary>
        /// <param name="sys_Code"></param>
        /// <returns></returns>
        private OperateObject CreateInsertObject(Sys_CodeInfo sys_Code)
        {
             BasicDataAccess basicDataAccess = new BasicDataAccess();
            //���������SQL���,�ж��Ƿ�Ϊ��ƴ��
            StringBuilder         strSql     = new StringBuilder();
            List<IDataParameter> parameters = new List<IDataParameter>();
            SqlParameter para;
            strSql.Append("INSERT INTO T_Sys_Code (");

            if (sys_Code.Flag != null)
            {
                //�������
                para = new SqlParameter("@Flag",SqlDbType.Char,3);
                para.Value = sys_Code.Flag;
                parameters.Add(para);
                strSql.Append("FLAG,");
            }

            if (sys_Code.Code != null)
            {
                //����
                para = new SqlParameter("@Code",SqlDbType.VarChar,30);
                para.Value = sys_Code.Code;
                parameters.Add(para);
                strSql.Append("CODE,");
            }

            if (sys_Code.Meaning != null)
            {
                //���뺬��
                para = new SqlParameter("@Meaning",SqlDbType.VarChar,100);
                para.Value = sys_Code.Meaning;
                parameters.Add(para);
                strSql.Append("Meaning,");
            }

            if (sys_Code.Is_enable != null)
            {
                //�Ƿ���Ч(0 ��Ч��1 ��Ч)
                para = new SqlParameter("@Is_enable",SqlDbType.Char,1);
                para.Value = sys_Code.Is_enable;
                parameters.Add(para);
                strSql.Append("IS_ENABLE,");
            }

            if (sys_Code.Filter != null)
            {
                //�����ֶ�
                para = new SqlParameter("@Filter",SqlDbType.VarChar,10);
                para.Value = sys_Code.Filter;
                parameters.Add(para);
                strSql.Append("Filter,");
            }

            if (sys_Code.Code_order != null)
            {
                //�����ֶ�
                para = new SqlParameter("@Code_order",SqlDbType.Int);
                para.Value = sys_Code.Code_order;
                parameters.Add(para);
                strSql.Append("CODE_ORDER,");
            }

            if (sys_Code.Remark != null)
            {
                //��ע
                para = new SqlParameter("@Remark",SqlDbType.VarChar,300);
                para.Value = sys_Code.Remark;
                parameters.Add(para);
                strSql.Append("Remark,");
            }

            if (sys_Code.Parent_code != null)
            {
                //������
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

             //������־����
             OperateObject operObj = new OperateObject();
             operObj.Parameters = parameters;
             operObj.SqlText = strSql.ToString();
             
             return operObj;
        }

        #endregion

        #endregion

        #region �޸����ݷ�����

        /// <summary>
        /// �޸����ݣ����������޸�����
        /// </summary>
        public void Update(Sys_CodeInfo sys_Code)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (sys_Code.Flag == null)
                throw new ArgumentException("�����������±�(T_Sys_Code),����(Flag)����Ϊ��!");

            if (sys_Code.Code == null)
                throw new ArgumentException("�����������±�(T_Sys_Code),����(Code)����Ϊ��!");

            whereParaList.Add(new WhereParameter("And FLAG = @Flag", "@Flag", sys_Code.Flag));
            whereParaList.Add(new WhereParameter("And CODE = @Code", "@Code", sys_Code.Code));

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(sys_Code, whereParaList);

                base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�����)
        /// </summary>
        public void Update(Sys_CodeInfo sys_Code,IDbTransaction trans)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (sys_Code.Flag == null)
                throw new ArgumentException("�����������±�(T_Sys_Code),����(Flag)����Ϊ��!");

            if (sys_Code.Code == null)
                throw new ArgumentException("�����������±�(T_Sys_Code),����(Code)����Ϊ��!");

            whereParaList.Add(new WhereParameter("And FLAG = @Flag", "@Flag", sys_Code.Flag));
            whereParaList.Add(new WhereParameter("And CODE = @Code", "@Code", sys_Code.Code));

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(sys_Code, whereParaList);

            base.ExecuteNonQuery(operateObject,trans);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�������)
        /// </summary>
        public void Update(Sys_CodeInfo sys_Code, List<IWhereParameter> whereParaList)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("������������,�����б���Ϊ��!");

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(sys_Code, whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�����)
        /// </summary>
        public void Update(Sys_CodeInfo sys_Code, List<IWhereParameter> whereParaList,IDbTransaction trans)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("������������,�����б���Ϊ��!");

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(sys_Code, whereParaList);

                base.ExecuteNonQuery(operateObject,trans);
        }


        #region ��������SQL��� 

        /// <summary>
        /// ��������SQL���
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
                //���뺬��

                para =  new SqlParameter("@Meaning",SqlDbType.VarChar,100);
                para.Value = sys_Code.Meaning;
                parameters.Add(para);
                strSql.Append("Meaning=@Meaning,");
            }
            if(sys_Code.Is_enable!=null)
            {
                //�Ƿ���Ч(0 ��Ч��1 ��Ч)

                para =  new SqlParameter("@Is_enable",SqlDbType.Char,1);
                para.Value = sys_Code.Is_enable;
                parameters.Add(para);
                strSql.Append("IS_ENABLE=@Is_enable,");
            }
            if(sys_Code.Filter!=null)
            {
                //�����ֶ�

                para =  new SqlParameter("@Filter",SqlDbType.VarChar,10);
                para.Value = sys_Code.Filter;
                parameters.Add(para);
                strSql.Append("Filter=@Filter,");
            }
            if(sys_Code.Code_order!=null)
            {
                //�����ֶ�

                para =  new SqlParameter("@Code_order",SqlDbType.Int);
                para.Value = sys_Code.Code_order;
                parameters.Add(para);
                strSql.Append("CODE_ORDER=@Code_order,");
            }
            if(sys_Code.Remark!=null)
            {
                //��ע

                para =  new SqlParameter("@Remark",SqlDbType.VarChar,300);
                para.Value = sys_Code.Remark;
                parameters.Add(para);
                strSql.Append("Remark=@Remark,");
            }
            if(sys_Code.Parent_code!=null)
            {
                //������

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
             
             // ���������Ϊ��,������������и���
             foreach (IWhereParameter wherePara in whereList)
             {
                 strSql.Append(" " + wherePara.WhereExpression);
                 parameters.Add(new SqlParameter(wherePara.ParameterName, wherePara.Value));
             }
             
             //������־����
              OperateObject operObj = new OperateObject();
             operObj.Parameters = parameters;
             operObj.SqlText = strSql.ToString();
              //�������ض���
             return operObj;
        }

        #endregion

        #endregion

        #region ɾ��������

        /// <summary>
        /// ��������ɾ��
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        public void Delete(string flag,string code)
        {
            if (flag == null)
                throw new ArgumentException("��������,ɾ����(T_Sys_Code)�м�¼,����(Flag)����Ϊ��!");
            if (code == null)
                throw new ArgumentException("��������,ɾ����(T_Sys_Code)�м�¼,����(Code)����Ϊ��!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And FLAG = @Flag ", "@Flag", flag));
            whereParaList.Add(new WhereParameter(" And CODE = @Code ", "@Code", code));
            //����SQL������
            OperateObject operateObject = CreateDeleteObject(whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// ��������ɾ��(�����)
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        public void Delete(string flag,string code,IDbTransaction trans)
        {
            if (flag == null)
                throw new ArgumentException("��������,ɾ����(T_Sys_Code)�м�¼,����(Flag)����Ϊ��!");
            if (code == null)
                throw new ArgumentException("��������,ɾ����(T_Sys_Code)�м�¼,����(Code)����Ϊ��!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And FLAG = @Flag ", "@Flag", flag));
            whereParaList.Add(new WhereParameter(" And CODE = @Code ", "@Code", code));
            //����SQL������
            OperateObject operateObject = CreateDeleteObject(whereParaList);
            base.ExecuteNonQuery(operateObject,trans);
        }

        /// <summary>
        /// ��������ɾ�����ݣ�
        /// </summary>
        public void Delete(List<IWhereParameter> whereParaList)
        {
            //����SQL������
            OperateObject operateObject = CreateDeleteObject(whereParaList);
            base.ExecuteNonQuery(operateObject);
        }
        /// <summary>
        /// ��������ɾ�����ݣ�
        /// </summary>
        public void Delete(List<IWhereParameter> whereParaList,IDbTransaction trans)
        {
           //����SQL������
            OperateObject operateObject = CreateDeleteObject(whereParaList);
            base.ExecuteNonQuery(operateObject,trans);
        }


        #region ����ɾ��SQL���� 
        
        /// <summary>  
        /// ����ɾ��SQL����  
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

            //������־����  
            OperateObject opereObj = new OperateObject(); 
            opereObj.SqlText = strSql.ToString(); 
            opereObj.Parameters = parameters; 

            //�������ض���  
            return opereObj; 
        } 

        #endregion 

        #endregion

        #region ����������ѯ�õ�ʵ��

        /// <summary>
        /// ���������õ�һ��ʵ��
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

                                              //�������
                                                new SqlParameter("@Flag",SqlDbType.Char,3),
                                              //����
                                                new SqlParameter("@Code",SqlDbType.VarChar,30)
                                             };
            parameters[0].Value = flag;//�������
            parameters[1].Value = code;//����
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
        /// ���������õ�һ��ʵ��
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

                                              //�������
                                                new SqlParameter("@Flag",SqlDbType.Char,3),
                                              //����
                                                new SqlParameter("@Code",SqlDbType.VarChar,30)
                                             };
            parameters[0].Value = flag;//�������
            parameters[1].Value = code;//����
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

        #region  ���ݲ�ѯ�������õ�LIST�����б�

        /// <summary>
        /// ���ݲ�ѯ�������õ������ LIST�����б�
        /// </summary>
        /// <param name="DataQuery">��ѯ����</param>
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
                //��ȡ��¼��(Reading RecordCount)
                if (dataQuery.PageView.IsPageView)
                {
                    dataQuery.PageView.RecordCount = basicDataAccess.GetRecordCount(connection,CommandType.Text, dataQuery, dataQuery.WhereParameters);
                    dataQuery.PageView.PageCount = Convert.ToInt32(dataQuery.PageView.RecordCount / dataQuery.PageView.PageSize) + 1;
                }
            }
            return returnList;
        }

        /// <summary>
        /// ���ݲ�ѯ�������õ������ LIST�����б�
        /// </summary>
        /// <param name="DataQuery">��ѯ����</param>
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
            //��ȡ��¼��(Reading RecordCount)
            if (dataQuery.PageView.IsPageView)
            {
                dataQuery.PageView.RecordCount = basicDataAccess.GetRecordCount(trans,CommandType.Text, dataQuery, dataQuery.WhereParameters);
                dataQuery.PageView.PageCount = Convert.ToInt32(dataQuery.PageView.RecordCount / dataQuery.PageView.PageSize) + 1;
            }
            return returnList;
        }


        #region ��������ʵ��
        /// <summary>
        /// ��������ʵ��
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private Sys_CodeInfo CreateSys_CodeInfoByReader(IDataReader dr)
        {
            Sys_CodeInfo sys_Code = new Sys_CodeInfo();
            //�������
            if (!Convert.IsDBNull(dr["FLAG"]))
                sys_Code.Flag = Convert.ToString(dr["FLAG"]);
 
            //����
            if (!Convert.IsDBNull(dr["CODE"]))
                sys_Code.Code = Convert.ToString(dr["CODE"]);
 
            //���뺬��
            if (!Convert.IsDBNull(dr["Meaning"]))
                sys_Code.Meaning = Convert.ToString(dr["Meaning"]);
 
            //�Ƿ���Ч(0 ��Ч��1 ��Ч)
            if (!Convert.IsDBNull(dr["IS_ENABLE"]))
                sys_Code.Is_enable = Convert.ToString(dr["IS_ENABLE"]);
 
            //�����ֶ�
            if (!Convert.IsDBNull(dr["Filter"]))
                sys_Code.Filter = Convert.ToString(dr["Filter"]);
 
            //�����ֶ�
            if (!Convert.IsDBNull(dr["CODE_ORDER"]))
                sys_Code.Code_order = Convert.ToInt32(dr["CODE_ORDER"]);
 
            //��ע
            if (!Convert.IsDBNull(dr["Remark"]))
                sys_Code.Remark = Convert.ToString(dr["Remark"]);
 
            //������
            if (!Convert.IsDBNull(dr["PARENT_CODE"]))
                sys_Code.Parent_code = Convert.ToString(dr["PARENT_CODE"]);
 
            //
            if (!Convert.IsDBNull(dr["SPELL_CODE"]))
                sys_Code.Spell_code = Convert.ToString(dr["SPELL_CODE"]);
 
            return sys_Code;
        }

        #endregion

        #endregion

        #region �ж��Ƿ񼺴���
        
        /// <summary> 
        /// �����������ж϶����Ƿ񼺴��� 
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
