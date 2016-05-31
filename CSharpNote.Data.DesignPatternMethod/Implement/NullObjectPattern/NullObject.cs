namespace CSharpNote.Data.DesignPattern.Implement.NullObjectPattern
{
    public class NullObject : ObjectBase
    {
        public override bool IsNull
        {
            get { return !base.IsNull; }
        }
    }
}