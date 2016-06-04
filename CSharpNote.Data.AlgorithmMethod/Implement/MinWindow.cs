using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class MinWindow : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var s = "abeceeeeeea";
            var t = "bc";

            GetMinWindow(s, t).ToConsole();
        }

        private string GetMinWindow(string s, string t)
        {
            var dictionary = new Dictionary<char, Queue<int>>();
            foreach (var @char in t)
            {
                if (!dictionary.ContainsKey(@char))
                    dictionary[@char] = new Queue<int>();

                dictionary[@char].Enqueue(-1);
            }

            var counter = 0;
            var firstIndex = 0;
            var start = -1;
            var minLength = s.Length;

            Queue<int> pointer;
            for (var index = 0; index < s.Length; index++)
            {
                if (!dictionary.ContainsKey(s[index]))
                    continue;

                pointer = dictionary[s[index]];
                if (pointer.Peek() == -1)
                    counter++;

                pointer.Enqueue(index);
                pointer.Dequeue();

                //Counter集滿前不向下進行
                if (counter != t.Length
                    || (minLength != s.Length && s[index] != s[firstIndex]))
                    continue;

                //最小的index
                firstIndex = dictionary
                    .Select(item => item.Value.Peek())
                    .Concat(new[] { s.Length })
                    .Min();

                var len = index - firstIndex + 1;
                if (len >= minLength && len != s.Length)
                    continue;

                start = firstIndex;
                minLength = len;
            }

            return start == -1 ? string.Empty : s.Substring(start, minLength);
        }
    }
}