using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class EnumToStringAndEnumGetNamePerformance : AbstractExecuteModule
    {
        /// <summary>
        ///     Conclusion
        ///     Performance of EnumGetName great than Performance of Getstring
        ///     100000times result
        ///     Performance of GetstringAction:94ms
        ///     Performance of EnumGetNameAction:46ms
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var times = 100000;
            var executeTimes = Enumerable.Range(0, times);
            Action getNamePerformanceCheck =
                () => { executeTimes.ForEach(n => { var t = PerformanceCheckEnum.Test.ToString(); }); };

            Action toStringPerformanceCheck =
                () =>
                {
                    executeTimes.ForEach(
                        n => { var t = Enum.GetName(typeof (PerformanceCheckEnum), PerformanceCheckEnum.Test); });
                };

            getNamePerformanceCheck.CaculateExcuteTime().ToConsole("GetNamePerformance:");
            toStringPerformanceCheck.CaculateExcuteTime().ToConsole("ToStringPerformanceCheck:");
        }

        private enum PerformanceCheckEnum
        {
            Test
        }
    }
}