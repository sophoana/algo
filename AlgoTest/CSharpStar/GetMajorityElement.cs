using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.CSharpStar
{
    class GetMajorityElement
    {
        public int Run(params int[] x)
        {
            throw new NotImplementedException();
        }

        public int Hello(params int[] arr)
        {
            var dict = new Dictionary<int, int>();
            var m = arr.Length / 2;
            foreach (var a in arr)
            {
                if (dict.ContainsKey(a))
                {
                    dict[a]++;
                    if (dict[a] > m) return a;
                }
                else
                {
                    dict.Add(a, 1);
                }
            }

            throw new KeyNotFoundException("No majority element found.");
        }
    }

    class DetectCycleSinglyLinkedList
    {
        class Node
        {
            Node Next;
            Object Value;
        }
        public void CreateCircle()
        {
            
        }

        public bool DetectCycle()
        {
            // Have two pointers
            // Run both of them until the end of the list
            // if they meet, there is a cycle
            // otherwise false.
            return false;
        }
    }
}
