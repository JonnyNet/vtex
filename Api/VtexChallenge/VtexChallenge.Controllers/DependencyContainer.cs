using Microsoft.Extensions.DependencyInjection;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.OwnerControllers;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyControllers;
using VtexChallenge.BusinessObjects.Interfaces.Controllers.PropertyImageControllers;
using VtexChallenge.Controllers.OwnerControllers;
using VtexChallenge.Controllers.PropertyControllers;
using VtexChallenge.Controllers.PropertyImageControllers;

namespace VtexChallenge.Controllers
{
	public static class DependencyContainer
	{
		public static IServiceCollection AddControllers(this IServiceCollection services)
		{
			AddOwnerControllers(services);
			AddPropertyControllers(services);
			AddPropertyImageControllers(services);
			return services;
		}

		private static void AddOwnerControllers(IServiceCollection services)
		{
			services.AddScoped<ICreateOwnerController, CreateOwnerController>();
			services.AddScoped<IFindOwnerController, FindOwnerController>();
			services.AddScoped<IGetAllOwnerController, GetAllOwnerController>();
		}

		private static void AddPropertyImageControllers(IServiceCollection services)
		{
			services.AddScoped<ICreatePropertyImageController, CreatePropertyImageController>();
			services.AddScoped<IGetAllByPropertyIdController, GetAllByPropertyIdController>();
		}

		private static void AddPropertyControllers(IServiceCollection services)
		{
			services.AddScoped<ICreatePropertyController, CreatePropertyController>();
			services.AddScoped<IFindPropertyController, FindPropertyController>();
			services.AddScoped<IGetAllPropertyController, GetAllPropertyController>();
			services.AddScoped<IUpdatePropertyController, UpdatePropertyController>();
		}
	}
}
