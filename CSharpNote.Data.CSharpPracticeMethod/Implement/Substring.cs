using System.Linq;
using System.Text;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class Substring : AbstractExecuteModule
    {
        private readonly char[] filterChar = {'.', '*'};

        [AopTarget]
        public override void Execute()
        {
            (SplitSubstringByFilter("") == "").ToConsole();
            (SplitSubstringByFilter(".") == ".").ToConsole();
            (SplitSubstringByFilter("...") == "...").ToConsole();
            (SplitSubstringByFilter("1.1") == "1.1").ToConsole();
            (SplitSubstringByFilter(".1") == ".1").ToConsole();
            (SplitSubstringByFilter("1.") == "1.").ToConsole();
            (SplitSubstringByFilter("1.1.1") == "1.1.1").ToConsole();
            (SplitSubstringByFilter("1.1.1...") == "1.1.1...").ToConsole();
            (SplitSubstringByFilter("1..1") == "1..1").ToConsole();
            (SplitSubstringByFilter("1*.1") == "1*.1").ToConsole();
            (SplitSubstringByFilter("1**********1") == "1**********1").ToConsole();
            (SplitSubstringByFilter("**********1") == "**********1").ToConsole();
            (SplitSubstringByFilter("***...*****1") == "***...*****1").ToConsole();
            (SplitSubstringByFilter("12345**********12345") == "12345**********12345").ToConsole();
        }

        public string SplitSubstringByFilter(string word)
        {
            if (string.IsNullOrEmpty(word))
                return string.Empty;

            var builder = new StringBuilder();
            var preIndex = 0;
            for (var index = 0; index < word.Length; index++)
            {
                if (!filterChar.Contains(word[index]) || preIndex == index)
                    continue;

                builder.Append(word.Substring(preIndex, index - preIndex));
                builder.Append(word[index]);
                preIndex = index + 1;
            }
            if (preIndex != word.Length)
                builder.Append(word.Substring(preIndex, word.Length - preIndex));

            return builder.ToString();
        }
    }
}