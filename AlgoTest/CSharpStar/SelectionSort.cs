using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.CSharpStar
{
    public interface ISortMethod<T>
    {
        void Sort(IList<T> list);
    }
    class SelectionSort<T> : ISortMethod<T>
        where T : IComparable
    {
        public void Sort(IList<T> list)
        {
            throw new NotImplementedException();
        }
    }

    public class SelectionSort
    {
        public void Sort(int[] arr)
        {
            int tmp, minIdx;
            for (int i = 0; i < arr.Length; i++)
            {
                minIdx = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                        minIdx = j;
                }

                // Swap the elment
                tmp = arr[minIdx];
                arr[minIdx] = arr[i];
                arr[i] = tmp;
            }
        }
    }
}
