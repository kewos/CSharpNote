using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpNote.Data.DataStructure.Implement.Tree
{
    public class BinaryTree<T>
    {
        public TreeNode<T> root;

        public BinaryTree(TreeNode<T> root)
        {
            this.root = root;
        }

        /// <summary>
        ///     中歷
        /// </summary>
        public static void InOrder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.Left);
            Console.Write(node.Value + " ");
            InOrder(node.Right);
        }

        /// <summary>
        ///     前歷
        /// </summary>
        public static void PreOrder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            Console.Write(node.Value + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        /// <summary>
        ///     後歷
        /// </summary>
        public static void PostOrder(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.Write(node.Value + " ");
        }

        public static IEnumerable<T> PreOrderWithStack(TreeNode<T> node)
        {
            var stack = new Stack<TreeNode<T>>();
            var temp = node;
            stack.Push(temp);

            while (stack.Count() != 0)
            {
                temp = stack.Peek();
                stack.Pop();

                yield return temp.Value;

                if (temp.Right != null)
                {
                    stack.Push(temp.Right);
                }
                if (temp.Left != null)
                {
                    stack.Push(temp.Left);
                }
            }
        }

        public static IEnumerable<T> InOrderWithStack(TreeNode<T> node)
        {
            return null;
        }

        public static IEnumerable<T> PostOrderWithStack(TreeNode<T> node)
        {
            return null;
        }
    }
}