using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Esint.CodeBuilder.Public;
using Esint.CodeBuilder.Model;
using Esint.CodeBuilder.BLL;
using Esint.CodeBuilder.InterFace;

namespace Esint.CodeBuilder.Forms
{
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
        }

        #region 链接窗口加载初始化

        /// <summary>
        /// 连接窗口加载事件
        /// 作者:刘伟通
        /// 日期:2010年8月1日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectForm_Load(object sender, EventArgs e)
        {
            //根据当前配置,显示连接设置面板
            cbx_DataBaseType.SelectedItem = PublicClass.DataBaseType.ToCode();

            //根据设置,回填连接设置项
            switch (PublicClass.DataBaseType)
            {
                case DataBaseType.SqlServer:
                    txt_ServerAddr.Text = GetConnectStringConfValue("server");
                    txt_SqlUserName.Text = GetConnectStringConfValue("User ID");
                    txt_SqlPassWord.Text = GetConnectStringConfValue("Password");
                    txt_SqlDbName.Text = GetConnectStringConfValue("database");
                    break;
                case DataBaseType.Oracle:
                    txt_serviceName.Text = GetConnectStringConfValue("Data Source");
                    txt_UserName.Text = GetConnectStringConfValue("User ID");
                    txt_password.Text = GetConnectStringConfValue("Password");
                    break;
            }
        }

        /// <summary>
        /// 根据配置名,获取连接串配置值
        /// 作者:刘伟通
        /// 日期:2010年8月1日
        /// </summary>
        /// <param name="ConfigName"></param>
        /// <returns></returns>
        private string GetConnectStringConfValue(string ConfigName)
        {
            string[] cstrs = PublicClass.ConnectString.Split(';');
            foreach (string cstr in cstrs)
            {
                if (cstr.IndexOf(ConfigName) == 0)
                    return cstr.Split('=')[1];
            }
            return "";
        }

        #endregion

        #region 测试连接数据库

        /// <summary>
        /// Oracle面板 测试连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CheckOraConn_Click(object sender, EventArgs e)
        {
            if (CheckOracleVali())
            {
                TestConnectOracle();
            }
        }

        /// <summary>
        /// SqlServer 面板,测试连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SqlCheckConn_Click(object sender, EventArgs e)
        {
            if (CheckSqlVali())
            {
                TestConnectSql();
            }
        }

        /// <summary>
        /// MySql 面板,测试连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_MySqlCheckConn_Click(object sender, EventArgs e)
        {
            if (CheckMySqlVali())
            {
                TestConnectMySql();
            }
        }

        /// <summary>
        /// 测试连接到Oracle 数据库
        /// </summary>
        private void TestConnectOracle()
        {
            //建立连接字符串
            string oracleConnectString = "User ID={0};Password={1};Data Source={2};".ToUpper();
            oracleConnectString = string.Format(oracleConnectString, txt_UserName.Text, txt_password.Text, txt_serviceName.Text);

            PublicClass.DataBaseType = DataBaseType.Oracle;
            // 建立Oracle业务处理对象
            ICodeBuilder codeBuilderBLL = Factory.CreateCodeBuilderBLL();

            //测试连接
            bool isSucc = codeBuilderBLL.TestConnect(oracleConnectString);

            //显示测试结果
            if (isSucc)
            {
                btn_Connect.Enabled = true;
                MessageBox.Show("连接测试成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btn_Connect.Enabled = false;
                MessageBox.Show("连接测试失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 测试SQLServer数据库连接
        /// 作者:刘伟通
        /// 日期:2010年8月1日
        /// </summary>
        private void TestConnectSql()
        {
            // 建立链接字符串
            string sqlConnectString = "server={0};User ID={1};Password={2};database={3};Connection Reset=true;Max Pool Size = 512";
            sqlConnectString = string.Format(sqlConnectString, txt_ServerAddr.Text, txt_SqlUserName.Text, txt_SqlPassWord.Text, txt_SqlDbName.Text);
            PublicClass.DataBaseType = DataBaseType.SqlServer;
            // 创键SqlServer业务处理对象
            ICodeBuilder codeBuilderBLL = Factory.CreateCodeBuilderBLL();

            //测试数据库连接
            bool isSucc = codeBuilderBLL.TestConnect(sqlConnectString);

            //显示测试结果
            if (isSucc)
            {
                btn_Connect.Enabled = true;
                MessageBox.Show("连接测试成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btn_Connect.Enabled = false;
                MessageBox.Show("连接测试失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 测试MySQL数据库连接
        /// 作者:刘伟通
        /// 日期:2010年8月1日
        /// </summary>
        private void TestConnectMySql()
        {
            // 建立链接字符串
            string sqlConnectString = "Data Source={0};Database={1};User Id={2};Password={3};Allow Zero DateTime=true;";
            sqlConnectString = string.Format(sqlConnectString, txt_MySqlAddr.Text, txt_MySqlDbName.Text, txt_MySqlUserName.Text, txt_MySqlPassWord.Text);
            PublicClass.DataBaseType = DataBaseType.MySql;
            // 创键SqlServer业务处理对象
            ICodeBuilder codeBuilderBLL = Factory.CreateCodeBuilderBLL();

            //测试数据库连接
            bool isSucc = codeBuilderBLL.TestConnect(sqlConnectString);

            //显示测试结果
            if (isSucc)
            {
                btn_Connect.Enabled = true;
                MessageBox.Show("连接测试成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btn_Connect.Enabled = false;
                MessageBox.Show("连接测试失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 连接按钮单击事件

        /// <summary>
        /// 连接按钮单击事件
        /// 作者:刘伟通
        /// 日期:2010年8月1日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (!CheckVali())
            {
                return;
            }
            //设置当前数据库类型为选择的数据库类型 
            PublicClass.DataBaseType = EnumExtend.ToDataBaseType(cbx_DataBaseType.SelectedItem.ToString());

            //打开系统配置XML文件 
            XmlDocument xDoc = XMLHelper.xmlDoc(PublicClass.SystemConfigFile);
            string sqlConnectString = "";

            // 根据数据库类型,设置接字符串
            switch (PublicClass.DataBaseType)
            {
                case DataBaseType.SqlServer:
                    XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "DataBaseType"), "SqlServer"); //更新数据库类型
                    sqlConnectString = "server={0};User ID={1};Password={2};database={3};Connection Reset=true;Max Pool Size=512";
                    PublicClass.ConnectString = string.Format(sqlConnectString, txt_ServerAddr.Text, txt_SqlUserName.Text, txt_SqlPassWord.Text, txt_SqlDbName.Text);
                    PublicClass.DataBaseName = txt_SqlDbName.Text;
                    XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "DBUserID"), txt_SqlUserName.Text);
                    break;
                case DataBaseType.Oracle:
                    XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "DataBaseType"), "Oracle");
                    sqlConnectString = "User ID={0};Password={1};Data Source={2};";
                    PublicClass.ConnectString = string.Format(sqlConnectString, txt_UserName.Text, txt_password.Text, txt_serviceName.Text);
                    PublicClass.DataBaseName = txt_serviceName.Text;
                    XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "DBUserID"), txt_UserName.Text);
                    break;
                case DataBaseType.MySql:
                    XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "DataBaseType"), "MySql");
                    sqlConnectString = "Data Source={0};Database={1};User Id={2};Password={3};Allow Zero DateTime=true;";
                    PublicClass.ConnectString = string.Format(sqlConnectString, txt_MySqlAddr.Text, txt_MySqlDbName.Text, txt_MySqlUserName.Text, txt_MySqlPassWord.Text);
                    PublicClass.DataBaseName = txt_MySqlDbName.Text;
                    XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "DBUserID"), txt_MySqlUserName.Text);
                    break;
            }

            //更新配置文件
            XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "ConnectString"), PublicClass.ConnectString);
            XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "DataBaseName"), PublicClass.DataBaseName);
            //保存配置文件
            xDoc.Save(PublicClass.SystemConfigFile);

            //设置连接状态为己连接
            PublicClass.IsConnect = true;

            new frm_Main().InitializeApply();
            //关闭对话框
            this.Close();
        }
        #endregion

        #region  数据库类型改变事件

        /// <summary>
        /// 数据库类型改变事件
        /// 控制显示连接设置面板
        /// 作者:刘伟通
        /// 日期:2010年8月1日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_DataBaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbx_DataBaseType.SelectedItem.ToString().ToUpper())
            {
                case "SQLSERVER":
                    pan_Sql.Visible = true;
                    pan_MySql.Visible = false;
                    pan_Oracle.Visible = false;
                    break;
                case "ORACLE":
                    pan_Sql.Visible = false;
                    pan_MySql.Visible = false;
                    pan_Oracle.Visible = true;
                    break;
                case "MYSQL":
                    pan_Sql.Visible = false;
                    pan_MySql.Visible = true;
                    pan_Oracle.Visible = false;
                    break;
            }
        }
        #endregion

        #region 验证方法
        /// <summary>
        /// 验证Sql面板必填项目
        /// </summary>
        /// <returns></returns>
        private bool CheckSqlVali()
        {
            if (txt_ServerAddr.Text == "")
            {
                MessageBox.Show("服务器地址不能为空;", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txt_SqlDbName.Text == "")
            {
                MessageBox.Show("数据库名称不能为空;", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txt_SqlUserName.Text == "")
            {
                MessageBox.Show("用户名不能为空;", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txt_SqlPassWord.Text == "")
            {
                MessageBox.Show("口令不能为空;", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证MySql面板必填项目
        /// </summary>
        /// <returns></returns>
        private bool CheckMySqlVali()
        {
            if (txt_MySqlAddr.Text == "")
            {
                MessageBox.Show("服务器地址不能为空;", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txt_MySqlDbName.Text == "")
            {
                MessageBox.Show("数据库名称不能为空;", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txt_MySqlUserName.Text == "")
            {
                MessageBox.Show("用户名不能为空;", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txt_MySqlPassWord.Text == "")
            {
                MessageBox.Show("口令不能为空;", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证Sql面板必填项目
        /// </summary>
        /// <returns></returns>
        private bool CheckOracleVali()
        {
            if (txt_serviceName.Text == "")
            {
                MessageBox.Show("服务名不能为空;");
                return false;
            }

            if (txt_UserName.Text == "")
            {
                MessageBox.Show("用户名不能为空;");
                return false;
            }

            if (txt_password.Text == "")
            {
                MessageBox.Show("口令不能为空;");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证输入项
        /// </summary>
        /// <returns></returns>
        public bool CheckVali()
        {
            switch (cbx_DataBaseType.SelectedItem.ToString().ToUpper())
            {
                case "SQLSERVER":
                    return CheckSqlVali();
                case "ORACLE":
                    return CheckOracleVali();
                case "MYSQL":
                    return CheckMySqlVali();
            }
            return false;
        }
        #endregion

        /// <summary>
        /// 关闭对话框 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
