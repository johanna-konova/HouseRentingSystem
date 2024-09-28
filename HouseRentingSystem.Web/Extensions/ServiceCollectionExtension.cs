using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Services;
using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Infrastructure.Common;
using HouseRentingSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IHouseService, HouseService>();
			services.AddScoped<IAgentService, AgentService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IStatisticsService, StatisticsService>();

            return services;
		}

		public static IServiceCollection AddApplicationDbContext(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			services.AddDbContext<HouseRentingDbContext>(options =>
				options.UseSqlServer(connectionString));

			services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();
			
			return services;
		}

		public static IServiceCollection AddApplicationIdentity(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			services
				.AddDefaultIdentity<ApplicationUser>(options =>
				{
					options.SignIn.RequireConfirmedAccount = 
						configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
					options.Password.RequireDigit = 
                        configuration.GetValue<bool>("Identity:Password:RequireDigit");
					options.Password.RequireLowercase =
                        configuration.GetValue<bool>("Identity:Password:RequireLowercase");
					options.Password.RequireNonAlphanumeric =
                        configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
					options.Password.RequireUppercase =
						configuration.GetValue<bool>("Identity:Password:RequireUppercase");
				})
				.AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<HouseRentingDbContext>();

			return services;
		}
	}
}
