using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;

namespace VtexChallenge.BusinessObjects.Interfaces.Ports.PropertyImagePorts.Create
{
	public interface ICreatePropertyImageInputPort
	{
		Task Handle(string rootPath, CreatePropertyImageDTO createPropertyImageDTO);
	}
}
