using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.DataStructure
{
    public class MinHeap
    {
        public int Size { get; private set; }
        public int Capacity { get; private set; } = 10;
        public int[] Items { get; set; }

        private void EnsureExtraCapacity()
        {
            if (Size == Capacity)
            {
                Array.Copy(Items, Items, Capacity * 2);
                Capacity *= 2;
            }
        }

        public int Peek()
        {
            if (Size == 0) throw new ArgumentException();
            return Items[0];
        }

        public int Poll()
        {
            if (Size == 0) throw new ArgumentException();
            int item = Items[0];
            Items[0] = Items[Size - 1];
            Size--;

            HeapifyDown();
            return item;
        }

        public void Add(int item)
        {
            EnsureExtraCapacity();

            Items[Size] = item;
            Size++;

            HeapifyUp();
        }

        private void HeapifyDown()
        {

        }

        public void HeapifyUp()
        {
            int idx = Size - 1;
        }
    }
}
