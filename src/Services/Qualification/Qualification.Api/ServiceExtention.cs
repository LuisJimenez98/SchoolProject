using Microsoft.AspNetCore.Mvc;

namespace Qualification.Api
{
    public static class ServiceExtention
    {
        public static void AddApiVersioningExtention(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });
        }
    }
}
