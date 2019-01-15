using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Esint.CodeBuilder.BLL;
using Esint.CodeBuilder.InterFace;
using Esint.CodeBuilder.Model;
using Esint.CodeBuilder.Public;
using System.Collections.Generic;
using System.Diagnostics;
using Esint.CodeBuilder.WebSite;

namespace Esint.CodeBuilder.Forms
{
    public partial class frm_Main : Form
    {
         public frm_Main()
         {}
        public frm_Main(Welcome w)
        {
            w.lbl_Status.Text = "正在初始化窗体...";
            w.Refresh();

            InitializeComponent();

            w.lbl_Status.Text = "正在初始化数据...";
            w.Refresh();


            //初始化系统
            InitializeApply();

            w.lbl_Status.Text = "正在连接知识库...";
            w.Refresh();
            if (PublicClass.WebServer.Trim() != "")
            {
                try
                {
                    // 加载知识库树
                    LoadCategoryTree();
                }
                catch
                {
                    MessageBox.Show("无法连接知识库，请检查配置是否正确及网络是否通畅！");
                }
            }
            w.Close();
        }

        #region 系统初始化



        /// <summary>
        /// 系统变量初始化
        /// </summary>
        public void InitializeApply()
        {
            //
            // 读取系统配置信息
            //
            try
            {
                //得到系统配置文件
                PublicClass.SystemConfigFile = Application.StartupPath + "\\Config\\SysConfig.xml";

                //得到模板配置文件
                PublicClass.ModelConfigFile = Application.StartupPath + "\\Config\\ModelConfig.xml";

                //得到模板配置列表
                PublicClass.TemplateList = BuilderTemplateList(PublicClass.ModelConfigFile);

                //得到数据库名称
                PublicClass.DataBaseName = XMLHelper.GetNode(PublicClass.SystemConfigFile, "DataBaseName").InnerText;

                //得到数据库连接字符串
                PublicClass.ConnectString = XMLHelper.GetNode(PublicClass.SystemConfigFile, "ConnectString").InnerText;

                //得到表头字符串
                PublicClass.TableHeaderString = XMLHelper.GetNode(PublicClass.SystemConfigFile, "TableHeaderString").InnerText;

                //得到代码表查询语句
                PublicClass.CodeSelectSQL = XMLHelper.GetNode(PublicClass.SystemConfigFile, "CodeSelectSQL").InnerText;

                //得到应用名称
                PublicClass.AppName = XMLHelper.GetNode(PublicClass.SystemConfigFile, "AppName").InnerText;

                //得到数据库类型
                PublicClass.DataBaseType = EnumExtend.ToDataBaseType(XMLHelper.GetNode(PublicClass.SystemConfigFile, "DataBaseType").InnerText);

                //得到当前操作者姓名
                PublicClass.OperName = XMLHelper.GetNode(PublicClass.SystemConfigFile, "OperName").InnerText;

                //得到当前数据库用户ID
                PublicClass.DbUserID = XMLHelper.GetNode(PublicClass.SystemConfigFile, "DBUserID").InnerText;

                //得到是否自动打开文件夹
                PublicClass.IsOpenFolder = XMLHelper.GetNode(PublicClass.SystemConfigFile, "IsOpenFolder").InnerText;


                //得到代码查询语句
                PublicClass.CodeSQL = XMLHelper.GetNode(PublicClass.SystemConfigFile, "CodeSQL").InnerText;

                PublicClass.WebServer = XMLHelper.GetNode(PublicClass.SystemConfigFile, "WebServer").InnerText;


                //根据数据库类型得到数据类型配置转换文件
                switch (PublicClass.DataBaseType)
                {
                    case DataBaseType.Oracle:
                        PublicClass.DataTypeConfigFile = Application.StartupPath + "\\Config\\OracleDataTypeConvert.xml";
                        break;

                    case DataBaseType.SqlServer:
                        PublicClass.DataTypeConfigFile = Application.StartupPath + "\\Config\\SqlServerDataTypeConvert.xml";
                        break;

                    case DataBaseType.MySql:
                        PublicClass.DataTypeConfigFile = Application.StartupPath + "\\Config\\MySqlDataTypeConvert.xml";
                        break;
                }
                //得到数据类型转换列表
                PublicClass.DataTypeList = CommBLL.GetDataTypeList(PublicClass.DataTypeConfigFile);

                //建立业务处理对象
                ICodeBuilder codeBuilderBLL = Factory.CreateCodeBuilderBLL();

                //测试是否可以连接到数据库
                bool isCanConnect = codeBuilderBLL.TestConnect(PublicClass.ConnectString);

                //如果不能连接,抛出异常
                if (!isCanConnect)
                    throw new Exception("未能连接数据库，检查和设置数据库连接！");


                if (tv_Tree != null)
                    //绑定树型控件
                    tv_Tree_Binding();

                if (PublicClass.WebServer != "")
                {
                    if (webBrowser1 != null)
                        webBrowser1.Url = new Uri(PublicClass.WebServer + "Default.aspx");
                }

                if (panel1 != null)
                    panel1.Visible = false;  //隐去网页


                if (tsm_Builder != null)
                    //绑定批量生成下拉菜单
                    BindingMTemplateMenu();

            }
            catch (System.Exception ex)
            {
                PublicClass.IsConnect = false;
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tsm_Builder != null)
            //绑定右击菜单(根据模板配置文件 ModelConfig.xml 绑定)
            ContextMenuModelBinding();
        }


