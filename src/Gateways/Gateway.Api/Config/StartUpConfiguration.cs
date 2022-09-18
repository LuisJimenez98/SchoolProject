using Api.Gateway.Application.Wrappers;

namespace Gateway.Api.Config
{
    public static class StartUpConfiguration
    {
        public static IServiceCollection AddAppsettingBinding(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<ApiUrl>(opts => configuration.GetSection("ApiUrl").Bind(opts));
            return service;
        }


        public static IServiceCollection AddProxiesRegistration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHttpContextAccessor();

            service.AddHttpClient<ISchoolProxy, SchoolProxy>();
            service.AddHttpClient<IMatterProxy, MatterProxy>();
            service.AddHttpClient<IQualificationProxy, QualificationProxy>();

            return service;
        }
    }
}
