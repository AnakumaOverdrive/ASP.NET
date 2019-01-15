using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo1
{
    public class Class1 : IDisposable
    {
        [Fact]
        public void Add()
        {
            Arithmetic a = new Arithmetic();
            int res = a.Add(1, 2);
            Assert.Equal(3, res);
        }

        [Fact(DisplayName = "除法测试")]
        public void Divide()
        {
            Arithmetic a = new Arithmetic();
            Assert.Throws<DivideByZeroException>(() => a.Divide(1, 0));
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(1, 0)]
        [InlineData(0, 2)]
        public void AddMultiple(int parmaA, int parmaB)
        {
            Arithmetic a = new Arithmetic();
            int res = a.Add(parmaA, parmaB);
            Assert.Equal(parmaA + parmaB, res);
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }
    }

    public class Arithmetic
    {
        public int Add(int nb1, int nb2)
        {
            return nb1 + nb2;
        }

        public int Divide(int nb1, int nb2)
        {
            return nb1 / nb2;
        }
    }
}
