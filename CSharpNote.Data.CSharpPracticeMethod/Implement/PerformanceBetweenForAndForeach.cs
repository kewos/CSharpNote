using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class PerformanceBetweenForAndForeach : AbstractExecuteModule
    {
        /// <summary>
        ///     ®ÄªG´ú¸ÕFor and Foreach
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var count = new List<int>();
            var lst1 = new List<int>();
            var lst2 = new List<int>();
            var lst3 = new List<int>();

            for (var i = 0; i < 100000; i++) count.Add(i);
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < count.Count; i++) lst1.Add(i);
            sw.Stop();
            Console.Write("for:{0},{1}", sw.ElapsedTicks, Environment.NewLine);

            sw.Restart();
            foreach (var x in Enumerable.Range(0, 10000)) lst2.Add(x);
            sw.Stop();
            Console.Write("foreach:{0},{1}", sw.ElapsedTicks, Environment.NewLine);

            sw.Restart();
            Enumerable.Range(0, 10000).ToList().ForEach(x => lst3.Add(x));
            sw.Stop();
            Console.Write("foreach:{0},{1}", sw.ElapsedTicks, Environment.NewLine);
            Console.ReadLine();
        }
    }
}