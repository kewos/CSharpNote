using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.Algorithm.Common;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/minimum-depth-of-binary-tree/
    //Given a binary tree, find its minimum depth.
    //The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
    public class MinimumDepthOfBinaryTree : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            Console.WriteLine(GetMinimumDepthOfBinaryTree(GetRootOfTree()));
        }

        private Node GetRootOfTree()
        {
            var root = new Node {Key = 1};
            var node2 = new Node {Key = 2};
            var node3 = new Node {Key = 3};
            var node4 = new Node {Key = 4};
            var node5 = new Node {Key = 5};
            var node6 = new Node {Key = 6};
            root.Left = node2;
            root.Right = node5;
            node2.Right = node4;
            node2.Left = node3;
            node5.Right = node6;

            return root;
        }

        private int GetMinimumDepthOfBinaryTree(Node head)
        {
            int leftDepth = 0, rightDepth = 0;

            if (head.Left != null)
                leftDepth = GetMinimumDepthOfBinaryTree(head.Left);

            if (head.Right != null)
                rightDepth = GetMinimumDepthOfBinaryTree(head.Right);

            if ((leftDepth == 0 && rightDepth != 0) || (rightDepth == 0 && leftDepth != 0))
                return 1 + Math.Max(leftDepth, rightDepth);

            return 1 + Math.Min(leftDepth, rightDepth);
        }
    }
}