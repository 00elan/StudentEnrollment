
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using StudentEnrollmentSystem.Application.Features.Events.Commands.EnrollStudent;
using StudentEnrollmentSystem.Application.Features.StudentManagement.Commands.EnrollStudent;
using StudentEnrollmentSystem.Application.Models;
using System.Reflection;

namespace StudentEnrollmentSystem.Application
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            //manages app's core business logic
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
