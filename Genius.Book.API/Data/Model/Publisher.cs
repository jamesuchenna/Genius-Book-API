using GeniusBooks.API.Data.Model;
using System.Collections.Generic;

namespace GeniusBook.API.Data.Model
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book> Books { get; set; }
    }
}
