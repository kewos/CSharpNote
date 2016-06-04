using System;
using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.FilterPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class FilterPatternImplement : AbstractExecuteModule
    {
        /// <summary>
        ///     獨立Filter的樣式
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var address = new List<Address>
            {
                new Address {Contry = "Taiwan", City = "kaohsiung"},
                new Address {Contry = "Japan", City = "Tokyo"},
                new Address {Contry = "Taiwan", City = "Taipei"},
                new Address {Contry = "US", City = "NewYork"},
                new Address {Contry = "UK", City = "Londom"}
            };

            var filterManger = new FilterManager<Address>();
            foreach (var taiwanAddress in filterManger.ExecuteFilter<AddressTaiwanFilter>(address))
            {
                Console.WriteLine("Contry:{0} City:{1}",
                    taiwanAddress.Contry,
                    taiwanAddress.City);
            }
        }
    }
}