using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDome4.CustomAttributes;
using WebApiDome4.Models;

namespace WebApiDome4.Controllers
{
    public class ProductsController : ApiController
    {
        [ApiDoc("获得所有Product对象")]
        public IEnumerable<Product> Get()
        {
            return new Product[0];
        }

        [ApiDoc("根据ID获得Product对象")]
        [ApiParameterDoc("id", "Product对象的id")]
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [ApiDoc("添加Product对象")]
        [ApiParameterDoc("value", "Product对象")]
        public void Post(Product value) { }

        [ApiDoc("更新Product对象")]
        [ApiParameterDoc("value", "Product对象")]
        public void Put(int id, Product value) { }
    }
}
