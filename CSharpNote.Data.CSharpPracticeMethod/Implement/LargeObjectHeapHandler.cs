using System;
using System.Collections.Generic;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class LargeObjectHeapHandler
    {
        /// <summary>
        /// Static variable used to store our 'big' block. This ensures that the block is always up for garbage collection.
        /// </summary>
        public byte[] bigBlock;

        /// <summary>
        /// Allocates 90,000 byte blocks, optionally intersperced with larger blocks
        /// </summary>
        public void Fill(bool allocateBigBlocks, bool grow, bool alwaysGC)
        {
            // Number of bytes in a small block
            // 90000 bytes, just above the limit for the LOH
            const int blockSize = 90000;

            // Number of bytes in a larger block: 16Mb initially
            int largeBlockSize = 1 << 24;

            // Number of small blocks allocated
            int count = 0;

            try
            {
                // We keep the 'small' blocks around
                // (imagine an algorithm that allocates memory in chunks)
                List<byte[]> smallBlocks = new List<byte[]>();

                while (true)
                {
                    // Write out some status information
                    if ((count % 1000) == 0)
                    {
                        Console.CursorLeft = 0;
                        Console.Write(new string(' ', 20));
                        Console.CursorLeft = 0;
                        Console.Write("{0}", count);
                        Console.CursorLeft = 0;
                    }

                    if (alwaysGC)
                    {
                        GC.Collect();
                    }
                    if (allocateBigBlocks)
                    {
                        bigBlock = new byte[largeBlockSize];
                    }
                    if (grow)
                    {
                        largeBlockSize++;
                    }
                    smallBlocks.Add(new byte[blockSize]);
                    count++;
                }
            }
            catch (OutOfMemoryException)
            {
                bigBlock = null;
                GC.Collect();
                Console.WriteLine("{1}Mb allocated", (count * blockSize) / (1024 * 1024));
            }
        }
    }
}
