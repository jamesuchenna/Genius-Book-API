using GeniusBooks.API.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace GeniusBook.API.Data
{
    public class AppDbSeeder
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "First Wisdom",
                        Description = "Wisdom is the principal thing",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 5,
                        Genre = "Christian",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "Software development principles",
                        Description = "Principles for building scalable software solutions",
                        IsRead = false,
                        Genre = "Tech",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
