using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Utility;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class ForAndLamdaPerformance : AbstractExecuteModule
    {
        /// <summary>
        ///     1. Lamda最慢
        ///     2. 抽出predicate 次快
        ///     3. for 最快
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var source = Enumerable.Range(1, 100);
            using (new TimeMeasurer("1. Lamda"))
            {
                for (var i = 0; i < 10000; i++)
                {
                    source.Where(x => x == 100).ToList();
                }
            }

            using (new TimeMeasurer("2. extract predicate"))
            {
                Func<int, bool> predicate = x => x == 100;
                for (var i = 0; i < 10000; i++)
                {
                    source.Where(predicate).ToList();
                }
            }

            using (new TimeMeasurer("3. for"))
            {
                for (var i = 0; i < 10000; i++)
                {
                    var list = new List<int>();
                    for (var j = 1; j < 100; j++)
                    {
                        if (j == 100)
                            list.Add(j);
                    }
                }
            }
        }
    }
}