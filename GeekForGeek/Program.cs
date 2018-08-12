using NUnit.Framework;
using System;

namespace GeekForGeek
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //}
    }

    class MyClass
    {
        [Test]
        public void Test_Test()
        {
            Assert.IsTrue(1 == 1);
        }
    }
}
