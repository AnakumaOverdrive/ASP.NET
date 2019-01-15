using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Esint.Common;
using Esint.Common.Model;

namespace Esint.CodeSite.Model
{
    /// <summary>
    /// �ļ�˵��: ��Ϣʵ��
    /// ��    ��: ��ΰͨ
    /// ��������: 2012��09��18��
    /// ����ģ��: Esint.Template.Model.Model_01 ��
    /// �ر�˵�������ļ��ɴ������ɹ����Զ����ɣ����������޸ģ�
    /// </summary>
    public partial class Info_ArticleInfo : BaseModel
    {
        /// <summary>
        /// ���±��
        /// </summary>
        public Guid AritcleID { get; set; }
 
        /// <summary>
        /// ����
        /// </summary>
        public string Title { get; set; }
 
        /// <summary>
        /// �����
        /// </summary>
        public Guid Category { get; set; }
 
        /// <summary>
        /// ����
        /// </summary>
        public string InfoBody { get; set; }
 
        /// <summary>
        /// �����
        /// </summary>
        public string OpName { get; set; }
 
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? OPTime { get; set; }
 
    }
}
