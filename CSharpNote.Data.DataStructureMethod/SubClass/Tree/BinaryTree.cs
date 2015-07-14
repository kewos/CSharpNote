using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DataStructureMethod.SubClass.Tree
{

    public class BinaryTree<T>
    {
        public TreeNode<T> root;

        public BinaryTree(TreeNode<T> root)
        {
            this.root = root;
        }

        /// <summary>
        /// 中歷
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
        /// 前歷
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
        /// 後歷
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
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            TreeNode<T> temp = node;
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

        //public static void BreadthFirstTraversal(TreeNode<T> root)
        //{
        //    var q = new Queue<TreeNode<T>>();
        //    var temp = root;
        //    if (temp != null)
        //    {
        //        q.Join(temp);
        //        while (!q.IsEmpty())
        //        {
        //            temp = q.Front.Value;
        //            q.Leave();
        //            Console.Write(temp.Value + " ");
        //            if (temp.Left != null)
        //                q.Join(temp.Left);
        //            if (temp.Right != null)
        //                q.Join(temp.Right);
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}
