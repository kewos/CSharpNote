using CSharpNote.Common.Attributes;
using CSharpNote.Core.Implements;

namespace CSharpNote.Data.RefactoringToPattern
{
    public class RefactoringToPatternRepository : AbstractRepository
    {
        [AopTarget]
        public void StateMachine()
        {
        }
    }
}