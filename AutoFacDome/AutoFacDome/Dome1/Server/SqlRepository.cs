using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class SqlRepository : IRepository
    {
        public void Get()
        {
            Console.WriteLine("sql数据源");
        }
    }
}
