using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.OwnerRespositories;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertyRepositories;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Exceptions;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.UseCases.Extensions;
using static VtexChallenge.UseCases.Constans;

namespace VtexChallenge.UseCases.OwnerInteractors
{
	public class FindOwnerInteractor : IFindOwnerInputPort
	{
		private readonly IFindOwnerOutputPort _findOwnerOutputPort;
		private readonly IOwnerQuerysRespository _ownerQuerysRespository;
		private readonly IPropertyQuerysRepository _propertyQueryRespository;
		private readonly IInputValidator<int> _inputValidator;
		private readonly IConfiguration _configuration;

		public FindOwnerInteractor(
			IFindOwnerOutputPort findOwnerOutputPort,
			IOwnerQuerysRespository ownerQuerysRespository,
			IPropertyQuerysRepository propertyQueryRespository,
			IInputValidator<int> inputValidator,
			IConfiguration configuration)
		{
			_findOwnerOutputPort = findOwnerOutputPort;
			_ownerQuerysRespository = ownerQuerysRespository;
			_propertyQueryRespository = propertyQueryRespository;
			_inputValidator = inputValidator;
			_configuration = configuration;
		}

		public async Task Handle(int idOwner)
		{
			await _inputValidator.ValidateAsync(idOwner);
			var owner = await _ownerQuerysRespository.FindAsync(idOwner);

			if (owner == default)
			{
				throw new RecordNotFoudException(idOwner);
			}

			IEnumerable<Property> properties = await _propertyQueryRespository.GetPropertiesByOwnerId(idOwner);
			IEnumerable<PropertyDTO> propertiesDto = properties.Select(x => (PropertyDTO)x);

			string imageRepositoryPath = _configuration.TryGetValue<string>(IMAGE_REPOSITORY_PATH);

			var ownerDto = (OwnerDTO)owner;
			ownerDto.Photo = Path.Combine(imageRepositoryPath, AVATAR_FOLDER, owner.Photo);
			ownerDto.Properties = propertiesDto;
			await _findOwnerOutputPort.Handle(ownerDto);
		}
	}
}
