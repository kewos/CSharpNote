namespace CSharpNote.Data.DesignPatternMethod.Implement.AdapterPattern
{
    public abstract class AnimalAdaptorBase<T> : IAnimal
    {
        protected readonly T element;
        public AnimalAdaptorBase(T element)
        {
            this.element = element;
        }

        public abstract void Run();
    }
}