        public void LoadCategoryTree()
        {
            // 
            WebSiteService ws = new WebSiteService();
            Info_CategoryInfo [] cateArray = ws.GetCategoryList("0", Guid.Empty);

            List<Info_CategoryInfo> cateList = new List<Info_CategoryInfo>();
            foreach (Info_CategoryInfo cate in cateArray)
            {
                cateList.Add(cate);
            }

            Info_CategoryInfo rootCate = cateList.Find(c => c.ParentCategory == Guid.Empty);
            foreach (Info_CategoryInfo cate in cateList.FindAll(c => c.ParentCategory == rootCate.CategoryID))
            { 
                TreeNode tn = new TreeNode();
                tn.Text=cate.CategoryName;
                tn.Tag = cate.CategoryID;
                tn.ImageIndex = 2;
                treeView1.Nodes.Add(tn);
                if (cateList.Find(c => c.ParentCategory == cate.CategoryID) != null)
                {
                    AddNode(tn, cateList);
                }
            }
        }

        public void AddNode(TreeNode node, List<Info_CategoryInfo> categoryList)
        {
            foreach (Info_CategoryInfo cate in categoryList.FindAll(c => c.ParentCategory == (Guid)node.Tag ))
            {
                TreeNode tn = new TreeNode();
                tn.Text = cate.CategoryName;
                tn.Tag = cate.CategoryID;
                tn.ImageIndex = 2;
                 node.Nodes.Add(tn);
                if (categoryList.Find(c => c.ParentCategory == cate.CategoryID) != null)
                {
                    AddNode(tn, categoryList);
                }
            }
        }


        /// <summary>
        /// 根据模板配置文件,生成模板配置对象列表
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="TemplateConfigFile"></param>
        /// <returns></returns>
        public List<TemplateConfig> BuilderTemplateList(string TemplateConfigFile)
        {

            List<TemplateConfig> templateList = new List<TemplateConfig>();
            //建立XML文档对象
            System.Xml.XmlDocument document = new System.Xml.XmlDataDocument();

            //加载模板配置文件(ModelConfig.XML)
            document.Load(TemplateConfigFile);

            //
            // 根据XML配置文件 生成配置对象列表
            //
            for (int i = 0; i < document.ChildNodes[1].ChildNodes.Count; i++)
            {
                TemplateConfig template = new TemplateConfig();
                template.Key = document.ChildNodes[1].ChildNodes[i].Attributes["Key"].Value;
                template.Path = document.ChildNodes[1].ChildNodes[i].Attributes["Path"].Value;
                template.ClassName = document.ChildNodes[1].ChildNodes[i].Attributes["ClassName"].Value;
                template.Title = document.ChildNodes[1].ChildNodes[i].Attributes["Title"].Value;
                template.FileName = document.ChildNodes[1].ChildNodes[i].Attributes["FileName"].Value;
                template.FilePath = document.ChildNodes[1].ChildNodes[i].Attributes["FilePath"].Value;
                template.CodeType = document.ChildNodes[1].ChildNodes[i].Attributes["CodeType"].Value;
                template.NameSpace = document.ChildNodes[1].ChildNodes[i].Attributes["NameSpace"].Value;
                template.IsMBuilder = document.ChildNodes[1].ChildNodes[i].Attributes["IsMBuilder"].Value.ToUpper() == "FALSE" ? false : true;
                if (document.ChildNodes[1].ChildNodes[i].Attributes["IsWeb"]!=null)
                    template.IsWeb = document.ChildNodes[1].ChildNodes[i].Attributes["IsWeb"].Value.ToUpper() == "FALSE" ? false : true;
          
                if (document.ChildNodes[1].ChildNodes[i].Attributes["SignFile"] != null)
                    template.IsSignFile = document.ChildNodes[1].ChildNodes[i].Attributes["SignFile"].Value.ToUpper() == "FALSE" ? false : true;

                templateList.Add(template);
            }
            return templateList;
        }

