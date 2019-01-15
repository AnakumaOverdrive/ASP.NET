using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo1
{
    public class Class2
    {
        [Fact(DisplayName = "通过测试")]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact(DisplayName = "失败测试")]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }
        
    }
}
