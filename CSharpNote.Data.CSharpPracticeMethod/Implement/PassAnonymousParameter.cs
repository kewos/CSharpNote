using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class PassAnonymousParameter : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            HandleAnonymousParameter(
                new List<dynamic>
                {
                    new
                    {
                        Name = "John",
                        Speak = (Action<string>) (name => { Console.WriteLine("MyName is {0}", name); })
                    },
                    new
                    {
                        Name = "Nancy",
                        Speak = (Action<string>) (name => { Console.WriteLine("MyName is {0}", name); })
                    },
                    new
                    {
                        Name = "Kent",
                        Speak = (Action<string>) (name => { Console.WriteLine("MyName is {0}", name); })
                    }
                }
                );
        }

        private void HandleAnonymousParameter(dynamic anonymousList)
        {
            foreach (var anonymousPerson in anonymousList)
            {
                anonymousPerson.Speak(anonymousPerson.Name);
            }
        }
    }
}