using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class LinqGroupBy : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var items = new List<GroupByItem>
            {
                new GroupByItem {A = 1, B = 1, C = 1, D = 1, E = 1},
                new GroupByItem {A = 1, B = 1, C = 1, D = 2, E = 2},
                new GroupByItem {A = 1, B = 1, C = 1, D = 3, E = 3},
                new GroupByItem {A = 1, B = 1, C = 1, D = 4, E = 4},
                new GroupByItem {A = 2, B = 1, C = 1, D = 5, E = 5},
                new GroupByItem {A = 2, B = 1, C = 1, D = 6, E = 6},
                new GroupByItem {A = 2, B = 1, C = 1, D = 7, E = 7}
            };

            var result = items.GroupBy(item => new
            {
                item.A,
                item.B,
                item.C
            })
                .Select(g => new
                {
                    g.Key,
                    MaxD = g.Max(item => item.D),
                    MinE = g.Min(item => item.E)
                })
                .DumpMany();
        }
    }

    public class GroupByItem
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int E { get; set; }
    }
}