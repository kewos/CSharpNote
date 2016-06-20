using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class TryCatchPerformance : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var times = 1000000;
            Action tryCatchInForLoopPerformance = () =>
            {
                double @double = 0;
                for (var index = 0; index < times; index++)
                {
                    try
                    {
                        @double = Math.Sin(@double);
                        @double = Math.Sin(@double);
                    }
                    catch (Exception e)
                    {
                        e.Message.ToConsole();
                    }
                }
            };

            Action tryCatchOutForLoopPerformance = () =>
            {
                double @double = 0;
                try
                {
                    for (var index = 0; index < times; index++)
                    {
                        @double = Math.Sin(@double);
                        @double = Math.Sin(@double);
                    }
                }
                catch (Exception e)
                {
                    e.Message.ToConsole();
                }
            };

            Action noTryCatchPerformance = () =>
            {
                double @double = 0;
                for (var index = 0; index < times; index++)
                {
                    @double = Math.Sin(@double);
                    @double = Math.Sin(@double);
                }
            };

            tryCatchInForLoopPerformance.CaculateExcuteTime().ToConsole("TryCatchInForLoopPerformance:");
            tryCatchOutForLoopPerformance.CaculateExcuteTime().ToConsole("TryCatchOutForLoopPerformance:");
            noTryCatchPerformance.CaculateExcuteTime().ToConsole("NoTryCatchPerformance:");
        }
    }
}