using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esint.Common.Web;
using Esint.CodeSite.Model;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Esint.CodeSite.Web
{
    public class BasePage : RootPage
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "AdminBlue";

        }

        protected void Page_Init(object sender, EventArgs e)
        {
        
        }
    
        //判断数据库连接是否有误
        public void Open()
        {
            string ConnStr = System.Configuration.ConfigurationManager.AppSettings["SqlDBConn"].ToString();
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            conn.Close();
        }

      

        /// <summary>
        /// 穿过代理服务器获取真实IP
        /// </summary>
        /// <returns></returns>
        public string AcceptTrueIP()
        {
            string user_IP = null;
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                user_IP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else
            {
                user_IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return user_IP;
        }

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
