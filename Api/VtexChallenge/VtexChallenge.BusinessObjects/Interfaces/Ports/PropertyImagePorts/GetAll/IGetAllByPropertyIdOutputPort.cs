using System.Collections.Generic;
using VtexChallenge.Entities.Interfaces;

namespace VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.GetAll
{
	public interface IGetAllByPropertyIdOutputPort : IHandleable<IEnumerable<string>>
	{
	}
}
