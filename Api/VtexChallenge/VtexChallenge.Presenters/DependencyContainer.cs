using Microsoft.Extensions.DependencyInjection;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.GetImage;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Update;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.OwnerPresenters;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyImagePresenters;
using VtexChallenge.BusinessObjects.Interfaces.Presenters.PropertyPresenters;
using VtexChallenge.Presenters.OwnerPresenters;
using VtexChallenge.Presenters.PropertyImagePresenters;
using VtexChallenge.Presenters.PropertyPresenters;

namespace VtexChallenge.Presenters
{
	public static class DependencyContainer
	{
		public static IServiceCollection AddPresenters(this IServiceCollection services)
		{
			AddOwnerPresenters(services);
			AddPropertyImagePresenters(services);
			AddPropertyPresenters(services);
			return services;
		}

		private static void AddOwnerPresenters(IServiceCollection services)
		{
			services.AddScoped<CreateOwnerPresenter>();
			services.AddScoped<FindOwnerPresenter>();
			services.AddScoped<GetAllOwnerPresenter>();

			services.AddScoped<ICreateOwnerOutputPort>(x => x.GetService<CreateOwnerPresenter>());
			services.AddScoped<ICreateOwnerPresenter>(x => x.GetService<CreateOwnerPresenter>());

			services.AddScoped<IFindOwnerOutputPort>(x => x.GetService<FindOwnerPresenter>());
			services.AddScoped<IFindOwnerPresenter>(x => x.GetService<FindOwnerPresenter>());

			services.AddScoped<IGetAllOwnerOutputPort>(x => x.GetService<GetAllOwnerPresenter>());
			services.AddScoped<IGetAllOwnerPresenter>(x => x.GetService<GetAllOwnerPresenter>());
		}

		private static void AddPropertyImagePresenters(IServiceCollection services)
		{
			services.AddScoped<CreatePropertyImagePresenter>();
			services.AddScoped<GetFirstPropertyImagePresenter>();

			services.AddScoped<ICreatePropertyImageOutputPort>(x => x.GetService<CreatePropertyImagePresenter>());
			services.AddScoped<ICreatePropertyImagePresenter>(x => x.GetService<CreatePropertyImagePresenter>());

			services.AddScoped<IGetFirstPropertyImageOutputPort>(x => x.GetService<GetFirstPropertyImagePresenter>());
			services.AddScoped<IGetFirstPropertyImagePresenter>(x => x.GetService<GetFirstPropertyImagePresenter>());
		}

		private static void AddPropertyPresenters(IServiceCollection services)
		{
			services.AddScoped<CreatePropertyPresenter>();
			services.AddScoped<FindPropertyPresenter>();
			services.AddScoped<GetAllPropertyPresenter>();
			services.AddScoped<UpdatePropertyPresenter>();

			services.AddScoped<ICreatePropertyOutputPort>(x => x.GetService<CreatePropertyPresenter>());
			services.AddScoped<ICreatePropertyPresenter>(x => x.GetService<CreatePropertyPresenter>());

			services.AddScoped<IFindPropertyOutputPort>(x => x.GetService<FindPropertyPresenter>());
			services.AddScoped<IFindPropertyPresenter>(x => x.GetService<FindPropertyPresenter>());

			services.AddScoped<IGetAllPropertyOutputPort>(x => x.GetService<GetAllPropertyPresenter>());
			services.AddScoped<IGetAllPropertyPresenter>(x => x.GetService<GetAllPropertyPresenter>());

			services.AddScoped<IUpdatePropertyOutputPort>(x => x.GetService<UpdatePropertyPresenter>());
			services.AddScoped<IUpdatePropertyPresenter>(x => x.GetService<UpdatePropertyPresenter>());
		}
	}
}
