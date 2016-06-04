using System;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class AssignByPropertyVsAssignDirectlyPerformance : AbstractExecuteModule
    {
        /// <summary>
        ///     AssignDirectly is better than AssignByProperty
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var times = 10000000;
            var executeTimes = Enumerable.Range(0, times);
            var testClass = new AssignByPropertyVsAssignDirectlyPerformanceTest();
            Action assignByProperty = () => { executeTimes.ForEach(n => { testClass.AssignByProperty = n; }); };

            Action assignDirectly = () => { executeTimes.ForEach(n => { testClass.testAssignDirectly = n; }); };

            assignByProperty.CaculateExcuteTime().ToConsole("AssignByProperty:");
            assignDirectly.CaculateExcuteTime().ToConsole("AssignDirectly:");
        }

        public class AssignByPropertyVsAssignDirectlyPerformanceTest
        {
            public int testAssignDirectly;
            public int AssignByProperty { get; set; }
        }
    }
}