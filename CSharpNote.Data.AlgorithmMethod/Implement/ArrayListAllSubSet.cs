using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class ArrayListAllSubSet : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var set = new List<int> { 1, 5, 9, 100, 4, 99, 88 };
            GetArrayListAllSubSet(set).DumpMany();
        }

        private List<List<int>> GetArrayListAllSubSet(List<int> set, List<int> subset = null, int index = 0)
        {
            if (index >= set.Count)
                return new List<List<int>> { subset };

            var newset1 = new List<int>();
            var newset2 = new List<int>();
            if (subset != null)
            {
                newset1.AddRange(subset);
                newset2.AddRange(subset);
            }

            newset2.Add(set[index]);
            var result1 = GetArrayListAllSubSet(set, newset1, index + 1);
            var result2 = GetArrayListAllSubSet(set, newset2, index + 1);

            result1.AddRange(result2);
            return result1;
        }
    }
}