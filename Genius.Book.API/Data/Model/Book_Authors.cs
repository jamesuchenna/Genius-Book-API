using GeniusBooks.API.Data.Model;

namespace GeniusBook.API.Data.Model
{
    public class Book_Authors
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
