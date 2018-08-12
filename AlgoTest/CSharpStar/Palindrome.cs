using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.CSharpStar
{
    class Palindrome
    {
        bool IsPalindrone(string word)
        {
            int low = 0;
            int high = word.Length;
            while (low < high)
            {
                if (word[low++] != word[--high])
                    return false;
            }
            return true;
        }

        [Test]
        public void Test()
        {
            string[] array =
            {
                "civic",
                "deleveled",
                "Hannah",
                "kayak",
                "level",
                "examiron",
                "racecar",
                "radar",
                "refer",
                "reviver",
                "easywcf",
                "rotator",
                "rotor",
                "sagas",
                "solos",
                "stats",
                "tenet",
                "Csharpstar",
                ""
            };

            Assert.IsTrue(IsPalindrone("civic") == true);
            Assert.IsTrue(IsPalindrone("Csharpstar") == false);
        }
    }
}
