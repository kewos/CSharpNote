using System.Linq;
using System.Text;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Utility;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class PerformanceStringAdd : AbstractExecuteModule
    {
        /// <summary>
        ///     1.硉程畉
        ///     2.计秖程е
        ///     3.硉い单code虏间 畉concat翴
        ///     4.硉い单code虏间
        /// </summary>
        [AopTarget]
        public override void Execute()
        {
            var elements = Enumerable.Range(65, 26).Select(n => (char) n);

            #region Action1

            using (new TimeMeasurer("1. + operator"))
            {
                var chars = elements.ToList();
                foreach (var i in Enumerable.Range(1, 100000))
                {
                    var s = string.Empty;
                    foreach (var c in chars)
                    {
                        s += c;
                    }
                }
            }

            #endregion

            #region Action2

            using (new TimeMeasurer("2. String StringBuilder"))
            {
                var chars = elements.ToList();
                foreach (var i in Enumerable.Range(1, 100000))
                {
                    var sb = new StringBuilder();
                    foreach (var c in chars)
                    {
                        sb.Append(c);
                    }
                    var s = sb.ToString();
                }
            }

            #endregion

            #region Action3

            using (new TimeMeasurer("3. String Join"))
            {
                var chars = elements.ToList();
                foreach (var i in Enumerable.Range(1, 100000))
                {
                    var s = string.Join("", chars);
                }
            }

            #endregion

            #region Action4

            using (new TimeMeasurer("4. String Concat"))
            {
                var chars = elements.ToList();
                foreach (var i in Enumerable.Range(1, 100000))
                {
                    var s = string.Concat(chars);
                }
            }

            #endregion
        }
    }
}