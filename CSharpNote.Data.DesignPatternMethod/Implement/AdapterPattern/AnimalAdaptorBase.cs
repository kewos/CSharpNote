namespace CSharpNote.Data.DesignPattern.Implement.AdapterPattern
{
    public abstract class AnimalAdaptorBase<T> : IAnimal
    {
        protected readonly T element;

        protected AnimalAdaptorBase(T element)
        {
            this.element = element;
        }

        public abstract void Run();
    }
}