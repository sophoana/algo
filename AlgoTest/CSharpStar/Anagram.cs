using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.CSharpStar
{
    class Anagram
    {
        bool Check(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            var dict = new Dictionary<char, int>();
            foreach (var ch in str1.ToCharArray())
            {
                if (dict.ContainsKey(ch))
                    dict[ch]++;
                else
                    dict.Add(ch, 1);
            }

            var dict2 = new Dictionary<char, int>();
            foreach (var ch in str2.ToCharArray())
            {
                if (dict2.ContainsKey(ch)) dict2[ch]++;
                else dict2.Add(ch, 1);
            }

            foreach (var key in dict.Keys)
            {
                if (!dict2.ContainsKey(key) || dict[key] != dict2[key])
                    return false;
            }
            return true;
        }

        bool CheckWithSort(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;

            var arr1 = s1.ToCharArray();
            var arr2 = s2.ToCharArray();

            // Sort the array
            Array.Sort(arr1);
            Array.Sort(arr2);

            // Convert to string
            var w1 = new string(arr1);
            var w2 = new string(arr2);

            if (w1 == w2)
                return true;

            return false;
        }
    }
}
