using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class TestAwait : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            Console.WriteLine("start");
            var primeListAsync = PrintPrimeAsync(1000);
            Console.WriteLine("end");

            foreach (var prime in primeListAsync.Result)
            {
                Console.WriteLine(prime);
            }
        }

        private async Task<List<int>> PrintPrimeAsync(int maxNumber)
        {
            var tcs = new TaskCompletionSource<List<int>>();
            await Task.Run(() =>
            {
                var query = Enumerable.Range(2, maxNumber)
                    .Where(x =>
                        x == 2 ||
                        Enumerable.Range(2, (int) Math.Sqrt(x)).All(y => x%y != 0));
                tcs.SetResult(query.ToList());
            });

            return await tcs.Task;
        }
    }
}