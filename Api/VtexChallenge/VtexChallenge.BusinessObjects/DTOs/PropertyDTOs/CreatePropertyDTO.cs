
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.BusinessObjects.DTOs.PropertyDTOs
{
	public class CreatePropertyDTO : PropertyBase
	{
		public int OwnerId { get; set; }


		public static explicit operator Property(CreatePropertyDTO createPropertyDTO) => new()
		{
			OwnerId = createPropertyDTO.OwnerId,
			Name = createPropertyDTO.Name,
			Address = createPropertyDTO.Address,
			Price = createPropertyDTO.Price,
			Year = createPropertyDTO.Year,
			BedRooms = createPropertyDTO.BedRooms,
			BathRooms = createPropertyDTO.BathRooms,
			Area = createPropertyDTO.Area,
			ParkingLot = createPropertyDTO.ParkingLot,
			Description = createPropertyDTO.Description,
		};
	}
}
