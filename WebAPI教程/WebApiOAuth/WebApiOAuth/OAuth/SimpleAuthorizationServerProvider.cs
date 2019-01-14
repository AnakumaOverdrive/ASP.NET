using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WebApiOAuth.OAuth
{
    /// <summary>
    /// 简单的认证服务
    /// </summary>
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            
            //用户登录
            //AccountService accService = new AccountService();
            //string md5Pwd = LogHelper.MD5CryptoPasswd(context.Password);
            //IList<object[]> ul = accService.Login(context.UserName, md5Pwd);
            //if (ul.Count() == 0)
            //{
            //    context.SetError("invalid_grant", "The username or password is incorrect");
            //    return;
            //}

            //添加了声明
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            context.Validated(identity);
        }
    }
}