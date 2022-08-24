using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.Find;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertiImageResposietories;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertyRepositories;
using VtexChallenge.Entities.Exceptions;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.UseCases.Extensions;
using static VtexChallenge.UseCases.Constans;

namespace VtexChallenge.UseCases.PropertyInteractors
{
	public class FindPropertyInteractor : IFindPropertyInputPort
	{
		private readonly IFindPropertyOutputPort _findPropertyOutputPort;
		private readonly IPropertyQuerysRepository _propertyQuerysRepository;
		private readonly IInputValidator<int> _inputValidator;
		private readonly IPropertyImageQuerysRepository _propertyImageQuerysRepository;
		private readonly IConfiguration _configuration;

		public FindPropertyInteractor(
			IFindPropertyOutputPort findPropertyOutputPort,
			IPropertyQuerysRepository propertyQuerysRepository,
			IInputValidator<int> inputValidator,
			IPropertyImageQuerysRepository propertyImageQuerysRepository,
			IConfiguration configuration)
		{
			_findPropertyOutputPort = findPropertyOutputPort;
			_propertyQuerysRepository = propertyQuerysRepository;
			_inputValidator = inputValidator;
			_propertyImageQuerysRepository = propertyImageQuerysRepository;
			_configuration = configuration;
		}

		public async Task Handle(int idProperty)
		{
			await _inputValidator.ValidateAsync(idProperty);
			var property = await _propertyQuerysRepository.FindAsync(idProperty);

			if (property == default)
			{
				throw new RecordNotFoudException(idProperty);
			}

			var listImage = await _propertyImageQuerysRepository.GetAllImageByPropertyId(idProperty);
			string imageTypePath = Path.Combine(PROPERTIES_FOLDER, idProperty.ToString());
			string imageRepositoryPath = _configuration.TryGetValue<string>(IMAGE_REPOSITORY_PATH);
			listImage = listImage.Select(x => Path.Combine(imageRepositoryPath, imageTypePath, x));

			var propertyDTO = (PropertyDTO)property;
			propertyDTO.Images = listImage;

			await _findPropertyOutputPort.Handle(propertyDTO);
		}
	}
}
