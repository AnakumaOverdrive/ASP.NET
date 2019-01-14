using DapperExtensionDemo.DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensionDemo.NunitTest
{
    [TestFixture]
    public class TestDAL
    {
        [Test]
        public void  TestGetTestInfoCount()
        {
            TestDal testDal = new TestDal();
            var result = testDal.GetTestInfoCount();
            Console.WriteLine(result);
        }
    }
}
