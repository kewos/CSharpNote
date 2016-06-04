using System;
using System.ComponentModel;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.CSharpPractice.Implement
{
    public class GetAllEnumDesciption : AbstractExecuteModule
    {
        public enum Country
        {
            [Description("Tailand Description")] Tailand,
            [Description("Japan Description")] Japan,
            [Description("Korea Description")] Korea,
            [Description("Singapore Description")] Singapore
        }

        [AopTarget]
        public override void Execute()
        {
            var type = typeof (Country);
            Enum.GetValues(type).Cast<Country>()
                .Select(mode =>
                {
                    var memInfo = type.GetMember(mode.ToString());
                    var attributes = memInfo[0].GetCustomAttributes(typeof (DescriptionAttribute),
                        false);

                    return ((DescriptionAttribute) attributes[0]).Description;
                })
                .DumpMany();
        }
    }
}