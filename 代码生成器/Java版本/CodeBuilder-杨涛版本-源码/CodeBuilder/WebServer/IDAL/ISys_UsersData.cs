using System.Collections.Generic;
using System.Data;
using Esint.Common.Model;
using Esint.CodeSite.Model;

namespace Esint.CodeSite.IDAL
{
    /// <summary>
    /// ģ�����ƣ���Ա������Ϣ ���ݷ��ʽӿڲ�
    /// ��    �ߣ���ΰͨ
    /// �������ڣ�2012��09��14��
    /// ����ģ��: Esint.Template.IDAL.IDAL_01 ��
    /// �޸�˵����
    /// </summary>
    public partial interface ISys_UsersData:IBaseData
    {
        Sys_UsersInfo UserLogin(string loginName, string LoginPwd, string IpStr);
    }
}
