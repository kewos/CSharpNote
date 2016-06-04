using System;
using System.Linq;
using System.Threading;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class PLinqReSourceCompete : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var counter1 = 0;

            //使用Interlocked類別進行資料鎖定
            var query1 = (from num in Enumerable.Range(0, 10000).AsParallel()
                where (Interlocked.Increment(ref counter1) > 10000)
                select num).ToArray();

            Console.WriteLine("lock resource times:{0}", counter1);

            var counter2 = 0;
            var query2 = (from num in Enumerable.Range(0, 10000).AsParallel()
                where (counter2++ > 10000)
                select num).ToArray();

            Console.WriteLine("without locked resource times:{0}", counter2);
        }
    }
}