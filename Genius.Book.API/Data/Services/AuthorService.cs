using GeniusBook.API.Data.Model;
using GeniusBook.API.Data.ViewModel;

namespace GeniusBook.API.Data.Services
{
    public class AuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;

        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName,
            };

            _context.Author.Add(_author);
            _context.SaveChanges();
        }
    }
}
