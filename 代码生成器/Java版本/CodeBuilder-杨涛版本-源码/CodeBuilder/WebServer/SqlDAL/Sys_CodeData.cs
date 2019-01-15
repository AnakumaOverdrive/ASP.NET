using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Esint.Common.Data;
using Esint.CodeSite.Model;
using Esint.CodeSite.IDAL;
using Esint.Common.Model;
using System.Data.SqlClient;

namespace Esint.CodeSite.SqlDAL
{
    /// <summary>
    /// ģ�����ƣ������ ���ݷ��ʲ�
    /// ��    �ߣ���ΰͨ
    /// �������ڣ�2012��09��09��
    /// ����ģ��: Esint.Template.SqlDAL.SqlDAL_11 ��
    ///           �����ڹ���ģʽ�ܹ�
    /// �޸�˵����
    /// </summary>
    public partial class Sys_CodeData  : BaseData, ISys_CodeData
    {
        public List<Sys_CodeInfo> GetCodeListByFlag(string flag)
        {
            DataQuery query = new DataQuery();
            if (!string.IsNullOrEmpty(flag))
                query.WhereParameters.Add(new WhereParameter("And IS_ENABLE=1 And Flag = @Flag", "@Flag", flag));
            return GetSys_CodeList(query);
        }

    }
} 
