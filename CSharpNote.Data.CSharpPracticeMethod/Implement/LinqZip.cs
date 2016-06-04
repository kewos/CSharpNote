using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class LinqZip : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var bands = new List<string> {"GnR", "PinkFloyd", "Rammstein", "Ozzy Osbourne", "The Verve", "Kasaabian"};
            var people = new List<string> {"John", "Peter", "Andrew", "Martin"};

            var result = people.Zip(bands, (p, b) => Tuple.Create(p, b)).ToList();
            result.ForEach(r => Console.WriteLine("{0} favor {1}", r.Item1, r.Item2));
        }
    }
}