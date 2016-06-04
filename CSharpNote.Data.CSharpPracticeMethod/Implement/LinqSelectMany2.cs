using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class LinqSelectMany2 : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var customers = new List<dynamic>
            {
                new {Id = 1, Name = "A"},
                new {Id = 2, Name = "B"},
                new {Id = 3, Name = "C"}
            };

            var orders = new List<dynamic>
            {
                new {Id = 1, CustomerId = 1, Description = "Order 1"},
                new {Id = 2, CustomerId = 1, Description = "Order 2"},
                new {Id = 3, CustomerId = 1, Description = "Order 3"},
                new {Id = 4, CustomerId = 1, Description = "Order 4"},
                new {Id = 5, CustomerId = 2, Description = "Order 5"},
                new {Id = 6, CustomerId = 2, Description = "Order 6"},
                new {Id = 7, CustomerId = 3, Description = "Order 7"},
                new {Id = 8, CustomerId = 3, Description = "Order 8"},
                new {Id = 9, CustomerId = 4, Description = "Order 9"}
            };

            var customerOrders2 = customers
                .SelectMany(c =>
                    orders.Where(o => o.CustomerId == c.Id),
                    (c, o) =>
                        new
                        {
                            CustomerId = c.Id,
                            c.Name,
                            OrderDescription = o.Description
                        });
            customerOrders2.DumpMany();
        }
    }
}