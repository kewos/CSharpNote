using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given a string containing only digits, restore it by returning all possible valid IP address combinations.
    //For example:
    //Given "25525511135",
    //return ["255.255.11.135", "255.255.111.35"]. (Order does not matter)
    public class RestoreIPAddresses : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/restore-ip-addresses/")]
        public override void Execute()
        {
            GetRestoreIPAddresses("25525511135").Dump();
        }

        private List<string> GetRestoreIPAddresses(string ip)
        {
            var ipSet = (from x in Enumerable.Range(1, 3)
                         from y in Enumerable.Range(1, 3)
                         from z in Enumerable.Range(1, 3)
                         select
                             new List<string>
                        {
                            ip.Substring(0, x),
                            ip.Substring(x, y),
                            ip.Substring(x + y + 1, z),
                            ip.Substring(x + y + z + 2)
                        }).ToList();

            return ipSet.Where(n => n.All(check)).Select(n => string.Join(".", n)).ToList();
        }

        private bool check(string ipNumber)
        {
            if (ipNumber.Length <= 0 || ipNumber.Length > 3)
                return false;

            var n = Convert.ToInt32(ipNumber);

            return n > 0 && n <= 255;
        }
    }
}