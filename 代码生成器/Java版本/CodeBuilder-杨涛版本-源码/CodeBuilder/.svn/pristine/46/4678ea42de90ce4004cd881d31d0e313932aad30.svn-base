using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Esint.CodeBuilder.InterFace;
using Esint.TemplateCommon;
using System.Reflection;

namespace Esint.Template.Model
{
    /// <summary>
    /// 模板生成页
    /// </summary>
    public partial class JAVA_Model : Form, ITemplate
    {
        const string Ver = "1.0";                  // 模板版本号

        public IDbTable Tbl { get; set; }          //要生成的主表
        public string NameSpace { get; set; }      //命名空间
        public string FileName { get; set; }       //文件名
        public bool IsPackage { get; set; }        //是否批量生成
        public string OperName { get; set; }       //操作人姓名
        public string ConnectString { get; set; }  //数据库连接字串
        public ICodeBuilder DataAccess { get; set; }//数据库访问对象
        public List<IDbTable> Tbls { get; set; }    //需要多表时，表列表

        public JAVA_Model()
        {
            InitializeComponent();
            gv_SubTable.AutoGenerateColumns = false;

        }
        /// <summary>
        /// 将字符串转换成首字母大写，其他字母小写
        /// </summary>
        /// <returns></returns>
        public string StringToTitleCase(string StringCode)
        {
            StringCode = StringCode.ToLower();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(StringCode);
        }
        /// <summary>
        /// 分割表字符串
        /// </summary>
        /// <param name="_StringSplit"></param>
        /// <returns></returns>
        public string StringSplit(string _StringSplit)
        {
            string TableName = _StringSplit;
            string[] TableName_array = TableName.Split(new char[] { '_' });
            TableName = "";
            for (int i = 0; i < TableName_array.Length; i++)
            {
                //转换字母大小写
                TableName += StringToTitleCase(TableName_array[i].ToString());
            }
            return TableName;
        }
        public IReturnCode[] GetCode()
        {
            // 如果是批量生成，则不显示对话框，只生成
            if (!IsPackage)
            {
                //Initi();
                //this.ShowDialog();
            }


            IReturnCode[] returnCode = new IReturnCode[1];
            returnCode[0] = new ReturnCode();
            //去掉表名中的第一个 T
            string NewFileName = Tbl.PascalName;
            if (Tbl.PascalName.IndexOf('T') == 0 || Tbl.PascalName.IndexOf('R') == 0 || Tbl.PascalName.IndexOf('G') == 0 || Tbl.PascalName.IndexOf('Z') == 0 || Tbl.PascalName.IndexOf('J') == 0 || Tbl.PascalName.IndexOf('D') == 0)
            {
                NewFileName = Tbl.PascalName.Substring(1, Tbl.PascalName.Length - 1);
            }
            returnCode[0].FileName = String.Format(NewFileName + ".java", NewFileName);
            returnCode[0].CodeText = CreateModelDesigner();
            returnCode[0].CodeType = "JAVA";

            //returnCode[1] = new ReturnCode();
            //returnCode[1].FileName = String.Format(FileName + "", Tbl.PascalName);
            //returnCode[1].CodeText = CreateModel();
            //returnCode[1].CodeType = "JAVA";
            return returnCode;
        }

        public void Initi()
        {
            if (DataAccess == null) MessageBox.Show("error");
            //Tbls = DataAccess.GetSubTables(Tbl, ConnectString);
            //foreach (IDbTable dbtable in Tbls)
            //{
            //    gv_SubTable.Rows.Add(new object[] { false, dbtable.TableName, dbtable.TableDescription });
            //}

            List<IDbTable> tbList = DataAccess.GetTableList(ConnectString);
            // cbx_BaseModel.Items.Add("BaseModel");
            foreach (IDbTable db in tbList)
            {
                cbx_BaseModel.Items.Add(db.PascalName);
            }
            //cbx_BaseModel.Text = " implements java.io.Serializable ";
        }

