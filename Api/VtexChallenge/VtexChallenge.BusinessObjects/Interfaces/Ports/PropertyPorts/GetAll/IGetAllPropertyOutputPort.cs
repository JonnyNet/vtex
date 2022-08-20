using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.Common.Collections;
using VtexChallenge.Entities.Interfaces;

namespace VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.GetAll
{
	public interface IGetAllPropertyOutputPort : IHandleable<DataCollection<PropertyDTO>>
	{
	}
}
