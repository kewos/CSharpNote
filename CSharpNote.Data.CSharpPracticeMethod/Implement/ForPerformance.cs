using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class ForPerformance : AbstractExecuteModule
    {
        /// <summary>
        ///     Conclusion
        ///     外層次數少速度快
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            Action forPerformanceCheck1 =
                () =>
                {
                    Enumerable.Range(0, 10000).ForEach(n => { Enumerable.Range(0, 100).ForEach(m => { var a = m*n; }); });
                };

            Action forPerformanceCheck2 =
                () =>
                {
                    Enumerable.Range(0, 100).ForEach(n => { Enumerable.Range(0, 10000).ForEach(m => { var a = m*n; }); });
                };

            forPerformanceCheck1.CaculateExcuteTime().ToConsole("ForPerformanceCheck1:");
            forPerformanceCheck2.CaculateExcuteTime().ToConsole("ForPerformanceCheck2:");
        }
    }
}