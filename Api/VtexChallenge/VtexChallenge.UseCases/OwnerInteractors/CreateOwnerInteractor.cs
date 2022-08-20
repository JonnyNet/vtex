using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Create;
using VtexChallenge.BusinessObjects.Interfaces.Repositories.OwnerRespositories;
using VtexChallenge.BusinessObjects.POCOEntities;
using VtexChallenge.Entities.Exceptions;
using VtexChallenge.Entities.Interfaces;
using VtexChallenge.UseCases.Extensions;
using VtexChallenge.UseCases.Helpers;
using static VtexChallenge.UseCases.Constans;

namespace VtexChallenge.UseCases.OwnerInteractors
{
	public class CreateOwnerInteractor : ICreateOwnerInputPort
	{
		private readonly ICreateOwnerOutputPort _createOwnerOutputPort;
		private readonly IOwnerCommandsRespository _ownerCommandsRespository;
		private readonly IInputValidator<CreateOwnerDTO> _inputValidator;
		private readonly IConfiguration _configuration;

		public CreateOwnerInteractor(
			ICreateOwnerOutputPort createOwnerOutputPort,
			IOwnerCommandsRespository ownerCommandsRespository,
			IInputValidator<CreateOwnerDTO> inputValidator,
			IConfiguration configuration)
		{
			_createOwnerOutputPort = createOwnerOutputPort;
			_ownerCommandsRespository = ownerCommandsRespository;
			_inputValidator = inputValidator;
			_configuration = configuration;
		}

		public async Task Handle(string rootPath, CreateOwnerDTO createOwnerDTO)
		{
			await _inputValidator.ValidateAsync(createOwnerDTO);
			Owner owner = (Owner)createOwnerDTO;

			string imageRepositoryPath = _configuration.TryGetValue<string>(IMAGE_REPOSITORY_PATH);
			string fileName = await FileHelper.SaveImage(rootPath, imageRepositoryPath, AVATAR_FOLDER, createOwnerDTO.Photo);
			owner.Photo = fileName;

			try
			{
				await _ownerCommandsRespository.CreateAsync(owner);
				await _ownerCommandsRespository.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				FileHelper.DeleteFile(rootPath, imageRepositoryPath, AVATAR_FOLDER, fileName);
				var source = $"{nameof(CreateOwnerInteractor)}: {ex.Message}";
				throw new GeneralException(source, ex);
			}

			await _createOwnerOutputPort.Handle(owner.Id);
		}
	}
}
