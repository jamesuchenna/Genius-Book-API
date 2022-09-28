using System.Collections.Generic;

namespace GeniusBook.API.Data.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<Book_Authors> Book_Authors { get; set; }
    }
}
