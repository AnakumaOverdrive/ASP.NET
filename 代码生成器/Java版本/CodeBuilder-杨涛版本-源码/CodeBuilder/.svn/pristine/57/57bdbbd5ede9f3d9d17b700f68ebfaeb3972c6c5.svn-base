using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using System.Windows.Forms;


namespace Esint.CodeBuilder.Template
{
    public class WebCs 
    {
        public IDbTable Tbl { get; set; }
        public string NameSpace { get; set; }
        public string FileName { get; set; }
        public StringBuilder GetCode()
        {
            bool isSet = false;
            foreach (IColumn col in Tbl.Columns)
            {
                if (col.ControlProperty.IsVisible)
                    isSet = true;
            }
            if (!isSet)
            {
                MessageBox.Show("还未进行页面设置，先使用页面设置工具设置后，再生成本代码！", "错误");
                return new StringBuilder();
            }



            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Linq;");
            sb.AppendLine("using System.Web;");
            sb.AppendLine("using System.Web.UI;");
            sb.AppendLine("using System.Web.UI.WebControls;");
            sb.AppendLine("using Esint."+NameSpace+".BLL;");
            sb.AppendLine("using Esint."+NameSpace+".Model;");
            sb.AppendLine("using Esint.Common;");
            sb.AppendLine("");
            sb.AppendLine("namespace Esint."+NameSpace+".Web");
            sb.AppendLine("{");
            sb.AppendLine("     public partial class "+Tbl.PascalName+"Page : System.Web.UI.Page");
            sb.AppendLine("     {");
            sb.AppendLine("         "+Tbl.PascalName+"Service "+Tbl.CamelName+"Service = new "+Tbl.PascalName+"Service();");
           
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("         "+col.DataType.CSharpType+" "+col.CamelName+";");
            }

            sb.AppendLine("         protected void Page_Load(object sender, EventArgs e)");
            sb.AppendLine("         { ");
            sb.AppendLine("             if (!Page.IsPostBack)");

            sb.AppendLine("             {");
            foreach (IColumn col in Tbl.Columns)
            {
                if (col.ControlProperty.ControlType == "下拉框")
                {
                    sb.AppendLine("                 drp_" + col.PascalName + ".CodeBinding(\"" + col.ControlProperty.Tag + "\");");
                }
            }
            sb.AppendLine("                 if ("+RequestQueryString()+")");
            sb.AppendLine("                 {");
            foreach(IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("                     " + col.CamelName + " = " + col.DataType.ConvertString+ "(Request.QueryString[\"" + col.PascalName + "\"]);");
            }

            sb.AppendLine("                     "+Tbl.CamelName+"Service.Get"+Tbl.PascalName+"Info("+GetPrimaryParaList()+");");
            sb.AppendLine("                  }");
            sb.AppendLine("             }");
            sb.AppendLine("      }");

            sb.AppendLine("         protected void btn_Submit_Click(object sender, EventArgs e)");
            sb.AppendLine("         {");
            sb.AppendLine("             if (ValidateData())");
            sb.AppendLine("             {");
            sb.AppendLine("                 "+Tbl.PascalName+"Info "+Tbl.CamelName+" = GetPageDataFor"+Tbl.PascalName+"();");
            sb.AppendLine("                 "+Tbl.CamelName+"Service.Save("+Tbl.CamelName+");");
            sb.AppendLine("             }");
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine("         protected void btn_Cancel_Click(object sender, EventArgs e)");
            sb.AppendLine("         {");
            sb.AppendLine("             //取消返回按钮");
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine("         protected " + Tbl.PascalName + "Info GetPageDataFor" + Tbl.PascalName + "()");
            sb.AppendLine("         {  ");
            sb.AppendLine("             " + Tbl.PascalName + "Info  " + Tbl.CamelName + " = new  " + Tbl.PascalName + "Info();");
            foreach(IColumn col in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("             if (!String.IsNullOrEmpty(hd_" + col.PascalName + ".Value))");
                sb.AppendLine("                 " + Tbl.CamelName + "." + col.PascalName + " = " + col.DataType.ConvertString + "(hd_" + col.PascalName + ".Value);");
            }

            foreach (IColumn col in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {
                    if (col.ControlProperty.IsVisible)
                        sb.AppendLine("              " + Tbl.CamelName + "." + col.PascalName + " = " + col.DataType.ConvertString + "(" + col.ControlProperty.ControlName + col.PascalName + col.ControlProperty.ControlValueStr + ");");
                }
            }

            sb.AppendLine("             return " + Tbl.CamelName+";");
            sb.AppendLine("         }");

            sb.AppendLine("          protected void SetPageDataBy" + Tbl.PascalName + "(" + Tbl.PascalName + "Info " + Tbl.CamelName + ")");
            sb.AppendLine("          {");
            
            foreach(IColumn col  in Tbl.PrimaryKey.Columns)
            {
                sb.AppendLine("             hd_"+col.PascalName+".Value = "+Tbl.CamelName+"."+col.PascalName+".ToString();");
            }
            
            foreach(IColumn col  in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {             
                    if (col.ControlProperty.IsVisible)
                        sb.AppendLine("             " + col.ControlProperty.ControlName + col.PascalName  + col.ControlProperty.ControlValueStr + " = " + Tbl.CamelName + "." + col.PascalName + ".ToString();");
                }
            }
            sb.AppendLine("         }");
            sb.AppendLine();
            sb.AppendLine("         protected bool ValidateData()");
            sb.AppendLine("         {");
            sb.AppendLine("             string errMessage = \"数据提交失败:<br>\";");
            sb.AppendLine("             bool isValidate = true;");


            foreach(IColumn col  in Tbl.Columns)
            {
                if (col.IsPrimaryKey == false)
                {             
                    if (col.ControlProperty.IsVisible)
                    {
                          sb.AppendLine("         if  (!Validator.Is"+col.DataType.CSharpType.Substring(0,1).ToUpper()+col.DataType.CSharpType.Substring(1)+"("+col.ControlProperty.ControlName+col.PascalName+col.ControlProperty.ControlValueStr+"))");
                          sb.AppendLine("         {");
                          sb.AppendLine("               isValidate = false;");
                          sb.AppendLine("               errMessage += \""+col.Description+"不是正确的格式<br>\";");
                          sb.AppendLine("         }");
                    }
                }
                    
            }

            sb.AppendLine("         lbl_errMsg.Text = errMessage;");
            sb.AppendLine("         return isValidate;");
            sb.AppendLine("       }");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb;

        }

        private string GetPrimaryParaList()
        {
            string str = "";
            foreach (IColumn col in Tbl.PrimaryKey.Columns)
            {
                str += col.CamelName+",";
            }
            return str.Substring(0, str.Length - 1);
        }

        private string RequestQueryString()
        {
            string str = "";
            foreach(IColumn col  in Tbl.PrimaryKey.Columns)
            {
                str += "!String.IsNullOrEmpty(Request.QueryString[\""+col.PascalName+"\"])&&";
            }
            return str.Substring(0, str.Length - 2);
        }
    }
}
