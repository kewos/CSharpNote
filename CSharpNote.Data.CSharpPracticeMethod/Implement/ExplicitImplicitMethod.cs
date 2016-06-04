using System;
using System.Text;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class ExplicitImplicitMethod : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            //隱含轉換
            TypeConvert obj1 = "test1";
            Console.WriteLine(obj1.ToString());

            //明確轉換
            var sb = new StringBuilder("test2");
            var obj2 = (TypeConvert) sb;

            //隱含轉換
            if (obj2)
            {
                Console.WriteLine(obj2.ToString());
            }

            Console.Read();
        }

        public class TypeConvert
        {
            private readonly string name;
            //將建構子設為私有，代表無法用new關鍵字new出A型別
            private TypeConvert(string name)
            {
                this.name = "ExampleObj:" + name;
            }

            //隱含轉換
            public static implicit operator TypeConvert(string expandedName)
            {
                return new TypeConvert(expandedName);
            }

            public static implicit operator bool(TypeConvert obj)
            {
                return true;
            }

            //明確轉換
            public static explicit operator TypeConvert(StringBuilder expandedName)
            {
                return new TypeConvert(expandedName.ToString());
            }

            public override string ToString()
            {
                return name;
            }
        }
    }
}