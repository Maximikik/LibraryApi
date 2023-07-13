using Library.Application.Interfaces;
using Library.Domain;
using Library.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence;

public class LibraryDbContext: DbContext, ILibraryDbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options): base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
