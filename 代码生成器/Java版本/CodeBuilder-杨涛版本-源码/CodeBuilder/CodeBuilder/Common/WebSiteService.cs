using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Esint.CodeBuilder.WebSite;
using Esint.CodeBuilder.Model;

namespace Esint.CodeBuilder.Forms
{

    [System.Diagnostics.DebuggerStepThrough(), System.ComponentModel.DesignerCategory("code"),

   System.Web.Services.WebServiceBinding(Name = "", Namespace = "")]

    public class WebSiteService : WebSite.WS_Category
    {

        public WebSiteService()
            : base()
        {
            
            //设置默认webService的地址

            this.Url =  PublicClass.WebServer+ "Client/WS_Category.asmx";

        }

        public WebSiteService(string webUrl)
            : base()
        {

            this.Url = webUrl;

        }

    }

}

