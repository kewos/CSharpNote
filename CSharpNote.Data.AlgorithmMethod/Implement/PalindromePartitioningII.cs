using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class PalindromePartitioningII : AbstractExecuteModule
    {
        [AopTarget("https://oj.leetcode.com/problems/palindrome-partitioning-ii/")]
        public override void Execute()
        {
            GetPalindromePartitioningII("aaabaaacc").Dump();
        }

        public List<string> GetPalindromePartitioningII(string @string)
        {
            var result = new List<string>();
            var index = 0;
            while (index < @string.Length)
            {
                var tempindex = 0;
                var tempString = string.Empty;
                for (var subStringLength = 1; index + subStringLength <= @string.Length; subStringLength++)
                {
                    var tempValue = @string.Substring(index, subStringLength);
                    if (!tempValue.IsPalindrome())
                        continue;

                    tempindex = index + subStringLength;
                    tempString = tempValue;
                }

                result.Add(tempString);
                index = tempindex;
            }

            return result;
        }
    }
}