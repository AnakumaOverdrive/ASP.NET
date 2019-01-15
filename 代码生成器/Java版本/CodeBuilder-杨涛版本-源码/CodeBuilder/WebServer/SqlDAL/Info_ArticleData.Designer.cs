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
    /// ģ�����ƣ� ���ݷ��ʲ�
    /// ��    �ߣ���ΰͨ
    /// �������ڣ�2012��09��18��
    /// ����ģ��: Esint.Template.SqlDAL.SqlDAL_11 ��
    /// �ر�˵�������ļ��ɴ������ɹ����Զ����ɣ����������޸ģ�
    /// </summary>
    public partial class Info_ArticleData  : BaseData, IInfo_ArticleData
    {
        #region �������� 

        /// <summary>
        /// ��������
        /// </summary>
        public void Insert(Info_ArticleInfo info_Article)
        {
            //����SQL������
            OperateObject operateObject = CreateInsertObject(info_Article);
            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// ��������(�����)
        /// </summary>
        public void Insert(Info_ArticleInfo info_Article,IDbTransaction trans)
        {
            //����SQL������
            OperateObject operateObject = CreateInsertObject(info_Article);
            base.ExecuteNonQuery(operateObject,trans);
        }

        #region ��������SQL��� 

        /// <summary>
        /// ��������SQL���
        /// </summary>
        /// <param name="info_Article"></param>
        /// <returns></returns>
        private OperateObject CreateInsertObject(Info_ArticleInfo info_Article)
        {
             BasicDataAccess basicDataAccess = new BasicDataAccess();
            //���������SQL���,�ж��Ƿ�Ϊ��ƴ��
            StringBuilder         strSql     = new StringBuilder();
            List<IDataParameter> parameters = new List<IDataParameter>();
            SqlParameter para;
            strSql.Append("INSERT INTO T_Info_Article (");
            if(info_Article.AritcleID ==Guid.Empty)
                info_Article.AritcleID = Guid.NewGuid();

            if (info_Article.AritcleID != Guid.Empty)
            {
                //���±��
                para = new SqlParameter("@AritcleID",SqlDbType.UniqueIdentifier);
                para.Value = info_Article.AritcleID;
                parameters.Add(para);
                strSql.Append("AritcleID,");
            }

            if (info_Article.Title != null)
            {
                //����
                para = new SqlParameter("@Title",SqlDbType.NVarChar,1000);
                para.Value = info_Article.Title;
                parameters.Add(para);
                strSql.Append("Title,");
            }

            if (info_Article.Category != Guid.Empty)
            {
                //�����
                para = new SqlParameter("@Category",SqlDbType.UniqueIdentifier);
                para.Value = info_Article.Category;
                parameters.Add(para);
                strSql.Append("Category,");
            }

            if (info_Article.InfoBody != null)
            {
                //����
                para = new SqlParameter("@InfoBody",SqlDbType.Text);
                para.Value = info_Article.InfoBody;
                parameters.Add(para);
                strSql.Append("InfoBody,");
            }

            if (info_Article.OpName != null)
            {
                //�����
                para = new SqlParameter("@OpName",SqlDbType.NVarChar,100);
                para.Value = info_Article.OpName;
                parameters.Add(para);
                strSql.Append("OpName,");
            }

            if (info_Article.OPTime != null)
            {
                //���ʱ��
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
        public void Update(Info_ArticleInfo info_Article)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (info_Article.AritcleID == null)
                throw new ArgumentException("�����������±�(T_Info_Article),����(AritcleID)����Ϊ��!");

            whereParaList.Add(new WhereParameter("And AritcleID = @AritcleID", "@AritcleID", info_Article.AritcleID));

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(info_Article, whereParaList);

                base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�����)
        /// </summary>
        public void Update(Info_ArticleInfo info_Article,IDbTransaction trans)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (info_Article.AritcleID == null)
                throw new ArgumentException("�����������±�(T_Info_Article),����(AritcleID)����Ϊ��!");

            whereParaList.Add(new WhereParameter("And AritcleID = @AritcleID", "@AritcleID", info_Article.AritcleID));

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(info_Article, whereParaList);

            base.ExecuteNonQuery(operateObject,trans);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�������)
        /// </summary>
        public void Update(Info_ArticleInfo info_Article, List<IWhereParameter> whereParaList)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("������������,�����б���Ϊ��!");

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(info_Article, whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�����)
        /// </summary>
        public void Update(Info_ArticleInfo info_Article, List<IWhereParameter> whereParaList,IDbTransaction trans)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("������������,�����б���Ϊ��!");

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(info_Article, whereParaList);

                base.ExecuteNonQuery(operateObject,trans);
        }


        #region ��������SQL��� 

        /// <summary>
        /// ��������SQL���
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
                //����

                para =  new SqlParameter("@Title",SqlDbType.NVarChar,1000);
                para.Value = info_Article.Title;
                parameters.Add(para);
                strSql.Append("Title=@Title,");
            }
            if(info_Article.Category!=Guid.Empty)
            {
                //�����

                para =  new SqlParameter("@Category",SqlDbType.UniqueIdentifier);
                para.Value = info_Article.Category;
                parameters.Add(para);
                strSql.Append("Category=@Category,");
            }
            if(info_Article.InfoBody!=null)
            {
                //����

                para =  new SqlParameter("@InfoBody",SqlDbType.Text);
                para.Value = info_Article.InfoBody;
                parameters.Add(para);
                strSql.Append("InfoBody=@InfoBody,");
            }
            if(info_Article.OpName!=null)
            {
                //�����

                para =  new SqlParameter("@OpName",SqlDbType.NVarChar,100);
                para.Value = info_Article.OpName;
                parameters.Add(para);
                strSql.Append("OpName=@OpName,");
            }
            if(info_Article.OPTime!=null)
            {
                //���ʱ��

                para =  new SqlParameter("@OPTime",SqlDbType.DateTime);
                para.Value = info_Article.OPTime;
                parameters.Add(para);
                strSql.Append("OPTime=@OPTime,");
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
        public void Delete(Guid aritcleID)
        {
            if (aritcleID == null)
                throw new ArgumentException("��������,ɾ����(T_Info_Article)�м�¼,����(AritcleID)����Ϊ��!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And AritcleID = @AritcleID ", "@AritcleID", aritcleID));
            //����SQL������
            OperateObject operateObject = CreateDeleteObject(whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// ��������ɾ��(�����)
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        public void Delete(Guid aritcleID,IDbTransaction trans)
        {
            if (aritcleID == null)
                throw new ArgumentException("��������,ɾ����(T_Info_Article)�м�¼,����(AritcleID)����Ϊ��!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And AritcleID = @AritcleID ", "@AritcleID", aritcleID));
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

            strSql.Append("DELETE FROM T_Info_Article "); 
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
        public Info_ArticleInfo GetInfo_ArticleInfo(Guid aritcleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AritcleID,Title,Category,InfoBody,OpName,OPTime from T_Info_Article");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And AritcleID = @AritcleID");
            SqlParameter[] parameters = {

                                              //���±��
                                                new SqlParameter("@AritcleID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = aritcleID;//���±��
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
        /// ���������õ�һ��ʵ��
        /// </summary>
        /// <returns></returns>
        public Info_ArticleInfo GetInfo_ArticleInfo(Guid aritcleID,IDbTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AritcleID,Title,Category,InfoBody,OpName,OPTime from T_Info_Article");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And AritcleID = @AritcleID");
            SqlParameter[] parameters = {

                                              //���±��
                                                new SqlParameter("@AritcleID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = aritcleID;//���±��
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

        #region  ���ݲ�ѯ�������õ�LIST�����б�

        /// <summary>
        /// ���ݲ�ѯ�������õ� LIST�����б�
        /// </summary>
        /// <param name="DataQuery">��ѯ����</param>
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
        /// ���ݲ�ѯ�������õ� LIST�����б�
        /// </summary>
        /// <param name="DataQuery">��ѯ����</param>
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
        private Info_ArticleInfo CreateInfo_ArticleInfoByReader(IDataReader dr)
        {
            Info_ArticleInfo info_Article = new Info_ArticleInfo();
            //���±��
            if (!Convert.IsDBNull(dr["AritcleID"]))
                info_Article.AritcleID = (Guid)(dr["AritcleID"]);
 
            //����
            if (!Convert.IsDBNull(dr["Title"]))
                info_Article.Title = Convert.ToString(dr["Title"]);
 
            //�����
            if (!Convert.IsDBNull(dr["Category"]))
                info_Article.Category = (Guid)(dr["Category"]);
 
            //����
            if (!Convert.IsDBNull(dr["InfoBody"]))
                info_Article.InfoBody = Convert.ToString(dr["InfoBody"]);
 
            //�����
            if (!Convert.IsDBNull(dr["OpName"]))
                info_Article.OpName = Convert.ToString(dr["OpName"]);
 
            //���ʱ��
            if (!Convert.IsDBNull(dr["OPTime"]))
                info_Article.OPTime = Convert.ToDateTime(dr["OPTime"]);
 
            return info_Article;
        }

        #endregion

        #endregion

        #region �ж��Ƿ񼺴���
        
        /// <summary> 
        /// �����������ж϶����Ƿ񼺴��� 
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
