using System;

namespace CSharpNote.Common.Extensions
{
    public static class ActionExtensions
    {
        /// <summary>
        /// 計算執行時間
        /// </summary>
        public static int CaculateExcuteTime(this Action source)
        {
            source.ValidationNotNull();

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            source();
            sw.Stop();
            return sw.Elapsed.Milliseconds;
        }

        /// <summary>
        /// 執行並且抓取例外
        /// </summary>
        public static string ExcauteAndCatchException(this Action source)
        {
            var result = string.Empty;

            try
            {
                source();
            }
            catch (Exception e)
            {
                result = string.Format("{0}:{1}", e.GetType().Name, e.Message);
            }

            return result;
        }
    }
}
