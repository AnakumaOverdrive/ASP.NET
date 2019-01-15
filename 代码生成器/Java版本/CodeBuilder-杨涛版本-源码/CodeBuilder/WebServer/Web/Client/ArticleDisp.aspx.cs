using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esint.CodeSite.Model;

namespace Esint.CodeSite.Web.Client
{
    public partial class ArticleDisp : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                string artId = Request.QueryString["AritcleID"];
                string artcategory  = Request.QueryString["Category"];
                Info_ArticleInfo art = new BLL.Info_ArticleService().GetInfo_ArticleInfo(new Guid(artId));
                lbl_Title.Text = art.Title;
                lbl_Body.Text = art.InfoBody;
                lbl_Info.Text = "作者： " + art.OpName + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + "日期：" + art.OPTime.Value.ToString();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ArticleList.aspx?category=" + Request.QueryString["category"]);
        }
    }
}
