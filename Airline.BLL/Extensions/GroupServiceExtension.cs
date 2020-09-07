using Airline.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Airline.BLL.Extensions
{
    public static class GroupServiceExtension
    {
        public static IServiceCollection AddGroupService(this IServiceCollection services)
        {
            return services.AddSingleton<IGroupService, GroupService>();
        }
    }
}
