﻿using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

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

				})
				.AddEntityFrameworkStores<HouseRentingDbContext>();

			return services;
		}
	}
}
