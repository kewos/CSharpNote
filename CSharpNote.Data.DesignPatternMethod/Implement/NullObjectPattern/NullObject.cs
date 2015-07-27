using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNote.Data.DesignPattern.Implement.NullObjectPattern
{
    public class NullObject : ObjectBase
    {
        public override bool IsNull
        {
            get
            {
                return !base.IsNull;
            }
        }
    }
}
