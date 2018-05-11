using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class TreeNode
    {
        int data;
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int val)
        {
            this.data = val;
        }
    }

    public class Node
    {
        public int Value { get; private set; }
        public Node Next { get; set; }
        public Node(int val)
        {
            this.Value = val;
        }
    }
}
