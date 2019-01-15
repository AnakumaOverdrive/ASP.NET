using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esint.CodeSite.BLL;
using Esint.CodeSite.Model;
using Esint.Common.Model;
using Esint.Common;
using Esint.Common.BLL;
using Esint.Common.Web;

namespace Esint.CodeSite.Web
{
    /// <summary>
    /// 模块名称： 表单控件
    /// 作    者：刘伟通
    /// 日    期：2012年09月18日
    /// 修改日期：
    /// 修 改 人：
    /// </summary>
    public partial class UC_Info_ArticleInfo: BaseUserControl
    {

       #region 控件属性区
        ///<summary>
        ///文章编号
        ///<summary>
        public Guid AritcleID
        {
            get { return ViewState["AritcleID"]==null?Guid.Empty:(Guid)ViewState["AritcleID"]; }
            set { ViewState["AritcleID"] = value; }
        }
 
        #endregion

        #region 页面加载

        protected void Page_Init(object sender, EventArgs e)
        { 
            if (!Page.IsPostBack)
            {
            }
        }
        #endregion

        #region 实体--控件值转换区

        ///<summary>
        ///
        ///<summary>
        public Info_ArticleInfo Info_Article
        {  
            get
            {
                //定义学生信息表对象实体
                Info_ArticleInfo info_Article = new Info_ArticleInfo();

                //文章编号
                info_Article.AritcleID = AritcleID;


                // 标题
                info_Article.Title = txt_Title.Text.Trim();

                // 内容
                info_Article.InfoBody = txt_InfoBody.Text.Trim();

                // 添加人
                info_Article.OpName = CurrentUser;

                info_Article.OPTime = DateTime.Now;
                
                info_Article.Category = new Guid(Request.QueryString["Category"]);
                return info_Article;
            }

            set
            {
                if (value == null)
                {
                    //文章编号
                    AritcleID = Guid.Empty;
                    // 标题
                    txt_Title.Text="";

                    // 内容
                    txt_InfoBody.Text="";

                    // 添加人
                    lbl_OpName.Text="";

                    // 添加时间
                    lbl_OPTime.Text="";

                }
                else
                {
                    //文章编号
                    AritcleID = value.AritcleID;


                    // 标题
                    txt_Title.Text=value.Title;

                    // 内容
                    txt_InfoBody.Text=value.InfoBody;

                    // 添加人
                    lbl_OpName.Text=value.OpName;

                    // 添加时间
                    if (value.OPTime!=null)
                        lbl_OPTime.Text=value.OPTime.Value.ToString("yyyy-MM-dd");
                }
            }
        }
        #endregion

        #region 验证区


        public bool ValidateData(ref string errMessage)
        {
            bool isValidate = true;

            if (!Validator.Required(txt_Title.Text))
            {
                isValidate = false;
                errMessage += "标题不能为空\\r\\n";
            }

            if (!Validator.Required(txt_InfoBody.Text))
            {
                isValidate = false;
                errMessage += "内容不能为空\\r\\n";
            }

            if  (!Validator.IsDateTime(lbl_OPTime.Text))
            {
                isValidate = false;
                errMessage += "添加时间不是正确的格式\\r\\n";
            }

            return isValidate;
        }
        #endregion
    }
}
