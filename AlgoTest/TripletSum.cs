using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest
{
    public class TripletSum
    {
        // Return list of index of couple whose sum equals to given sum
        public IEnumerable<Tuple<int, int>> FindTuple_BF(int[] arr, int sum)
        {
            var list = new List<Tuple<int, int>>();
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == sum)
                    {
                        list.Add(Tuple.Create(i, j));
                    }
                }
            }

            return list;
        }

        public IEnumerable<Tuple<int, int>> FindTuple_HM(int[] arr, int sum)
        {
            return null;
        }
    }
}
