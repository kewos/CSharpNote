using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Common.Helper;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class TestFastInvokerPerformance : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var type = typeof (TestFastInvoker);
            var methodInfo = type.GetMethod("Multiply");
            var testObj = new TestFastInvoker();
            object[] param = {3, 3};

            Action reflectorAction = () =>
            {
                for (var i = 0; i < 1000000; i++)
                {
                    methodInfo.Invoke(testObj, param);
                }
            };

            Action fastInvokerAction = () =>
            {
                var fastInvoker = FastInvokeHelper.Create(methodInfo);
                for (var i = 0; i < 1000000; i++)
                {
                    fastInvoker(testObj, param);
                }
            };

            Action newAction = () =>
            {
                for (var i = 0; i < 1000000; i++)
                {
                    testObj.Multiply(3, 3);
                }
            };

            reflectorAction.CaculateExcuteTime().ToConsole("reflectorAction:");
            fastInvokerAction.CaculateExcuteTime().ToConsole("fastInvokerAction");
            newAction.CaculateExcuteTime().ToConsole("newAction");
        }

        public class TestFastInvoker
        {
            public int Multiply(int x, int y)
            {
                return x*y;
            }
        }
    }
}