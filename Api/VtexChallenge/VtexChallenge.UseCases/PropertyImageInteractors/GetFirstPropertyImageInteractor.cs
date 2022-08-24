using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.GetImage;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertiImageResposietories;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.UseCases.Extensions;
using static VtexChallenge.UseCases.Constans;

namespace VtexChallenge.UseCases.PropertyImageInteractors
{
	public class GetFirstPropertyImageInteractor : IGetFirstPropertyImageInputPort
	{
		private readonly IGetFirstPropertyImageOutputPort _getAllByPropertyIdOutputPort;
		private readonly IPropertyImageQuerysRepository _propertyImageQuerysRepository;
		private readonly IInputValidator<int> _inputValidator;
		private readonly IConfiguration _configuration;

		public GetFirstPropertyImageInteractor(
			IGetFirstPropertyImageOutputPort getAllByPropertyIdOutputPort,
			IPropertyImageQuerysRepository propertyImageQuerysRepository,
			IInputValidator<int> inputValidator,
			IConfiguration configuration)
		{
			_getAllByPropertyIdOutputPort = getAllByPropertyIdOutputPort;
			_propertyImageQuerysRepository = propertyImageQuerysRepository;
			_inputValidator = inputValidator;
			_configuration = configuration;
		}

		public async Task Handle(int propertyId)
		{
			await _inputValidator.ValidateAsync(propertyId);

			string imageRepositoryPath = _configuration.TryGetValue<string>(IMAGE_REPOSITORY_PATH);
			string imageName = await _propertyImageQuerysRepository.GetFirstImageByPropertyId(propertyId);
			string imagePath = string.Empty;
			if (!string.IsNullOrEmpty(imageName))
			{
				imagePath = Path.Combine(imageRepositoryPath, PROPERTIES_FOLDER, propertyId.ToString(), imageName);
			}
			await _getAllByPropertyIdOutputPort.Handle(new() { Image = imagePath });
		}
	}
}
