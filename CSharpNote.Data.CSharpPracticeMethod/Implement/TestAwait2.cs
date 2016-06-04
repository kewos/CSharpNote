using System;
using System.Threading.Tasks;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class TestAwait2 : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var awaitTask = AwaitTest();
            Console.WriteLine(awaitTask.Result);
        }

        private async Task<string> AwaitTest()
        {
            var tcs = new TaskCompletionSource<string>();
            await Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(3));
                tcs.SetResult("result");
            });

            return await tcs.Task;
        }
    }
}