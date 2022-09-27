using GeniusBooks.API.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace GeniusBook.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Books> Books { get; set; }
    }
}
