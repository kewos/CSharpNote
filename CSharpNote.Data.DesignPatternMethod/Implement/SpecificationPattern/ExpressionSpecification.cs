using System;

namespace CSharpNote.Data.DesignPatternMethod.SubClass.SpecificationPattern
{
    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private Func<T, bool> expression;

        public ExpressionSpecification(Func<T, bool> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            this.expression = expression;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return expression(o);
        }
    }
}