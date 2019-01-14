using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiDome4.Models;

namespace WebApiDome4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Help()
        {
            var explorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();
            return View(new ApiModel(explorer));
        }
    }
}
