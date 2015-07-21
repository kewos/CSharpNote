namespace CSharpNote.Data.DesignPatternMethod.Implement.VistorPattern
{
    public interface IFood
    {
        void Accept(IVisitor visitor);
    }
}