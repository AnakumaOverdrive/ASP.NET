using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Esint.CodeSite.Model;
using Esint.CodeSite.Factory;
using Esint.CodeSite.IDAL;
using Esint.Common.Model;

namespace Esint.CodeSite.BLL
{
    /// <summary>
    /// �ļ�˵��:  ҵ���߼���
    /// ��    ��: ��ΰͨ
    /// ��������: 2012��09��18��
    /// ģ��汾: Esint.Template.BLL.BLL_01 �棬�����ڼ����㿪��!
    /// ����˵����
    /// </summary>
    public partial class Info_ArticleService
    {
        /// <summary>
        /// ��    ��: �������
        /// ˵    ��: ������Ϊ��ʱ����������
        ///           ��������Ϊ�գ��������������޸�
        /// <summary>
        public void Save(Info_ArticleInfo info_Article)
        {
            if (info_Article.AritcleID==Guid.Empty)
            {
                 dataAccess.Insert(info_Article);
            }
            else
            {
                 dataAccess.Update(info_Article);
            }
        }

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
        public ReturnTable GetInfo_ArticleTable(PageSplit pageView, string orderStr, string title, Guid category)
        {
            return dataAccess.GetInfo_ArticleTable(pageView, orderStr, title, category);
        }
    }
}
