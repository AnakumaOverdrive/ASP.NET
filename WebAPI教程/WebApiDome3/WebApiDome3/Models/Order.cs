using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiDome3.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string Customer { get; set; }

        // 导航属性
        public ICollection<OrderDetail> OrderDetails { get; set; } 
    }
}