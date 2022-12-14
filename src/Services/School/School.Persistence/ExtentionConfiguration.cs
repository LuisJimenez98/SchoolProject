using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using School.Application.Interfaces;
using School.Persistence.Repository;

namespace School.Persistence;
public static class ExtentionConfiguration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
         options.UseSqlServer(
             configuration.GetConnectionString("DefaultConnection"),
             x => x.MigrationsHistoryTable("__EFMigrationsHistory", "School")
        ));

        services.AddTransient(typeof(IRepository<>), typeof(MyRepository<>));
    }


}
