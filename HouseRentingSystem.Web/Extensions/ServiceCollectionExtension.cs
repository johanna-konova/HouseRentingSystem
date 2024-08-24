using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			return services;
		}

		public static IServiceCollection AddApplicationDbContext(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			services.AddDbContext<HouseRentingDbContext>(options =>
				options.UseSqlServer(connectionString));

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
				.AddEntityFrameworkStores<HouseRentingDbContext>();

			return services;
		}
	}
}
