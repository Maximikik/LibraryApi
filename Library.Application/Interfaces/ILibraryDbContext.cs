using Library.Domain;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Interfaces
{
    public interface ILibraryDbContext
    {
        DbSet<Book> Books { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
