using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentEnrollmentSystem.Application.Contracts.Repository;
using StudentEnrollmentSystem.Application.Features.Events.Commands.EnrollStudent;
using StudentEnrollmentSystem.Application.Features.StudentManagement.Commands.EnrollStudent;
using StudentEnrollmentSystem.Infrastructure.Configuration;
using StudentEnrollmentSystem.Infrastructure.Interfaces;
using StudentEnrollmentSystem.Infrastructure.Repositories;

namespace StudentEnrollmentSystem.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, ConfigureHostBuilder host)
        {
            services.AddScoped<HttpContextAccessor>();

            //to provide connection strings and DB connection
            services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));
            services.AddScoped<IDbConfiguration, DbConfiguration>();

            //repositories are registered to use services or for data access
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();

            return services;
        }
    }
}
