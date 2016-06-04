using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class LinqAll : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var rules = new List<dynamic>
            {
                new
                {
                    Test = (Func<dynamic, bool>) (e => e.Name == "aa"),
                    Message = "He isnt aa"
                },
                new
                {
                    Test = (Func<dynamic, bool>) (e => e.ID != 0),
                    Message = "Without Indentify"
                },
                new
                {
                    Test = (Func<dynamic, bool>) (e => e.Age > 18),
                    Message = "Age dont enought"
                }
            };

            var people = new
            {
                Name = "aa",
                ID = 485489,
                Age = 25
            };

            if (rules.All(rule => rule.Test(people)))
            {
                foreach (var failState in rules.Where(rule => !rule.Test(people)))
                {
                    Console.WriteLine(failState.Message);
                }
            }
        }
    }
}