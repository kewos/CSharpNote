namespace CSharpNote.Data.DesignPatternMethod.SubClass.SpecificationPattern
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        ISpecification<T> leftSpecification;
        ISpecification<T> rightSpecification;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            leftSpecification = left;
            rightSpecification = right;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return leftSpecification.IsSatisfiedBy(o) && rightSpecification.IsSatisfiedBy(o);
        }
    }
}