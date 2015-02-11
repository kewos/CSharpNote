namespace CSharpNote.Data.DesignPatternMethod.SubClass.NullObjectPattern
{
    public abstract class ObjectBase
    {
        public virtual string GetTypeName { get { return GetType().Name; } }
        public static NullObject Null { get { return new NullObject(); } }

        public class NullObject : ObjectBase
        {
        }
    }
}