using System;
using System.Diagnostics;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class TestExecuteRun : AbstractExecuteModule
    {
        [AopTarget("http://codeblog.jonskeet.uk/category/linq/")]
        public override void Execute()
        {
            var size = 10000000;
            Console.WriteLine("Always true");
            RunTests(size, x => false, true);
            Console.WriteLine("Always true");
            RunTests(size, x => false && false && false, false);
        }

        private void RunTests(int size, Func<string, bool> predicate, bool check)
        {
            for (var i = 1; i <= 10; i++)
            {
                RunTest(i, size, predicate, check);
            }
        }

        private void RunTest(int depth, int size, Func<string, bool> predicate, bool check)
        {
            var input = Enumerable.Repeat("value", size);

            for (var i = 0; i < depth; i++)
            {
                if (check)
                {
                    input = input.Where(predicate).Where(predicate).Where(predicate);
                }
                else
                {
                    input = input.Where(predicate);
                }
            }
            var sw = Stopwatch.StartNew();
            input.Count();
            sw.Stop();
            Console.WriteLine("Depth: {0} Size: {1} Time: {2}ms",
                depth, size, sw.ElapsedMilliseconds);
        }
    }
}