using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDome2.Models;

namespace WebApiDome2.Controllers
{
    public class ProductsController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        // Not the final implementation!
        // 非最终实现！
        //public Product PostProduct(Product item)
        //{
        //    item = repository.Add(item);
        //    return item;
        //}

        //改进实现
        public HttpResponseMessage PostProduct(Product item)
        {
            item = repository.Add(item);

            //操纵HTTP响应消息 服务器应当用状态201（已创建）进行回答。
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, item);
            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        //一个成功的DELETE请求，可以返回200（OK）状态，并带有一个描述该状态的条目体；
        //也可以在删除未决的情况下返回202（Accepted）状态；或者返回无条目体的204（No Content）状态。
        //在本例中，该方法返回204状态。
        public HttpResponseMessage DeleteProduct(int id)
        {
            repository.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }
    }
}
