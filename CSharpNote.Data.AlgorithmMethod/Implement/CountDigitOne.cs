using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class CountDigitOne : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            GetCountDigitOne(10).ToConsole();
            GetCountDigitOne(100).ToConsole();
            GetCountDigitOne(1000).ToConsole();
        }

        private int GetCountDigitOne(int n)
        {
            if (n < 1)
                return 0;

            long ones = 0;
            for (long m = 1; m <= n; m *= 10)
            {
                ones += (n / m + 8) / 10 * m + (n / m % 10 == 1 ? n % m + 1 : 0);
            }

            return (int)ones;
        }
    }
}