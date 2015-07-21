namespace CSharpNote.Data.DesignPatternMethod.Implement.SpecificationPattern
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