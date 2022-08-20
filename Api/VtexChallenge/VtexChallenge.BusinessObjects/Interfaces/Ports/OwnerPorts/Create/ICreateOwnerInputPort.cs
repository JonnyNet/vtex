using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.OwnerDTOs;

namespace VtexChallenge.BusinessObjects.Interfaces.Ports.OwnerPorts.Create
{
	public interface ICreateOwnerInputPort
	{
		Task Handle(string rootPath, CreateOwnerDTO createOwnerDTO);
	}
}
