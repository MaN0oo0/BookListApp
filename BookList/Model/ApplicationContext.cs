using Microsoft.EntityFrameworkCore;

namespace BookList.Model
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext>options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
