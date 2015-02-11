using System.Reflection;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.FecadePattern
{
    public class Fecade : IFecade
    {
        private readonly SubClassA subClassA;
        private readonly SubClassB subClassB;

        public Fecade()
        {
            subClassA = new SubClassA();
            subClassB = new SubClassB();
        }

        public string MethodA()
        {
            return subClassA.DoSomeThing() + MethodBase.GetCurrentMethod().Name;
        }

        public string MethodB()
        {
            return subClassB.DoSomeThing() + MethodBase.GetCurrentMethod().Name;
        }


        public string MethodC()
        {
            return MethodA() + MethodB();
        }
    }
}