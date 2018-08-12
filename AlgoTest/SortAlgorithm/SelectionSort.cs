using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.SortAlgorithm
{
    public class SelectionSort
    {
        public void Sort(int[] arr)
        {
            // Find the smallest index, then swap to current index
            for (int i = 0; i < arr.Length; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                        minIdx = j;
                }

                // Swap the element to i-th index
                int tmp = arr[i];
                arr[i] = arr[minIdx];
                arr[minIdx] = tmp;
            }
        }

        [Test]
        public void SelectionSort_Test()
        {
            int[] input = { 2, 1, 8, 5, 10, 4 };
            Sort(input);

            int[] expected = { 1, 2, 4, 5, 8, 10 };
            Assert.AreEqual(input, expected);
        }
    }
}
