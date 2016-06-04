using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.Algorithm.Common;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class SerializeAndDeserializeBinaryTree : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);

            node1.left = node2;
            node1.right = node3;
            node3.left = node4;
            node3.right = node5;

            var codec = new Codec();
            var serializeStr = codec.Serialize(node1);
            serializeStr.ToConsole();

            var deserializeNode = codec.Deserialize(serializeStr);

            codec.Serialize(deserializeNode).ToConsole();
        }

        public class Codec
        {
            public string Serialize(TreeNode root)
            {
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                var builder = new StringBuilder();
                while (queue.Any())
                {
                    var temp = queue.Dequeue();
                    if (temp == null)
                    {
                        builder.Append("#N");
                        continue;
                    }
                    builder.Append("#" + temp.val);
                    queue.Enqueue(temp.left);
                    queue.Enqueue(temp.right);
                }

                return builder.ToString();
            }

            public TreeNode Deserialize(string data)
            {
                if (string.IsNullOrEmpty(data))
                    return null;

                var nodesValue = data.Split('#').Where(x => x != string.Empty).ToArray();
                if (!nodesValue.Any())
                    return null;

                int rootValue;
                if (!int.TryParse(nodesValue.First(), out rootValue))
                    return null;

                var root = new TreeNode(rootValue);
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);

                for (var index = 1; index < nodesValue.Length;)
                {
                    if (!queue.Any())
                        break;

                    var temp = queue.Dequeue();
                    int value;
                    if (int.TryParse(nodesValue[index++], out value))
                    {
                        var leftNode = new TreeNode(value);
                        temp.left = leftNode;
                        queue.Enqueue(leftNode);
                    }
                    if (int.TryParse(nodesValue[index++], out value))
                    {
                        var rightNode = new TreeNode(value);
                        temp.right = rightNode;
                        queue.Enqueue(rightNode);
                    }
                }

                return root;
            }
        }
    }
}