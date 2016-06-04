using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Utility;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class PerformaceStringNull : AbstractExecuteModule
    {
        /// <summary>
        ///     IsNullOrEmpty > string.empty > ""
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            #region Action1

            using (new TimeMeasurer("1. ''"))
            {
                foreach (var i in Enumerable.Range(1, 10000000))
                {
                    string s = null;
                    if (s == "")
                    {
                    }
                }
            }

            #endregion

            #region Action2

            using (new TimeMeasurer("2.string.Empty"))
            {
                foreach (var i in Enumerable.Range(1, 10000000))
                {
                    string s = null;
                    if (s == string.Empty)
                    {
                    }
                }
            }

            #endregion

            #region Action3

            using (new TimeMeasurer("3.IsNullOrEmpty"))
            {
                foreach (var i in Enumerable.Range(1, 10000000))
                {
                    string s = null;
                    if (string.IsNullOrEmpty(s))
                    {
                    }
                }
            }

            #endregion
        }
    }
}