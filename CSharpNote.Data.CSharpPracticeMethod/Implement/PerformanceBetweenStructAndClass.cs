using System;
using System.Diagnostics;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class PerformanceBetweenStructAndClass : AbstractExecuteModule
    {
        /// <summary>
        ///     ®Ä¯à´ú¸Õ Struct and Class
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            const int max = 10000;

            var objStruct = new MyStructure[max];
            var objClass = new MyClass[max];

            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < max; i++)
            {
                objStruct[i] = new MyStructure {firstName = "test", lastName = "test"};
            }
            sw.Stop();
            Console.Write("struct :{0},{1}", sw.ElapsedTicks, Environment.NewLine);
            sw.Restart();

            for (var i = 0; i < max; i++)
            {
                objClass[i] = new MyClass {firstName = "test", lastName = "test"};
            }
            sw.Stop();
            Console.Write("class :{0},{1}", sw.ElapsedTicks, Environment.NewLine);

            Console.ReadLine();
        }

        private class MyClass
        {
            public string firstName;
            public string lastName;
        }

        private struct MyStructure
        {
            public string firstName;
            public string lastName;
        }
    }
}