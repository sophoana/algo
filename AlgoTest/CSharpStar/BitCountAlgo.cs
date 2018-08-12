using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.CSharpStar
{
    class BitCountAlgo
    {
        int SparshCount(int n)
        {
            int count = 0;
            while (n != 0)
            {
                count++;
                n &= n - 1;
            }

            return count;
        }

        [Test]
        public void SparshCount_Test()
        {
            int input = int.MaxValue;
            int expected = 31;
            int result = SparshCount(input);

            Assert.AreEqual(expected, result);
            Assert.AreEqual(0, SparshCount(0));
            Assert.AreEqual(1, SparshCount(1));
            Assert.AreEqual(2, SparshCount(3));
        }
    }
}
