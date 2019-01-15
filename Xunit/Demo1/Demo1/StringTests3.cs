using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo1
{
    public class StringTests3
    {
        [Theory, ClassData(typeof(IndexOfData))]
        public void IndexOf(string input, char letter, int expected)
        {
            var actual = input.IndexOf(letter);
            Assert.Equal(expected, actual);
        }
    }

    public class IndexOfData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
    {
        new object[] { "hello world", 'w', 6 },
        new object[] { "goodnight moon", 'w', -1 }
    };

        public IEnumerator<object[]> GetEnumerator()
        { return _data.GetEnumerator(); }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
