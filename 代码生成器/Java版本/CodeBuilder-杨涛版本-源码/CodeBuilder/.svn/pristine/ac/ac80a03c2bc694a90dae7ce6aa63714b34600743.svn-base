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

namespace Esint.CodeBuilder.Forms
{
    public partial class frm_SysConfig : Form
    {
        public frm_SysConfig()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 页面加载,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_SysConfig_Load(object sender, EventArgs e)
        {
            //打开系统配置XML文件 
            txt_TableHead.Text = XMLHelper.GetNode(PublicClass.SystemConfigFile, "TableHeaderString").InnerText;
            txt_OperName.Text = XMLHelper.GetNode(PublicClass.SystemConfigFile, "OperName").InnerText;
            txt_DbName.Text = XMLHelper.GetNode(PublicClass.SystemConfigFile, "DataBaseName").InnerText;
            txt_SqlText.Text = XMLHelper.GetNode(PublicClass.SystemConfigFile, "CodeSelectSQL").InnerText;
            txt_CodeSql.Text = XMLHelper.GetNode(PublicClass.SystemConfigFile, "CodeSQL").InnerText;
            txt_AppName.Text = XMLHelper.GetNode(PublicClass.SystemConfigFile, "AppName").InnerText;
            cbx_IsOpen.Checked = XMLHelper.GetNode(PublicClass.SystemConfigFile, "IsOpenFolder").InnerText == "1" ? true : false;
        }

        /// <summary>
        /// 保存设置,并使设置生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (!CheckVali())
            {
                return;
            } 
            //打开系统配置XML文件 
            XmlDocument xDoc = XMLHelper.xmlDoc(PublicClass.SystemConfigFile);

            XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "TableHeaderString"), txt_TableHead.Text);
            XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "OperName"), txt_OperName.Text);
            XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "DataBaseName"), txt_DbName.Text);
            XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "CodeSelectSQL"), txt_SqlText.Text);
            XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "CodeSQL"), txt_CodeSql.Text);
            XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "AppName"), txt_AppName.Text);
            XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc,"IsOpenFolder"),cbx_IsOpen.Checked?"1":"0");

            PublicClass.TableHeaderString = txt_TableHead.Text.Trim();
            PublicClass.DataBaseName = txt_DbName.Text;
            PublicClass.CodeSQL = txt_CodeSql.Text;
            PublicClass.CodeSelectSQL = txt_SqlText.Text;
            PublicClass.OperName = txt_OperName.Text;
            PublicClass.IsOpenFolder = cbx_IsOpen.Checked ? "1" : "0";
            //保存配置文件
            xDoc.Save(PublicClass.SystemConfigFile);
            //关闭对话框
            this.Close();
        }

        /// <summary>
        /// 验证界面完整性
        /// </summary>
        /// <returns></returns>
        private bool CheckVali()
        {
            if (string.IsNullOrEmpty(txt_OperName.Text))
            {
                MessageBox.Show("请填写 操作者!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txt_DbName.Text))
            {
                MessageBox.Show("请填写 数据库名称!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txt_TableHead.Text))
            {
                MessageBox.Show("请填写 表头字串!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txt_SqlText.Text))
            {
                MessageBox.Show("请填写 查询代码类SQL文本!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

       
    }
}
