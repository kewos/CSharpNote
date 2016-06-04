using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.Algorithm.Common;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/flatten-binary-tree-to-linked-list/
    //Given a binary tree, flatten it to a linked list in-place.
    public class FlattenBinaryTreetoLinkedList : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            TreeToList(GetRootOfTree()).ForEach(Console.WriteLine);
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

        private List<int> TreeToList(Node head)
        {
            var newList = new List<int> {head.Key};

            if (head.Left != null)
                newList.AddRange(TreeToList(head.Left));

            if (head.Right != null)
                newList.AddRange(TreeToList(head.Right));

            return newList;
        }
    }
}