using System;

namespace CSharpNote.Common.Extendsions
{
    public static class ActionExtensions
    {
        public static int CaculateExcuteTime(this Action action)
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            if (action != null) action();
            sw.Stop();
            return sw.Elapsed.Milliseconds;
        }

        public static string ExcauteAndCatchException(this Action action)
        {
            var result = string.Empty;

            try
            {
                action();
            }
            catch (Exception e)
            {
                result = string.Format("{0}:{1}", e.GetType().Name, e.Message);
            }

            return result;
        }
    }
}
