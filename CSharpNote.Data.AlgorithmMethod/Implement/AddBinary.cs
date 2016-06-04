using System;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    /// <summary>
    ///     context
    ///     二進位字串加法
    ///     solution
    ///     先反轉ab字串列出所有加法情況逐一進行運算
    /// </summary>
    public class AddBinary : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            GetAddBinary("11", "1").ToConsole();
        }

        private string GetAddBinary(string a, string b)
        {
            if (string.IsNullOrEmpty(a))
                return b;

            if (string.IsNullOrEmpty(b))
                return a;

            a = a.Reverse();
            b = b.Reverse();

            var result = string.Empty;
            var bound = Math.Min(a.Length, b.Length);
            var carry = false;
            var currentIndex = 0;
            for (; currentIndex < bound; currentIndex++)
            {
                result += CaculateBit(ref carry, a[currentIndex], b[currentIndex]);
            }

            if (a.Length != b.Length)
            {
                var longArray = (a.Length > b.Length) ? a : b;
                for (; currentIndex < longArray.Length; currentIndex++)
                {
                    result += CaculateBit(ref carry, longArray[currentIndex]);
                }
            }

            if (carry)
                result += "1";

            return result.Reverse();
        }

        private string CaculateBit(ref bool add, char right = '0', char left = '0')
        {
            switch (right.ToString() + left.ToString() + add.ToString())
            {
                case "00False":
                    return "0";
                case "10False":
                case "01False":
                    return "1";
                case "11False":
                    add = true;
                    return "0";
                case "00True":
                    add = false;
                    return "1";
                case "10True":
                case "01True":
                    return "0";
                case "11True":
                    return "1";
                default:
                    throw new Exception();
            }
        }
    }
}