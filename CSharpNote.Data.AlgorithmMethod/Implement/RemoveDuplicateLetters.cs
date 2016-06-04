using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class RemoveDuplicateLetters : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            RemoveDuplicateLetter("cbacdcbc").ToConsole();
        }

        public string RemoveDuplicateLetter(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            var letterDic = new Dictionary<char, KeyValuePair<int, int>>();
            var index = 0;
            foreach (var c in s)
            {
                index++;
                if (!letterDic.ContainsKey(c))
                    letterDic[c] = new KeyValuePair<int, int>(1, index);

                if (letterDic.ContainsKey(c) && letterDic[c].Key > 1)
                    continue;

                letterDic[c] = new KeyValuePair<int, int>(2, index);
            }

            return string.Concat(letterDic.OrderBy(x => x.Value.Value).Select(x => x.Key));
        }
    }
}