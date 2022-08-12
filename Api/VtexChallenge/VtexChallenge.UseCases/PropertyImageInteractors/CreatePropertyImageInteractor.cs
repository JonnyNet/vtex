using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Repositories;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Exceptions;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.UseCases.Helpers;
using static VtexChallenge.Entities.Constans;
using static VtexChallenge.UseCases.Constans;

namespace VtexChallenge.UseCases.PropertyImageInteractors
{
	public class CreatePropertyImageInteractor : ICreatePropertyImageInputPort
	{
		private readonly ICreatePropertyImageOutputPort _createPropertyImageOutputPort;
		private readonly IPropertyImageCommandsRepository _propertyImageCommandsRepository;
		private readonly IInputValidator<CreatePropertyImageDTO> _inputValidator;
		private readonly IConfiguration _configuration;

		public async Task Handle(CreatePropertyImageDTO createPropertyImageDTO)
		{
			await _inputValidator.ValidateAsync(createPropertyImageDTO);

			var imageRepositoryPath = _configuration.GetValue<string>(IMAGE_REPOSITORY_PATH);
			if (string.IsNullOrEmpty(imageRepositoryPath))
			{
				var message = string.Format(KEY_DOES_NOT_EXIST_ERROR, IMAGE_REPOSITORY_PATH);
				throw new GeneralException(message);
			}

			if (!Uri.IsWellFormedUriString(imageRepositoryPath, UriKind.RelativeOrAbsolute))
			{
				var message = string.Format(INVALID_PATH_ERROR, imageRepositoryPath);
				throw new GeneralException(message);
			}

			var fileName = await FileHelper.SaveImage(imageRepositoryPath, createPropertyImageDTO);
			PropertyImage propertyImage = new()
			{
				PropertyId = createPropertyImageDTO.PropertyId,
				File = fileName,
			};

			try
			{
				await _propertyImageCommandsRepository.CreateAsync(propertyImage);
				await _propertyImageCommandsRepository.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				FileHelper.DeleteFile(imageRepositoryPath, createPropertyImageDTO.PropertyId, fileName);
				var source = $"{nameof(CreatePropertyImageInteractor)}: {ex.Message}";
				throw new GeneralException(source, ex);
			}


			await _createPropertyImageOutputPort.Handle(propertyImage.Id);
		}
	}
}
