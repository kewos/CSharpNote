using System.Collections.Generic;
using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Common.Utility;
using CSharpNote.Core.Implements;
using CSharpNote.Data.Project.Implement.ORM;

namespace CSharpNote.Data.Project.Implement
{
    public class TestOrm : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
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