        public StringBuilder GetAspxCode()
        {
            return new StringBuilder();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 将字段的首字母变成小写，其他驼峰命名规则
        /// 杨涛
        /// </summary>
        /// <param name="colname"></param>
        /// <returns></returns>
        public string OneStringLower(string colname)
        {
            string newcolname = "";
            newcolname = colname.Substring(0, 1).ToLower();
            newcolname += colname.Substring(1, colname.Length - 1);
            return newcolname;
        }
        /// <summary>
        /// 将字段的首字母变成大写，其他驼峰命名规则
        /// 杨涛
        /// </summary>
        /// <param name="colname"></param>
        /// <returns></returns>
        public string OneStringUpper(string colname)
        {
            string newcolname = "";
            newcolname = colname.Substring(0, 1).ToUpper();
            newcolname += colname.Substring(1, colname.Length - 1);
            return newcolname;
        }
        /// <summary>
        /// JAVA使用的生成方法
        /// </summary>
        /// <returns></returns>
        private StringBuilder CreateModelDesigner()
        {
            StringBuilder sb = new StringBuilder();
            #region  //C#的生成方法
            //sb.AppendLine("using System;");
            //sb.AppendLine("using System.Collections.Generic;");
            //sb.AppendLine("using System.ComponentModel.DataAnnotations.Schema;");

            //sb.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName));
            //sb.AppendLine("{");
            //sb.AppendLine("    /// <summary>");
            //sb.AppendLine("    /// 文件说明: " + Tbl.TableDescription + "信息实体");
            //sb.AppendLine("    /// 作    者: " + this.OperName);
            //sb.AppendLine("    /// 生成日期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
            //sb.AppendLine("    /// 生成模板: Esint.Template.Model.EF_Model 版");
            //sb.AppendLine("    /// 修改说明：");
            //sb.AppendLine("    /// </summary>");
            //if (cbx_BaseModel.Text.Trim() == "")
            //    sb.AppendLine("    public  class " + Tbl.PascalName + " : BaseModel");
            //else
            //    sb.AppendLine("    public  class " + Tbl.PascalName + ": " + cbx_BaseModel.Text);

            //sb.AppendLine("    {");
            //sb.AppendLine("        public " + Tbl.PascalName + "()");
            //sb.AppendLine("        {");
            //sb.AppendLine("           // this.T_Sys_RoleUser = new List<T_Sys_RoleUser>();");
            //sb.AppendLine("        }");
            //sb.AppendLine(""); 
            //foreach (IColumn col in Tbl.Columns)
            //{
            //    sb.AppendLine("        /// <summary>");
            //    sb.AppendLine("        /// " + col.Description);
            //    sb.AppendLine("        /// </summary>");
            //    sb.AppendLine("        public " + col.DataType.CSharpType + " " + col.PascalName + " { get; set; }");
            //    sb.AppendLine(" ");
            //} 
            //sb.AppendLine("       // public virtual T_Sys_Department T_Sys_Department { get; set; }");
            //sb.AppendLine("     //   public virtual ICollection<T_Sys_RoleUser> T_Sys_RoleUser { get; set; }");
            //sb.AppendLine("");
            //sb.AppendLine("        //[NotMapped]");
            //sb.AppendLine("        //public List<T_Sys_Power> Powers { get; set; }");
            //sb.AppendLine("    }");
            //sb.AppendLine("}");
            #endregion

            //头信息
            sb.AppendLine("package " + string.Format(NameSpace, DataAccess.AppName));
            sb.AppendLine(" ");
            //包的引入

            sb.AppendLine("import java.io.Serializable;");

            if (DataAccess.DataBaseType == "ORACLE")
            {
                sb.AppendLine("import org.hibernate.validator.constraints.Length;");
                sb.AppendLine("import org.hibernate.validator.constraints.Email;");
                sb.AppendLine("import javax.validation.constraints.Digits;");
                sb.AppendLine("import javax.validation.constraints.Pattern;");
                sb.AppendLine("import com.ggzy.common.constant.RegularConstant;");
            }
            if (DataAccess.DataBaseType == "MYSQL")
            {
                sb.AppendLine("import org.hibernate.validator.constraints.Length;");
                sb.AppendLine("import org.hibernate.validator.constraints.Email;");
                sb.AppendLine("import javax.validation.constraints.Digits;");
                sb.AppendLine("import javax.validation.constraints.Pattern;");
                sb.AppendLine("import com.zhpt.common.constant.RegularConstant;");
            }
            if (DataAccess.DataBaseType == "SQLSERVER")
            {
                sb.AppendLine("import org.hibernate.validator.constraints.Length;");
                sb.AppendLine("import org.hibernate.validator.constraints.Email;");
                sb.AppendLine("import javax.validation.constraints.Digits;");
                sb.AppendLine("import javax.validation.constraints.Pattern;");
                sb.AppendLine("import com.zhpt.common.constant.RegularConstant;");
            }

            int m = 0;
            foreach (IColumn col in Tbl.Columns)
            {
                if (m > 0)
                    continue;
                if (DataAccess.DataBaseType == "ORACLE")
                {
                    //if (col.DataType.DbDataType.ToString().ToUpper().Equals("TIMESTAMP") || col.DataType.DbDataType.ToString().ToUpper().Equals("DATE"))
                    //{
                    //    sb.AppendLine("import org.codehaus.jackson.map.annotate.JsonDeserialize;");
                    //    sb.AppendLine("import org.codehaus.jackson.map.annotate.JsonSerialize;");
                    //    m++;
                    //}

                    //if (col.DataType.DbDataType.ToUpper()=="NUMBER")
                    //{
                    //    sb.AppendLine("import javax.validation.constraints.Digits;");
                    //    m++;
                    //}
                }
                if (DataAccess.DataBaseType == "SQLSERVER")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATETIME" || col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        sb.AppendLine("import org.codehaus.jackson.map.annotate.JsonDeserialize;");
                        sb.AppendLine("import org.codehaus.jackson.map.annotate.JsonSerialize;");
                        m++;
                    }
                }
                if (DataAccess.DataBaseType == "MYSQL")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATETIME" || col.DataType.DbDataType.ToUpper() == "TIMESTAMP" || col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        sb.AppendLine("import org.codehaus.jackson.map.annotate.JsonDeserialize;");
                        sb.AppendLine("import org.codehaus.jackson.map.annotate.JsonSerialize;");
                        m++;
                    }
                }
            }


            //import org.codehaus.jackson.map.annotate.JsonDeserialize;
            //import org.codehaus.jackson.map.annotate.JsonSerialize;


            int i = 0;
            int j = 0;
            foreach (IColumn col in Tbl.Columns)
            {
                if (DataAccess.DataBaseType == "ORACLE")
                {
                    //if (i > 0)
                    //    continue;
                    //if (col.DataType.DbDataType.ToUpper() == "TIMESTAMP")
                    //{
                    //    sb.AppendLine("import java.sql.Timestamp;");
                    //    sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateTimeDeserializer;");
                    //    sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateTimeSerializer;");
                    //    i++;
                    //}
                    //else if (col.DataType.DbDataType.ToUpper() == "DATE")
                    //{
                    //    if (j > 0)
                    //        continue;
                    //    sb.AppendLine("import java.sql.Date;");
                    //    sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateDeserializer;");
                    //    sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateSerializer;");
                    //    j++;
                    //}
                }
                if (DataAccess.DataBaseType == "SQLSERVER")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATETIME")
                    {
                        if (i > 0)
                            continue;
                        sb.AppendLine("import java.sql.Timestamp;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateTimeDeserializer;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateTimeSerializer;");
                        i++;
                    }
                    else if (col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        if (j > 0)
                            continue;
                        sb.AppendLine("import java.sql.Date;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateDeserializer;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateSerializer;");
                        j++;
                    }
                }
                if (DataAccess.DataBaseType == "MYSQL")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATETIME")
                    {
                        if (i > 0)
                            continue;
                        sb.AppendLine("import java.sql.Timestamp;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateTimeDeserializer;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateTimeSerializer;");
                        i++;
                    }
                    if (col.DataType.DbDataType.ToUpper() == "TIMESTAMP")
                    {
                        if (i > 0)
                            continue;
                        sb.AppendLine("import java.sql.Timestamp;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateTimeDeserializer;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateTimeSerializer;");
                        i++;
                    }
                    if (col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        if (j > 0)
                            continue;
                        sb.AppendLine("import java.sql.Date;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateDeserializer;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateSerializer;");
                        j++;
                    }
                    if (col.DataType.DbDataType.ToUpper() == "YEAR")
                    {
                        if (j > 0)
                            continue;
                        sb.AppendLine("import java.sql.Date;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateDeserializer;");
                        sb.AppendLine("import com.esint.common.jsonSerializer.JsonDateSerializer;");
                        j++;
                    }
                }
            }



            sb.AppendLine("/**");
            sb.AppendLine(" * " + Tbl.TableName + " 表的实体对象");
            sb.AppendLine(" * 文件说明: " + Tbl.TableDescription + "信息实体");
            sb.AppendLine(" * 作   者: " + this.OperName);
            sb.AppendLine(" * 生成日期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine(" * 生成模板: Esint.Template.Model.JAVA_Model 版");
            sb.AppendLine(" * 修改说明：");
            sb.AppendLine(" */");
            //去掉表名中的第一个 T
            string NewPascalName = Tbl.PascalName;
            if (Tbl.PascalName.IndexOf('T') == 0 || Tbl.PascalName.IndexOf('R') == 0 || Tbl.PascalName.IndexOf('G') == 0 || Tbl.PascalName.IndexOf('Z') == 0 || Tbl.PascalName.IndexOf('J') == 0 || Tbl.PascalName.IndexOf('D') == 0)
            {
                NewPascalName = Tbl.PascalName.Substring(1, Tbl.PascalName.Length - 1);
            }
            //if (cbx_BaseModel.Text.Trim() == "")
            //    sb.Append("    public  class " + NewPascalName);
            //else
            sb.Append("public class " + NewPascalName + " implements Serializable ");

            sb.AppendLine(" {");//类第一个大括号
            //属性开始
            sb.AppendLine("// 属性开始");
            //固定的头一行
            sb.AppendLine("	private static final long serialVersionUID = 1L;");
            foreach (IColumn col in Tbl.Columns)//循环添加属性
            {
                sb.AppendLine("	//" + col.Description);

                #region 添加验证

                if (DataAccess.DataBaseType == "ORACLE")
                {
                    if (col.DataType.DbDataType.ToUpper() == "NVARCHAR2")
                    {
                        sb.AppendLine("@Length(max = " + (col.ColumnLength * 0.5) + ", message = \"" + col.Description + "最大长度不能超过{max}\")");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "CHAR")
                    {
                        sb.AppendLine("@Length(max = 1, message = \"" + col.Description + "最大长度不能超过{max}\")");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "NUMBER")
                    {
                        sb.AppendLine("@Digits(integer = 16, fraction = 2, message = \"" + col.Description + "整数部分不能超过{integer}位,小数部分不能超过{fraction}位\")");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.DATE_REG, message = RegularConstant.DATE_MSG)");
                    }

                    if (col.Description.Contains("手机") || col.Description.Contains("移动电话"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.MOBILE_REG, message = RegularConstant.MOBILE_MSG)");
                    }
                    if (col.Description.Contains("电话") || col.Description.Contains("固话"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.TEL_REG, message = RegularConstant.TEL_MSG)");
                    }
                    if (col.Description.Contains("传真"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.FAX_REG, message = RegularConstant.FAX_MSG)");
                    }
                    if (col.Description.Contains("邮箱") || col.Description.ToUpper().Contains("EMAIL"))
                    {
                        sb.AppendLine("@Email(message = \"邮箱格式错误\")");
                    }
                    if (col.Description.Contains("身份证"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.ID_CARD_REG, message = RegularConstant.ID_CARD_MSG)");
                    }
                    if (col.Description.Contains("邮编") || col.Description.Contains("邮政编码"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.ZIP_REG, message = RegularConstant.ZIP_MSG)");
                    }
                    if (col.Description.Contains("网址") || col.Description.Contains("网站"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.URL_REG, message = RegularConstant.URL_MSG)");
                    }
                }

                if (DataAccess.DataBaseType == "MYSQL")
                {
                    if (col.DataType.DbDataType.ToUpper() == "VARCHAR")
                    {
                        sb.AppendLine("@Length(max = " + (col.ColumnLength) + ", message = \"" + col.Description + "最大长度不能超过{max}\")");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "CHAR")
                    {
                        sb.AppendLine("@Length(max = 1, message = \"" + col.Description + "最大长度不能超过{max}\")");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "DOUBLE" || col.DataType.DbDataType.ToUpper() == "DECIMAL")
                    {
                        sb.AppendLine("@Digits(integer = 16, fraction = 2, message = \"" + col.Description + "整数部分不能超过{integer}位,小数部分不能超过{fraction}位\")");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "DATETIME")
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.DATE_REG, message = RegularConstant.DATE_MSG)");
                    }
                    if (col.Description.Contains("手机") || col.Description.Contains("移动电话"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.MOBILE_REG, message = RegularConstant.MOBILE_MSG)");
                    }
                    if (col.Description.Contains("电话") || col.Description.Contains("固话"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.TEL_REG, message = RegularConstant.TEL_MSG)");
                    }
                    if (col.Description.Contains("传真"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.FAX_REG, message = RegularConstant.FAX_MSG)");
                    }
                    if (col.Description.Contains("邮箱") || col.Description.ToUpper().Contains("EMAIL"))
                    {
                        sb.AppendLine("@Email(message = \"邮箱格式错误\")");
                    }
                    if (col.Description.Contains("身份证"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.ID_CARD_REG, message = RegularConstant.ID_CARD_MSG)");
                    }
                    if (col.Description.Contains("邮编") || col.Description.Contains("邮政编码"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.ZIP_REG, message = RegularConstant.ZIP_MSG)");
                    }
                    if (col.Description.Contains("网址") || col.Description.Contains("网站"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.URL_REG, message = RegularConstant.URL_MSG)");
                    }
                }

                if (DataAccess.DataBaseType == "SQLSERVER")
                {
                    if (col.DataType.DbDataType.ToUpper() == "NVARCHAR")
                    {
                        sb.AppendLine("@Length(max = " + (col.ColumnLength) + ", message = \"" + col.Description + "最大长度不能超过{max}\")");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "CHAR")
                    {
                        sb.AppendLine("@Length(max = 1, message = \"" + col.Description + "最大长度不能超过{max}\")");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "FLOAT" || col.DataType.DbDataType.ToUpper() == "DECIMAL"||col.DataType.DbDataType.ToUpper() == "NUMERIC"||col.DataType.DbDataType.ToUpper() == "MONEY")
                    {
                        sb.AppendLine("@Digits(integer = 16, fraction = 2, message = \"" + col.Description + "整数部分不能超过{integer}位,小数部分不能超过{fraction}位\")");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "DATETIME")
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.DATE_REG, message = RegularConstant.DATE_MSG)");
                    }

                    if (col.Description.Contains("手机") || col.Description.Contains("移动电话"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.MOBILE_REG, message = RegularConstant.MOBILE_MSG)");
                    }
                    if (col.Description.Contains("电话") || col.Description.Contains("固话"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.TEL_REG, message = RegularConstant.TEL_MSG)");
                    }
                    if (col.Description.Contains("传真"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.FAX_REG, message = RegularConstant.FAX_MSG)");
                    }
                    if (col.Description.Contains("邮箱") || col.Description.ToUpper().Contains("EMAIL"))
                    {
                        sb.AppendLine("@Email(message = \"邮箱格式错误\")");
                    }
                    if (col.Description.Contains("身份证"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.ID_CARD_REG, message = RegularConstant.ID_CARD_MSG)");
                    }
                    if (col.Description.Contains("邮编") || col.Description.Contains("邮政编码"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.ZIP_REG, message = RegularConstant.ZIP_MSG)");
                    }
                    if (col.Description.Contains("网址") || col.Description.Contains("网站"))
                    {
                        sb.AppendLine("@Pattern(regexp = RegularConstant.URL_REG, message = RegularConstant.URL_MSG)");
                    }
                }

                #endregion

                sb.AppendLine("	private " + col.DataType.CSharpType + " " + OneStringLower(col.PascalName) + ";");
            }
            //属性结束
            sb.AppendLine("// 属性结束");
            sb.AppendLine("");


            //构造器开始
            sb.AppendLine("// 构造器开始");
            //默认构造器
            sb.AppendLine("	/**");
            sb.AppendLine("	* 默认构造器");
            sb.AppendLine("	*/");
            sb.AppendLine("	public " + NewPascalName + "() {");
            sb.AppendLine("        }");
            //全属性构造器
            sb.AppendLine("	/**");
            sb.AppendLine("	* 全属性构造器");
            sb.AppendLine("	*/");
            string JavaType = "";
            foreach (IColumn col in Tbl.Columns)//循环添加全构造器参数
            {
                JavaType += col.DataType.CSharpType + " " + OneStringLower(col.PascalName) + ",";
            }
            //如果有属性，则去掉最后一个属性后面的逗号
            if (JavaType != "")
            {
                JavaType = JavaType.Substring(0, JavaType.Length - 1);
            }
            sb.AppendLine("	public " + NewPascalName + "(" + JavaType + ") {");
            foreach (IColumn col in Tbl.Columns)//循环添加方法内的赋值
            {
                sb.AppendLine("		this." + OneStringLower(col.PascalName) + " = " + OneStringLower(col.PascalName) + ";");
            }
            sb.AppendLine("        }");
            //构造器结束
            sb.AppendLine("// 构造器结束");
            sb.AppendLine("");
            //get set方法
            sb.AppendLine("// 属性访问方法开始");
            foreach (IColumn col in Tbl.Columns)//循环添加方法内的赋值
            {
                sb.AppendLine("	/**");
                sb.AppendLine("	* 获取属性" + col.Description);
                sb.AppendLine("	*/");
                if (DataAccess.DataBaseType == "ORACLE")
                {
                    //if (col.DataType.DbDataType.ToUpper() == "TIMESTAMP")
                    //{
                    //    sb.AppendLine("@JsonSerialize(using = JsonDateTimeSerializer.class)");
                    //}
                    //if (col.DataType.DbDataType.ToUpper() == "DATE")
                    //{
                    //    sb.AppendLine("@JsonSerialize(using = JsonDateSerializer.class)");
                    //}
                }
                if ((DataAccess.DataBaseType == "SQLSERVER"))
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATETIME")
                    {
                        sb.AppendLine("@JsonSerialize(using = JsonDateTimeSerializer.class)");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        sb.AppendLine("@JsonSerialize(using = JsonDateSerializer.class)");
                    }
                }
                if (DataAccess.DataBaseType == "MYSQL")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        sb.AppendLine("@JsonSerialize(using = JsonDateSerializer.class)");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "DATETIME")
                    {
                        sb.AppendLine("@JsonSerialize(using = JsonDateTimeSerializer.class)");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "TIMESTAMP")
                    {
                        sb.AppendLine("@JsonSerialize(using = JsonDateTimeSerializer.class)");
                    }
                }

                sb.AppendLine("	public " + col.DataType.CSharpType + " get" + OneStringUpper(col.PascalName) + "() {");
                sb.AppendLine("		return " + OneStringLower(col.PascalName) + ";");
                sb.AppendLine("        }");
                sb.AppendLine("");


                sb.AppendLine("	/**");
                sb.AppendLine("	* 设置属性" + col.Description);
                sb.AppendLine("	*/");
                if (DataAccess.DataBaseType == "ORACLE")
                {
                    //if (col.DataType.DbDataType.ToUpper() == "TIMESTAMP")
                    //{
                    //    sb.AppendLine("@JsonDeserialize(using = JsonDateTimeDeserializer.class)");
                    //}
                    //if (col.DataType.DbDataType.ToUpper() == "DATE")
                    //{
                    //    sb.AppendLine("@JsonDeserialize(using = JsonDateDeserializer.class)");
                    //}
                }
                if ((DataAccess.DataBaseType == "SQLSERVER"))
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATETIME")
                    {
                        sb.AppendLine("@JsonDeserialize(using = JsonDateTimeDeserializer.class)");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        sb.AppendLine("@JsonDeserialize(using = JsonDateDeserializer.class)");
                    }
                }
                if ((DataAccess.DataBaseType == "MYSQL"))
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        sb.AppendLine("@JsonDeserialize(using = JsonDateDeserializer.class)");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "DATETIME")
                    {
                        sb.AppendLine("@JsonDeserialize(using = JsonDateTimeDeserializer.class)");
                    }
                    if (col.DataType.DbDataType.ToUpper() == "TIMESTAMP")
                    {
                        sb.AppendLine("@JsonDeserialize(using = JsonDateTimeDeserializer.class)");
                    }
                }

                sb.AppendLine("	public void set" + OneStringUpper(col.PascalName) + "(" + col.DataType.CSharpType + " " + OneStringLower(col.PascalName) + ") {");
                sb.AppendLine("		this." + OneStringLower(col.PascalName) + " = " + OneStringLower(col.PascalName) + ";");
                sb.AppendLine("        }");
                sb.AppendLine("");
            }
            sb.AppendLine("// 属性访问方法结束");
            sb.AppendLine("}");//类结束最后一个大括号

            return sb;
        }

        private StringBuilder CreateModel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using Esint.Common;");
            sb.AppendLine("using Esint.Common.Model;");
            sb.AppendLine("");
            sb.AppendLine("namespace " + string.Format(NameSpace, DataAccess.AppName));
            sb.AppendLine("{");
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 文件说明: " + Tbl.TableDescription + "信息实体");
            sb.AppendLine("    /// 作    者: " + this.OperName);
            sb.AppendLine("    /// 生成日期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine("    /// 生成模板: Esint.Template.Model.Model_01 版");
            sb.AppendLine("    /// 修改说明：");
            sb.AppendLine("    /// </summary>");
            if (cbx_BaseModel.Text.Trim() == "")
                sb.AppendLine("    public partial class " + Tbl.PascalName + "Info : BaseModel");
            else
                sb.AppendLine("    public partial class " + Tbl.PascalName + "Info : " + cbx_BaseModel.Text);


            sb.AppendLine("    {");

            // 如果不是批量生成，则根据选择生成相关属性
            if (!IsPackage)
            {
                foreach (DataGridViewRow row in gv_SubTable.Rows)
                {
                    if (row.Cells[0].EditedFormattedValue.ToString() == "True")
                    {
                        IDbTable subTable = Tbls.Find(delegate(IDbTable s) { return s.TableName == row.Cells[1].EditedFormattedValue.ToString(); });

                        sb.AppendLine("        // <summary>");
                        sb.AppendLine("        // " + subTable.TableDescription);
                        sb.AppendLine("        // </summary>");
                        sb.AppendLine("        private List<" + subTable.PascalName + "Info> _" + subTable.CamelName + ";");
                        sb.AppendLine("        public List<" + subTable.PascalName + "Info> " + subTable.PascalName + "List");
                        sb.AppendLine("        {");
                        sb.AppendLine("            get");
                        sb.AppendLine("            {");
                        sb.AppendLine("                if (_" + subTable.CamelName + " == null)");
                        sb.AppendLine("                   _" + subTable.CamelName + " = new List<" + subTable.PascalName + "Info>();");
                        sb.AppendLine("                return _" + subTable.CamelName + ";");
                        sb.AppendLine("            }");
                        sb.AppendLine("            set");
                        sb.AppendLine("            {");
                        sb.AppendLine("                _" + subTable.CamelName + " = value;");
                        sb.AppendLine("            }");
                        sb.AppendLine("        }");
                        sb.AppendLine();
                    }
                }
            }
            sb.AppendLine("    ");
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb;
        }

        private void btn_AddTable_Click(object sender, EventArgs e)
        {

            Esint.TemplateCommon.SelectTable select_Table_Form = new Esint.TemplateCommon.SelectTable(DataAccess, ConnectString);

            select_Table_Form.ShowDialog();

            foreach (IDbTable dbtable in select_Table_Form.Tables)
            {
                Tbls.Add(dbtable);
                gv_SubTable.Rows.Add(new object[] { true, dbtable.TableName, dbtable.TableDescription });
            }

        }


    }
}
