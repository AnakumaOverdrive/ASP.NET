using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Esint.CodeSite.Web.Client
{
    public partial class Tree : System.Web.UI.Page
    {
        public string strCode
        {
            get { return (string)ViewState["strCode"]; }
            set { ViewState["strCode"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // SysCodemapInfo codeMap = new BLL.SysCodemapService().GetSysCodemapInfo(CodeFlag);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "", new BLL.Sys_CodeService().CreateJsonTree(CodeFlag, codeMap.Meaning), true);


            strCode = new BLL.Info_CategoryService().CreateJsonTree("0",Guid.Empty);
        }
    }
}
