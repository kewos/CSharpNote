using System.Collections.Generic;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.NullObjectPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class NullObjectPatternImplement : AbstractExecuteModule
    {
        [MarkedItem]
        public override void Execute()
        {
            var repository = new ObjectRespository(new List<ObjectBase>
            {
                new ObjectA(),
                new ObjectB(),
                new ObjectC()
            });

            repository.Find("ObjectA").IsNull.ToConsole("ObjectAIsNull:");
            repository.Find("ObjectB").IsNull.ToConsole("ObjectBIsNull:");
            repository.Find("ObjectC").IsNull.ToConsole("ObjectCIsNull:");
            repository.Find("ObjectD").IsNull.ToConsole("ObjectDIsNull:");

            var nullObj = ObjectBase.Null;
            nullObj.IsNull.ToConsole("NullObjectIsNull");

            (ObjectBase.Null == ObjectBase.Null).ToConsole("NullObject == NullObject");
        }
    }
}