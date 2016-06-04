using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class RepeatedDnaSequences : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var dna = "AAAAACCCCCAAAAACCCCCAAAAAGGGTTT";

            GetRepeatedDnaSequences(dna, 10).Dump();
        }

        private List<string> GetRepeatedDnaSequences(string dna, int letterLong)
        {
            var dictionary = new Dictionary<string, int>();
            for (var index = 0; index < dna.Length - letterLong; index++)
            {
                var str = dna.Substring(index, letterLong);
                if (dictionary.ContainsKey(str))
                {
                    dictionary[str]++;
                    continue;
                }

                dictionary.Add(str, 1);
            }

            return dictionary.Where(d => d.Value >= 2).Select(d => d.Key).ToList();
        }
    }
}