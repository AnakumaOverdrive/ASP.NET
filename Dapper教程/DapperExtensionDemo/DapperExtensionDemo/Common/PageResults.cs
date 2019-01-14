using DapperExtensionDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensionDemo.Common
{
    public class PageResults<T> where T : BaseModel
    {
        public IEnumerable<T> Results { get; set; }

        public PageView PageView { get; set; }
    }
}
