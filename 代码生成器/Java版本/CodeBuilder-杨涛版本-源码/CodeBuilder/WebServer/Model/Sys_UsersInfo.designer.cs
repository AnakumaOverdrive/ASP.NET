using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Esint.Common;
using Esint.Common.Model;

namespace Esint.CodeSite.Model
{
    /// <summary>
    /// �ļ�˵��: ��Ա������Ϣ��Ϣʵ��
    /// ��    ��: ��ΰͨ
    /// ��������: 2012��09��14��
    /// ����ģ��: Esint.Template.Model.Model_01 ��
    /// �ر�˵�������ļ��ɴ������ɹ����Զ����ɣ����������޸ģ�
    /// </summary>
    public partial class Sys_UsersInfo : BaseModel
    {
        /// <summary>
        /// �û�ID
        /// </summary>
        public Guid UserID { get; set; }
 
        /// <summary>
        /// ���ű��
        /// </summary>
        public Guid DepartmentID { get; set; }
 
        /// <summary>
        /// �û���
        /// </summary>
        public string UserName { get; set; }
 
        /// <summary>
        /// ��ʵ����
        /// </summary>
        public string RealName { get; set; }
 
        /// <summary>
        /// ��½����
        /// </summary>
        public string Password { get; set; }
 
        /// <summary>
        /// �Ƿ���Ч(0:��Ч,1:����)
        /// </summary>
        public string IsEffective { get; set; }
 
        /// <summary>
        /// �Ա�
        /// </summary>
        public string Sex { get; set; }
 
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string Tel { get; set; }
 
        /// <summary>
        /// ����¼ʱ��
        /// </summary>
        public DateTime? LastLoginTime { get; set; }
 
        /// <summary>
        /// ����¼IP
        /// </summary>
        public string LastLoginIP { get; set; }
 
        /// <summary>
        /// ��¼����
        /// </summary>
        public int? LoginTimes { get; set; }
 
        /// <summary>
        /// �����
        /// </summary>
        public string OpName { get; set; }
 
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? OpTime { get; set; }
 
    }
}
