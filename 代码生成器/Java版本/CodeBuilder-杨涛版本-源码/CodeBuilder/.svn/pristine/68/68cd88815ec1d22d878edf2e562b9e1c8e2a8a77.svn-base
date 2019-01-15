using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.TemplateCommon;

namespace Esint.Template.BLL
{
    public class BLL_JAVA33 : ITemplate
    {
        public IDbTable Tbl { get; set; }
        public string NameSpace { get; set; }
        public string FileName { get; set; }
        public string OperName { get; set; }
        public string ConnectString { get; set; }
        public ICodeBuilder DataAccess { get; set; }
        public List<IDbTable> Tbls { get; set; }
        public bool IsPackage { get; set; }


        public IReturnCode[] GetCode()
        {

            //============================================第一部分BLL.designer.cs(the first part)=================================
            StringBuilder sb = new StringBuilder();
          

            sb.AppendLine("package com." + DataAccess.AppName + ".service;");
            sb.AppendLine("import com.esint.common.service.BaseService;");
            sb.AppendLine("import com." + DataAccess.AppName + ".pojo." + GetewPascalName() + ";");




            //============================================第一部分Service.java(the first part)=================================


            sb.AppendLine("/**");
            sb.AppendLine("* " + GetewPascalName() + " 业务逻辑接口");
            sb.AppendLine("*");
            sb.AppendLine("* @author " + OperName + "");
            sb.AppendLine("* ");
            sb.AppendLine("*/");

            sb.AppendLine("public interface " + GetewPascalName() + "Service extends BaseService<" + GetewPascalName() + ", " + GetPrimaryDataType() + "> {}");










            //==================================================End===========================================================

            //========================================第二部分BLL.cs开始(The second part)=============================
            StringBuilder sb1 = new StringBuilder();
            sb1.AppendLine("package com." + DataAccess.AppName + ".service.impl;");
            //sb1.AppendLine("import org.springframework.beans.factory.annotation.Autowired;");
            //sb1.AppendLine("import org.springframework.beans.factory.annotation.Qualifier;");
            sb1.AppendLine("import javax.annotation.Resource;");
            sb1.AppendLine("import org.springframework.stereotype.Service;");
            sb1.AppendLine("import com.esint.common.mapper.BaseMapper;");
            sb1.AppendLine("import com.esint.common.service.impl.BaseServiceImpl;");
            sb1.AppendLine("import com." + DataAccess.AppName + ".mapper." + GetewPascalName() + "Mapper;");
            sb1.AppendLine("import com." + DataAccess.AppName + ".pojo." + GetewPascalName() + ";");
            sb1.AppendLine("import com." + DataAccess.AppName + ".service." + GetewPascalName() + "Service;");

            sb1.AppendLine("/**");
            sb1.AppendLine(" * " + Tbl.TableName + " 业务逻辑实现类");
            sb1.AppendLine(" * 文件说明: " + Tbl.TableDescription + "业务逻辑实现类");
            sb1.AppendLine(" * 作    者: " + this.OperName);
            sb1.AppendLine(" * 生成日期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb1.AppendLine(" * 生成模板: Esint.Template.ServiceImpl.JAVA_ServiceImpl版");
            sb1.AppendLine(" * 修改说明：");
            sb1.AppendLine(" */");




          
            sb1.AppendLine("@Service(\"" + Lower() + "Service\")");
            sb1.AppendLine("public class " + GetewPascalName() + "ServiceImpl extends BaseServiceImpl<" + GetewPascalName() + ", " + GetPrimaryDataType() + "> implements");
            sb1.AppendLine("" + GetewPascalName() + "Service {");
            //sb1.AppendLine("@Autowired");
            //sb1.AppendLine("@Qualifier(\"" + Lower() + "Mapper\")");
            sb1.AppendLine("@Resource(name = \"" + Lower() + "Mapper\")");
            sb1.AppendLine("private " + GetewPascalName() + "Mapper " + Lower() + "Mapper;");
            sb1.AppendLine("@Override");
            sb1.AppendLine("protected BaseMapper<" + GetewPascalName() + ", " + GetPrimaryDataType() + "> getMapper() {");
            sb1.AppendLine(" return " + Lower() + "Mapper;");
            sb1.AppendLine("}");
            sb1.AppendLine("}");

         
            //===========================================End =========================================================

            ReturnCode[] returnCode = new ReturnCode[1];
            returnCode[0] = new ReturnCode();
            returnCode[0].FileName = String.Format(FileName + ".java", GetewPascalName());
            returnCode[0].CodeType = "C#";
            returnCode[0].CodeText = sb1;
            return returnCode;


        }

        /// <summary>
        ///获取主键列方法
        /// </summary>
        /// <returns></returns>
        private string GetPrimaryParaList()
        {
            if (Tbl.PrimaryKey == null) return "";
            string returnstr = "";
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                returnstr += col.DataType.CSharpType + " " + col.CamelName + ",";
            }
            returnstr = returnstr.Substring(0, returnstr.Length - 1);
            return returnstr;
        }

