using Airline.BLL.Repository;
using Airline.DAL.IRepository;
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

            return services;
        }
    }
}
