using Airline.DAL.IRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Airline_Yurchenko.LoggerManager
{
    public static class MyLoggerExtentions
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, Airline.BLL.Repository.LoggerManager>();
        }
    }
}
