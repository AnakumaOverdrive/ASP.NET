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
    /// �������ڣ�2012��09��17��
    /// ����ģ��: Esint.Template.SqlDAL.SqlDAL_11 ��
    /// �ر�˵�������ļ��ɴ������ɹ����Զ����ɣ����������޸ģ�
    /// </summary>
    public partial class Info_CategoryData  : BaseData, IInfo_CategoryData
    {
        #region �������� 

        /// <summary>
        /// ��������
        /// </summary>
        public void Insert(Info_CategoryInfo info_Category)
        {
            //����SQL������
            OperateObject operateObject = CreateInsertObject(info_Category);
            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// ��������(�����)
        /// </summary>
        public void Insert(Info_CategoryInfo info_Category,IDbTransaction trans)
        {
            //����SQL������
            OperateObject operateObject = CreateInsertObject(info_Category);
            base.ExecuteNonQuery(operateObject,trans);
        }

        #region ��������SQL��� 

        /// <summary>
        /// ��������SQL���
        /// </summary>
        /// <param name="info_Category"></param>
        /// <returns></returns>
        private OperateObject CreateInsertObject(Info_CategoryInfo info_Category)
        {
             BasicDataAccess basicDataAccess = new BasicDataAccess();
            //���������SQL���,�ж��Ƿ�Ϊ��ƴ��
            StringBuilder         strSql     = new StringBuilder();
            List<IDataParameter> parameters = new List<IDataParameter>();
            SqlParameter para;
            strSql.Append("INSERT INTO T_Info_Category (");
            if(info_Category.CategoryID ==Guid.Empty)
                info_Category.CategoryID = Guid.NewGuid();

            if (info_Category.CategoryID != Guid.Empty)
            {
                //�����
                para = new SqlParameter("@CategoryID",SqlDbType.UniqueIdentifier);
                para.Value = info_Category.CategoryID;
                parameters.Add(para);
                strSql.Append("CategoryID,");
            }

            if (info_Category.CategoryName != null)
            {
                //�������
                para = new SqlParameter("@CategoryName",SqlDbType.NVarChar,200);
                para.Value = info_Category.CategoryName;
                parameters.Add(para);
                strSql.Append("CategoryName,");
            }

            if (info_Category.CategoryType != null)
            {
                //����(1������2 ˽��)
                para = new SqlParameter("@CategoryType",SqlDbType.Char,1);
                para.Value = info_Category.CategoryType;
                parameters.Add(para);
                strSql.Append("CategoryType,");
            }

            if (info_Category.ParentCategory != Guid.Empty)
            {
                //�������
                para = new SqlParameter("@ParentCategory",SqlDbType.UniqueIdentifier);
                para.Value = info_Category.ParentCategory;
                parameters.Add(para);
                strSql.Append("ParentCategory,");
            }

            if (info_Category.UserID != Guid.Empty)
            {
                //�û����
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
        public void Update(Info_CategoryInfo info_Category)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (info_Category.CategoryID == null)
                throw new ArgumentException("�����������±�(T_Info_Category),����(CategoryID)����Ϊ��!");

            whereParaList.Add(new WhereParameter("And CategoryID = @CategoryID", "@CategoryID", info_Category.CategoryID));

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(info_Category, whereParaList);

                base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�����)
        /// </summary>
        public void Update(Info_CategoryInfo info_Category,IDbTransaction trans)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (info_Category.CategoryID == null)
                throw new ArgumentException("�����������±�(T_Info_Category),����(CategoryID)����Ϊ��!");

            whereParaList.Add(new WhereParameter("And CategoryID = @CategoryID", "@CategoryID", info_Category.CategoryID));

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(info_Category, whereParaList);

            base.ExecuteNonQuery(operateObject,trans);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�������)
        /// </summary>
        public void Update(Info_CategoryInfo info_Category, List<IWhereParameter> whereParaList)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("������������,�����б���Ϊ��!");

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(info_Category, whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�����)
        /// </summary>
        public void Update(Info_CategoryInfo info_Category, List<IWhereParameter> whereParaList,IDbTransaction trans)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("������������,�����б���Ϊ��!");

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(info_Category, whereParaList);

                base.ExecuteNonQuery(operateObject,trans);
        }


        #region ��������SQL��� 

        /// <summary>
        /// ��������SQL���
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
                //�������

                para =  new SqlParameter("@CategoryName",SqlDbType.NVarChar,200);
                para.Value = info_Category.CategoryName;
                parameters.Add(para);
                strSql.Append("CategoryName=@CategoryName,");
            }
            if(info_Category.CategoryType!=null)
            {
                //����(1������2 ˽��)

                para =  new SqlParameter("@CategoryType",SqlDbType.Char,1);
                para.Value = info_Category.CategoryType;
                parameters.Add(para);
                strSql.Append("CategoryType=@CategoryType,");
            }
            if(info_Category.ParentCategory!=Guid.Empty)
            {
                //�������

                para =  new SqlParameter("@ParentCategory",SqlDbType.UniqueIdentifier);
                para.Value = info_Category.ParentCategory;
                parameters.Add(para);
                strSql.Append("ParentCategory=@ParentCategory,");
            }
            if(info_Category.UserID!=Guid.Empty)
            {
                //�û����

                para =  new SqlParameter("@UserID",SqlDbType.UniqueIdentifier);
                para.Value = info_Category.UserID;
                parameters.Add(para);
                strSql.Append("UserID=@UserID,");
            }
            if(info_Category.OrderNum!=null)
            {
                //�����

                para =  new SqlParameter("@OrderNum",SqlDbType.Int);
                para.Value = info_Category.OrderNum;
                parameters.Add(para);
                strSql.Append("OrderNum=@OrderNum,");
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
        public void Delete(Guid categoryID)
        {
            if (categoryID == null)
                throw new ArgumentException("��������,ɾ����(T_Info_Category)�м�¼,����(CategoryID)����Ϊ��!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And CategoryID = @CategoryID ", "@CategoryID", categoryID));
            //����SQL������
            OperateObject operateObject = CreateDeleteObject(whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// ��������ɾ��(�����)
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        public void Delete(Guid categoryID,IDbTransaction trans)
        {
            if (categoryID == null)
                throw new ArgumentException("��������,ɾ����(T_Info_Category)�м�¼,����(CategoryID)����Ϊ��!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And CategoryID = @CategoryID ", "@CategoryID", categoryID));
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

            strSql.Append("DELETE FROM T_Info_Category "); 
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
        public Info_CategoryInfo GetInfo_CategoryInfo(Guid categoryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CategoryID,CategoryName,CategoryType,ParentCategory,UserID,OrderNum from T_Info_Category");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And CategoryID = @CategoryID");
            SqlParameter[] parameters = {

                                              //�����
                                                new SqlParameter("@CategoryID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = categoryID;//�����
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
        /// ���������õ�һ��ʵ��
        /// </summary>
        /// <returns></returns>
        public Info_CategoryInfo GetInfo_CategoryInfo(Guid categoryID,IDbTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CategoryID,CategoryName,CategoryType,ParentCategory,UserID,OrderNum from T_Info_Category");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And CategoryID = @CategoryID");
            SqlParameter[] parameters = {

                                              //�����
                                                new SqlParameter("@CategoryID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = categoryID;//�����
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

        #region  ���ݲ�ѯ�������õ�LIST�����б�

        /// <summary>
        /// ���ݲ�ѯ�������õ� LIST�����б�
        /// </summary>
        /// <param name="DataQuery">��ѯ����</param>
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
        private Info_CategoryInfo CreateInfo_CategoryInfoByReader(IDataReader dr)
        {
            Info_CategoryInfo info_Category = new Info_CategoryInfo();
            //�����
            if (!Convert.IsDBNull(dr["CategoryID"]))
                info_Category.CategoryID = (Guid)(dr["CategoryID"]);
 
            //�������
            if (!Convert.IsDBNull(dr["CategoryName"]))
                info_Category.CategoryName = Convert.ToString(dr["CategoryName"]);
 
            //����(1������2 ˽��)
            if (!Convert.IsDBNull(dr["CategoryType"]))
                info_Category.CategoryType = Convert.ToString(dr["CategoryType"]);
 
            //�������
            if (!Convert.IsDBNull(dr["ParentCategory"]))
                info_Category.ParentCategory = (Guid)(dr["ParentCategory"]);
 
            //�û����
            if (!Convert.IsDBNull(dr["UserID"]))
                info_Category.UserID = (Guid)(dr["UserID"]);
 
            //�����
            if (!Convert.IsDBNull(dr["OrderNum"]))
                info_Category.OrderNum = Convert.ToInt32(dr["OrderNum"]);
 
            return info_Category;
        }

        #endregion

        #endregion

        #region �ж��Ƿ񼺴���
        
        /// <summary> 
        /// �����������ж϶����Ƿ񼺴��� 
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
