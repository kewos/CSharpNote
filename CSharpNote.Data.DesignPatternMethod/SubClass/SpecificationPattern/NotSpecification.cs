namespace CSharpNote.Data.DesignPatternMethod.SubClass.SpecificationPattern
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> specification;

        public NotSpecification(ISpecification<T> spec)
        {
            specification = spec;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return !specification.IsSatisfiedBy(o);
        }
    }
}