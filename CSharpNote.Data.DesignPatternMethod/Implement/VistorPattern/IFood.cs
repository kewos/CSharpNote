namespace CSharpNote.Data.DesignPattern.Implement.VistorPattern
{
    public interface IFood
    {
        void Accept(IVisitor visitor);
    }
}