using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = Get(6); 
        }

        static int Get(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Get(n - 1) + Get(n - 2);
        }

        static bool CheckBST(TreeNode node)
        {
            if (node == null) return false;
            return CheckBST(node.Left) && CheckBST(node.Right);

        }

        static bool IsBalance(string str)
        {
            if (string.IsNullOrEmpty(str)) return false;

            Stack<char> stack = new Stack<char>();
            foreach (var ch in str.ToCharArray())
            {
                if (stack.Count == 0 ||
                    ch.Equals('{') ||
                    ch.Equals('(') || ch.Equals('['))
                {
                    stack.Push(ch);
                }
                else
                {
                    if (ch.Equals(')') && !stack.Peek().Equals('('))
                        return false;
                    else if (ch.Equals('}') && !stack.Peek().Equals('{'))
                        return false;
                    else if (ch.Equals(']') && !stack.Peek().Equals('['))
                        return false;
                    else
                        stack.Pop();
                }
            }

            return stack.Count == 0 ? true : false;
        }
    }
}
