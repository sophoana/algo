using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.SortAlgorithm
{
    public class BubbleSort
    {
        public void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int j = i;
                while (j + 1 < arr.Length)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = tmp;
                    }

                    j++;
                }
            }
        }

        [Test]
        public void BubbleSort_Test()
        {
            int[] input = { 2, 1, 8, 5, 10, 4 };
            Sort(input);

            int[] expected = { 1, 2, 4, 5, 8, 10 };
            Assert.AreEqual(input, expected);
        }
    }
}
