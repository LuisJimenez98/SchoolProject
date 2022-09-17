using Matter.Application.Interfaces;
using Matter.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Matter.Persistence;
public static class ExtentionConfiguration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Matter")
            ));

        services.AddTransient(typeof(IRepository<>), typeof(MyRepository<>));
    }

}
