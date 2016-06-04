using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DataStructure.Implement.Tree;

namespace CSharpNote.Data.DataStructure.Implement
{
    public class TestBinaryTree : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var n7 = new TreeNode<int>(7);
            var n6 = new TreeNode<int>(6);
            var n5 = new TreeNode<int>(5);
            var n4 = new TreeNode<int>(4);
            var n3 = new TreeNode<int>(3, n7, null);
            var n2 = new TreeNode<int>(2, n5, n6);
            var n1 = new TreeNode<int>(1, n3, n4);
            var n0 = new TreeNode<int>(0, n1, n2);

            foreach (var i in BinaryTree<int>.InOrderWithStack(n0))
            {
                i.ToConsole();
            }
        }
    }
}