using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AlgoTest.SortAlgorithm
{
    public class InsertionSort
    {
        // In-Place Sorting
        // Ascending
        public void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int cur = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > cur)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }

                arr[j + 1] = cur;
            }
        }

        [Test]
        public void InsertionSort_Test()
        {
            int[] input = { 2, 1, 8, 5, 10, 4 };
            Sort(input);

            int[] expected = { 1, 2, 4, 5, 8, 10 };
            Assert.AreEqual(input, expected);
        }
    }
}
