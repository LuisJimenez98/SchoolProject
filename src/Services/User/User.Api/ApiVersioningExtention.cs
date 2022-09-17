using User.Api.Middlewares;

namespace User.Api
{
    public static class ApiVersioningExtention
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
