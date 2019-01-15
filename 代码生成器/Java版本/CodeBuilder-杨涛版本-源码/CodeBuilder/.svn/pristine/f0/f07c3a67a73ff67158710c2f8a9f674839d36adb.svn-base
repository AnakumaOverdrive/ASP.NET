using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Esint.Common.Model;
using Esint.Common.Web;
using Esint.CodeSite.BLL;

namespace Esint.CodeSite.Web
{
    /// <summary>
    /// 模块名称： 表单控件
    /// 作    者：刘伟通
    /// 日    期：2012年09月18日
    /// 修改日期：
    /// 修 改 人：
    /// </summary>
    public partial class UC_Info_ArticleList: BaseUserControl
    {

       #region 控件事件区
        //GridView 行命令事件 
        public event GridViewCommandEventHandler OnRowCommand;

        //GridView 行数据绑定事件 
        public event GridViewRowEventHandler  OnRowDataBound;

       #endregion

       #region 控件属性区
        ///<summary>
        ///类别编号
        ///<summary>
        public Guid Category
        {
            get { return (Guid)ViewState["Category"]; }
            set { ViewState["Category"] = value; }
        }
       #endregion

        #region 页面加载

        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!Page.IsPostBack)
            {
                //JsHelper.Window.OpenModalDialog(btn_Add, "Client/Info_ArticlePage.aspx?category=" + Category, 900, 700);
            }
        }
        #endregion

        #region GridView 数据操作区[绑定，排序，分页]

        #region  数据表格绑定

        /// <summary>
        /// 数据表格绑定
        /// </summary>
        public void DataGridBinding()
        {
            //
            // 设置手动分页
            //
            PageSplit pages = new PageSplit();
            pages.IsPageView = true;
            pages.PageSize = AspNetPager1.PageSize;
            pages.PageIndex = AspNetPager1.CurrentPageIndex;

            // 查询数据源
            ReturnTable returnTable = new Info_ArticleService().GetInfo_ArticleTable(pages, SortExpression,txt_Title.Text.Trim(),Category); 

            // 绑定分页控件
            AspNetPager1.RecordCount = returnTable.PageInfo.RecordCount;
            if (AspNetPager1.CurrentPageIndex != returnTable.PageInfo.PageIndex)
                AspNetPager1.CurrentPageIndex = returnTable.PageInfo.PageIndex;

            // 绑定GridView
            gv_Info_Article.DataSource = returnTable.Table;
            gv_Info_Article.DataBind();
        }

        #endregion

        #region GridView 行数据绑定事件 

        /// <summary>
        /// 行数据绑定事件
        /// </summary>
        protected void gv_Info_Article_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType== DataControlRowType.DataRow)
            {
                 e.Row.SetDeleteMsg("lbtn_delete");
                 this.OnRowDataBound(sender, e);
            }
        }

        #endregion

        #region GridView 行命令 事件 

        /// <summary>
        /// 行 命令 RowCommand 事件
        /// </summary>
        protected void gv_Info_Article_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            this.OnRowCommand(sender, e);
            
        }

        #endregion

        #region GridView 列头排序 事件 

        /// <summary>
        /// 列头排序方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gv_Info_Article_Sorting(object sender, GridViewSortEventArgs e)
        {
            SortExpression = e.ToSortString(sender);
            DataGridBinding();
        }

        #endregion

        #region GridView 分页 事件 

        /// <summary>
        /// 分页事件
        /// </summary>
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DataGridBinding();
        }

        #endregion

        #endregion

        #region 查询按钮查询 事件 

        /// <summary>
        /// 查询按钮 单击事件 
        /// </summary>
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            DataGridBinding();
        }

        #endregion

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("Info_ArticlePage.aspx?category=" + Category);
           // DataGridBinding();
        }

        
    }
}
