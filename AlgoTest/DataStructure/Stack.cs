using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.DataStructure
{
    public class MyStack
    {
        public int EqualStacks(int[] h1, int[] h2, int[] h3)
        {
            // Stack1
            Stack<Tuple<int, int>> s1 = new Stack<Tuple<int, int>>();
            int sum = 0;
            for (int i = h1.Length - 1; i >= 0; i--)
            {
                sum += h1[i];
                s1.Push(Tuple.Create(h1[i], sum));
            }

            // Stack2
            sum = 0;
            var s2 = new Stack<Tuple<int, int>>();
            for (int i = h2.Length - 1; i >= 0; i--)
            {
                sum += h2[i];
                s2.Push(Tuple.Create(h2[i], sum));
            }

            // Stack3
            sum = 0;
            var s3 = new Stack<Tuple<int, int>>();
            for (int i = h3.Length - 1; i >= 0; i--)
            {
                sum += h3[i];
                s3.Push(Tuple.Create(h3[i], sum));
            }

            while (s1.Count != 0 && s2.Count != 0 && s3.Count != 0)
            {
                int min = Math.Min(
                    Math.Min(s1.Peek().Item2, s2.Peek().Item2),
                    s3.Peek().Item2);

                if(s1.Peek().Item2 > min)
                    s1.Pop();
                if (s2.Peek().Item2 > min)
                    s2.Pop();
                if (s3.Peek().Item2 > min)
                    s3.Pop();

                if (s1.Count == 0 || s2.Count == 0 || s3.Count == 0)
                    return 0;
                else if (s1.Peek().Item2 == s2.Peek().Item2 && s1.Peek().Item2 == s3.Peek().Item2)
                    return s1.Peek().Item2;
            }

            return 0;
        }

        [Test]
        public void EqualStacks_Test()
        {
            int[] h1 = { 3, 2, 1, 1, 1 };
            int[] h2 = { 4, 3, 2 };
            int[] h3 = { 1, 1, 4, 1 };

            var actual = EqualStacks(h1, h2, h3);
            Assert.IsTrue(5 == actual);
        }
    }
}
