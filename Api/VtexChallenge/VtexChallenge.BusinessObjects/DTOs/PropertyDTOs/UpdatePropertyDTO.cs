using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.BusinessObjects.DTOs.PropertyDTOs
{
	public class UpdatePropertyDTO : PropertyBase
	{
		public int Id { get; set; }
		public int? TraceId { get; set; }
		public int OwnerId { get; set; }

		public static explicit operator Property(UpdatePropertyDTO updatePropertyDTO) => new()
		{
			Id = updatePropertyDTO.Id,
			OwnerId = updatePropertyDTO.OwnerId,
			Name = updatePropertyDTO.Name,
			Address = updatePropertyDTO.Address,
			Price = updatePropertyDTO.Price,
			Year = updatePropertyDTO.Year,
			TraceId = updatePropertyDTO.TraceId,
			BedRooms = updatePropertyDTO.BedRooms,
			BathRooms = updatePropertyDTO.BathRooms,
			Area = updatePropertyDTO.Area,
			ParkingLot = updatePropertyDTO.ParkingLot,
			Description = updatePropertyDTO.Description,
		};
	}
}
