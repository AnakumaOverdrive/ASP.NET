using System;
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
    /// ģ��汾: Esint.Template.BLL.BLL_11 �棬�����ڷ��乤��ģʽ����!
    /// �ر�˵��: ���ļ��ɴ������ɹ����Զ����ɣ����������޸ģ�
    /// </summary>
    public partial class Info_ArticleService
    {
        private IInfo_ArticleData dataAccess = Factory.Factory.CreateInfo_ArticleData();
        /// <summary>
        /// ����Info_ArticleInfo ʵ��
        /// <summary>
        /// <param name="info_Article"></param>
        public void Insert(Info_ArticleInfo info_Article)
        {
            dataAccess.Insert(info_Article);
        }

        /// <summary>
        /// ������������Info_ArticleInfo ʵ��
        /// <summary>
        /// <param name="info_Article"></param>
        public void Update(Info_ArticleInfo info_Article)
        {
            dataAccess.Update(info_Article);
        }

        /// <summary>
        /// ��������ɾ��
        /// </summary>
        public void Delete(Guid aritcleID)
        {
            dataAccess.Delete(aritcleID);
        }

        /// <summary>
        /// ���������õ�һ��ʵ��
        /// </summary>
        /// <returns></returns>
        public Info_ArticleInfo GetInfo_ArticleInfo(Guid aritcleID)
        {
            return dataAccess.GetInfo_ArticleInfo(aritcleID);
        }

    }
}
