using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
    //For example, given n = 3, a solution set is:
    //"((()))", "(()())", "(())()", "()(())", "()()()"
    public class GenerateParentheses : AbstractExecuteModule
    {
        [AopTarget(@"https://oj.leetcode.com/problems/generate-parentheses/")]
        public override void Execute()
        {
            GetGenerateParenthesesⅰ(6).Dump();
        }

        private void GetGenerateParentheses(List<string> set, int n, string s = "")
        {
            if (n == 0)
            {
                if (!set.Contains(s))
                    set.Add(s);

                return;
            }

            if (s != "()")
                GetGenerateParentheses(set, n - 1, s + "()");

            GetGenerateParentheses(set, n - 1, "()" + s);
            GetGenerateParentheses(set, n - 1, "(" + s + ")");
        }

        private List<string> GetGenerateParenthesesⅰ(int n)
        {
            var set = new List<string> {"()"};
            var tempSet = new List<string>();
            for (var i = 1; i < n; i++)
            {
                tempSet.Clear();
                tempSet.AddRange(set);
                set.Clear();
                tempSet.ForEach(s =>
                {
                    if (s != "()")
                        set.Add(s + "()");

                    set.Add("()" + s);
                    set.Add("(" + s + ")");
                });
            }

            return set;
        }
    }
}