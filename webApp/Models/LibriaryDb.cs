using System.Data.Entity;

namespace webApp.Models
{
    public class LibriaryDb : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}