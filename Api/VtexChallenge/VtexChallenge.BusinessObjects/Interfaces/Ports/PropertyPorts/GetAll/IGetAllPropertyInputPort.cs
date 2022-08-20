using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.Entities.Interfaces;

namespace VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyPorts.GetAll
{
	public interface IGetAllPropertyInputPort : IHandleable<PropertyFilter>
	{
	}
}
