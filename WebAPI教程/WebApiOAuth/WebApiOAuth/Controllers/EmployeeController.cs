using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiOAuth.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        //查询所有员工
        [HttpGet]
        public string GetAllEmps()
        {
            return "成功";
        }
    }
}
