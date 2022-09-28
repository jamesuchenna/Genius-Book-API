using GeniusBook.API.Data.ViewModel;
using GeniusBooks.API.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniusBook.API.Data.Services
{
    public class BookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                Author = book.Author,
                DateAdded = DateTime.Now
            };

            _context.Books.Add(_book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();
        public Book GetABook(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId);

        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);

            if (_book == null)
            {
                throw new Exception();
            }

            _book.Title = book.Title;
            _book.Description = book.Description;
            _book.IsRead = book.IsRead;
            _book.DateRead = book.IsRead ? book.DateRead.Value : null;
            _book.Rate = book.IsRead ? book.Rate.Value : null;
            _book.Genre = book.Genre;
            _book.CoverUrl = book.CoverUrl;
            _book.Author = book.Author;

            _context.SaveChanges();

            return _book;
        }

        public void DeleteBookById(int bookId)
        {
            var book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            
            if (book == null)
            {
                throw new Exception();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
