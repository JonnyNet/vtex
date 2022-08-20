using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.BusinessObjects.DTOs.PropertyDTOs
{
	public class PropertyDTO : UpdatePropertyDTO
	{
		public int OwnerId { get; set; }
		public string CodeInternal { get; set; }

		public static explicit operator PropertyDTO(Property property) => new()
		{
			Id = property.Id,
			Name = property.Name,
			Address = property.Address,
			Price = property.Price,
			CodeInternal = property.CodeInternal,
			OwnerId = property.OwnerId,
			Enabled = property.Enabled,
			TraceId = property.TraceId,
			Year = property.Year
		};
	}
}
