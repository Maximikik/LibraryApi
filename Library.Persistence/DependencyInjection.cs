using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Library.Application.Interfaces;

namespace Library.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services,
        string? connectionString)
    {
        services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<ILibraryDbContext>(provider =>
            provider.GetService<LibraryDbContext>()!);
        return services;
    }
}
