using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.CSharpStar
{
    public class Factorial
    {
        int Factorial_Recursive(int n)
        {
            if (n < 3) return n;
            return n * Factorial_Recursive(n - 1);
        }

        int Factorial_ForLoop(int n)
        {
            int f = 1;
            for (int i = 1; i < n + 1; i++)
            {
                f *= i;
            }

            return f;
        }

        [Test]
        public void Test()
        {
            Assert.IsTrue(Factorial_Recursive(3) == 6);
            Assert.IsTrue(Factorial_Recursive(4) == 24);
            Assert.IsTrue(Factorial_Recursive(2) == 2);

            Assert.IsTrue(Factorial_ForLoop(5) == 120);
        }
    }
}
