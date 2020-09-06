using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Global_Logic_ASP.Core.IRepository;
using Global_Logic_ASP.Core.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Global_Logic_ASP.Core.Extensions
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
