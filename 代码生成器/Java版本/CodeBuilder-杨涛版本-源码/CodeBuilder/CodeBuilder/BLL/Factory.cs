using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.Public;
using Esint.CodeBuilder.Model;
using System.Reflection;
using System.Windows.Forms;
using Esint.CodeBuilder.InterFace;

namespace Esint.CodeBuilder.BLL
{
    public class Factory
    {
        /// <summary>
        /// 工厂方法,根据数据库类型,建立对应的BLL对象
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <returns></returns>
        public static ICodeBuilder CreateCodeBuilderBLL()
        {  
            ICodeBuilder codeBuilderBLL=null;
            string className;
            switch (PublicClass.DataBaseType)
            {
                case DataBaseType.SqlServer:
                    className = "Esint.CodeBuilder.SqlData.BLL.SqlBLL";
                    codeBuilderBLL = (ICodeBuilder)Assembly.LoadFrom(Application.StartupPath + "\\SqlData.dll").CreateInstance(className);
                    break;
                case DataBaseType.Oracle:
                    className = "Esint.CodeBuilder.OracleData.BLL.OracleBLL";
                    codeBuilderBLL = (ICodeBuilder)Assembly.LoadFrom(Application.StartupPath + "\\OracleData.dll").CreateInstance(className);
                    break;
                case DataBaseType.MySql:
                    className = "Esint.CodeBuilder.MySqlData.BLL.MySqlBLL";
                    codeBuilderBLL = (ICodeBuilder)Assembly.LoadFrom(Application.StartupPath + "\\MySqlData.dll").CreateInstance(className);
                    break;
            }
            codeBuilderBLL.AppName = PublicClass.AppName;
            codeBuilderBLL.CodeSQL = PublicClass.CodeSQL;
            return codeBuilderBLL;
        }
    }
}
