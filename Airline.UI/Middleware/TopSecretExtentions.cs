using Microsoft.AspNetCore.Builder;

namespace Airline_Yurchenko.Middleware
{
    static class TopSecretExtentions
    {
        public static IApplicationBuilder UseTopSecret(this IApplicationBuilder app, string path)
        {
            return app.UseMiddleware<TopSecret>(path);
        }
    }
}
