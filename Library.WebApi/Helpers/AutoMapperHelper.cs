using Library.Application.Common.Mapping;
using Library.Application.Interfaces;
using System.Reflection;

namespace Library.WebApi.Helpers;

public static class AutoMapperHelper
{
    public static IServiceCollection AddConfiguredAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(ILibraryDbContext).Assembly));
        });

        return services;
    }
}
