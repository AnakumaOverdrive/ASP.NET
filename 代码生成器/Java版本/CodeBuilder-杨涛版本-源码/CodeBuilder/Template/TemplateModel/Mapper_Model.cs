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
    public partial class Mapper_Model : Form, ITemplate
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

        public Mapper_Model()
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
            IReturnCode[] returnCode = new IReturnCode[2];
            returnCode[0] = new ReturnCode();
            //去掉表名中的第一个 T
            string NewFileName = Tbl.PascalName;
            if (Tbl.PascalName.IndexOf('T') == 0 || Tbl.PascalName.IndexOf('R') == 0 || Tbl.PascalName.IndexOf('G') == 0 || Tbl.PascalName.IndexOf('Z') == 0 || Tbl.PascalName.IndexOf('J') == 0 || Tbl.PascalName.IndexOf('D') == 0)
            {
                NewFileName = Tbl.PascalName.Substring(1, Tbl.PascalName.Length - 1);
            }
            returnCode[0].FileName = String.Format(NewFileName + "Mapper.java", NewFileName);
            returnCode[0].CodeText = CreateModelDesigner();
            returnCode[0].CodeType = "JAVA";

            returnCode[1] = new ReturnCode();
            returnCode[1].FileName = String.Format(NewFileName + "Mapper.xml", NewFileName);
            returnCode[1].CodeText = CreateModel();
            returnCode[1].CodeType = "JAVA";
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
                cbx_BaseModel.Items.Add(db.PascalName + "Info");
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
        /// JAVA使用的生成方法 Mapper.java
        /// </summary>
        /// <returns></returns>
        private StringBuilder CreateModelDesigner()
        {
            StringBuilder sb = new StringBuilder();

            //去掉表名中的第一个 T
            string NewPascalName = Tbl.PascalName;
            if (Tbl.PascalName.IndexOf('T') == 0 || Tbl.PascalName.IndexOf('R') == 0 || Tbl.PascalName.IndexOf('G') == 0 || Tbl.PascalName.IndexOf('Z') == 0 || Tbl.PascalName.IndexOf('J') == 0 || Tbl.PascalName.IndexOf('D') == 0)
            {
                NewPascalName = Tbl.PascalName.Substring(1, Tbl.PascalName.Length - 1);
            }
            //头信息
            sb.AppendLine("package " + string.Format(NameSpace, DataAccess.AppName) + ".mapper;");
            sb.AppendLine(" ");
            //包的引入
            sb.AppendLine("import com.esint.common.mapper.BaseMapper;");
            sb.AppendLine("import " + string.Format(NameSpace, DataAccess.AppName) + ".pojo." + NewPascalName + ";");

            sb.AppendLine("/**");
            sb.AppendLine(" * " + NewPascalName + " 数据映射接口");
            sb.AppendLine(" * 作    者: " + this.OperName);
            sb.AppendLine(" * 生成日期: " + DateTime.Now.ToString("yyyy年MM月dd日"));
            sb.AppendLine(" * 修改说明：");
            sb.AppendLine(" */");
            sb.AppendLine("public interface " + NewPascalName + "Mapper extends BaseMapper<" + NewPascalName + ", " + GetPrimaryDataType() + "> {");
            sb.AppendLine(" ");
            sb.AppendLine("}");

            return sb;
        }

        /// <summary>
        /// JAVA使用的生成方法 Mapper.xml
        /// </summary>
        /// <returns></returns>
        private StringBuilder CreateModel()
        {
            StringBuilder sb = new StringBuilder();
            //去掉表名中的第一个 T
            string NewPascalName = Tbl.PascalName;
            if (Tbl.PascalName.IndexOf('T') == 0 || Tbl.PascalName.IndexOf('R') == 0 || Tbl.PascalName.IndexOf('G') == 0 || Tbl.PascalName.IndexOf('Z') == 0 || Tbl.PascalName.IndexOf('J') == 0 || Tbl.PascalName.IndexOf('D') == 0)
            {
                NewPascalName = Tbl.PascalName.Substring(1, Tbl.PascalName.Length - 1);
            }

            #region//生成头文件
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sb.AppendLine("<!DOCTYPE mapper PUBLIC \"-//mybatis.org//DTD Mapper 3.0//EN\" \"http://mybatis.org/dtd/mybatis-3-mapper.dtd\" >");
            #endregion

            #region//生成 mapper及其下面的resultMap
            sb.AppendLine("<mapper namespace=\"" + string.Format(NameSpace, DataAccess.AppName) + ".mapper." + NewPascalName + "Mapper\">");
            sb.AppendLine("	<resultMap id=\"BaseResultMap\" type=\"" + string.Format(NameSpace, DataAccess.AppName) + ".pojo." + NewPascalName + "\">");
            foreach (IColumn col in Tbl.Columns)//循环添加属性节点
            {
                if (col.IsPrimaryKey)
                {
                    sb.AppendLine("		<id column=\"" + col.ColumnName.ToUpper() + "\" property=\"" + OneStringLower(col.PascalName) + "\" jdbcType=\"" + col.DataType.DbType.ToUpper() + "\" />");
                }
                else
                {
                    sb.AppendLine("		<result column=\"" + col.ColumnName.ToUpper() + "\" property=\"" + OneStringLower(col.PascalName) + "\" jdbcType=\"" + col.DataType.DbType.ToUpper() + "\" />");
                }
            }
            sb.AppendLine("	</resultMap>");
            #endregion

            #region //生成 Base_Column_List
            sb.AppendLine("<sql id=\"Base_Column_List\">");
            string Base_Column_List = "";
            string Base_Column_List2 = "";
            foreach (IColumn col in Tbl.Columns)//循环添加属性节点
            {
                if (DataAccess.DataBaseType == "ORACLE")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        Base_Column_List += "TO_CHAR(" + col.ColumnName.ToUpper() + ",'YYYY-MM-DD HH24:MI:SS') " + col.ColumnName.ToUpper() + ", ";
                    }
                    else
                    {
                        Base_Column_List += col.ColumnName.ToUpper() + ", ";
                    }
                }
                if (DataAccess.DataBaseType == "SQLSERVER")
                {
                    Base_Column_List += col.ColumnName.ToUpper() + ", ";
                }
                if (DataAccess.DataBaseType == "MYSQL")
                {
                    Base_Column_List += col.ColumnName.ToUpper() + ", ";
                }

                //批量添加使用
                Base_Column_List2 += col.ColumnName.ToUpper() + ", ";
            }
            //如果有字段则删除最后的逗号
            if (Base_Column_List != "")
            {
                Base_Column_List = Base_Column_List.Substring(0, Base_Column_List.Length - 2);
            }
            if (Base_Column_List2 != "")
            {
                Base_Column_List2 = Base_Column_List2.Substring(0, Base_Column_List2.Length - 2);
            }
            sb.AppendLine("		" + Base_Column_List);
            sb.AppendLine("</sql>");
            #endregion

            #region //生成 Base_Count
            sb.AppendLine("<sql id=\"Base_Count\">");
            sb.AppendLine("		SELECT COUNT(0) FROM " + Tbl.TableName);
            sb.AppendLine("</sql>");
            #endregion

            #region //生成 Base_Select
            sb.AppendLine("<sql id=\"Base_Select\">");
            sb.AppendLine("		SELECT");
            sb.AppendLine("		<include refid=\"Base_Column_List\" />");
            sb.AppendLine("		FROM " + Tbl.TableName);
            sb.AppendLine("</sql>");
            #endregion

            #region //生成 Base_Where
            sb.AppendLine("<sql id=\"Base_Where\">");
            sb.AppendLine("		<where>");
            foreach (IColumn col in Tbl.Columns)//循环添加属性节点
            {
                if (DataAccess.DataBaseType == "ORACLE")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                        sb.AppendLine("				 AND " + col.ColumnName.ToUpper() + " = TO_DATE(#{" + OneStringLower(col.PascalName) + "},'YYYY-MM-DD HH24:MI:SS')");
                        sb.AppendLine("			</if>");
                    }
                    else if (col.DataType.DbDataType.ToUpper() == "NUMBER" || col.DataType.DbDataType.ToUpper() == "INTEGER")
                    {
                        sb.AppendLine("		    <if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                        sb.AppendLine("			 	 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                        sb.AppendLine("		    </if>");
                    }
                    else
                    {
                        sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                        sb.AppendLine("				 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                        sb.AppendLine("			</if>");
                    }
                }
                if (DataAccess.DataBaseType == "SQLSERVER")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DECIMAL" || col.DataType.DbDataType.ToUpper() == "INT" || col.DataType.DbDataType.ToUpper() == "FLOAT" || col.DataType.DbDataType.ToUpper() == "MONEY" || col.DataType.DbDataType.ToUpper() == "NUMERIC")
                    {
                        sb.AppendLine("		    <if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                        sb.AppendLine("			 	 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                        sb.AppendLine("		    </if>");
                    }
                    else
                    {
                        sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                        sb.AppendLine("				 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                        sb.AppendLine("			</if>");
                    }
                }
                if (DataAccess.DataBaseType == "MYSQL")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DECIMAL" || col.DataType.DbDataType.ToUpper() == "INTEGER" || col.DataType.DbDataType.ToUpper() == "INT" || col.DataType.DbDataType.ToUpper() == "FLOAT" || col.DataType.DbDataType.ToUpper() == "DOUBLE")
                    {
                        sb.AppendLine("		    <if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                        sb.AppendLine("			 	 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                        sb.AppendLine("		    </if>");
                    }
                    else
                    {
                        sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                        sb.AppendLine("				 AND " + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "}");
                        sb.AppendLine("			</if>");
                    }
                }
            }
            sb.AppendLine("		</where>");
            sb.AppendLine("</sql>");
            #endregion

            #region //生成 Base_Sort
            sb.AppendLine("<sql id=\"Base_Sort\">");
            sb.AppendLine("		<if test=\"_parameter.getSortParam().size() != 0\">");
            sb.AppendLine("			ORDER BY");
            sb.AppendLine("			<foreach collection=\"_parameter.getSortParam()\" item=\"sortParam\"");
            sb.AppendLine("				separator=\",\">");
            sb.AppendLine("				${sortParam.column} ${sortParam.order}");
            sb.AppendLine("			</foreach>");
            sb.AppendLine("		</if>");
            sb.AppendLine("</sql>");
            #endregion

            #region //生成 Base_Page
            if (DataAccess.DataBaseType == "ORACLE")
            {
                #region //生成 Base_Page(Oracle 11g及以下版本)
                sb.AppendLine("<sql id=\"Base_Page_Begin\">");
                sb.AppendLine("		<if test=\"isPage == 1\">");
                sb.AppendLine("			SELECT * FROM (SELECT A.*,ROWNUM RN FROM (");
                sb.AppendLine("		</if>");
                sb.AppendLine("</sql>");

                sb.AppendLine("<sql id=\"Base_Page_End\">");
                sb.AppendLine("		<if test=\"isPage == 1\">");
                sb.AppendLine("			) A WHERE ROWNUM <![CDATA[<= #{_end}) WHERE RN >= #{_begin}]]>");
                sb.AppendLine("		</if>");
                sb.AppendLine("</sql>");
                #endregion

                #region //生成 Base_Page(Oracle12c)
                //sb.AppendLine("<sql id=\"Base_Page\">");
                //sb.AppendLine("		<if test=\"isPage == 1\">");
                //sb.AppendLine("			offset #{_offset} row fetch next #{_pagesize} rows only");
                //sb.AppendLine("		</if>");
                //sb.AppendLine("</sql>");
                #endregion
            }
            if (DataAccess.DataBaseType == "SQLSERVER")
            {
                #region //生成 Base_Page
                sb.AppendLine("<sql id=\"Base_Page\">");
                sb.AppendLine("		<if test=\"isPage == 1\">");
                sb.AppendLine("			offset #{_offset} row fetch next #{_pagesize} rows only");
                sb.AppendLine("		</if>");
                sb.AppendLine("</sql>");
                #endregion
            }
            if (DataAccess.DataBaseType == "MYSQL")
            {
                #region //生成 Base_Page
                sb.AppendLine("<sql id=\"Base_Page\">");
                sb.AppendLine("		<if test=\"isPage == 1\">");
                sb.AppendLine("			limit #{_offset}, #{_pagesize}");
                sb.AppendLine("		</if>");
                sb.AppendLine("</sql>");
                #endregion
            }
            #endregion


            //获得主键列
            IColumn PK_Column = Tbl.Columns.Find(o => o.IsPrimaryKey == true);

            //基于主键条件等于号的的 where 语句条件
            string PKColumns = "		WHERE " + PK_Column.ColumnName.ToUpper() + " = #{" + OneStringLower(PK_Column.PascalName) + "}";

            sb.AppendLine("<!-- 基础方法 开始 -->");

            #region//生成insert方法
            sb.AppendLine("<insert id=\"insert\" parameterType=\"" + string.Format(NameSpace, DataAccess.AppName) + ".pojo." + NewPascalName + "\">");

            sb.AppendLine("<selectKey resultType=\"string\" keyProperty=\"" + OneStringLower(PK_Column.PascalName) + "\" order=\"BEFORE\">");
            //ORACLE主键
            if (DataAccess.DataBaseType == "ORACLE")
            {
                sb.AppendLine("SELECT SYS_GUID() FROM DUAL");
            }
            //SQLSERVER主键
            if (DataAccess.DataBaseType == "SQLSERVER")
            {
                sb.AppendLine("SELECT NEWID()");
            }
            //MYSQL主键
            if (DataAccess.DataBaseType == "MYSQL")
            {
                sb.AppendLine("SELECT UUID()");
            }
            sb.AppendLine("</selectKey>");

            sb.AppendLine("		INSERT INTO " + Tbl.TableName);
            //拼接insert的字段
            sb.AppendLine("		<trim prefix=\"(\" suffix=\")\" suffixOverrides=\",\">");
            foreach (IColumn col in Tbl.Columns)//循环添加属性节点
            {
                if (DataAccess.DataBaseType == "ORACLE")
                {
                    if (col.DataType.DbDataType.ToUpper() == "NUMBER" || col.DataType.DbDataType.ToUpper() == "INTEGER")
                    {
                        sb.AppendLine("		<if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                        sb.AppendLine("				" + col.ColumnName.ToUpper() + ",");
                        sb.AppendLine("		</if>");
                    }
                    else
                    {
                        sb.AppendLine("		<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                        sb.AppendLine("				" + col.ColumnName.ToUpper() + ",");
                        sb.AppendLine("		</if>");
                    }
                }
                if (DataAccess.DataBaseType == "SQLSERVER")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DECIMAL" || col.DataType.DbDataType.ToUpper() == "INT" || col.DataType.DbDataType.ToUpper() == "FLOAT" || col.DataType.DbDataType.ToUpper() == "MONEY" || col.DataType.DbDataType.ToUpper() == "NUMERIC")
                    {
                        sb.AppendLine("		<if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                        sb.AppendLine("				" + col.ColumnName.ToUpper() + ",");
                        sb.AppendLine("		</if>");
                    }
                    else
                    {
                        sb.AppendLine("		<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                        sb.AppendLine("				" + col.ColumnName.ToUpper() + ",");
                        sb.AppendLine("		</if>");
                    }
                }
                if (DataAccess.DataBaseType == "MYSQL")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DECIMAL" || col.DataType.DbDataType.ToUpper() == "INTEGER" || col.DataType.DbDataType.ToUpper() == "INT" || col.DataType.DbDataType.ToUpper() == "FLOAT" || col.DataType.DbDataType.ToUpper() == "DOUBLE")
                    {
                        sb.AppendLine("		<if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                        sb.AppendLine("				" + col.ColumnName.ToUpper() + ",");
                        sb.AppendLine("		</if>");
                    }
                    else
                    {
                        sb.AppendLine("		<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                        sb.AppendLine("				" + col.ColumnName.ToUpper() + ",");
                        sb.AppendLine("		</if>");
                    }
                }
            }
            sb.AppendLine("		</trim>");
            //拼接insert的字段对应的values
            sb.AppendLine("		<trim prefix=\"values (\" suffix=\")\" suffixOverrides=\",\">");
            foreach (IColumn col in Tbl.Columns)//循环添加属性节点
            {
                if (DataAccess.DataBaseType == "ORACLE")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                        sb.AppendLine("				 	TO_DATE(#{" + OneStringLower(col.PascalName) + "},'YYYY-MM-DD HH24:MI:SS'),");
                        sb.AppendLine("			</if>");
                    }
                    else if (col.DataType.DbDataType.ToUpper() == "NUMBER" || col.DataType.DbDataType.ToUpper() == "INTEGER")
                    {
                        sb.AppendLine("		    <if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                        sb.AppendLine("				 	#{" + OneStringLower(col.PascalName) + "},");
                        sb.AppendLine("		    </if>");
                    }
                    else
                    {
                        sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                        sb.AppendLine("				 	#{" + OneStringLower(col.PascalName) + "},");
                        sb.AppendLine("			</if>");
                    }
                }
                if (DataAccess.DataBaseType == "SQLSERVER")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DECIMAL" || col.DataType.DbDataType.ToUpper() == "INT" || col.DataType.DbDataType.ToUpper() == "FLOAT" || col.DataType.DbDataType.ToUpper() == "MONEY" || col.DataType.DbDataType.ToUpper() == "NUMERIC")
                    {
                        sb.AppendLine("		    <if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                        sb.AppendLine("				 	#{" + OneStringLower(col.PascalName) + "},");
                        sb.AppendLine("		    </if>");
                    }
                    else
                    {
                        sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                        sb.AppendLine("				 	#{" + OneStringLower(col.PascalName) + "},");
                        sb.AppendLine("			</if>");
                    }
                }
                if (DataAccess.DataBaseType == "MYSQL")
                {
                    if (col.DataType.DbDataType.ToUpper() == "DECIMAL" || col.DataType.DbDataType.ToUpper() == "INTEGER" || col.DataType.DbDataType.ToUpper() == "INT" || col.DataType.DbDataType.ToUpper() == "FLOAT" || col.DataType.DbDataType.ToUpper() == "DOUBLE")
                    {
                        sb.AppendLine("		    <if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                        sb.AppendLine("				 	#{" + OneStringLower(col.PascalName) + "},");
                        sb.AppendLine("		    </if>");
                    }
                    else
                    {
                        sb.AppendLine("			<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                        sb.AppendLine("				 	#{" + OneStringLower(col.PascalName) + "},");
                        sb.AppendLine("			</if>");
                    }
                }
            }
            sb.AppendLine("		</trim>");
            sb.AppendLine("	</insert>");
            #endregion

            #region //生成insertBatch方法
            if (DataAccess.DataBaseType == "ORACLE")
            {
                string Column_List = "";
                foreach (IColumn col in Tbl.Columns)//循环添加属性节点
                {
                    if (col.DataType.DbDataType.ToUpper() == "DATE")
                    {
                        Column_List += "TO_DATE(#{item." + OneStringLower(col.PascalName) + "}" + ",'YYYY-MM-DD HH24:MI:SS'), ";
                    }
                    else
                    {
                        Column_List += "#{item." + OneStringLower(col.PascalName) + "}, ";
                    }
                }
                //如果有字段则删除最后的逗号
                if (Column_List != "")
                {
                    Column_List = Column_List.Substring(0, Column_List.Length - 2);
                }
                sb.AppendLine("<insert id=\"insertBatch\" parameterType=\"list\">");
                sb.AppendLine("		INSERT INTO");
                sb.AppendLine("     " + Tbl.TableName + "(" + Base_Column_List2 + ")");
                sb.AppendLine("     <foreach collection=\"list\" item=\"item\" separator=\"UNION ALL\">");
                sb.AppendLine("	    	SELECT " + Column_List + " FROM DUAL");
                sb.AppendLine("     </foreach>");
                sb.AppendLine("</insert>");
            }
            else
            {
                string Column_List = "";
                foreach (IColumn col in Tbl.Columns)//循环添加属性节点
                {
                    Column_List += "#{item." + OneStringLower(col.PascalName) + "}, ";
                }
                //如果有字段则删除最后的逗号
                if (Column_List != "")
                {
                    Column_List = Column_List.Substring(0, Column_List.Length - 2);
                }
                sb.AppendLine("<insert id=\"insertBatch\" parameterType=\"list\">");
                sb.AppendLine("		INSERT INTO");
                sb.AppendLine("     " + Tbl.TableName + "(" + Base_Column_List2 + ")");
                sb.AppendLine("     VALUES");
                sb.AppendLine("     <foreach collection=\"list\" item=\"item\" separator=\",\">");
                sb.AppendLine("	    	(" + Column_List + ")");
                sb.AppendLine("     </foreach>");
                sb.AppendLine("</insert>");
            }
            #endregion

            #region//生成delete方法
            sb.AppendLine("<delete id=\"delete\" parameterType=\"string\">");
            sb.AppendLine("		DELETE FROM " + Tbl.TableName);
            sb.AppendLine("		WHERE " + PK_Column.ColumnName.ToUpper());
            sb.AppendLine("		= #{" + OneStringLower(PK_Column.PascalName) + "}");
            sb.AppendLine("</delete>");
            #endregion

            #region//生成deleteBatch方法
            sb.AppendLine("<delete id=\"deleteBatch\" parameterType=\"list\">");
            sb.AppendLine("		DELETE FROM " + Tbl.TableName);
            sb.AppendLine("		WHERE " + PK_Column.ColumnName.ToUpper() + " IN ");
            sb.AppendLine("		<foreach collection=\"list\" item=\"" + OneStringLower(PK_Column.PascalName) + "\" open=\"(\" close=\")\" separator=\",\">");
            sb.AppendLine("		#{" + OneStringLower(PK_Column.PascalName) + "}");
            sb.AppendLine("		</foreach>");
            sb.AppendLine("</delete>");
            #endregion

            #region//生成update方法
            sb.AppendLine("<update id=\"update\" parameterType=\"" + string.Format(NameSpace, DataAccess.AppName) + ".pojo." + NewPascalName + "\">");
            sb.AppendLine("		UPDATE " + Tbl.TableName);
            sb.AppendLine("		<set>");
            foreach (IColumn col in Tbl.Columns)//循环添加属性节点
            {
                if (!col.IsPrimaryKey)
                {
                    if (DataAccess.DataBaseType == "ORACLE")
                    {
                        if (col.DataType.DbDataType.ToUpper() == "DATE")
                        {
                            sb.AppendLine("		<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                            sb.AppendLine("				" + col.ColumnName.ToUpper() + " = TO_DATE(#{" + OneStringLower(col.PascalName) + "},'YYYY-MM-DD HH24:MI:SS'),");
                            sb.AppendLine("		</if>");
                        }
                        else if (col.DataType.DbDataType.ToUpper() == "NUMBER" || col.DataType.DbDataType.ToUpper() == "INTEGER")
                        {
                            sb.AppendLine("		<if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                            sb.AppendLine("			 	" + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "},");
                            sb.AppendLine("		</if>");
                        }
                        else
                        {
                            sb.AppendLine("		<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                            sb.AppendLine("			 	" + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "},");
                            sb.AppendLine("		</if>");
                        }
                    }
                    if (DataAccess.DataBaseType == "SQLSERVER")
                    {
                        if (col.DataType.DbDataType.ToUpper() == "DECIMAL" || col.DataType.DbDataType.ToUpper() == "INT" || col.DataType.DbDataType.ToUpper() == "FLOAT" || col.DataType.DbDataType.ToUpper() == "MONEY" || col.DataType.DbDataType.ToUpper() == "NUMERIC")
                        {
                            sb.AppendLine("		<if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                            sb.AppendLine("			 	" + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "},");
                            sb.AppendLine("		</if>");
                        }
                        else
                        {
                            sb.AppendLine("		<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                            sb.AppendLine("			 	" + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "},");
                            sb.AppendLine("		</if>");
                        }
                    }
                    if (DataAccess.DataBaseType == "MYSQL")
                    {
                        if (col.DataType.DbDataType.ToUpper() == "DECIMAL" || col.DataType.DbDataType.ToUpper() == "INTEGER" || col.DataType.DbDataType.ToUpper() == "INT" || col.DataType.DbDataType.ToUpper() == "FLOAT" || col.DataType.DbDataType.ToUpper() == "DOUBLE")
                        {
                            sb.AppendLine("		<if test=\"(" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != '') or " + OneStringLower(col.PascalName) + " == 0\">");
                            sb.AppendLine("			 	" + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "},");
                            sb.AppendLine("		</if>");
                        }
                        else
                        {
                            sb.AppendLine("		<if test=\"" + OneStringLower(col.PascalName) + " != null and " + OneStringLower(col.PascalName) + " != ''\">");
                            sb.AppendLine("			 	" + col.ColumnName.ToUpper() + " = #{" + OneStringLower(col.PascalName) + "},");
                            sb.AppendLine("		</if>");
                        }
                    }
                }
            }
            sb.AppendLine("		</set>");
            //添加基于主键条件等于号的的 where 语句条件
            sb.AppendLine(PKColumns);
            sb.AppendLine("</update>");
            #endregion

            #region//生成selectByID方法
            sb.AppendLine("<select id=\"selectByID\" resultMap=\"BaseResultMap\" parameterType=\"string\">");
            sb.AppendLine("		<include refid=\"Base_Select\" />");
            //添加基于主键条件等于号的的 where 语句条件
            sb.AppendLine(PKColumns);
            sb.AppendLine("</select>");
            #endregion

            #region//生成select方法
            //基于Oracle12c的分页
            if (DataAccess.DataBaseType == "ORACLE")
            {
                #region 老版本分页
                sb.AppendLine("<select id=\"select\" resultMap=\"BaseResultMap\" parameterType=\"param\">");
                sb.AppendLine("		<include refid=\"Base_Page_Begin\" />");
                sb.AppendLine("		<include refid=\"Base_Select\" />");
                sb.AppendLine("		<include refid=\"Base_Where\" />");
                sb.AppendLine("		<include refid=\"Base_Sort\" />");
                sb.AppendLine("		<include refid=\"Base_Page_End\" />");
                sb.AppendLine("</select>");
                #endregion

                #region Oracle12c 分页
                //sb.AppendLine("<select id=\"select\" resultMap=\"BaseResultMap\" parameterType=\"param\">");
                //sb.AppendLine("		<include refid=\"Base_Select\" />");
                //sb.AppendLine("		<include refid=\"Base_Where\" />");
                //sb.AppendLine("		<include refid=\"Base_Sort\" />");
                //sb.AppendLine("		<include refid=\"Base_Page\" />");
                //sb.AppendLine("</select>");
                #endregion
            }
            //基于SqlServer2012的分页
            if (DataAccess.DataBaseType == "SQLSERVER")
            {
                sb.AppendLine("<select id=\"select\" resultMap=\"BaseResultMap\" parameterType=\"param\">");
                sb.AppendLine("		<include refid=\"Base_Select\" />");
                sb.AppendLine("		<include refid=\"Base_Where\" />");
                sb.AppendLine("		<include refid=\"Base_Sort\" />");
                sb.AppendLine("		<include refid=\"Base_Page\" />");
                sb.AppendLine("</select>");
            }
            //基于MySql
            if (DataAccess.DataBaseType == "MYSQL")
            {
                #region 作废
                //sb.AppendLine("<select id=\"select\" resultMap=\"BaseResultMap\" parameterType=\"param\">");
                //sb.AppendLine("	  <include refid=\"Base_Select\" />");
                //sb.AppendLine("     <choose>");
                //sb.AppendLine("         <when test=\"isPage == 1\">");
                //sb.AppendLine("             inner join (");
                //sb.AppendLine("             select " + PK_Column.ColumnName.ToUpper() + " from " + Tbl.TableName);
                //sb.AppendLine("		        <include refid=\"Base_Where\" />");
                //sb.AppendLine("		        <include refid=\"Base_Sort\" />");
                //sb.AppendLine("             limit #{_offset}, #{_pagesize}");
                //sb.AppendLine("             ) as page using(" + PK_Column.ColumnName.ToUpper() + ")");
                //sb.AppendLine("         </when>");
                //sb.AppendLine("         <otherwise>");
                //sb.AppendLine("		        <include refid=\"Base_Where\" />");
                //sb.AppendLine("		        <include refid=\"Base_Sort\" />");
                //sb.AppendLine("         </otherwise>");
                //sb.AppendLine("     </choose>");
                //sb.AppendLine("</select>");
                #endregion

                sb.AppendLine("<select id=\"select\" resultMap=\"BaseResultMap\" parameterType=\"param\">");
                sb.AppendLine("		<include refid=\"Base_Select\" />");
                sb.AppendLine("		<include refid=\"Base_Where\" />");
                sb.AppendLine("		<include refid=\"Base_Sort\" />");
                sb.AppendLine("		<include refid=\"Base_Page\" />");
                sb.AppendLine("</select>");
            }
            #endregion

            #region//生成selectCount方法
            sb.AppendLine("<select id=\"selectCount\" resultType=\"_int\" parameterType=\"param\">");
            sb.AppendLine("		<include refid=\"Base_Count\" />");
            sb.AppendLine("		<include refid=\"Base_Where\" />");
            sb.AppendLine("</select>");
            #endregion

            sb.AppendLine("<!-- 基础方法 结束 -->");

            sb.AppendLine("<!-- 扩展方法 开始 -->");
            sb.AppendLine("<!-- 扩展方法 结束 -->");

            sb.AppendLine("</mapper>");
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
    }
}
