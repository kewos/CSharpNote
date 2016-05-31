namespace CSharpNote.Data.DesignPattern.Implement.SpecificationPattern
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T> leftSpecification;
        private readonly ISpecification<T> rightSpecification;

        public OrSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            leftSpecification = left;
            rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return leftSpecification.IsSatisfiedBy(o) || rightSpecification.IsSatisfiedBy(o);
        }
    }
}