
using ConsoleDisplay.Common.Extendsions;

namespace ConsoleDisplay.Data.DesignPatternMethod.SubClass
{
    public class SubClassA
    {
        public void DoSomeThing()
        {
            "SubClassA Do SomeThing".ToConsole();
        }
    }

    public class SubClassB
    {
        public void DoSomeThing()
        {
            "SubClassB Do SomeThing".ToConsole();
        }
    }

    public class Fecade
    {
        private readonly SubClassA subClassA;
        private readonly SubClassB subClassB;

        public Fecade()
        {
            subClassA = new SubClassA();
            subClassB = new SubClassB();
        }

        public void DoSomeThing()
        {
            subClassA.DoSomeThing();
            subClassB.DoSomeThing();
        }
    }
}
