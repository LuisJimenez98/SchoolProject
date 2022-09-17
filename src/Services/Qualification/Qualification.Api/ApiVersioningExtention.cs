using Qualification.Api.Middlewares;

namespace Qualification.Api
{
    public static class ApiVersioningExtention
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
