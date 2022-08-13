using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VtexChallenge.Controllers;
using VtexChallenge.Presenters;
using VtexChallenge.Repositories;
using VtexChallenge.UseCases;

namespace VtexChallenge.IoC
{
	public static class DependencyContainer
	{
		public static IServiceCollection AddVtexChallengeDependencies(
			this IServiceCollection services,
			IConfiguration configuration,
			string connectionString)
		{
			services.AddRepositories(configuration, connectionString);
			services.AddUsesCases();
			services.AddPresenters();
			services.AddControllers();
			return services;
		}
	}
}
