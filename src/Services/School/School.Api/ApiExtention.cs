using School.Api.Middlewares;

namespace School.Api
{
    public static class ApiExtention
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
