using Matter.Api.Middlewares;

namespace Matter.Api
{
    public static class ApiVersioningExtention
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
