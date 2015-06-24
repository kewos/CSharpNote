using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Common.Utility
{
    /// <summary>
    /// 於Constructor start StopWatch
    /// 於Dispose stop StopWatch
    /// 
    /// 使用方式
    /// Using(var tm = new TimeMeasurer())
    /// {
    ///     tm.Message = "xxx";
    /// }
    /// </summary>
    public class TimeMeasurer : IDisposable
    {
        #region Constructor
        public TimeMeasurer()
            : this(new Stopwatch())
        { 
        }

        public TimeMeasurer(Stopwatch stopWatch)
        {
            this.StopWatch = stopWatch;

            if (StopWatch == null)
            {
                return;
            }

            StopWatch.Start();
        }
        #endregion

        #region Property
        private Stopwatch StopWatch { get; set; }
        public string Message { get; set; } 
        #endregion

        #region IDisposable Member
        public void Dispose()
        {
            if (StopWatch == null)
            {
                return;
            }

            var result = string.Format("{0} excution time:{1}ms", Message, StopWatch.Elapsed.Milliseconds);
            Console.WriteLine(result.Trim());
        } 
        #endregion
    }
}
