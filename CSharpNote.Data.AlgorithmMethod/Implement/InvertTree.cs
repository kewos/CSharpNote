using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.Algorithm.Common;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class InvertTree : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            //https://leetcode.com/problems/invert-binary-tree/
            var root = new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(7)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(9)
                }
            };

            DoInvertTree(root);
        }

        private TreeNode DoInvertTree(TreeNode root)
        {
            if (root == null)
                return null;

            if (root.left != null)
                DoInvertTree(root.left);

            if (root.right != null)
                DoInvertTree(root.right);

            var temp = root.left;
            root.left = root.right;
            root.right = temp;

            return root;
        }
    }
}