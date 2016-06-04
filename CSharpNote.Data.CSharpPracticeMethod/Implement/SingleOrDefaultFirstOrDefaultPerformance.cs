using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class SingleOrDefaultFirstOrDefaultPerformance : AbstractExecuteModule
    {
        /// <summary>
        ///     Conclusion
        ///     FirstOrDefaule scan until fine first item
        ///     SingleOrDefaultPerformance scan all item if result greater than 2 thow exception
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var items = Enumerable.Range(1, 1000);
            Action firstOrDefaultPerformance = () => items.Select(n => items.FirstOrDefault(m => n == m)).ToList();
            Action singleOrDefaultPerformance = () => items.Select(n => items.SingleOrDefault(m => n == m)).ToList();

            firstOrDefaultPerformance.CaculateExcuteTime().ToConsole("FirstOrDefaultPerformance:");
            singleOrDefaultPerformance.CaculateExcuteTime().ToConsole("SingleOrDefaultPerformance:");

            Action singleOrDefaultThrowException =
                () => items.Select(n => items.SingleOrDefault(m => n%2 == 0)).ToList();
            singleOrDefaultThrowException.ExcauteAndCatchException().ToConsole("ExceptionMessage:");
        }
    }
}