using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.WebService.Tests
{
    [TestFixture]
    public class FooTest
    {
        [Test]
        public void AddTest()
        {
            var f = new Foo();
            var result1 = f.Add(3, 4);
            Assert.AreEqual(7, result1);

            var result2 = f.Add(-5, 3);
            Assert.AreEqual(-2, result2);
        }
    }

    public class Foo
    {
        public int Add(int i, int j)
        {
            return i + j;
        }
    }
}
