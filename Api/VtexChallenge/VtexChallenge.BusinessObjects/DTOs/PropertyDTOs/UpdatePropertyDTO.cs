using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.BusinessObjects.DTOs.PropertyDTOs
{
	public class UpdatePropertyDTO : PropertyBase
	{
		public int Id { get; set; }
		public int? TraceId { get; set; }
		public bool Enabled { get; set; }

		public static explicit operator Property(UpdatePropertyDTO updatePropertyDTO) => new()
		{
			Id = updatePropertyDTO.Id,
			Name = updatePropertyDTO.Name,
			Address = updatePropertyDTO.Address,
			Price = updatePropertyDTO.Price,
			Year = updatePropertyDTO.Year,
			TraceId = updatePropertyDTO.TraceId,
			Enabled = updatePropertyDTO.Enabled
		};
	}
}
