using Global_Logic_ASP.Core.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Global_Logic_ASP.Core.Extensions
{
    static class TopSecretExtentions
    {
        public static IApplicationBuilder UseTopSecret(this IApplicationBuilder app, string path)
        {
            return app.UseMiddleware<TopSecret>(path);
        }
    }
}
