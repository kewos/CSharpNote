using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.Algorithm.Implement
{
    //https://oj.leetcode.com/problems/valid-number/
    //Validate if a given string is numeric.
    //Some examples:
    //"0" => true
    //" 0.1 " => true
    //"abc" => false
    //"1 a" => false
    //"2e10" => true
    //Note: It is intended for the problem statement to be ambiguous. You should gather all requirements up front before implementing one.
    public class ValidNumber : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            IsNumberic("0");
            IsNumberic("0.1");
            IsNumberic("abc");
            IsNumberic("1 a");
            IsNumberic("2e");
        }

        private void IsNumberic(string validationString)
        {
            var integerRegex1 = @"^[0]$";
            var integerRegex = @"^[-]??[1-9]{1}[0-9]+$";
            var floatRegex = @"^[-]??[0-9]+[.]{1}[0-9]+$";
            var floatRegex1 = @"^[-]??[0-9]{1}[.]{1}[0-9]+$";
            var scientificNotation = @"^[-]??[1-9]{1}[0-9]{0,}[e]{1}$";

            var regexList = new List<string>
            {
                integerRegex,
                integerRegex1,
                floatRegex,
                floatRegex1,
                scientificNotation
            };

            var state = regexList
                .Any(regex => new Regex(regex).IsMatch(validationString));

            Console.WriteLine("{0}:{1}", validationString, state);
        }
    }
}