        #endregion

        #region 绑定模板菜单

        /// <summary>
        /// 绑定批量生成下拉菜单
        /// </summary>
        private void BindingMTemplateMenu()
        {
            foreach (TemplateConfig template in PublicClass.TemplateList)
            {
                if (template.IsMBuilder)
                {
                    //建立弹出菜单项
                    ToolStripMenuItem menuItem = new System.Windows.Forms.ToolStripMenuItem();

                    //菜单项的文本
                    menuItem.Text = template.Title;

                    //菜单项的Tag 为模板配置项的Key
                    menuItem.Tag = template.Key;

                    //是否有效
                    // menuItem.Enabled = template.IsBuilder;

                    //绑定菜单项的单击事件
                    menuItem.Click += new EventHandler(M_MenuItemClick);

                    tsm_Builder.DropDownItems.Add(menuItem);
                }
            }
        }


        /// <summary>
        /// 根据模板配置文件,绑定右击菜单
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        private void ContextMenuModelBinding()
        {
            //建立右击菜单数据项数组
            System.Windows.Forms.ToolStripItem[] contextMenuItems = new System.Windows.Forms.ToolStripItem[PublicClass.TemplateList.Count];

            int i = 0;
            foreach (TemplateConfig template in PublicClass.TemplateList)
            {
                //建立弹出菜单项
                ToolStripMenuItem menuItem = new System.Windows.Forms.ToolStripMenuItem();

                //菜单项的文本
                menuItem.Text = template.Title;

                //菜单项的Tag 为模板配置项的Key
                menuItem.Tag = template.Key;

                //是否有效
               // menuItem.Enabled = template.IsBuilder;

                //绑定菜单项的单击事件
                menuItem.Click += new EventHandler(MenuItemClick);

                //将菜单项添加到菜单数组
                contextMenuItems[i++] = menuItem;
            }

            //将菜单项数组,添加到弹出菜单
            popMenu_Template.Items.AddRange(contextMenuItems);
        }
        #endregion

        #region 菜单事件

