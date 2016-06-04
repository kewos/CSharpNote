using System;
using System.Linq;
using System.Linq.Expressions;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Utility;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class ExpressionVsLamdaPerformance : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            using (new TimeMeasurer("1. Lamda"))
            {
                Func<int, int> action = x => x*x;
                foreach (var i in Enumerable.Range(1, 100000))
                {
                    action(1);
                }
            }

            using (new TimeMeasurer("2. Expression"))
            {
                Expression<Func<int, int>> myExpression = x => x*x;
                var p = myExpression.Compile();
                foreach (var i in Enumerable.Range(1, 100000))
                {
                    p(1);
                }
            }
        }
    }
}