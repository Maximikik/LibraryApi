using Library.Persistence;
using Microsoft.AspNetCore.Identity;

namespace Library.WebApi.Helpers;

public static class IdentityCoreHelper
{
    public static IServiceCollection AddConfiguredIdentityCore(this IServiceCollection services)
    {
        services
            .AddIdentityCore<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<LibraryDbContext>();


        return services;
    }
}

