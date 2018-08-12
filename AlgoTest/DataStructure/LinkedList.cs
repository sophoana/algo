using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.DataStructure
{
    public class ChlangLinkedList
    {
        public class Node
        {
            public int Data { get; private set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }
            public Node(int val)
            {
                this.Data = val;
            }
        }

        public static Node Reverse(Node head)
        {
            var stack = new Stack<int>();
            var cur = head;
            while (cur != null)
            {
                stack.Push(head.Data);
                cur = cur.Next;
            }

            cur = head;
            while (stack.Count != 0)
            {
                cur.Data = stack.Pop();
                cur = cur.Next;
            }
        }

        public static void ReversePrint(Node head)
        {
            System.Collections.Generic.Stack<int> stack = new Stack<int>();
            while (head != null)
            {
                stack.Push(head.Data);
                head = head.Next;
            }

            while (stack.Count != 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
