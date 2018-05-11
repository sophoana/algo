using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class MyQueue<T>
    {
        Stack<T> deq = new Stack<T>();
        Stack<T> enq = new Stack<T>();

        public void Enqueue(T value)
        {
            enq.Push(value);
        }

        public T Peek()
        {
            if (deq != null && deq.Count != 0)
                return deq.Peek();
            else if (enq != null && enq.Count != 0)
            {
                while (enq.Count != 0)
                    deq.Push(enq.Pop());

                return deq.Peek();
            }

            return default(T);
        }

        public T Dequeue()
        {
            T val = Peek();
            if (!val.Equals(default(T))) return deq.Pop();
            return val;
        }
    }
}
