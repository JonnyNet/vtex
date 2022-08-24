using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.GetAll;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertyRepositories;
using VtexChallenge.Common.Models;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.UseCases.Extensions;

namespace VtexChallenge.UseCases.PropertyInteractors
{
	public class GetAllPropertyInteractor : IGetAllPropertyInputPort
	{
		private readonly IGetAllPropertyOutputPort _getAllPropertyOutputPort;
		private readonly IPropertyQuerysRepository _propertyQuerysRepository;
		private readonly IInputValidator<RequestFilter> _inputValidator;

		public GetAllPropertyInteractor(
			IGetAllPropertyOutputPort getAllPropertyOutputPort,
			IPropertyQuerysRepository propertyQuerysRepository,
			IInputValidator<RequestFilter> inputValidator)
		{
			_getAllPropertyOutputPort = getAllPropertyOutputPort;
			_propertyQuerysRepository = propertyQuerysRepository;
			_inputValidator = inputValidator;
		}

		public async Task Handle(PropertyFilter requestFilter)
		{
			await _inputValidator.ValidateAsync(requestFilter);

			var page = await _propertyQuerysRepository.GetAll(requestFilter);
			var pageResult = page.ChangeType(entity => (PropertyDTO)entity);

			await _getAllPropertyOutputPort.Handle(pageResult);
		}
	}
}
