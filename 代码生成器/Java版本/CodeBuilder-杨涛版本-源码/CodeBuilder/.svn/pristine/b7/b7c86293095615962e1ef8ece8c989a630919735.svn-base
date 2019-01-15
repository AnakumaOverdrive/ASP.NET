using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using Esint.TemplateCommon;
using Esint.CodeBuilder.Public;

namespace Esint.Template.BLL
{
    public class BLL_JAVA22 : ITemplate
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

            //============================================第一部分Controller.java(the first part)=================================
            string pascalName = GetewPascalName();
            string lower = Lower();

            string systemConfigFile = System.Environment.CurrentDirectory + "\\Config\\SysConfig.xml";

            string page = XMLHelper.GetNode(systemConfigFile, "page").InnerText;
            string pageSize = XMLHelper.GetNode(systemConfigFile, "pageSize").InnerText;
            string sort = XMLHelper.GetNode(systemConfigFile, "sort").InnerText;
            string order = XMLHelper.GetNode(systemConfigFile, "order").InnerText;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("package com." + DataAccess.AppName + ".controller;");
            //sb.AppendLine("import java.util.Arrays;");
            //sb.AppendLine("import java.util.List;");
            //sb.AppendLine("import java.util.Map;");
            //sb.AppendLine("import org.springframework.beans.factory.annotation.Autowired;");
            //sb.AppendLine("import org.springframework.beans.factory.annotation.Qualifier;");
            sb.AppendLine("import javax.annotation.Resource;");
            sb.AppendLine("import org.springframework.stereotype.Controller;");
            sb.AppendLine("import org.springframework.web.bind.annotation.RequestMapping;");
            //sb.AppendLine("import org.springframework.web.bind.annotation.ResponseBody;");
            //sb.AppendLine("import com.esint.common.util.Message;");
            sb.AppendLine("import com.esint.common.service.BaseService;");
            sb.AppendLine("import com.esint.common.controller.BaseController;");
            sb.AppendLine("import com." + DataAccess.AppName + ".pojo." + pascalName + ";");
            sb.AppendLine("import com." + DataAccess.AppName + ".service." + pascalName + "Service;");



