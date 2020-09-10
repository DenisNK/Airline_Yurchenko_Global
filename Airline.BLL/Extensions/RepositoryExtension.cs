using Airline.BLL.Repository;
using Airline.BLL.Repository.EntityRepository;
using Airline.DAL.IRepository;
using Airline.DAL.IRepository.IEntityRepository;
using Microsoft.Extensions.DependencyInjection;

namespace Airline.BLL.Extensions
{
   public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(Repository<>));
            services.AddScoped<IDisciplinesRepository, DisciplinesRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IPilotRepository, PilotRepository>();
            services.AddScoped<INavigatorRepository, NavigatorRepository>();

            return services;
        }
    }
}
