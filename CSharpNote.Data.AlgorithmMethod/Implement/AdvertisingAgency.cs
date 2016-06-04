using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class AdvertisingAgency : AbstractExecuteModule
    {
        [MarkedItem(@"http://community.topcoder.com/stat?c=problem_statement&pm=7558")]
        public override void Execute()
        {
            var input1 = new List<int> { 1, 2, 3 };
            Console.WriteLine(NumberOfRejections(input1));

            var input2 = new List<int> { 1, 1, 1 };
            Console.WriteLine(NumberOfRejections(input2));

            var input3 = new List<int> { 1, 2, 1, 2 };
            Console.WriteLine(NumberOfRejections(input3));
        }

        private int NumberOfRejections(List<int> requests)
        {
            if (requests.Count > 50)
                return -1;

            var reject = 0;
            var accepts = new List<int>();
            foreach (var request in requests)
            {
                if (request > 100 || request < 1)
                {
                    reject++;
                    continue;
                }

                if (accepts.Contains(request))
                    reject++;
                else
                    accepts.Add(request);
            }

            return reject;
        }
    }
}