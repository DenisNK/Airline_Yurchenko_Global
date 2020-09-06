using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using static System.IO.File;
using static System.IO.Path;

namespace Global_Logic_ASP.Core.Middleware
{
    public class TopSecret
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;
        private readonly string _path;
                                                                
        public TopSecret(RequestDelegate next, IWebHostEnvironment env, string path)
        {
            _next = next;
            _env = env;
            _path = path;
        }
                            
        public async Task Invoke(HttpContext context)
        {
            var name = context.Request.Path.Value.Split("/").Last(); // like secret.secret
            if (!name.EndsWith("secret.secret"))
            {
                await _next(context);  //If the file is not needed, give the content
            }
            else
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    var pathToSecret = Combine(_env.ContentRootPath, _path, name);

                    await using FileStream f = Open(pathToSecret, FileMode.Open, FileAccess.Read);
                    var buffer = new byte[f.Length];
                    f.Read(buffer, 0, (int) f.Length);

                    await context.Response.Body.WriteAsync(buffer, 0, (int) f.Length);
                }
                else
                {
                    await context.Response.HttpContext.ForbidAsync(); //.Response.WriteAsync("This file is only accessible to authenticated user");
                }
            }
        }
    }
}
