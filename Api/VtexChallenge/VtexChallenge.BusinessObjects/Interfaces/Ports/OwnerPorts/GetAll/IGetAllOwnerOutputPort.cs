using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;
using VtexChallenge.Common.Collections;
using VtexChallenge.Entities.Interfaces;

namespace VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.GetAll
{
	public interface IGetAllOwnerOutputPort : IHandleable<DataCollection<OwnerDTO>>
	{
	}
}
