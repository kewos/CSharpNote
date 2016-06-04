using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class BadNeighbors : AbstractExecuteModule
    {
        [AopTarget(@"http://community.topcoder.com/tc?module=ProblemDetail&rd=5009&pm=2402")]
        public override void Execute()
        {
            var donations = new List<int> {10, 3, 2, 5, 7, 8};
            Console.WriteLine(MaxDonations(donations));

            var donations1 = new List<int> {11, 15};
            Console.WriteLine(MaxDonations(donations1));

            var donations2 = new List<int> {7, 7, 7, 7, 7, 7, 7};
            Console.WriteLine(MaxDonations(donations2));

            var donations3 = new List<int> {1, 2, 3, 4, 5, 1, 2, 3, 4, 5};
            Console.WriteLine(MaxDonations(donations3));

            var donations4 = new List<int>
            {
                94,
                40,
                49,
                65,
                21,
                21,
                106,
                80,
                92,
                81,
                679,
                4,
                61,
                6,
                237,
                12,
                72,
                74,
                29,
                95,
                265,
                35,
                47,
                1,
                61,
                397,
                52,
                72,
                37,
                51,
                1,
                81,
                45,
                435,
                7,
                36,
                57,
                86,
                81,
                72
            };

            Console.WriteLine(MaxDonations(donations4));
        }

        private int MaxDonations(List<int> donations)
        {
            var max = new Dictionary<int, int>
            {
                {0, donations[0]},
                {1, donations[1]}
            };

            var index = 2;
            while (index < donations.Count() - 1)
            {
                if (index - 2 == 0)
                {
                    max.Add(2, Math.Max(donations[0], donations[donations.Count() - 1]) + donations[2]);
                    index++;
                    continue;
                }

                max.Add(index, Math.Max(max[index - 2], max[index - 3]) + donations[index]);
                index++;
            }

            return max.Max(m => m.Value);
        }
    }
}