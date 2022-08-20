using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.PropertiImageResposietories;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Exceptions;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.UseCases.Extensions;
using VtexChallenge.UseCases.Helpers;
using static VtexChallenge.UseCases.Constans;

namespace VtexChallenge.UseCases.PropertyImageInteractors
{
	public class CreatePropertyImageInteractor : ICreatePropertyImageInputPort
	{
		private readonly ICreatePropertyImageOutputPort _createPropertyImageOutputPort;
		private readonly IPropertyImageCommandsRepository _propertyImageCommandsRepository;
		private readonly IInputValidator<CreatePropertyImageDTO> _inputValidator;
		private readonly IConfiguration _configuration;

		public CreatePropertyImageInteractor(
			ICreatePropertyImageOutputPort createPropertyImageOutputPort,
			IPropertyImageCommandsRepository propertyImageCommandsRepository,
			IInputValidator<CreatePropertyImageDTO> inputValidator,
			IConfiguration configuration)
		{
			_createPropertyImageOutputPort = createPropertyImageOutputPort;
			_propertyImageCommandsRepository = propertyImageCommandsRepository;
			_inputValidator = inputValidator;
			_configuration = configuration;
		}

		public async Task Handle(string rootPath, CreatePropertyImageDTO createPropertyImageDTO)
		{
			await _inputValidator.ValidateAsync(createPropertyImageDTO);

			string imageRepositoryPath = _configuration.TryGetValue<string>(IMAGE_REPOSITORY_PATH);
			string imageTypePath = Path.Combine(PROPERTIES_FOLDER, createPropertyImageDTO.PropertyId.ToString());
			List<string> imagesResult = new();

			foreach (string image in createPropertyImageDTO.Images)
			{
				var fileName = await FileHelper.SaveImage(rootPath, imageRepositoryPath, imageTypePath, image);
				try
				{
					PropertyImage propertyImage = new()
					{
						PropertyId = createPropertyImageDTO.PropertyId,
						File = fileName,
					};

					imagesResult.Add(Path.Combine(imageRepositoryPath, imageTypePath, fileName));
					await _propertyImageCommandsRepository.CreateAsync(propertyImage);
					await _propertyImageCommandsRepository.SaveChangesAsync();
				}
				catch (Exception ex)
				{
					FileHelper.DeleteFile(rootPath, imageRepositoryPath, imageTypePath, fileName);
					var source = $"{nameof(CreatePropertyImageInteractor)}: {ex.Message}";
					throw new GeneralException(source, ex);
				}
			}

			await _createPropertyImageOutputPort.Handle(imagesResult);
		}
	}
}
