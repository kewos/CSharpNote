using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Project.Implement
{
    public class TestResultData : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var data1 = new ResultData.ResultData(new Exception("Test"), "");
            if (!data1)
            {
                Console.WriteLine(data1.ToString());
            }

            var data2 = new ResultData.ResultData(true, "Test", 1);
            if (!data2)
            {
                Console.WriteLine(data2.ToString());
                Console.WriteLine(data2.GetData<int>());
            }
        }
    }
}