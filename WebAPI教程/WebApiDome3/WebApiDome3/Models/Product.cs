using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiDome3.Models
{
    public class Product
    {
        //ScaffoldColumn（支架列）注解属性是告诉ASP.NET MVC，在生成编辑表单时，跳过这个Id属性。
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        //Required注解属性用于对模型进行验证。它指定Name属性必须是一个非空字符串。
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal ActualCost { get; set; }
    }
}