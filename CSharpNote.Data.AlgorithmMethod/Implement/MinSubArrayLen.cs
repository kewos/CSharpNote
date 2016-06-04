using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class MinSubArrayLen : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            DoMinSubArrayLen(100, new[] {10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10}).ToConsole();
        }

        public int DoMinSubArrayLen(int target, int[] nums)
        {
            var queue = new Queue<ValueNext>();
            for (var i = 0; i < nums.Length; i++)
            {
                queue.Enqueue(new ValueNext {Value = nums[i], Index = i});
            }

            queue.Enqueue(null);

            for (var index = 0; index < nums.Length && queue.Peek() != null; index++)
            {
                while (queue.Peek() != null)
                {
                    if (queue.Peek().Value == target)
                        return index + 1;

                    var temp = queue.Dequeue();
                    if (temp.Index + 1 >= nums.Length || temp.Value > target)
                        continue;

                    temp.Value += nums[++temp.Index];

                    queue.Enqueue(temp);
                }

                queue.Dequeue();
                queue.Enqueue(null);
            }

            return 0;
        }

        public int MinSubArrayLenⅱ(int target, int[] nums)
        {
            var sum = 0;
            var length = nums.Length + 1;
            var preIndex = 0;
            for (var index = 0; index < nums.Length; index++)
            {
                if (sum == 0)
                    length = Math.Min(length, index - preIndex + 1);

                sum += nums[index];
                while (sum > target && preIndex + 1 < index)
                {
                    sum -= nums[preIndex++];
                }
            }

            return length <= nums.Length ? length : 0;
        }

        public class ValueNext
        {
            public int Value { get; set; }
            public int Index { get; set; }
        }
    }
}