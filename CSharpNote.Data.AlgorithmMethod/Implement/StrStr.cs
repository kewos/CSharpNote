using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// <summary>
    ///     context
    ///     ±qhaystack´M§äneedleªº¦ì¸m
    ///     solution
    /// </summary>
    public class StrStr : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var haystack = "mississippi";
            var needle = "pi";

            GetStrStr(haystack, needle).ToConsole();
        }

        private int GetStrStr(string haystack, string needle)
        {
            if (needle.Length > haystack.Length)
                return -1;

            if (needle == haystack)
                return 0;

            if (haystack.Length == 0 || needle.Length == 0)
                return -1;

            for (var i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                if (haystack[i] == needle[0] && haystack.Substring(i, needle.Length) == needle)
                    return i;
            }

            return -1;
        }
    }
}