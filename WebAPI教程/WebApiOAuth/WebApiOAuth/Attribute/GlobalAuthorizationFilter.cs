using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiOAuth.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true),]
    public class GlobalAuthorizationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // 这是一个基本例子，使用的ASP.NET Forms 身份验证
            var context = HttpContext.Current;
            string methodName1 = actionContext.ActionDescriptor.ActionName;
            //var ad=actionContext.ActionDescriptor.MethodInfo;

            var session = context.Session;

            if (SysConfig.GetCurUser() == null) /*自定义验证方式(从header取token并验证);同样适用于session验证(先登录,然后打开swagger测试)*/
            {
                PreUnauthorized(actionContext); /*用户验证未通过,则输出 请登录*/
                return;
            }
        }

        private void PreUnauthorized(HttpActionContext actionContext)
        {
            // 如果用户没有登录，则返回一个通用的错误Model
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, "请登录");
        }
    }
}