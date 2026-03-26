using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApi.Application.Abstractions;
using MyApi.Infrastructure.Data;
using MyApi.Infrastructure.Repositories;
using MyApi.Infrastructure.Auth;

namespace MyApi.Infrastructure;

// keeps EF and repository registration out of Program.cs.
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordHasherService, PasswordHasherService>();

        return services;
    }
}