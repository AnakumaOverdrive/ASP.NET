using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esint.Common.Web;

namespace Esint.CodeSite.Web.Client
{ 
    /// <summary>
    /// 功能说明:  查询页面；
    /// 作    者: 刘伟通
    /// 日    期: 2012年09月18日
    /// 参数说明: 
    /// 修改说明: 
    /// </summary>
    public partial class ArticleList : BasePage
    {
        #region  页面权限点
        /// <summary>
        /// 权限点说明: 有此权限点可打开，无权限不能访问
        ///             [权限名称]:     权限含义
        /// </summary>
        const string PAGE_POWERPOINT = "";
        /// <summary>
        /// 页面参数 AritcleID 文章编号
        /// </summary>
        public string UserName
        {
            get
            {
                return Request.QueryString["UserName"];
            }
        }

        #endregion

        #region 页面加载事件

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 注册GridView事件

            // 注册GridView事件
            UC_Info_ArticleList1.OnRowCommand += new GridViewCommandEventHandler(UC_Info_ArticleList1_OnRowCommand);
            UC_Info_ArticleList1.OnRowDataBound += new GridViewRowEventHandler(UC_Info_ArticleList1_OnRowDataBound);

            #endregion

            //
            // 绑定 GridView 数据列表
            //
            if (!Page.IsPostBack)
            {
                if (string.IsNullOrEmpty(CurrentUser))
                {
                    CurrentUser = HttpUtility.UrlDecode(UserName);
                }

                this.UC_Info_ArticleList1.Category = new Guid(Request.QueryString["cateGory"]);
                this.UC_Info_ArticleList1.DataGridBinding();
            }
        }

        #endregion

        #region GridView 事件

        /// <summary>
        /// UC_Info_ArticleList1 行记录绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UC_Info_ArticleList1_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
          //  JsHelper.Window.OpenModalDialog(((LinkButton)e.Row.FindControl("lbtn_edit")), "Client/Info_ArticlePage.aspx?category="+Request.QueryString["category"]+"&AritcleID=" + DataBinder.Eval(e.Row.DataItem,"AritcleID").ToString(), 900, 700);
        }

        /// <summary>
        /// UC_Info_ArticleList1 行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UC_Info_ArticleList1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            //
            // 修改按钮单击事件
            //
            if (e.CommandName.ToUpper() == "DISP")
            {

                Response.Redirect("ArticleDisp.aspx?category=" + Request.QueryString["category"] +"&AritcleID="+e.CommandArgument.ToString());
            }
             if (e.CommandName.ToUpper() == "ROWEDIT")
            {
                Response.Redirect("Info_ArticlePage.aspx?category=" + Request.QueryString["category"] + "&AritcleID=" + e.CommandArgument.ToString());
            }
            //
            // 删除按钮单击事件
            //
            if (e.CommandName.ToUpper() == "ROWDELETE")
            {   
                // 根据主键 删除 企业基本信息 
                new BLL.Info_ArticleService().Delete(new Guid(e.CommandArgument.ToString()));

                // 显示删除成功
                JsHelper.Message.ShowMessage("删除成功！");

                // 刷新 列表
                UC_Info_ArticleList1.DataGridBinding();
             }
         }
        #endregion
    }

}
