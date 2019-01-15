using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esint.CodeSite.Web
{
    public partial class CommonFrame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GetRequestQuery();
        }

        public void GetRequestQuery()
        {
            string url = Request.QueryString["url"];
            foreach (string key in Request.QueryString.AllKeys)
            {
                if (key.ToLower() != "url")
                    url += "&" + key + "=" + Request.QueryString[key];

            }
            Response.Write("<html xmlns=\"http://www.w3.org/1999/xhtml\" >\r\n");
            Response.Write("<head id=\"Head1\" runat=\"server\">\r\n");
            Response.Write("    <title>网页对话框</title>\r\n");
            Response.Write("</head>\r\n");
            Response.Write("	<frameset>\r\n");
            Response.Write("		<frame name=\"popmain\" src=\"" + url + "\" scrolling=\"auto\" noresize>\r\n");
            Response.Write("		<noframes>\r\n");
            Response.Write("	    </noframes>\r\n");
            Response.Write("	</frameset>\r\n");
            Response.Write("</html>\r\n");
            Response.End();
        }
    }
}