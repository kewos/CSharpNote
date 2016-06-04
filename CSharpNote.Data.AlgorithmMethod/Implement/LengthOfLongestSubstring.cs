using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class LengthOfLongestSubstring : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            GetLengthOfLongestSubstring("ac").ToConsole();
        }

        private int GetLengthOfLongestSubstring(string s)
        {
            if (s == string.Empty)
                return 0;

            if (s.Length == 1)
                return 1;

            var index = 0;
            var max = int.MinValue;
            for (var i = 0; i < s.Length; i++)
            {
                var sub = s.Substring(index, i - index);
                if (sub.Contains(s[i]))
                    index += sub.IndexOf(s[i]) + 1;

                max = Math.Max(max, i - index + 1);
            }

            return max;
        }
    }
}