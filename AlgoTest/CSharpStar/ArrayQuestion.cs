using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.CSharpStar
{
    class ArrayQuestion
    {
        int[] MergeTwoArrays(int[] arr, int[] brr)
        {
            int[] merge = new int[arr.Length + brr.Length];
            int a = 0; int b = 0; int m = 0;

            while (a < arr.Length && b < brr.Length)
            {
                if (arr[a] < brr[b])
                    merge[m++] = arr[a++];
                else
                    merge[m++] = brr[b++];
            }

            // merge the remaining
            if (a < arr.Length)
            {
                while (a < arr.Length)
                    merge[m++] = arr[a++];
            }
            else if (b < brr.Length)
            {
                while (b < brr.Length)
                    merge[m++] = brr[b++];
            }

            return merge;
        }

        [Test]
        public void Merge_One_Test()
        {
            int[] input = { 1, 2, 3, 5, 9, 10 };
            int[] input2 = { 2, 4, 7 };

            var result = MergeTwoArrays(input, input2);
            int[] expected = { 1, 2, 2, 3, 4, 5, 7, 9, 10 };

            Assert.AreEqual(expected, result);
            Assert.AreEqual(new int[0],
                MergeTwoArrays(new int[] { }, new int[] { }));

            Assert.AreEqual(new int[] { 1 },
                MergeTwoArrays(new int[] { 1 }, new int[] { }));

            Assert.AreEqual(new int[] { 1 },
                MergeTwoArrays(new int[] { }, new int[] { 1 }));
        }
    }
}
