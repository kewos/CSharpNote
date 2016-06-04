using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class DynamicalCreateGeneric : AbstractExecuteModule
    {
        /// <summary>
        ///     動態產生汎形物件
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var types = new List<Type> {typeof (int), typeof (string), typeof (double), typeof (char), typeof (bool)};

            var type = typeof (ObjectA<>);
            foreach (dynamic obj in
                types.Select(t => Activator.CreateInstance(type.MakeGenericType(t)))
                )
            {
                obj.SpeakType();
            }
        }

        private class ObjectA<T>
        {
            public void SpeakType()
            {
                Console.WriteLine(typeof (T));
            }
        }
    }
}