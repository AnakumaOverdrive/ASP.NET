using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class RedisRepository : IRepository
    {
        public void Get()
        {
            Console.WriteLine("Redis数据源");
        }
    }
}
