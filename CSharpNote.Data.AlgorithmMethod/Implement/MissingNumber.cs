using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class MissingNumber : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            DoMissingNumber(new[] {1, 2, 3, 5}).ToConsole();
        }

        public int DoMissingNumber(int[] nums)
        {
            var items = Enumerable.Range(0, nums.Length + 1).ToList();
            foreach (var num in nums)
            {
                items.Remove(num);
            }

            throw new Exception();
        }
    }
}