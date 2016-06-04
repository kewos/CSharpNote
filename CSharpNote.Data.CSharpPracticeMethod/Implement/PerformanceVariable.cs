using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Utility;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class PerformanceVariable : AbstractExecuteModule
    {
        /// <summary>
        ///     ½sÄ¶«áILCode
        ///     Action1 ((((((((((i + 1) + 1) + 1) + 1) + 1) + 1) + 1) + 1) + 1) + 1)
        ///     Action2 i + 10
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            #region Action1

            using (new TimeMeasurer("Action1"))
            {
                foreach (var i in Enumerable.Range(1, 10000000))
                {
                    var j = i + 1 + 1 + 1 + 1 + 1 + 1 + 1 + 1 + 1 + 1;
                }
            }

            #endregion

            #region Action2

            using (new TimeMeasurer("Action2"))
            {
                foreach (var i in Enumerable.Range(1, 10000000))
                {
                    var j = i + (1 + 1 + 1 + 1 + 1 + 1 + 1 + 1 + 1 + 1);
                }
            }

            #endregion
        }
    }
}