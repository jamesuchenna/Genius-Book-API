using System.Collections.Generic;

namespace GeniusBook.API.Data.ViewModel
{
    public class AuthorWithBooksVM
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