        /// <summary>
        /// 返回判断实体主键为空字符串
        /// </summary>
        /// <returns></returns>
        private string GetCheckIsNullPrimaryList()
        {
            if (Tbl.PrimaryKey == null) return "";
            string returnstr = null;
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                if (col.DataType.CSharpType == "string")
                    returnstr += "String.IsNullOrEmpty(" + Tbl.CamelName + "." + col.PascalName + ") || ";
                else if (col.DataType.CSharpType.IndexOf('?') != -1)
                {
                    returnstr += "!" + Tbl.CamelName + "." + col.PascalName + ".HasValue || ";
                }
                else if (col.DataType.CSharpType == "Guid")
                {
                    returnstr += Tbl.CamelName + "." + col.PascalName + "==Guid.Empty|| ";
                }
                else
                {
                    returnstr += "String.IsNullOrEmpty(Convert.ToString(" + Tbl.CamelName + "." + col.PascalName + ")) || ";
                }
            }
            if (returnstr.Substring(returnstr.Length - 3, 3) == "|| ")
                returnstr = returnstr.Substring(0, returnstr.Length - 3);
            return returnstr;
        }

        /// <summary>
        /// 返回不带类型的主键集合串
        /// </summary>
        /// <returns></returns>
        private string GetPrimaryParaListNoCsType()
        {
            if (Tbl.PrimaryKey == null) return "";
            string returnstr = "";
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                returnstr += col.CamelName + ",";
            }

            returnstr = returnstr.Substring(0, returnstr.Length - 1);
            return returnstr;
        }
        /// <summary>
        /// 返回主键类型
        /// </summary>
        /// <returns></returns>
        private string GetPrimaryDataType()
        {
            String PKType = "";
            foreach (IColumn item in Tbl.Columns)
            {
                if (item.IsPrimaryKey)
                {
                    PKType = item.DataType.CSharpType;
                }
            }
            return PKType;
        }


        private string GetewPascalName()
        {
            //去掉表名中的第一个 T
            string NewPascalName = "";
            if (Tbl.PascalName.IndexOf('T') == 0 || Tbl.PascalName.IndexOf('R') == 0 || Tbl.PascalName.IndexOf('G') == 0 || Tbl.PascalName.IndexOf('Z') == 0 || Tbl.PascalName.IndexOf('J') == 0 || Tbl.PascalName.IndexOf('D') == 0)
            {
                NewPascalName = Tbl.PascalName.Substring(1, Tbl.PascalName.Length - 1);
            }
            else { NewPascalName = Tbl.PascalName; }
            return NewPascalName;
        }



        public string Lower()
        {
            string str = GetewPascalName();
            string newStr = string.Empty;

            if (str.Length > 0)
            {
                newStr = str.Substring(0, 1).ToLower() + str.Substring(1);
            }
            return newStr;
        }

    }
}
