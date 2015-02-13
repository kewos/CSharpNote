namespace CSharpNote.Data.DesignPatternMethod.SubClass.VistorPattern
{
    public interface IFood
    {
        void Accept(IVisitor visitor);
    }
}