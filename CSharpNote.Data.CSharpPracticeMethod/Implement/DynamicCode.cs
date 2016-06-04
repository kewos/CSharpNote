using System.CodeDom.Compiler;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using Microsoft.CSharp;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class DynamicCode : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var fooInterface = @"
            class Foo : FooLibrary.IPrint {
                public void Print() {
                    System.Console.WriteLine(""Hello from class Foo"");
                }
            }";

            CodeDomProvider cpd = new CSharpCodeProvider();
            var cp = new CompilerParameters();
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("¹Bºâ¤¸¾Þ§@.dll");
            cp.GenerateExecutable = false;

            // Invoke compilation.
            var cr = cpd.CompileAssemblyFromSource(cp, fooInterface);
            var assembly = cr.CompiledAssembly;

            var fType = assembly.GetTypes()[0];
            var iType = fType.GetInterface("FooLibrary.IPrint");

            if (iType != null)
            {
                //FooLibrary.IPrint foo = (FooLibrary.IPrint)assembly.CreateInstance(fType.FullName);
                //foo.Print();
            }
        }
    }
}