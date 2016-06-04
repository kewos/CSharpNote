using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    public class LengthOfLastWord1 : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            GetLengthOfLastWord("abc abca abc").ToConsole();
        }

        private int GetLengthOfLastWord(string s)
        {
            return (from set in s.Split(' ').Reverse() where set.Length != 0 select set.Length).FirstOrDefault();
        }
    }
}