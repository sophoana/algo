using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.CSharpStar
{
    public class FindSumDigits
    {
        public int Run(int num)
        {
            if (num / 10 == 0) return num;
            return (num % 10) + Run(num / 10);
        }

        public int Hello(int num)
        {
            if (num == 0)
                return num;
            return (num % 10) + Hello(num / 10);
        }
    }

    [TestClass]
    public class FindSumDigitsTest
    {
        [TestMethod]
        public void Test()
        {
            var input = 156;
            var expected = 12;
            var result = new FindSumDigits().Run(input);
            Assert.IsTrue(result == expected);
        }
    }
}
