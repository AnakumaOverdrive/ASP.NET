using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo1
{
    public class StringTests1
    {
        [Theory,
        InlineData("goodnight moon", "moon", true),
        InlineData("hello world", "hi", false)]
        public void Contains(string input, string sub, bool expected)
        {
            var actual = input.Contains(sub);
            Assert.Equal(expected, actual);
        }

    }
}
