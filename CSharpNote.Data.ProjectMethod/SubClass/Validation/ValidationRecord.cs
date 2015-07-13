using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.ProjectMethod.SubClass.Validation
{
    public class ValidationRecord
    {
        public string Notification { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public RuleTitle Type { get; set; }
        public bool IsReverse { get; set; }
        public bool IsReturn { get; set; }
    }
}
