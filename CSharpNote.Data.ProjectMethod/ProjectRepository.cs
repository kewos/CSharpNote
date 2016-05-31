using System;
using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Common.Utility;
using CSharpNote.Core.Implements;
using CSharpNote.Data.Project.Implement.ORM;
using CSharpNote.Data.Project.Implement.ResultData;
using CSharpNote.Data.Project.Implement.Validation;

namespace CSharpNote.Data.Project
{
    [MarkedRepositoryAttribue]
    public class ProjectRepository : AbstractRepository
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

        [MarkedItem]
        public void Orm()
        {
            var data = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    {"Name", "tt"},
                    {"Id", "111"},
                    {"Phone", "111"},
                    {"TestDBColumn", "True"},
                    {"TestNullable", ""},
                    {"Money", "1010.22"},
                    {"CreateOn", "2015/3/11"},
                    {"ModifyOn", ""},
                    {"Level", "VIP"}
                },
                new Dictionary<string, string>
                {
                    {"Name", "tt"},
                    {"Id", "111"},
                    {"Phone", ""},
                    {"TestDBColumn", "false"},
                    {"TestNullable", "FaLse"},
                    {"Money", "1010.22"},
                    {"CreateOn", "2015/3/11"},
                    {"ModifyOn", ""},
                    {"Level", "Normal"}
                }
            };

            var helper = new ConvertHelper();
            using (new TimeMeasurer("Convert 200000Times"))
            {
                Enumerable.Range(1, 100000).ForEach(x =>
                {
                    var item = helper.Convert<Custom>(data).ToList();
                    var a = 0;
                });
            }
        }
    }
}