        /// <summary>
        /// 右击弹出菜单项单击事件（单表生成）
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MenuItemClick(object sender, EventArgs e)
        {
            // 查询选中项的模板配置项
            TemplateConfig templateConf = PublicClass.TemplateList.Find(delegate(TemplateConfig t) { return t.Key == ((ToolStripItem)sender).Tag.ToString(); });

            TreeNode tn = tv_Tree.SelectedNode;

            //如果选中的结点是表
            if (tn.Tag.ToString() == "Table")
            {
                // 根据表名,查询表的详细信息
                IDbTable db = Factory.CreateCodeBuilderBLL().GetTableByTableName(PublicClass.ConnectString, tn.Text);

                //设置当前表为 选中结点的表
                PublicClass.CurrentTable = db;
            }

            //加载模板
            Assembly refObj = Assembly.LoadFrom(templateConf.Path);
            Type templ = refObj.GetType(templateConf.ClassName); //得到类名，用于反射

            // 反射得到模板实例
            object templateClass = refObj.CreateInstance(templateConf.ClassName);//反射

            // 将当前表注入到对象中
            PropertyInfo Tbl = templ.GetProperty("Tbl");

            Tbl.SetValue(templateClass, PublicClass.CurrentTable, null);

            // 将当前NameSpace注入到对象中
            PropertyInfo spc = templ.GetProperty("NameSpace");
            spc.SetValue(templateClass, templateConf.NameSpace, null);


            // 将当前OperName当前操作者 注入到对象中
            PropertyInfo oper = templ.GetProperty("OperName");
            oper.SetValue(templateClass, PublicClass.OperName, null);


            // 将文件名注入到对象中
            PropertyInfo fname = templ.GetProperty("FileName");
            fname.SetValue(templateClass, templateConf.FileName, null);



            // 将当前ConnectString当前连接字符串 注入到对象中
            PropertyInfo cstr = templ.GetProperty("ConnectString");
            cstr.SetValue(templateClass, PublicClass.ConnectString, null);

            // 将当前OperName当前数据库类型 注入到对象中
            PropertyInfo dataAccess = templ.GetProperty("DataAccess");
            dataAccess.SetValue(templateClass, Factory.CreateCodeBuilderBLL(), null);

            // 如果是Web层
            if (templateConf.IsWeb)
            {
                // 得到代码类别表
                PublicClass.CodeTypeList = Factory.CreateCodeBuilderBLL().GetCodeTypeList(PublicClass.ConnectString);

                // 将代码表传到模板
                PropertyInfo parasDic = templ.GetProperty("CodeTypeList");
                parasDic.SetValue(templateClass, PublicClass.CodeTypeList, null);

                //程序名称映射
                PropertyInfo appProperty = templ.GetProperty("AppName");
                appProperty.SetValue(templateClass, PublicClass.AppName, null);
            }

            // 执行模板中生成代码的方法
            MethodInfo buildercode = templ.GetMethod("GetCode");

            // 得到模板生成的代码数组
            PublicClass.ReturnCodes = (IReturnCode[])buildercode.Invoke(templateClass, null);

            //清除当前代码类下拉列表框 
            tscb_FileList.Items.Clear();

            //绑定生成的代码文件列表
            for (int i = 0; i < PublicClass.ReturnCodes.Length; i++)
            {
                tscb_FileList.Items.Add(PublicClass.ReturnCodes[i].FileName);
                PublicClass.ReturnCodes[i].FilePath = templateConf.FilePath;
            }
            tscb_FileList.SelectedIndex = 0;

            //显示第1组代码
            ShowCode(0);

        }

