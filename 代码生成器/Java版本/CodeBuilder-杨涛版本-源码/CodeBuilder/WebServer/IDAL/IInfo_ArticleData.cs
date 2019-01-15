using System.Collections.Generic;
using System.Data;
using Esint.Common.Model;
using Esint.CodeSite.Model;
using System;

namespace Esint.CodeSite.IDAL
{
    /// <summary>
    /// ģ�����ƣ� ���ݷ��ʽӿڲ�
    /// ��    �ߣ���ΰͨ
    /// �������ڣ�2012��09��18��
    /// ����ģ��: Esint.Template.IDAL.IDAL_01 ��
    /// �޸�˵����
    /// </summary>
    public partial interface IInfo_ArticleData:IBaseData
    {
        /// <summary>
        /// ����˵��: ����������ѯ  �б�����DataTable
        /// ��    ��: ��ΰͨ
        /// ��    ��: 2012��09��18��
        /// </summary>
        /// <param name="pageView">��ҳ����</param>
        /// <param name="orderStr">�����ֶ�</param>
        /// <param name="title">����</param>
        /// <param name="category">�����</param>
        /// <returns>  DataTable�����</returns>
        ReturnTable GetInfo_ArticleTable(PageSplit pageView, string orderStr, string title, Guid category);

    }
}
