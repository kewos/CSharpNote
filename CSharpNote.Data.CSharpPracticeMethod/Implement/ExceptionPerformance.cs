using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class ExceptionPerformance: AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var times = 100;
            Action tryCatchPerformance = () =>
            {
                double @double = 0;
                for (var index = 0; index < times; index++)
                {
                    try
                    {
                        throw new ArgumentException();
                    }
                    catch (Exception e)
                    {
                        var a = e.Message;
                        var b = a;
                    }
                }
            };

            Action noTryCatchPerformance = () =>
            {
                double @double = 0;
                for (var index = 0; index < times; index++)
                {
                    try
                    {
                        throw new ArgumentException();
                    }
                    catch (ArgumentException e)
                    {
                        var a = e.Message;
                        var b = a;
                    }
                }
            };

            tryCatchPerformance.CaculateExcuteTime().ToConsole("TryCatchPerformance:");
            noTryCatchPerformance.CaculateExcuteTime().ToConsole("NoTryCatchPerformance:");
        }
    }
}