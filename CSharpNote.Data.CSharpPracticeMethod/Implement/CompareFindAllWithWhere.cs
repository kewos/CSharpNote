using System;
using System.Diagnostics;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class CompareFindAllWithWhere : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            //find is better than where when collection is list 

            var numbers = Enumerable.Range(1, 1000000).ToList();

            var sw = new Stopwatch();
            sw.Start();
            var testFindAll = numbers.FindAll(number => (number%2) == 0);
            sw.Stop();

            var sw1 = new Stopwatch();
            sw1.Start();
            var testWhere = numbers.Where(number => (number%2) == 0).ToList();
            sw1.Stop();

            Console.WriteLine("where{0}, findall{1}", sw.ElapsedMilliseconds, sw1.ElapsedMilliseconds);
        }
    }
}