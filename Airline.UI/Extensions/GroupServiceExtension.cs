using Global_Logic_ASP.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Global_Logic_ASP.Core.Extensions
{
    public static class GroupServiceExtension
    {
        public static IServiceCollection AddGroupService(this IServiceCollection services)
        {
            return services.AddSingleton<IGroupService, GroupService>();
        }
    }
}
