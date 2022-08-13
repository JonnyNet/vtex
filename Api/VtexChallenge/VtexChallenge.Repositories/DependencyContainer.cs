using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VtexChallenge.BusinessObjects.Interfaces.Contexts;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.OwnerRespositories;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertiImageResposietories;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertyRepositories;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.Repositories.DataContext;
using VtexChallenge.Repositories.Repositories;
using VtexChallenge.Repositories.Repositories.OwnerRespositories;
using VtexChallenge.Repositories.Repositories.PropertiImageResposietories;
using VtexChallenge.Repositories.Repositories.PropertyRepositories;

namespace VtexChallenge.Repositories
{
	public static class DependencyContainer
	{
		public static IServiceCollection AddRepositories(
			this IServiceCollection services,
			IConfiguration configuration,
			string connectionString)
		{
			services.AddDbContext<VtexChallengeContext>(options
				=> options.UseSqlServer(configuration.GetConnectionString(connectionString)));

			services.AddScoped<IDbContext>(provider => provider.GetService<VtexChallengeContext>());

			services.AddScoped<IOwnerCommandsRespository, OwnerCommandsRespository>();
			services.AddScoped<IOwnerQuerysRespository, OwnerQuerysRespository>();

			services.AddScoped<IPropertyImageCommandsRepository, PropertyImageCommandsRepository>();
			services.AddScoped<IPropertyImageQuerysRepository, PropertyImageQuerysRepository>();

			services.AddScoped<IPropertyCommandsRepository, PropertyCommandsRepository>();
			services.AddScoped<IPropertyQuerysRepository, PropertyQuerysRepository>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();

			return services;
		}

		public static IApplicationBuilder RunMigrationsRepositories(this IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<VtexChallengeContext>();
				context.Database.Migrate();
			}
			return app;
		}
	}
}
