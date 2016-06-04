using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class GuidIsNotUnique : AbstractExecuteModule
    {
        [AopTarget("http://stackoverflow.com/questions/1705008/simple-proof-that-guid-is-not-unique?page=1&tab=votes")]
        public override void Execute()
        {
            var reserveSomeRam = new byte[1024*1024*100];
            Console.WriteLine("{0:u} - Building a bigHeapOGuids.", DateTime.Now);
            // Fill up memory with guids.   
            var bigHeapOGuids = new HashSet<Guid>();
            try
            {
                do
                {
                    bigHeapOGuids.Add(Guid.NewGuid());
                } while (true);
            }
            catch (OutOfMemoryException)
            {
                // Release the ram we allocated up front.             
                GC.KeepAlive(reserveSomeRam);
                GC.Collect();
            }
            Console.WriteLine("{0:u} - Built bigHeapOGuids, contains {1} of them.", DateTime.Now,
                bigHeapOGuids.LongCount());
            // Spool up some threads to keep checking if there's a match.         
            // Keep running until the heat death of the universe.          
            for (long k = 0; k < long.MaxValue; k++)
            {
                for (long j = 0; j < long.MaxValue; j++)
                {
                    Console.WriteLine("{0:u} - Looking for collisions with {1} thread(s)....", DateTime.Now,
                        Environment.ProcessorCount);
                    Parallel.For(0, int.MaxValue, i =>
                    {
                        if (bigHeapOGuids.Contains(Guid.NewGuid()))
                            throw new ApplicationException("Guids collided! Oh my gosh!");
                    });
                    Console.WriteLine("{0:u} - That was another {1} attempts without a collision.", DateTime.Now,
                        ((long) int.MaxValue)*Environment.ProcessorCount);
                }
            }
            Console.WriteLine("Umm... why hasn't the universe ended yet?");
        }
    }
}