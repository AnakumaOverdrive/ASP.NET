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
    /// 功能说明:  添加、修改页面；
    /// 作    者: 刘伟通
    /// 日    期: 2012年09月18日
    /// 参数说明: 
    ///           AritcleID               文章编号
    /// 修改说明: 
    /// </summary>
    public partial class Info_ArticlePage : BasePage
    {
        #region  页面权限点
        /// <summary>
        /// 权限点说明: 有此权限点可打开，无权限不能访问
        ///             [权限名称]:     权限含义
        /// </summary>
        const string PAGE_POWERPOINT = "";

        #endregion

        #region 页面参数
        /// <summary>
        /// 页面参数 AritcleID 文章编号
        /// </summary>
        public string AritcleID
        {
            get
            {
                return Request.QueryString["AritcleID"];
            }
        }

      
        #endregion

        #region 页面加载

        /// <summary>
        /// 页面加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // 设置保存按钮，添加前台Js验证事件
            btn_Save.Attributes.Add("onclick", "return chkform_info_Article()");

            if (!Page.IsPostBack)
            {
         
                // 如果首次加载，根据页面参数获取对象
                if (!String.IsNullOrEmpty(AritcleID))
                {
                    this.UC_Info_ArticleInfo1.Info_Article = new BLL.Info_ArticleService().GetInfo_ArticleInfo(new Guid(AritcleID));
                }
                
               
            }
        }

        #endregion

        #region 按钮事件

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Save_Click(object sender, EventArgs e)
        {

            if (IsValidate())
            {
                // 保存存 信息
                new BLL.Info_ArticleService().Save(UC_Info_ArticleInfo1.Info_Article);

                // 提示保存成功
                JsHelper.Message.ShowMessage("保存成功！","ArticleList.aspx?category="+Request.QueryString["category"]);
            }
        }

        /// <summary>
        ///  返回按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Return_Click(object sender, EventArgs e)
        {
        }

        #endregion

        #region 验证方法
        /// <summary>
        /// 验证页面方法，验证通过返回 true 验证失败显示提示信息，并返回 false
        /// </summary>
        /// <returns></returns>
        private bool IsValidate()
        {
            string msg = "";
            if (UC_Info_ArticleInfo1.ValidateData(ref msg))
            {
                return true;
            }
            else
            {
                JsHelper.Message.ShowMessage(msg);
            }
            return false;
        }
        #endregion

        protected void btn_Close_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArticleList.aspx?category=" + Request.QueryString["category"] );
        }

        
    }
}
