using GeniusBook.API.Data.Model;
using GeniusBook.API.Data.ViewModel;

namespace GeniusBook.API.Data.Services
{
    public class PublisherService
    {
        private readonly AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;

        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name,
            };

            _context.Publisher.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
