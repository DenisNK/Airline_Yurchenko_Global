using System;
using System.IO;
using System.Linq;
using Airline.BLL.Extensions;
using Airline.DAL.Airline_Db_Context;
using Airline.DAL.Initializator;
using Airline_Yurchenko.FiltersApp;
using Airline_Yurchenko.LoggerManager;
using Airline_Yurchenko.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static Airline.DAL.Initializator.Constants;
using NLog;

namespace Airline_Yurchenko
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AirlineContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString(DEFAULT_CONNECTION)));

            services.AddRepositories();
            services.AddScoped(typeof(IMyImage<>), typeof(MyImage<>));
            services.AddScoped<DbContext, AirlineContext>();                               

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 5;
                })
                .AddEntityFrameworkStores<AirlineContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(ADMIN,
                    t => t.RequireAssertion(
                        context => !context.User.Claims.Any(c => c.Type == Constants.USERID)
                    ));
            });

            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            services.ConfigureLoggerService();

            services.AddControllersWithViews(options => options.Filters.Add(new CurrentDataTimeFilter()));    // подключение по объекту

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);     
            
            services.AddGroupService();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(HOME_ERROR);
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // подключение аутентификации
            app.UseAuthorization();

            app.UseTopSecret(SECRET_FILE);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: DEFAULT,
                    pattern: DEFAULT_PATH);
            });


            app.UseCors("CorsPolicy");

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");                }
            });
        }
    }

    public partial class Startup
    {
        #region Constants
        private const string DEFAULT_PATH = "{controller=Home}/{action=Index}/{id?}";
        private const string DEFAULT_CONNECTION = "DefaultConnection";
        private const string HOME_ERROR = "/Home/Error";
        private const string DEFAULT = "default";
        private const string ADMINID = "AdminId";
        private const string USERID = "UserId";
        private const string ADMIN = "Admin";
        private const string USER = "User";

        #endregion
    }
}
