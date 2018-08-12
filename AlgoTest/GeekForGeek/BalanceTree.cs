using LeetCode;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.GeekForGeek
{
    class BalanceTree
    {
        public bool IsBalance(TreeNode node)
        {
            if (node == null)
                return true;

            int left = Height(node.Left);
            int right = Height(node.Right);

            if (Math.Abs(left - right) <= 1 &&
                IsBalance(node.Left) &&
                IsBalance(node.Right))
                return true;

            return false;
        }

        public int Height(TreeNode node)
        {
            if (node == null) return 0;
            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        [Test]
        public void Height_Test()
        {
            var tree = _buildTree();
            int height = Height(tree);

            Assert.IsTrue(4 == height);
        }

        private TreeNode _buildTree()
        {
            var tree = new TreeNode(1);
            tree.Left = new TreeNode(2);
            tree.Right = new TreeNode(3);
            tree.Left.Left = new TreeNode(4);
            tree.Left.Right = new TreeNode(5);
            tree.Left.Left.Left = new TreeNode(8);

            return tree;
        }
    }
}
