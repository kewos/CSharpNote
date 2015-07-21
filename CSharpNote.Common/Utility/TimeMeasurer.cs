using System;
using System.Diagnostics;

namespace CSharpNote.Common.Utility
{
    /// <summary>
    /// 於Constructor start StopWatch
    /// 於Dispose stop StopWatch
    /// 
    /// 使用方式
    /// Using(new TimeMeasurer("xxx"))
    /// {
    ///     your action
    /// }
    /// </summary>
    public class TimeMeasurer : IDisposable
    {
        #region Constructor
        public TimeMeasurer(string message = "")
            : this(new Stopwatch(), message)
        { 
        }

        public TimeMeasurer(Stopwatch stopWatch, string message = "")
        {
            if (stopWatch == null)
            {
                return;
            }

            StopWatch = stopWatch;
            Message = message;

            StopWatch.Start();
        }
        #endregion

        #region Property
        private Stopwatch StopWatch { get; set; }
        private string Message { get; set; } 
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
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
