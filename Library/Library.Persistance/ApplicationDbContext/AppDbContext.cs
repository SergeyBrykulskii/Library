using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Persistance.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistance.ApplicationDbContext;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());

        modelBuilder.Entity<Author>().HasData(
                new Author { Id = Guid.Parse("5d836356-e43b-421d-985e-add2a4b341db"), FirstName = "Leo", Surname = "Tolstoy" },
                new Author { Id = Guid.Parse("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"), FirstName = "Ray", Surname = "Bradbury" }
            );

        modelBuilder.Entity<Book>().HasData(

                 new Book
                 {
                     Id = Guid.Parse("295dbecc-3bac-4b46-934a-1b4dabdab24e"),
                     ISBN = "978-0-006-54606-1",
                     Title = "Fahrenheit 451",
                     Description = "Nearly seventy years after its original publication," +
                         " Ray Bradbury’s internationally acclaimed novel Fahrenheit 451 stands" +
                         " as a classic of world literature set in a bleak, dystopian future." +
                         " Today its message has grown more relevant than ever before",
                     RecieveDate = DateTime.Now,
                     ReturnDate = DateTime.Now,
                     AuthorId = Guid.Parse("f209ef7c-5537-4c17-a5ad-b0584b55a0d9"),
                     Genre = "Dystopian",
                 },

                 new Book
                 {
                     Id = Guid.Parse("b0bbcaf3-5b56-48b5-a2e6-4ed00050826f"),
                     ISBN = "978-9-464-81540-5",
                     Title = "War and Peace",
                     Description = "War and Peace is a vast epic centred on Napoleon's war with Russia.",
                     RecieveDate = DateTime.Now,
                     ReturnDate = DateTime.Now,
                     AuthorId = Guid.Parse("5d836356-e43b-421d-985e-add2a4b341db"),
                     Genre = "Historical novel",
                 }
            );

        base.OnModelCreating(modelBuilder);
    }
}
