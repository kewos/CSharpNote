using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class InterleavingString : AbstractExecuteModule
    {
        [AopTarget("https://oj.leetcode.com/problems/interleaving-string/")]
        public override void Execute()
        {
            var s1 = "a";
            var s2 = "b";
            var s3 = "ab";

            IsInterleave(s1, s2, s3).ToConsole();
        }

        private bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;

            if (s3.Length == 0)
                return true;

            if (s1.Length == 0)
                return s2 == s3;

            if (s2.Length == 0)
                return s1 == s3;

            return (s1[0] == s3[0]
                    &&
                    IsInterleave(s1.Substring(1, s1.Length - 1), s2, s3.Substring(1, s3.Length - 1)))
                   ||
                   (s2[0] == s3[0]
                    &&
                    IsInterleave(s1, s2.Substring(1, s2.Length - 1), s3.Substring(1, s3.Length - 1)));
        }
    }
}