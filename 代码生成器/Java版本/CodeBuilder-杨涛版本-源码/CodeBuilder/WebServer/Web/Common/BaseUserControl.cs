using Esint.Common.Web;
using Esint.CodeSite.Model;


namespace Esint.CodeSite.Web
{
    public class BaseUserControl:RootUserControl
    {
        /// <summary>
        ///   
        /// </summary>
        public string CurrentUser
        {
            get
            {
                return Session["CurrentUser"] as string;
            }
            set
            {
                Session["CurrentUser"] = value;
            }
        }
     
    }
}
