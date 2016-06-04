using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class PerformanceBetweenListAndArray : AbstractExecuteModule
    {
        /// <summary>
        ///     ®Ä¯à´ú¸Õ List And Array
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var list = new List<int>();
            var sw = new Stopwatch();
            sw.Start();

            for (var i = 0; i < 10000; i++)
            {
                list.Add(i);
            }
            sw.Stop();

            Console.Write("List:{0},{1}", sw.ElapsedTicks, Environment.NewLine);
            sw.Reset();

            sw.Start();
            var array = new int[10000];
            for (var i = 0; i < 10000; i++)
            {
                array[i] = i;
            }
            sw.Stop();
            Console.Write("Array:{0},{1}", sw.ElapsedTicks, Environment.NewLine);
            Console.ReadLine();
        }
    }
}