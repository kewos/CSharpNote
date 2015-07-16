namespace CSharpNote.Data.DesignPatternMethod.SubClass.NullObjectPattern
{
    public abstract class ObjectBase
    {
        private static readonly NullObject nullObject = new NullObject();

        public virtual string GetTypeName 
        {
            get 
            {
                return GetType().Name;
            } 
        }

        public virtual bool IsNull
        {
            get
            {
                return false;
            }
        }

        public static NullObject Null
        {
            get 
            {
                return nullObject;
            } 
        }
    }

    
}