            sb.AppendLine("/**");
            sb.AppendLine(" * " + Tbl.TableName + " Controller类");
            sb.AppendLine(" * 文件说明: " + Tbl.TableDescription + "Controller类");
            sb.AppendLine(" * 作    者: " + this.OperName);
            sb.AppendLine(" * 生成日期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine(" * 生成模板: Esint.Template.Controller.JAVA_Controller 版");
            sb.AppendLine(" * 修改说明：");
            sb.AppendLine(" */");


            sb.AppendLine("@Controller");
            sb.AppendLine("@RequestMapping(\"" + lower + "\")");
            sb.AppendLine("public class " + pascalName + "Controller extends BaseController<" + pascalName + "," + GetPrimaryDataType() + "> {");
            sb.AppendLine("// 引用Service开始");
            //sb.AppendLine("@Autowired");
            //sb.AppendLine("@Qualifier(\"" + lower + "Service\")");
            sb.AppendLine("@Resource(name = \"" + lower + "Service\")");
            sb.AppendLine("private " + pascalName + "Service " + lower + "Service;");

            sb.AppendLine("@Override");
            sb.AppendLine("protected BaseService<" + pascalName + ", " + GetPrimaryDataType() + "> getService() {");
            sb.AppendLine("return " + lower + "Service;");
            sb.AppendLine("}");
            sb.AppendLine("// 引用Service结束");

            sb.AppendLine("@Override");
            sb.AppendLine("protected String defaultSortString() {");
            sb.AppendLine("return \"" + GetPrimary().ToUpper() + ":DESC\";");
            sb.AppendLine("}");

            //sb.AppendLine("// 基础方法开始");
            //sb.AppendLine("/**");
            //sb.AppendLine("* 分页查询");
            //sb.AppendLine("* ");
            //sb.AppendLine("* @param " + lower + "");
            //sb.AppendLine("* @param " + page + "");
            //sb.AppendLine("* @param " + pageSize + "");
            //sb.AppendLine("* @param " + sort + "");
            //sb.AppendLine("* @param " + order + "");
            //sb.AppendLine("* @return");
            //sb.AppendLine("* @throws Exception");
            //sb.AppendLine("*/");
            //sb.AppendLine("@RequestMapping(\"query" + pascalName + "List.do\")");
            //sb.AppendLine("@ResponseBody");
            //sb.AppendLine("public Map<String, Object> query" + pascalName + "List(" + pascalName + " " + lower + ", String " + page + ", String " + pageSize + ", String " + sort + ", String " + order + ")");
            //sb.AppendLine("throws Exception {");
            //sb.AppendLine("String sortString = getSortString(\"" + GetPrimary().ToUpper() + ":DESC\", " + sort + ", " + order + ", true);");
            //sb.AppendLine("return " + lower + "Service.queryPaging(" + lower + ", sortString, " + page + ", " + pageSize + ", true);");
            //sb.AppendLine("}");




            //sb.AppendLine("/**");
            //sb.AppendLine("* 查询");
            //sb.AppendLine("* ");
            //sb.AppendLine("* @param " + lower + "");
            //sb.AppendLine("* @param " + sort + "");
            //sb.AppendLine("* @param " + order + "");
            //sb.AppendLine("* @return");
            //sb.AppendLine("* @throws Exception");
            //sb.AppendLine("*/");
            //sb.AppendLine("@RequestMapping(\"get" + pascalName + "List.do\")");
            //sb.AppendLine("@ResponseBody");
            //sb.AppendLine("public List<" + pascalName + "> get" + pascalName + "List(" + pascalName + " " + lower + ", String " + sort + ", String " + order + ")");
            //sb.AppendLine("throws Exception {");
            //sb.AppendLine("String sortString = getSortString(\"" + GetPrimary().ToUpper() + ":DESC\", " + sort + ", " + order + ", true);");
            //sb.AppendLine("return " + lower + "Service.query(" + lower + ", sortString);");
            //sb.AppendLine("}");



            //sb.AppendLine("/**");
            //sb.AppendLine("* 获得实体对象");
            //sb.AppendLine("* ");
            //sb.AppendLine("* @param id ");
            //sb.AppendLine("* @return");
            //sb.AppendLine("* @throws Exception");
            //sb.AppendLine("*/");
            //sb.AppendLine("@RequestMapping(\"/get" + pascalName + ".do\")");
            //sb.AppendLine("@ResponseBody");
            //sb.AppendLine("public " + pascalName + " get" + pascalName + "(String id) throws Exception {");
            //sb.AppendLine("return " + lower + "Service.queryByID(id);");
            //sb.AppendLine("}");


            //sb.AppendLine("/**");
            //sb.AppendLine("* 添加");
            //sb.AppendLine("* ");
            //sb.AppendLine("* @param " + lower + " ");
            //sb.AppendLine("* @return");
            //sb.AppendLine("* @throws Exception");
            //sb.AppendLine("*/");
            //sb.AppendLine("@RequestMapping(\"add" + pascalName + ".do\")");
            //sb.AppendLine("@ResponseBody");
            //sb.AppendLine("public Map<String, Object> add" + pascalName + "(" + pascalName + " " + lower + ") throws Exception {");
            //sb.AppendLine("if (" + lower + "Service.add(" + lower + ")) {");
            //sb.AppendLine(" return Message.getMessage(\"ok\", \"添加成功\");");
            //sb.AppendLine(" } else {");
            //sb.AppendLine(" return Message.getMessage(\"error\", \"添加失败\");");
            //sb.AppendLine(" }");
            //sb.AppendLine("}");



            //sb.AppendLine("/**");
            //sb.AppendLine("* 修改");
            //sb.AppendLine("* ");
            //sb.AppendLine("* @param " + lower + " ");
            //sb.AppendLine("* @return");
            //sb.AppendLine("* @throws Exception");
            //sb.AppendLine("*/");
            //sb.AppendLine("@RequestMapping(\"edit" + pascalName + ".do\")");
            //sb.AppendLine("@ResponseBody");
            //sb.AppendLine("public Map<String, Object> edit" + pascalName + "(" + pascalName + " " + lower + ") throws Exception {");
            //sb.AppendLine("if (" + lower + "Service.edit(" + lower + ")) {");
            //sb.AppendLine(" return Message.getMessage(\"ok\", \"修改成功\");");
            //sb.AppendLine(" } else {");
            //sb.AppendLine(" return Message.getMessage(\"error\", \"修改失败\");");
            //sb.AppendLine(" }");
            //sb.AppendLine("}");



            //sb.AppendLine("/**");
            //sb.AppendLine("* 删除");
            //sb.AppendLine("* ");
            //sb.AppendLine("* @param ids");
            //sb.AppendLine("* @return");
            //sb.AppendLine("* @throws Exception");
            //sb.AppendLine("*/");
            //sb.AppendLine("@RequestMapping(\"remove" + pascalName + ".do\")");
            //sb.AppendLine("@ResponseBody");
            //sb.AppendLine("public Map<String, Object> remove" + pascalName + "(String[] ids) throws Exception {");
            //sb.AppendLine("if (" + lower + "Service.removeBatch(Arrays.asList(ids))) {");
            //sb.AppendLine("return Message.getMessage(\"ok\", \"删除成功\");");
            //sb.AppendLine("} else {");
            //sb.AppendLine("return Message.getMessage(\"error\", \"删除失败\");");
            //sb.AppendLine(" }");
            //sb.AppendLine("}");
            //sb.AppendLine("// 基础方法结束");


            sb.AppendLine("// 扩展方法 开始");
            sb.AppendLine("// 扩展方法 结束");

            sb.AppendLine("}");






            ReturnCode[] returnCode = new ReturnCode[1];
            returnCode[0] = new ReturnCode();
            returnCode[0].FileName = String.Format(FileName + ".java", GetewPascalName());
            returnCode[0].CodeType = "C#";
            returnCode[0].CodeText = sb;
            return returnCode;
        }


        /// <summary>
        /// 返回单表主键
        /// </summary>
        /// <returns></returns>
        private string GetPrimary()
        {
            if (Tbl.PrimaryKey == null) return "";
            string returnstr = "";
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                returnstr = col.CamelName;
            }
            return returnstr;
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
