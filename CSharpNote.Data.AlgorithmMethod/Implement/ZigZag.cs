using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class ZigZag : AbstractExecuteModule
    {
        [AopTarget(@"http://community.topcoder.com/tc?module=ProblemDetail&rd=4493&pm=1259")]
        public override void Execute()
        {
            //var zigZagSequence = new List<int> { 1, 7, 4, 9, 2, 5 };
            //Console.WriteLine(LongestZigZag(zigZagSequence));
            var zigZagSequence1 = new List<int> {1, 17, 5, 10, 13, 15, 10, 5, 16, 8};
            Console.WriteLine(LongestZigZag(zigZagSequence1));
            //var zigZagSequence2 = new List<int> { 44 };
            //Console.WriteLine(LongestZigZag(zigZagSequence2));
        }

        private int LongestZigZag(List<int> zigZagSequence)
        {
            var index = 0;
            var max = 1;
            var tempMax = 1;
            bool? state = null;
            while (index < zigZagSequence.Count() - 1)
            {
                var nextState = (zigZagSequence[index] > zigZagSequence[index + 1]);
                if (state == null)
                {
                    state = nextState;
                    tempMax = 2;
                    max = Math.Max(tempMax, max);
                    index++;
                    continue;
                }

                if (nextState == state)
                {
                    state = !state;
                    max = Math.Max(++tempMax, max);
                    index++;
                }
                else
                    state = null;
            }

            return max;
        }
    }
}