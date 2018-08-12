using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest
{
    public class MathQuestion//<T> where T : IComparable
    {

        public int Multiple(int a, int b)
        {
            if (a == 0 || b == 0) return 0;
            int time = b < 0 ? -b : b;
            int ans = 0;

            for (int i = 0; i < time; i++)
            {
                ans += a;
            }

            if (b < 0) return -ans;
            return ans;
        }

        // Could have overflow
        public int Power(int a, int b)
        {
            if (b == 0) return 1;
            if (b % 2 == 0) return Power(a, b / 2) * Power(a, b / 2);
            return a * Power(a, b / 2) * Power(a, b / 2);
        }

        [Test]
        public void Power_Test()
        {
            var ans = Power(12, 2);
            Assert.IsTrue(Math.Pow(13, 6) == Power(13, 6));
        }

        [Test]
        public void Multiple_Test()
        {
            Assert.IsTrue(Multiple(2, 3) == 6);
            Assert.IsTrue(Multiple(-2, 3) == -6);
            Assert.IsTrue(Multiple(-2, -2) == 4);
            Assert.IsTrue(Multiple(2, -3) == -6);
        }

        public void SwapTwo(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }

        public int GCD(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;

            if (a == b)
                return a;

            if (a > b)
                return GCD(a - b, b);

            return GCD(a, b - a);
        }

        public int GCD2(int a, int b)
        {
            if (b == 0) return a;
            return GCD2(b, a % b);
        }

        [Test]
        public void GCD2_Test()
        {
            Assert.IsTrue(12 == GCD2(12, 24));
            Assert.IsTrue(12 == GCD(12, 24));
        }

        public T GCD<T>(T a, T b) where T : IComparable
        {
            if (a.CompareTo(0) == 0 || b.CompareTo(0) == 0) return default(T);

            return default(T);
        }

        public int LCM(int a, int b)
        {
            return (a * b) / GCD(a, b); // Losing Precision?
        }
    }

    public class Matrix_Manipulation
    {
        public int[,] Add(int[,] a, int[,] b)
        {
            // a and b has to be the same size.
            int b0 = a.GetUpperBound(0);
            int b1 = a.GetUpperBound(1);

            int[,] c = new int[b0 + 1, b1 + 1];

            for (int i = 0; i <= b0; i++)
            {
                for (int j = 0; j <= b1; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            return c;
        }

        public int[,] Substract(int[,] a, int[,] b)
        {
            throw new NotImplementedException();
        }

        public int[,] Multiply(int[,] a, int[,] b)
        {
            throw new NotImplementedException();
        }

        public int[,] Divide(int[,] a, int[,] b)
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Add_Test()
        {
            int[,] a = { { 1, 2 }, { 1, 3 } };
            int[,] b = { { 3, 4 }, { 2, 5 } };

            int[,] expected = { { 4, 6 }, { 3, 8 } };
            var actual = Add(a, b);

            // Test the matrix size and result
            // Matrix is 2x2 - so the last index upper bound is 1
            Assert.IsTrue(actual.GetUpperBound(0) == 1);
            Assert.IsTrue(actual.GetUpperBound(1) == 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Substract_Test()
        {
            int[,] a = {
                { 1, 2 },
                { 1, 3 } };

            int[,] b = {
                { 3, 4 },
                { 2, 5 } };

            int[,] expected = {
                {-2, -2 },
                {-1, -2 }
            };

            int[,] actual = Substract(a, b);

            Assert.IsTrue(actual.GetUpperBound(0) == 1);
            Assert.IsTrue(actual.GetUpperBound(1) == 1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Multiply_Test()
        {
            int[,] a = { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } };

        }
    }
}