        /// <summary>
        /// 多表批量代码（多表生成）
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void M_MenuItemClick(object sender, EventArgs e)
        {
            // 查询选中项的模板配置项
            TemplateConfig templateConf = PublicClass.TemplateList.Find(delegate(TemplateConfig t) { return t.Key == ((ToolStripItem)sender).Tag.ToString(); });

            List<TreeNode> nodes = new List<TreeNode>();
            GetTreeCheckedNodes(tv_Tree.Nodes[0], nodes);

            if (templateConf.IsSignFile == false)
            {
                #region 生成每个单表
                foreach (TreeNode tn in nodes)
                {
                    //如果选中的结点是表
                    if (tn.Tag.ToString() == "Table")
                    {
                        // 根据表名,查询表的详细信息
                        IDbTable db = Factory.CreateCodeBuilderBLL().GetTableByTableName(PublicClass.ConnectString, tn.Text);

                        //设置当前表为 选中结点的表
                        PublicClass.CurrentTable = db;
                    }

                    //加载模板
                    Assembly refObj = Assembly.LoadFrom(templateConf.Path);
                    Type templ = refObj.GetType(templateConf.ClassName); //得到类名，用于反射

                    // 反射得到模板实例
                    object templateClass = refObj.CreateInstance(templateConf.ClassName);//反射


                    // 将是否批量生成标志
                    PropertyInfo isPackage = templ.GetProperty("IsPackage");

                    isPackage.SetValue(templateClass,true, null);

                    // 将当前表注入到对象中
                    PropertyInfo Tbl = templ.GetProperty("Tbl");
                    
                    Tbl.SetValue(templateClass, PublicClass.CurrentTable, null);

                    // 将当前NameSpace注入到对象中
                    PropertyInfo spc = templ.GetProperty("NameSpace");
                    spc.SetValue(templateClass, templateConf.NameSpace, null);


                    // 将当前OperName当前操作者 注入到对象中
                    PropertyInfo oper = templ.GetProperty("OperName");
                    oper.SetValue(templateClass, PublicClass.OperName, null);


                    // 将文件名注入到对象中
                    PropertyInfo fname = templ.GetProperty("FileName");
                    fname.SetValue(templateClass, templateConf.FileName, null);

                    // 如果是Web层
                    if (templateConf.IsWeb)
                    {
                        // 得到代码类别表
                        PublicClass.CodeTypeList = Factory.CreateCodeBuilderBLL().GetCodeTypeList(PublicClass.ConnectString);

                        // 将代码表传到模板
                        PropertyInfo parasDic = templ.GetProperty("CodeTypeList");
                        parasDic.SetValue(templateClass, PublicClass.CodeTypeList, null);

                        //程序名称映射
                        PropertyInfo appProperty = templ.GetProperty("AppName");
                        appProperty.SetValue(templateClass, PublicClass.AppName, null);
                    }

                    // 将当前OperName当前数据库类型 注入到对象中
                    PropertyInfo dataAccess = templ.GetProperty("DataAccess");
                    dataAccess.SetValue(templateClass, Factory.CreateCodeBuilderBLL(), null);

                    // 执行模板中生成代码的方法
                    MethodInfo buildercode = templ.GetMethod("GetCode");

                    // 得到模板生成的代码数组
                    PublicClass.ReturnCodes = (IReturnCode[])buildercode.Invoke(templateClass, null);

                    // 检查是否己经生成代码
                    if (PublicClass.ReturnCodes == null || PublicClass.ReturnCodes.Length == 0)
                    {
                        MessageBox.Show("没有生成可用代码[" + PublicClass.CurrentTable.TableName + "]!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    //检查文件保存路径,是否存在 
                    if (!Directory.Exists(templateConf.FilePath))
                    {
                        Directory.CreateDirectory(templateConf.FilePath);
                      //  MessageBox.Show("文件保存位置不存在,请检查路径:" + templateConf.FilePath + "是否存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       // return;
                    }

                    //检查所有的文件,是否有己存在的
                    bool is_Exists = false;
                    bool isReadOnly = false;
                    foreach (IReturnCode returnCode in PublicClass.ReturnCodes)
                    {
                        if (File.Exists(templateConf.FilePath + returnCode.FileName))
                        {
                            is_Exists = true;
                            isReadOnly = new FileInfo(templateConf.FilePath + returnCode.FileName).IsReadOnly;
                        }
                    }

                    if (is_Exists)
                    {
                        if (MessageBox.Show("文件已经存在,是否覆盖?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;
                    }

                    if (isReadOnly)
                    {
                        MessageBox.Show("代码没有签出,请签出后,再点击保存按钮!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (IReturnCode returnCode in PublicClass.ReturnCodes)
                    {
                        var utf8WithoutBom = new UTF8Encoding(false); 
                        StreamWriter sw = new StreamWriter(templateConf.FilePath + returnCode.FileName, false, utf8WithoutBom);
                        sw.Write(returnCode.CodeText.ToString());
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                    }
                }
                #endregion
            }
            else
            {
                List<IDbTable> tableList = new List<IDbTable>();

                foreach (TreeNode tn in nodes)
                {
                    //如果选中的结点是表
                    if (tn.Tag.ToString() == "Table")
                    {
                        // 根据表名,查询表的详细信息
                        tableList.Add(Factory.CreateCodeBuilderBLL().GetTableByTableName(PublicClass.ConnectString, tn.Text));
                    }
                }
                //加载模板
                Assembly refObj = Assembly.LoadFrom(templateConf.Path);
                Type templ = refObj.GetType(templateConf.ClassName); //得到类名，用于反射

                // 反射得到模板实例
                object templateClass = refObj.CreateInstance(templateConf.ClassName);//反射

                // 将是否批量生成标志
                PropertyInfo isPackage = templ.GetProperty("IsPackage");

                isPackage.SetValue(templateClass, false, null);

                // 将当前表注入到对象中
                PropertyInfo Tbl = templ.GetProperty("Tbl");

                Tbl.SetValue(templateClass, PublicClass.CurrentTable, null);

                // 将表列表注入到表中
                PropertyInfo Tbls = templ.GetProperty("Tbls");

                Tbls.SetValue(templateClass, tableList, null);

                // 将当前NameSpace注入到对象中
                PropertyInfo spc = templ.GetProperty("NameSpace");
                spc.SetValue(templateClass, templateConf.NameSpace, null);


                // 将当前OperName当前操作者 注入到对象中
                PropertyInfo oper = templ.GetProperty("OperName");
                oper.SetValue(templateClass, PublicClass.OperName, null);


                // 将当前ConnectString当前连接字符串 注入到对象中
                PropertyInfo cstr = templ.GetProperty("ConnectString");
                cstr.SetValue(templateClass, PublicClass.OperName, null);

                // 将当前OperName当前数据库类型 注入到对象中
                PropertyInfo dataAccess = templ.GetProperty("DataAccess");
                dataAccess.SetValue(templateClass, Factory.CreateCodeBuilderBLL(), null);


                // 将文件名注入到对象中
                PropertyInfo fname = templ.GetProperty("FileName");
                fname.SetValue(templateClass, templateConf.FileName, null);

                // 如果是Web层
                if (templateConf.IsWeb)
                {
                    // 得到代码类别表
                    PublicClass.CodeTypeList = Factory.CreateCodeBuilderBLL().GetCodeTypeList(PublicClass.ConnectString);

                    // 将代码表传到模板
                    PropertyInfo parasDic = templ.GetProperty("CodeTypeList");
                    parasDic.SetValue(templateClass, PublicClass.CodeTypeList, null);

                    //程序名称映射
                    PropertyInfo appProperty = templ.GetProperty("AppName");
                    appProperty.SetValue(templateClass, PublicClass.AppName, null);
                }

                // 执行模板中生成代码的方法
                MethodInfo buildercode = templ.GetMethod("GetCode");

                // 得到模板生成的代码数组
                PublicClass.ReturnCodes = (IReturnCode[])buildercode.Invoke(templateClass, null);

                //清除当前代码类下拉列表框 
                tscb_FileList.Items.Clear();

                //绑定生成的代码文件列表
                for (int i = 0; i < PublicClass.ReturnCodes.Length; i++)
                {
                    tscb_FileList.Items.Add(PublicClass.ReturnCodes[i].FileName);
                    PublicClass.ReturnCodes[i].FilePath = templateConf.FilePath;
                }
                tscb_FileList.SelectedIndex = 0;

                //显示第1组代码
                ShowCode(0);
            }
        }


        public void GetTreeCheckedNodes(TreeNode parentNode, List<TreeNode> nodes)
        {
             foreach(TreeNode node in parentNode.Nodes)
             {
                 if (node.Checked&&node.Text!="表"&&node.Text!="视图")
                     nodes.Add(node);
                 GetTreeCheckedNodes(node, nodes);
             }
        }

        #endregion

        /// <summary>
        /// 显示代码
        /// 作者:刘伟通
        /// 日期:2010年7月31日
        /// </summary>
        /// <param name="i"></param>
        public void ShowCode(int i)
        {
            StringBuilder sb = PublicClass.ReturnCodes[i].CodeText;
            //tsl_FileName.Tag = PublicClass.ReturnCodes[i].FilePath + PublicClass.ReturnCodes[i].FileName;
            //
            // tsl_FileName.Text = String.Format(PublicClass.ReturnCodes[i].FileName, PublicClass.CurrentTable.PascalName);
            txtEdit_Code.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingStrategyFactory.CreateHighlightingStrategy(PublicClass.ReturnCodes[i].CodeType);
            txtEdit_Code.Text = sb.ToString();
        }

        #region 绑定数据库对象

        /// <summary>
        /// 将数据表,数据视图绑定到tree控件
        /// 作者:刘伟通
        /// 日期:2010年7月30日
        /// </summary>
        public void tv_Tree_Binding()
        {
            ICodeBuilder codeBuilderBLL = Factory.CreateCodeBuilderBLL();

            //查询数据表列表
            List<IDbTable> tableList = new List<IDbTable>();
            tableList = codeBuilderBLL.GetTableList(PublicClass.ConnectString);

            //查询视图列表
            List<IDbTable> viewList = new List<IDbTable>();
            viewList = codeBuilderBLL.GetViewList(PublicClass.ConnectString);

            if (tv_Tree == null) return; 

            tv_Tree.Tag = "Table";
            tv_Tree.ImageList = imglist_DataBase;

            // 添加数据库结点
            TreeNode tn_DataBase = new TreeNode(PublicClass.DataBaseName, 3, 3);
            tn_DataBase.Tag = "DataBase";
            tv_Tree.Nodes.Add(tn_DataBase);

            // 添加表文件夹结点
            TreeNode tn_Table = new TreeNode("表", 2, 2);
            tn_Table.Tag = "FTable";
            tv_Tree.Nodes[0].Nodes.Add(tn_Table);

            //添加视图结点
            TreeNode tn_View = new TreeNode("视图", 2, 2);
            tn_View.Tag = "FView";
            tv_Tree.Nodes[0].Nodes.Add(tn_View);

            //
            // 绑定表结点
            //
            foreach (DbTable tb in tableList)
            {
                TreeNode tn = new TreeNode();
                tn.Text = tb.TableName;
                tn.SelectedImageIndex = 0;
                tn.ImageIndex = 0;
                tn.Tag = "Table";
                tv_Tree.Nodes[0].Nodes[0].Nodes.Add(tn);
            }

            //
            // 绑定视图结点
            //
            foreach (DbTable tb in viewList)
            {
                TreeNode tn = new TreeNode();
                tn.Text = tb.TableName;
                tn.SelectedImageIndex = 1;
                tn.ImageIndex = 1;
                tn.Tag = "View";
                tv_Tree.Nodes[0].Nodes[1].Nodes.Add(tn);
            }
        }
        #endregion

        /// <summary>
        /// 显示设置连接窗口
        /// </summary>
        private void ShowConnectForm()
        {
            ConnectForm connect_Form = new ConnectForm();
            connect_Form.ShowDialog();
            //如果连接成功，则绑定数据库对象

            if (PublicClass.IsConnect)
            {
                tv_Tree.Nodes.Clear();
                tv_Tree_Binding();
            }
        }

        /// <summary>
        /// 文件列表选择改变事件,改变加载相应的代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscb_FileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowCode(tscb_FileList.SelectedIndex);
        }

        /// <summary>
        /// 树型结点鼠标按下事件: 打开右键菜单
        /// 作者:刘伟通
        /// 日期:2010年7月31日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_Tree_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode mySelectedNode = tv_Tree.GetNodeAt(e.X, e.Y);

            if (mySelectedNode == null) return;

            tv_Tree.SelectedNode = mySelectedNode;
            if (e.Button == MouseButtons.Right)
            {
                tv_Tree.SelectedNode.ContextMenuStrip = popMenu_Template;
            }
            if (e.Button == MouseButtons.Left)
            {
                if (mySelectedNode.Text=="表" || mySelectedNode.Text=="视图")
                {
                    mySelectedNode.Checked = !mySelectedNode.Checked;
                    foreach (TreeNode tn in mySelectedNode.Nodes)
                    {
                        tn.Checked = mySelectedNode.Checked;
                    }
                }
            }
        }

        /// <summary>
        /// 设置菜单 --> 设置连接 单击事件
        /// 显示设置连接窗口
        /// 作者:刘伟通
        /// 日期:2010年7月31日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_SetConnect_Click(object sender, EventArgs e)
        {
            ShowConnectForm();
        }

        /// <summary>
        /// 保存全部按钮单击事件,保存本次生成全部代码文件
        /// 作者:刘伟通
        /// 日期:2010年7月31日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtn_SaveAll_Click(object sender, EventArgs e)
        {
            // 检查是否己经生成代码
            if (PublicClass.ReturnCodes == null || PublicClass.ReturnCodes.Length == 0)
            {
                MessageBox.Show("请先生成代码后,再点击保存按钮!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //检查文件保存路径,是否存在 
            if (!Directory.Exists(PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FilePath))
            {
                Directory.CreateDirectory(PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FilePath);
              //  MessageBox.Show("文件保存位置不存在,请检查路径:" + PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FilePath + "是否存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  return;
            }

            //检查所有的文件,是否有己存在的
            bool is_Exists = false;
            bool isReadOnly = false;
            foreach (IReturnCode returnCode in PublicClass.ReturnCodes)
            {
                if (File.Exists(returnCode.FilePath + returnCode.FileName))
                {
                    is_Exists = true;
                    isReadOnly = new FileInfo(returnCode.FilePath + returnCode.FileName).IsReadOnly;
                }
            }

            if (is_Exists)
            {
                if (MessageBox.Show("文件已经存在,是否覆盖?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            if (isReadOnly)
            {
                MessageBox.Show("代码没有签出,请签出后,再点击保存按钮!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fpath = "";
            foreach (IReturnCode returnCode in PublicClass.ReturnCodes)
            {
                var utf8WithoutBom = new UTF8Encoding(false);
                StreamWriter sw = new StreamWriter(returnCode.FilePath + returnCode.FileName, false, utf8WithoutBom);
              //  StreamWriter sw = new StreamWriter(returnCode.FilePath + returnCode.FileName, true, System.Text.Encoding.UTF8, 512);

                sw.Write(returnCode.CodeText.ToString());
                
                sw.Flush();
                sw.Close();
                sw.Dispose();
                fpath= returnCode.FilePath ;
            }
            MessageBox.Show("保存成功!", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (PublicClass.IsOpenFolder == "1")
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "explorer";
                //打开资源管理器
                proc.StartInfo.Arguments = @"" + fpath;
                //选中"notepad.exe"这个程序,即记事本
                proc.Start();
            }
        }

        /// <summary>
        /// 复制按钮单击事件,将当前窗口的代码复制到剪贴版
        /// 作者:刘伟通
        /// 日期:2010年7月31日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtn_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtEdit_Code.Text);
        }

        private void tsbtn_Save_Click(object sender, EventArgs e)
        {
            // 检查是否己经生成代码
            if (PublicClass.ReturnCodes == null || PublicClass.ReturnCodes.Length == 0)
            {
                MessageBox.Show("请先生成代码后,再点击保存按钮!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //检查文件保存路径,是否存在 
            if (!Directory.Exists(PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FilePath))
            {
                Directory.CreateDirectory(PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FilePath);
              //  MessageBox.Show("文件保存位置不存在,请检查路径:" + PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FilePath + "是否存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // return;
            }

            //检查所有的文件,是否有己存在的
            bool is_Exists = false;
            bool isReadOnly = false;

            if (File.Exists(PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FilePath + PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FileName))
            {
                is_Exists = true;
                isReadOnly = new FileInfo(PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FilePath + PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FileName).IsReadOnly;
            }
            if (is_Exists)
            {
                if (MessageBox.Show("文件已经存在,是否覆盖?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            if (isReadOnly)
            {
                MessageBox.Show("代码没有签出,请签出后,再点击保存按钮!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var utf8WithoutBom = new UTF8Encoding(false);
            StreamWriter sw = new StreamWriter(PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FilePath + PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FileName, false, utf8WithoutBom);
            sw.Write(PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].CodeText.ToString());
            sw.Flush();
            sw.Close();
            sw.Dispose();

            MessageBox.Show("保存成功!", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
            // 保存后打开文件夹
            //
            if (PublicClass.IsOpenFolder == "1")
            {
                Process proc = new Process();
                proc.StartInfo.FileName = "explorer";
                //打开资源管理器
                proc.StartInfo.Arguments = @"" + PublicClass.ReturnCodes[tscb_FileList.SelectedIndex].FilePath;
                //选中"notepad.exe"这个程序,即记事本
                proc.Start();
            }
        }

        /// <summary>
        /// 系统选项设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_SysConfig_Click(object sender, EventArgs e)
        {
            frm_SysConfig config_Form = new frm_SysConfig();
            config_Form.ShowDialog();
        }

        private void 帮助F1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           string helpfile = "help.chm";   
            Help.ShowHelp(this, helpfile);
        }

        private void txtEdit_Code_Load(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                panel1.Visible = false;
            }
            else
                panel1.Visible = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            webBrowser1.Navigate( PublicClass.WebServer + "Client/ArticleList.aspx?UserName=" +System.Web.HttpUtility.UrlEncode(PublicClass.OperName) + "&category=" + e.Node.Tag);
        }
    }
}
