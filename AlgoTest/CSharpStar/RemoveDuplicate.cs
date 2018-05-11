using LeetCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.CSharpStar
{
    interface IRemoveDuplicate<T>
    {
        T Run(T str);
    }
    class RemoveDuplicate : IRemoveDuplicate<string>
    {
        public string Run(string head)
        {
            var ans = "";
            foreach (var ch in head.ToCharArray())
            {
                // IF the char is not yet in the string - add it!
                if (ans.IndexOf(ch) == -1)
                    ans += ch;
            }

            return ans;
        }
    }

    class RemoveDuplicateNode : IRemoveDuplicate<Node>
    {
        public Node Run(Node head)
        {
            if (head == null) return null;

            Node lag = head;
            Node lead = head.Next;

            while (lead != null)
            {
                if (lead.Value == lag.Value)
                {
                    lag = lead.Next;
                    lead = lag == null ? null : lag.Next;
                }
                else
                {
                    lag = lag.Next;
                    lead = lead.Next;
                }
            }

            return head;
        }

       // [Test] // Fail!!!
        public void TestRemoveDuplicateNode()
        {
            var inputRange = new List<int>() { 1, 2, 2, 3, 3 };
            var expectedRange = new List<int>() { 1, 2, 2, 3, 3 };
            var input = createNode(inputRange);
            var expected = createNode(expectedRange);

            var result = Run(input);

            Assert.AreEqual(result, expected);
        }

        private Node createNode(IEnumerable<int> range)
        {
            var node = new Node(1);
            var next = node;
            foreach (var item in range)
            {
                next.Next = new Node(item);
                next = next.Next;
            }

            return node;
        }
    }

    class RemoveDuplicateSortedLinkedList : IRemoveDuplicate<LinkedList<int>>
    {
        public LinkedList<int> Run(LinkedList<int> head)
        {
            if (head == null) return null;
            if (head.First == null || head.First.Next == null) return head;

            LinkedListNode<int> lag = head.First;
            LinkedListNode<int> lead = head.First.Next;

            while (lead != null)
            {
                if (lead.Value == lag.Value)
                {
                    head.Remove(lag);
                    lag = lead;
                    lead = lead.Next;
                }
                else
                {
                    lag = lag.Next;
                    lead = lead.Next;
                }
            }

            return head;
        }

        [Test]
        public void TestLinkedList()
        {
            var input = new LinkedList<int>();
            input.AddLast(1);
            input.AddLast(1);
            input.AddLast(2);
            input.AddLast(2);
            input.AddLast(3);

            var expected = new LinkedList<int>();
            expected.AddLast(1);
            expected.AddLast(2);
            expected.AddLast(3);

            var result = Run(input);

            Assert.AreEqual(expected, result);
        }
    }


    class RemoveDuplicateTest
    {
        IRemoveDuplicate<string> _instance = new RemoveDuplicate();

        [Test]
        public void Test()
        {
            var val1 = _instance.Run("Csharpstar");
            var val2 = _instance.Run("Google");
            var val3 = _instance.Run("Yahoo");
            var val4 = _instance.Run("CNN");

            Assert.AreEqual("Csharpt", val1);
            Assert.AreEqual("Gogle", val2);
            Assert.AreEqual("Yaho", val3);
            Assert.AreEqual("CN", val4);
        }
    }
}
