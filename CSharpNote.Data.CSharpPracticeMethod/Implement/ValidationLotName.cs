using System.Collections.Generic;
using System.Text.RegularExpressions;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class ValidationLotName : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var regex = @"^[1-9]{1}[0-9]{6,}[.]{1}[1-9]{1}[0-9]*$";
            var validation = new List<string>
            {
                "2929330.01",
                "2929330.1000",
                "2929330.00",
                "292933.1",
                "0929330.1",
                "19293301.1",
                "19293301111111111111.11111111111111"
            };
            foreach (var valid in validation)
            {
                var bon = new Regex(regex).IsMatch(valid);
                string.Format("{0}:{1}", valid, bon).ToConsole();
            }
        }
    }
}