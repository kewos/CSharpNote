using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //Given a positive integer, return its corresponding column title as appear in an Excel sheet.
    public class ExcelSheetColumnTitle : AbstractExecuteModule
    {
        [MarkedItem(@"https://oj.leetcode.com/problems/excel-sheet-column-title/")]
        public override void Execute()
        {
            GetExcelSheetColumnTitle(28).ToConsole();
        }

        private string GetExcelSheetColumnTitle(int number)
        {
            var chars = new List<char>();
            while (number > 0)
            {
                chars.Add((char)((number - 1) % 26 + 65));
                number = (number - 1) / 26;
            }

            chars.Reverse();

            return string.Concat(chars);
        }
    }
}