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
    /// ģ�����ƣ���Ա������Ϣ ���ݷ��ʲ�
    /// ��    �ߣ���ΰͨ
    /// �������ڣ�2012��09��14��
    /// ����ģ��: Esint.Template.SqlDAL.SqlDAL_11 ��
    /// �ر�˵�������ļ��ɴ������ɹ����Զ����ɣ����������޸ģ�
    /// </summary>
    public partial class Sys_UsersData  : BaseData, ISys_UsersData
    {
        #region �������� 

        /// <summary>
        /// ��������
        /// </summary>
        public void Insert(Sys_UsersInfo sys_Users)
        {
            //����SQL������
            OperateObject operateObject = CreateInsertObject(sys_Users);
            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// ��������(�����)
        /// </summary>
        public void Insert(Sys_UsersInfo sys_Users,IDbTransaction trans)
        {
            //����SQL������
            OperateObject operateObject = CreateInsertObject(sys_Users);
            base.ExecuteNonQuery(operateObject,trans);
        }

        #region ��������SQL��� 

        /// <summary>
        /// ��������SQL���
        /// </summary>
        /// <param name="sys_Users"></param>
        /// <returns></returns>
        private OperateObject CreateInsertObject(Sys_UsersInfo sys_Users)
        {
             BasicDataAccess basicDataAccess = new BasicDataAccess();
            //���������SQL���,�ж��Ƿ�Ϊ��ƴ��
            StringBuilder         strSql     = new StringBuilder();
            List<IDataParameter> parameters = new List<IDataParameter>();
            SqlParameter para;
            strSql.Append("INSERT INTO T_Sys_Users (");
            if(sys_Users.UserID ==Guid.Empty)
                sys_Users.UserID = Guid.NewGuid();

            if (sys_Users.UserID != Guid.Empty)
            {
                //�û�ID
                para = new SqlParameter("@UserID",SqlDbType.UniqueIdentifier);
                para.Value = sys_Users.UserID;
                parameters.Add(para);
                strSql.Append("UserID,");
            }

            if (sys_Users.DepartmentID != Guid.Empty)
            {
                //���ű��
                para = new SqlParameter("@DepartmentID",SqlDbType.UniqueIdentifier);
                para.Value = sys_Users.DepartmentID;
                parameters.Add(para);
                strSql.Append("DepartmentID,");
            }

            if (sys_Users.UserName != null)
            {
                //�û���
                para = new SqlParameter("@UserName",SqlDbType.VarChar,20);
                para.Value = sys_Users.UserName;
                parameters.Add(para);
                strSql.Append("UserName,");
            }

            if (sys_Users.RealName != null)
            {
                //��ʵ����
                para = new SqlParameter("@RealName",SqlDbType.NVarChar,40);
                para.Value = sys_Users.RealName;
                parameters.Add(para);
                strSql.Append("RealName,");
            }

            if (sys_Users.Password != null)
            {
                //��½����
                para = new SqlParameter("@Password",SqlDbType.VarChar,50);
                para.Value = sys_Users.Password;
                parameters.Add(para);
                strSql.Append("Password,");
            }

            if (sys_Users.IsEffective != null)
            {
                //�Ƿ���Ч(0:��Ч,1:����)
                para = new SqlParameter("@IsEffective",SqlDbType.Char,1);
                para.Value = sys_Users.IsEffective;
                parameters.Add(para);
                strSql.Append("IsEffective,");
            }

            if (sys_Users.Sex != null)
            {
                //�Ա�
                para = new SqlParameter("@Sex",SqlDbType.Char,1);
                para.Value = sys_Users.Sex;
                parameters.Add(para);
                strSql.Append("Sex,");
            }

            if (sys_Users.Tel != null)
            {
                //��ϵ�绰
                para = new SqlParameter("@Tel",SqlDbType.NVarChar,40);
                para.Value = sys_Users.Tel;
                parameters.Add(para);
                strSql.Append("Tel,");
            }

            if (sys_Users.LastLoginTime != null)
            {
                //����¼ʱ��
                para = new SqlParameter("@LastLoginTime",SqlDbType.DateTime);
                para.Value = sys_Users.LastLoginTime;
                parameters.Add(para);
                strSql.Append("LastLoginTime,");
            }

            if (sys_Users.LastLoginIP != null)
            {
                //����¼IP
                para = new SqlParameter("@LastLoginIP",SqlDbType.VarChar,20);
                para.Value = sys_Users.LastLoginIP;
                parameters.Add(para);
                strSql.Append("LastLoginIP,");
            }

            if (sys_Users.LoginTimes != null)
            {
                //��¼����
                para = new SqlParameter("@LoginTimes",SqlDbType.Int);
                para.Value = sys_Users.LoginTimes;
                parameters.Add(para);
                strSql.Append("LoginTimes,");
            }

            if (sys_Users.OpName != null)
            {
                //�����
                para = new SqlParameter("@OpName",SqlDbType.NVarChar,40);
                para.Value = sys_Users.OpName;
                parameters.Add(para);
                strSql.Append("OpName,");
            }

            if (sys_Users.OpTime != null)
            {
                //���ʱ��
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
        public void Update(Sys_UsersInfo sys_Users)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (sys_Users.UserID == null)
                throw new ArgumentException("�����������±�(T_Sys_Users),����(UserID)����Ϊ��!");

            whereParaList.Add(new WhereParameter("And UserID = @UserID", "@UserID", sys_Users.UserID));

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(sys_Users, whereParaList);

                base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�����)
        /// </summary>
        public void Update(Sys_UsersInfo sys_Users,IDbTransaction trans)
        {
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();

            if (sys_Users.UserID == null)
                throw new ArgumentException("�����������±�(T_Sys_Users),����(UserID)����Ϊ��!");

            whereParaList.Add(new WhereParameter("And UserID = @UserID", "@UserID", sys_Users.UserID));

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(sys_Users, whereParaList);

            base.ExecuteNonQuery(operateObject,trans);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�������)
        /// </summary>
        public void Update(Sys_UsersInfo sys_Users, List<IWhereParameter> whereParaList)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("������������,�����б���Ϊ��!");

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(sys_Users, whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// �޸����ݣ����������޸�����(�����)
        /// </summary>
        public void Update(Sys_UsersInfo sys_Users, List<IWhereParameter> whereParaList,IDbTransaction trans)
        {
            if (whereParaList == null || whereParaList.Count == 0)
                throw new ArgumentException("������������,�����б���Ϊ��!");

            //����SQL������
            OperateObject operateObject = CreateUpdateObject(sys_Users, whereParaList);

                base.ExecuteNonQuery(operateObject,trans);
        }


        #region ��������SQL��� 

        /// <summary>
        /// ��������SQL���
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
                //���ű��

                para =  new SqlParameter("@DepartmentID",SqlDbType.UniqueIdentifier);
                para.Value = sys_Users.DepartmentID;
                parameters.Add(para);
                strSql.Append("DepartmentID=@DepartmentID,");
            }
            if(sys_Users.UserName!=null)
            {
                //�û���

                para =  new SqlParameter("@UserName",SqlDbType.VarChar,20);
                para.Value = sys_Users.UserName;
                parameters.Add(para);
                strSql.Append("UserName=@UserName,");
            }
            if(sys_Users.RealName!=null)
            {
                //��ʵ����

                para =  new SqlParameter("@RealName",SqlDbType.NVarChar,40);
                para.Value = sys_Users.RealName;
                parameters.Add(para);
                strSql.Append("RealName=@RealName,");
            }
            if(sys_Users.Password!=null)
            {
                //��½����

                para =  new SqlParameter("@Password",SqlDbType.VarChar,50);
                para.Value = sys_Users.Password;
                parameters.Add(para);
                strSql.Append("Password=@Password,");
            }
            if(sys_Users.IsEffective!=null)
            {
                //�Ƿ���Ч(0:��Ч,1:����)

                para =  new SqlParameter("@IsEffective",SqlDbType.Char,1);
                para.Value = sys_Users.IsEffective;
                parameters.Add(para);
                strSql.Append("IsEffective=@IsEffective,");
            }
            if(sys_Users.Sex!=null)
            {
                //�Ա�

                para =  new SqlParameter("@Sex",SqlDbType.Char,1);
                para.Value = sys_Users.Sex;
                parameters.Add(para);
                strSql.Append("Sex=@Sex,");
            }
            if(sys_Users.Tel!=null)
            {
                //��ϵ�绰

                para =  new SqlParameter("@Tel",SqlDbType.NVarChar,40);
                para.Value = sys_Users.Tel;
                parameters.Add(para);
                strSql.Append("Tel=@Tel,");
            }
            if(sys_Users.LastLoginTime!=null)
            {
                //����¼ʱ��

                para =  new SqlParameter("@LastLoginTime",SqlDbType.DateTime);
                para.Value = sys_Users.LastLoginTime;
                parameters.Add(para);
                strSql.Append("LastLoginTime=@LastLoginTime,");
            }
            if(sys_Users.LastLoginIP!=null)
            {
                //����¼IP

                para =  new SqlParameter("@LastLoginIP",SqlDbType.VarChar,20);
                para.Value = sys_Users.LastLoginIP;
                parameters.Add(para);
                strSql.Append("LastLoginIP=@LastLoginIP,");
            }
            if(sys_Users.LoginTimes!=null)
            {
                //��¼����

                para =  new SqlParameter("@LoginTimes",SqlDbType.Int);
                para.Value = sys_Users.LoginTimes;
                parameters.Add(para);
                strSql.Append("LoginTimes=@LoginTimes,");
            }
            if(sys_Users.OpName!=null)
            {
                //�����

                para =  new SqlParameter("@OpName",SqlDbType.NVarChar,40);
                para.Value = sys_Users.OpName;
                parameters.Add(para);
                strSql.Append("OpName=@OpName,");
            }
            if(sys_Users.OpTime!=null)
            {
                //���ʱ��

                para =  new SqlParameter("@OpTime",SqlDbType.DateTime);
                para.Value = sys_Users.OpTime;
                parameters.Add(para);
                strSql.Append("OpTime=@OpTime,");
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
        public void Delete(Guid userID)
        {
            if (userID == null)
                throw new ArgumentException("��������,ɾ����(T_Sys_Users)�м�¼,����(UserID)����Ϊ��!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And UserID = @UserID ", "@UserID", userID));
            //����SQL������
            OperateObject operateObject = CreateDeleteObject(whereParaList);

            base.ExecuteNonQuery(operateObject);
        }

        /// <summary>
        /// ��������ɾ��(�����)
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="code"></param>
        public void Delete(Guid userID,IDbTransaction trans)
        {
            if (userID == null)
                throw new ArgumentException("��������,ɾ����(T_Sys_Users)�м�¼,����(UserID)����Ϊ��!");
            List<IWhereParameter> whereParaList = new List<IWhereParameter>();
            whereParaList.Add(new WhereParameter(" And UserID = @UserID ", "@UserID", userID));
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

            strSql.Append("DELETE FROM T_Sys_Users "); 
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
        public Sys_UsersInfo GetSys_UsersInfo(Guid userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,DepartmentID,UserName,RealName,Password,IsEffective,Sex,Tel,LastLoginTime,LastLoginIP,LoginTimes,OpName,OpTime from T_Sys_Users");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And UserID = @UserID");
            SqlParameter[] parameters = {

                                              //�û�ID
                                                new SqlParameter("@UserID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = userID;//�û�ID
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
        /// ���������õ�һ��ʵ��
        /// </summary>
        /// <returns></returns>
        public Sys_UsersInfo GetSys_UsersInfo(Guid userID,IDbTransaction trans)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,DepartmentID,UserName,RealName,Password,IsEffective,Sex,Tel,LastLoginTime,LastLoginIP,LoginTimes,OpName,OpTime from T_Sys_Users");
            strSql.Append(" Where 1=1  ");
            strSql.Append(" And UserID = @UserID");
            SqlParameter[] parameters = {

                                              //�û�ID
                                                new SqlParameter("@UserID",SqlDbType.UniqueIdentifier,16)
                                             };
            parameters[0].Value = userID;//�û�ID
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

        #region  ���ݲ�ѯ�������õ�LIST�����б�

        /// <summary>
        /// ���ݲ�ѯ�������õ���Ա������Ϣ LIST�����б�
        /// </summary>
        /// <param name="DataQuery">��ѯ����</param>
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
        /// ���ݲ�ѯ�������õ���Ա������Ϣ LIST�����б�
        /// </summary>
        /// <param name="DataQuery">��ѯ����</param>
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
        private Sys_UsersInfo CreateSys_UsersInfoByReader(IDataReader dr)
        {
            Sys_UsersInfo sys_Users = new Sys_UsersInfo();
            //�û�ID
            if (!Convert.IsDBNull(dr["UserID"]))
                sys_Users.UserID = (Guid)(dr["UserID"]);
 
            //���ű��
            if (!Convert.IsDBNull(dr["DepartmentID"]))
                sys_Users.DepartmentID = (Guid)(dr["DepartmentID"]);
 
            //�û���
            if (!Convert.IsDBNull(dr["UserName"]))
                sys_Users.UserName = Convert.ToString(dr["UserName"]);
 
            //��ʵ����
            if (!Convert.IsDBNull(dr["RealName"]))
                sys_Users.RealName = Convert.ToString(dr["RealName"]);
 
            //��½����
            if (!Convert.IsDBNull(dr["Password"]))
                sys_Users.Password = Convert.ToString(dr["Password"]);
 
            //�Ƿ���Ч(0:��Ч,1:����)
            if (!Convert.IsDBNull(dr["IsEffective"]))
                sys_Users.IsEffective = Convert.ToString(dr["IsEffective"]);
 
            //�Ա�
            if (!Convert.IsDBNull(dr["Sex"]))
                sys_Users.Sex = Convert.ToString(dr["Sex"]);
 
            //��ϵ�绰
            if (!Convert.IsDBNull(dr["Tel"]))
                sys_Users.Tel = Convert.ToString(dr["Tel"]);
 
            //����¼ʱ��
            if (!Convert.IsDBNull(dr["LastLoginTime"]))
                sys_Users.LastLoginTime = Convert.ToDateTime(dr["LastLoginTime"]);
 
            //����¼IP
            if (!Convert.IsDBNull(dr["LastLoginIP"]))
                sys_Users.LastLoginIP = Convert.ToString(dr["LastLoginIP"]);
 
            //��¼����
            if (!Convert.IsDBNull(dr["LoginTimes"]))
                sys_Users.LoginTimes = Convert.ToInt32(dr["LoginTimes"]);
 
            //�����
            if (!Convert.IsDBNull(dr["OpName"]))
                sys_Users.OpName = Convert.ToString(dr["OpName"]);
 
            //���ʱ��
            if (!Convert.IsDBNull(dr["OpTime"]))
                sys_Users.OpTime = Convert.ToDateTime(dr["OpTime"]);
 
            return sys_Users;
        }

        #endregion

        #endregion

        #region �ж��Ƿ񼺴���
        
        /// <summary> 
        /// �����������ж϶����Ƿ񼺴��� 
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
