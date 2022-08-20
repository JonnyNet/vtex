using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Update;
using VtexChallenge.Common.Models;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.UseCases.OwnerInteractors;
using VtexChallenge.UseCases.PropertyImageInteractors;
using VtexChallenge.UseCases.PropertyInteractors;
using VtexChallenge.UseCases.Validators.Adapters;
using VtexChallenge.UseCases.Validators.CommonValidators;
using VtexChallenge.UseCases.Validators.OwnerValidators;
using VtexChallenge.UseCases.Validators.PropertyImageValidators;
using VtexChallenge.UseCases.Validators.PropertyValidators;

namespace VtexChallenge.UseCases
{
	public static class DependencyContainer
	{
		public static IServiceCollection AddUsesCases(this IServiceCollection services)
		{

			AddOwnerServices(services);
			AddPropertyServices(services);
			AddPropertyImageServices(services);
			AddValidators(services);
			return services;
		}

		private static void AddOwnerServices(IServiceCollection services)
		{
			services.AddTransient<ICreateOwnerInputPort, CreateOwnerInteractor>();
			services.AddTransient<IFindOwnerInputPort, FindOwnerInteractor>();
			services.AddTransient<IGetAllOwnerInputPort, GetAllOwnerInteractor>();
		}

		private static void AddPropertyServices(IServiceCollection services)
		{
			services.AddTransient<ICreatePropertyInputPort, CreatePropertyInteractor>();
			services.AddTransient<IFindPropertyInputPort, FindPropertyInteractor>();
			services.AddTransient<IGetAllPropertyInputPort, GetAllPropertyInteractor>();
			services.AddTransient<IUpdatePropertyInputPort, UpdatePropertyInteractor>();
		}

		private static void AddPropertyImageServices(IServiceCollection services)
		{
			services.AddTransient<ICreatePropertyImageInputPort, CreatePropertyImageInteractor>();
			services.AddTransient<IGetAllByPropertyIdInputPort, GetAllByPropertyIdInteractor>();
		}

		private static void AddValidators(IServiceCollection services)
		{
			services.AddScoped(typeof(IInputValidator<>), typeof(ValidatorAdapter<>));

			services.AddScoped<IValidator<int>, IntegerValidator>();
			services.AddScoped<IValidator<RequestFilter>, RequestFilterValidator>();

			services.AddScoped<IValidator<CreateOwnerDTO>, CreateOwnerDTOValidator>();
			services.AddScoped<IValidator<CreatePropertyDTO>, CreatePropertyDTOValidator>();
			services.AddScoped<IValidator<UpdatePropertyDTO>, UpdatePropertyDTOValidator>();
			services.AddScoped<IValidator<CreatePropertyImageDTO>, CreatePropertyImageDTOValidator>();
		}
	}
}
