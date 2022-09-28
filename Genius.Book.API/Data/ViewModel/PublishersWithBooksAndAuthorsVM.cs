using System.Collections.Generic;

namespace GeniusBook.API.Data.ViewModel
{
    public class PublishersWithBooksAndAuthorsVM
    {
        public string Name { get; set; }
        public List<BookAuthorVM> BookAuthors { get; set; }
    }
}
