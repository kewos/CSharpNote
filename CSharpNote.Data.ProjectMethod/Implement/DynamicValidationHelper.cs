using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.Project.Implement.Validation;

namespace CSharpNote.Data.Project.Implement
{
    public class DynamicValidationHelper : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var helper = new ValidationHelper(new List<ValidationRecord>
            {
                new ValidationRecord
                {
                    Notification = null,
                    Skip = 0,
                    Take = 5,
                    Type = RuleTitle.English,
                    IsReverse = false,
                    IsReturn = false
                },
                new ValidationRecord
                {
                    Notification = null,
                    Skip = 0,
                    Take = 3,
                    Type = RuleTitle.English,
                    IsReverse = true,
                    IsReturn = false
                },
                new ValidationRecord
                {
                    Notification = null,
                    Skip = 5,
                    Take = 3,
                    Type = RuleTitle.Number,
                    IsReverse = false,
                    IsReturn = true
                }
            });

            var expect = helper.Parse("AAAAA678AAA");
            expect.ToConsole();
        }
    }
}