using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.Model;
using System.Xml;
using System.IO;

namespace Esint.CodeBuilder.BLL
{
    public class CommBLL
    {
        /// <summary>
        /// 根据数据类型配置文件,得到数据类型配置列表
        /// 作者:刘伟通
        /// 日期:2010年7月31日
        /// </summary>
        /// <param name="dataTypeConfigFile"></param>
        /// <returns></returns>
        public static List<DataType> GetDataTypeList(string dataTypeConfigFile)
        {
            List<DataType> dataTypeList = new List<DataType>();
            XmlDocument xmldoc = new XmlDocument();
            if (!File.Exists(dataTypeConfigFile)) 
            {
                throw new Exception("数据类型配置文件:"+dataTypeConfigFile+"不存在,请检查!");
            }
            xmldoc.Load(dataTypeConfigFile);

            foreach (XmlNode node in xmldoc.DocumentElement.ChildNodes)
            {
                dataTypeList.Add(new DataType(node.Attributes["CSharpType"].Value, node.Attributes["DbType"].Value, node.Attributes["DataType"].Value, node.Attributes["Convert"].Value,Convert.ToBoolean(node.Attributes["AutoWidth"].Value)));
            }
           return dataTypeList;
        }
    }
}
