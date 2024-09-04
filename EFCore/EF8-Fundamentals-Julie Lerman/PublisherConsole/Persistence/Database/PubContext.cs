using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PublisherDomain;

namespace PublisherConsole.Persistence.Database
{
    public class PubContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public PubContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase");

            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Rhoda", LastName = "Lerman" });

            var authorList = new Author[]
            {
                new Author { Id = 2, FirstName = "Archer", LastName = "Schanz" },
                new Author { Id = 3, FirstName = "Molly", LastName = "Rhodes" },
                new Author { Id = 4, FirstName = "Rafa", LastName = "Schrhodes" },
                new Author { Id = 5, FirstName = "Rodger", LastName = "Schrhodes" }
            };

            modelBuilder.Entity<Author>().HasData(authorList);

            //base.OnModelCreating(modelBuilder);
        }

    }
}
