using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Qualification.Application.Interfaces;
using Qualification.Persistence.Repository;

namespace Qualification.Persistence;
public static class ExtentionConfiguration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Qualification")
            ));

        services.AddTransient(typeof(IRepository<>), typeof(MyRepository<>));
    }

}
