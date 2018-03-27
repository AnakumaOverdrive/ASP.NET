using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutofacTest.Lib
{
    public class User : Identity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
