using Application.Abstractions;
using Infrastructure.Options;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
        {
            services.ConfigureOptions<DatabaseOptionsSetup>();

            services.AddDbContext<ApplicationDbContext>((serviceProvider, optionBuilder) =>
            {
                var dbOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

                optionBuilder.UseSqlServer(dbOptions.ConnectionString);
                optionBuilder.EnableDetailedErrors(dbOptions.EnableDetailedErrors);
                optionBuilder.EnableSensitiveDataLogging(dbOptions.EnableSensitiveDataLogging);
            });

            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IMealPlanRepository, MealPlanRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetService<ApplicationDbContext>()!);

            return services;
        }
    }
}