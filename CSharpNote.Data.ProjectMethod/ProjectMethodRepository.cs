using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.ProjectMethod.Validation;

namespace CSharpNote.Data.ProjectMethod
{
    [MarkedRepositoryAttribue]
    public class ProjectMethodRepository : AbstractMethodRepository
    {
        [MarkedItem]
        public void DynamicValidationHelper()
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
