using Microsoft.AspNetCore.Identity;
using ProjectDemo1.Migrations;

namespace ProjectDemo1.Configurations;

public static class ServiceConfiguration
{
    public static void ConfigPassword(IServiceCollection service)
    {
        service.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 1;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }
}