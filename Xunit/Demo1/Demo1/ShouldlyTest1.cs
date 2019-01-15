using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo1
{
    public class ShouldlyTest1
    {
        [Theory]
        public void Test1()
        {
            (new[] { 1, 2, 3 }).ShouldBe(new[] { 1, 2, 4 });
        }
    }
}
