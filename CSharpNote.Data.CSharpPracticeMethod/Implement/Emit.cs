using System;
using System.Reflection;
using System.Reflection.Emit;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class Emit : AbstractExecuteModule
    {
        /// <summary>
        ///     1.Create an Assembly in an Application Domain.AssemblyBuilder will help you in that.
        ///     2.Create a Module inside the Assembly
        ///     3.Create a number of Type inside a Module
        ///     4.Add Properties, Methods, Events etc inside the Type.
        ///     5.Use ILGenerator to write inside the Properties, Methods etc.
        /// </summary>
        [AopTarget(@"http://www.codeproject.com/Articles/121568/Dynamic-Type-Using-Reflection-Emit")]
        public override void Execute()
        {
            var asmbuilder = GetAssemblyBuilder("MyAssembly");
            var mbuilder = GetModule(asmbuilder);
            var tbuilder = GetType(mbuilder, "MyClass");
            Type[] tparams = {typeof (int), typeof (int)};
            var methodSum = GetMethod(tbuilder, "Sum", typeof (float), tparams);

            //5.Use ILGenerator to write inside the Properties, Methods etc.
            var generator = methodSum.GetILGenerator();
            generator.DeclareLocal(typeof (float));
            generator.Emit(OpCodes.Ldarg_1);
            generator.Emit(OpCodes.Ldarg_2);
            generator.Emit(OpCodes.Add_Ovf);
            generator.Emit(OpCodes.Conv_R4);
            generator.Emit(OpCodes.Stloc_0);
            generator.Emit(OpCodes.Ldloc_0);
            generator.Emit(OpCodes.Ret);

            var type = tbuilder.CreateType();
            var a = type.GetMethod("Sum").Invoke(null, new object[] {10, 10});
        }

        #region emit

        /// <summary>
        ///     1.Create an Assembly in an Application Domain.AssemblyBuilder will help you in that.
        /// </summary>
        private AssemblyBuilder GetAssemblyBuilder(string assembleName)
        {
            var aname = new AssemblyName(assembleName);
            var currentDomain = AppDomain.CurrentDomain; // Thread.GetDomain();
            return currentDomain.DefineDynamicAssembly(aname, AssemblyBuilderAccess.Run);
        }

        /// <summary>
        ///     2.Create a Module inside the Assembly
        /// </summary>
        private ModuleBuilder GetModule(AssemblyBuilder asmBuilder)
        {
            return asmBuilder.DefineDynamicModule("EmitMethods", "EmitMethods.dll");
        }

        /// <summary>
        ///     3.Create a number of Type inside a Module
        /// </summary>
        private TypeBuilder GetType(ModuleBuilder modBuilder,
            string className)
        {
            var builder = modBuilder.DefineType(className, TypeAttributes.Public);
            return builder;
        }

        /// <summary>
        ///     4.Add Properties, Methods, Events etc inside the Type.
        /// </summary>
        /// <returns></returns>
        private MethodBuilder GetMethod(TypeBuilder typBuilder,
            string methodName,
            Type returnType, params Type[] parameterTypes)
        {
            var builder = typBuilder.DefineMethod(methodName,
                MethodAttributes.Public | MethodAttributes.HideBySig,
                CallingConventions.HasThis, returnType, parameterTypes);
            return builder;
        }

        #endregion emit
    }
}