using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class IsIsomorphic : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            DoIsIsomorphic("ab", "aa").ToConsole();
        }

        public bool DoIsIsomorphic(string s, string t)
        {
            if (s == t)
                return true;

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
                return false;

            if (s.Length != t.Length)
                return false;

            var dic = new Dictionary<char, char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i]))
                    dic.Add(s[i], t[i]);

                if (dic[s[i]] != t[i])
                    return false;
            }

            return true;
        }

        private class IntComparer : IComparer<int>
        {
            public int Compare(int a, int b)
            {
                var strA = a.ToString();
                var strB = b.ToString();
                var minLength = Math.Min(strA.Length, strB.Length);
                var maxLength = Math.Max(strA.Length, strB.Length);

                var preIndex = -1;
                while (++preIndex < minLength)
                {
                    if (strA[preIndex] > strB[preIndex])
                        return -1;

                    if (strA[preIndex] < strB[preIndex])
                        return 1;
                }

                if (strA.Length == strB.Length)
                    return 0;

                var lastIndex = -1;
                var state = (strA.Length > strB.Length)
                    ? 1
                    : -1;

                var maxString = (strA.Length > strB.Length)
                    ? strA
                    : strB;

                while (preIndex + ++lastIndex < maxLength)
                {
                    if (maxString[lastIndex] > maxString[preIndex + lastIndex])
                        return 1*state;

                    if (maxString[lastIndex] < maxString[preIndex + lastIndex])
                        return -1*state;
                }

                for (var index = 0; index < maxLength - 1; index++)
                {
                    if (maxString[index] > maxString[index + 1])
                        return -1*state;

                    if (maxString[index] < maxString[index + 1])
                        return 1*state;
                }

                return state*-1;
            }
        }
    }
}