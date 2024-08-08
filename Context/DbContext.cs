using Microsoft.EntityFrameworkCore;
using SimpleLibraryAPI.Models;

namespace SimpleLibraryAPI.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
