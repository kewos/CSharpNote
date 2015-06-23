using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Common.Utility
{
    public class TimeMeasurer : IDisposable
    {
        public TimeMeasurer()
            : this(new Stopwatch())
        { 
        }

        public TimeMeasurer(Stopwatch stopWatch)
        {
            this.StopWatch = stopWatch;
            Start();
        }

        private Stopwatch StopWatch { get; set; }

        private void Start()
        {
            if (StopWatch == null)
            {
                return;
            }
            StopWatch.Start();
            Console.WriteLine("==================Start->>");
        }

        private void Stop()
        {
            if (StopWatch == null)
            {
                return;
            }
            StopWatch.Stop();
            Console.WriteLine("==================Stop->> excution time:{0}ms", StopWatch.Elapsed.Milliseconds);
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
