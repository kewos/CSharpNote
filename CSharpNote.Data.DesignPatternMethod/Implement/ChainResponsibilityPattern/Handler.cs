using CSharpNote.Common.Extensions;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.ChainResponsibilityPattern
{
    public class HandlerA : AbstractHandler
    {
        public HandlerA()
            : base(new HandlerB())
        {
        }

        protected override void DoSometing()
        {
            "Execute HandlerA".ToConsole();
        }
    }

    public class HandlerB : AbstractHandler
    {
        public HandlerB()
            : base(new HandlerC())
        {
        }

        protected override void DoSometing()
        {
            "Execute HandlerB".ToConsole();
        }
    }

    public class HandlerC : AbstractHandler
    {
        public HandlerC()
            : base(new HandlerD())
        {
        }

        protected override void DoSometing()
        {
            "Execute HandlerC".ToConsole();
        }
    }

    public class HandlerD : AbstractHandler
    {
        public HandlerD()
            : base(null)
        {
        }

        protected override void DoSometing()
        {
            "Execute HandlerD".ToConsole();
        }
    }
}