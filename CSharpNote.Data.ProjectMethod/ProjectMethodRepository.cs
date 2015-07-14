using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extendsions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.ProjectMethod.SubClass.Validation;
using CSharpNote.Data.ProjectMethod.SubClass.ResultData;

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

        [MarkedItem]
        public void ResultData()
        { 
            var data1 = new ResultData(new Exception("Test"), "");
            if (!data1)
            {
                Console.WriteLine(data1.ToString());
            }

            var data2 = new ResultData(true, "Test", 1);
            if (!data2)
            {
                Console.WriteLine(data2.ToString());
                Console.WriteLine(data2.GetData<int>());
            }
        }
    }
}
