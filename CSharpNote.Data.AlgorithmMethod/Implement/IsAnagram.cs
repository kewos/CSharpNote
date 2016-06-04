using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// <summary>
    ///     context
    ///     是否為字謎
    ///     solution
    ///     t字串變成字典檔s字串逐一去減看是否全部被去除
    /// </summary>
    public class IsAnagram : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            DoIsAnagram("a", "b").ToConsole();
        }

        public bool DoIsAnagram(string s, string t)
        {
            if (s == t)
                return true;
            if (t.Length != s.Length)
                return false;

            var dic = new Dictionary<char, int>();
            foreach (var c in t)
            {
                if (!dic.ContainsKey(c))
                {
                    dic.Add(c, 1);
                    continue;
                }

                dic[c]++;
            }

            foreach (var c in s.Where(x => dic.ContainsKey(x)))
            {
                dic[c]--;
            }

            return dic.All(x => x.Value == 0);
        }
    }
}