﻿namespace CSharpNote.Data.DataStructure.Implement.Tree
{
    public class TreeNode<T>
    {
        public TreeNode(T value)
            : this(value, null, null)
        {
        }

        public TreeNode(T value, TreeNode<T> left, TreeNode<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
        }

        public T Value { get; private set; }
        public TreeNode<T> Left { get; private set; }
        public TreeNode<T> Right { get; private set; }
    }
}