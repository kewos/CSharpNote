using System.Collections.Generic;

namespace CSharpNote.Data.DesignPatternMethod.Implement.IteratorPattern
{
    public class BookStore : IAggregate<Book>
    {
        private readonly List<Book> books;

        public BookStore()
        {
            books = new List<Book>();
        }

        public void RegistBook(Book book)
        {
            books.Add(book);
        }

        public void RegistBook(IEnumerable<Book> books)
        {
            this.books.AddRange(books);
        }

        public IIterator<Book> GetIterator()
        {
            return new Iterator<Book>(books);
        }
    }
}
