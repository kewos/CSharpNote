using System.Linq;
using CSharpNote.Common.Attributes;
using CSharpNote.Common.Extensions;
using CSharpNote.Core.Implements;
using CSharpNote.Data.DesignPattern.Implement.IteratorPattern;

namespace CSharpNote.Data.DesignPattern.Implement
{
    public class IteratorPatternImplement : AbstractExecuteModule
    {
        [AopTarget]
        public override void Execute()
        {
            var bookStore = new BookStore();
            bookStore.RegistBook(Enumerable.Range(1, 10)
                .Select(x => new Book
                {
                    Id = x,
                    Descriptioin = x.ToString()
                }));

            var iterator = bookStore.GetIterator();
            while (iterator.HasNext())
            {
                var book = iterator.Next();
                book.Id.ToConsole();
            }
        }
    }
}