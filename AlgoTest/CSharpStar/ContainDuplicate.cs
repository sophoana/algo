using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.CSharpStar
{
    public class ContainDuplicate
    {
        bool CheckDuplicate(int[] arr)
        {
            var dict = new Dictionary<int, int>();
            foreach (var a in arr)
            {
                if (dict.ContainsKey(a))
                    return true;
                else
                    dict.Add(a, 1);
            }

            return false;
        }

        [Test]
        public void CheckDuplicate_Test()
        {
            int[] input = { 1, 2, 3, 2 };
            bool expected = true;
            var result = CheckDuplicate(input);
            Assert.IsTrue(result == expected);
        }

    }
}
