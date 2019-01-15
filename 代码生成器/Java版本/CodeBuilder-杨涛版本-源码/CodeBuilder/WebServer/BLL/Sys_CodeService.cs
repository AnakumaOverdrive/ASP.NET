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
    /// �ļ�˵��: ����� ҵ���߼���
    /// ��    ��: ��ΰͨ
    /// ��������: 2012��09��09��
    /// ģ��汾: Esint.Template.BLL.BLL_01 �棬�����ڼ����㿪��!
    /// ����˵����
    /// </summary>
    public partial class Sys_CodeService
    {
        /// <summary>
        /// ��    ��: �����������
        /// ˵    ��: ������Ϊ��ʱ����������
        ///           ��������Ϊ�գ��������������޸�
        /// <summary>
        public void Save(Sys_CodeInfo sys_Code)
        {
            if (String.IsNullOrEmpty(sys_Code.Flag) || String.IsNullOrEmpty(sys_Code.Code) )
            {
                 dataAccess.Insert(sys_Code);
            }
            else
            {
                 dataAccess.Update(sys_Code);
            }
        }

        public List<Sys_CodeInfo> GetCodeListByFlag(string flag)
        { 
            return dataAccess.GetCodeListByFlag(flag);
        }
    }
}
