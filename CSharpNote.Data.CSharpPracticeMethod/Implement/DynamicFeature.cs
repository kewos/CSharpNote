using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class DynamicFeature : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            new DairyItem().Apply();
        }

        private class AggregateRoot
        {
            public void Apply()
            {
                dynamic d = this;
                d.handle();
            }
        }

        private class DairyItem : AggregateRoot
        {
            public void Handle()
            {
                "DairyItem handle something".ToConsole();
            }
        }
    }
}