using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class DefaultValue : AbstractExecuteModule
    {
        /// <summary>
        ///     Conclusion
        ///     1.refenence type default value is null
        ///     2.value type default value is 0, struct is value type each item all default value
        ///     3.nullable return nullable<T>
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            //refenece type
            default(List<int>).ToConsole("List<int> default:");
            default(string).ToConsole("string default:");
            default(TestClass).ToConsole("TestClass default:");

            //value type
            default(int).ToConsole("int default:");
            default(DateTime).ToConsole("DateTime default:");
            default(TestEnum).ToConsole("TestEnum default:");

            //nullable type
            default(DateTime?).ToConsole("DateTime? default:");
            default(int?).ToConsole("int? default:");
        }

        private enum TestEnum
        {
        }

        private class TestClass
        {
        }
    }
}