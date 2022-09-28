using GeniusBook.API.Data.Model;
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

        public void AddBookWithAuthors(BookVM book)
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
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };

            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Authors()
                {
                    AuthorId = id,
                    BookId = _book.Id
                };

                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() => _context.Books.ToList();
        public BookWithAuthorsVM GetABook(int bookId)
        {
            var _bookWithAuthors = _context.Books.Where(b => b.Id == bookId).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
        }

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
