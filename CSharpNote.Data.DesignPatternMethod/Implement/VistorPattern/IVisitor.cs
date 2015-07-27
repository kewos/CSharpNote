namespace CSharpNote.Data.DesignPattern.Implement.VistorPattern
{
    public interface IVisitor
    {
        void VisitCoffee(Coffee coffee);
        void VisitMeat(Meat meet);
        void VisitVegetable(Vegetable vegetable);
    }
}