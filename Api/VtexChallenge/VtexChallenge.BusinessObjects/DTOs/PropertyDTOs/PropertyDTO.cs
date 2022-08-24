using System;
using System.Collections.Generic;
using System.Linq;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.BusinessObjects.DTOs.PropertyDTOs
{
	public class PropertyDTO : UpdatePropertyDTO
	{
		public int OwnerId { get; set; }
		public string CodeInternal { get; set; }
		public DateTime UpdatedAt { get; set; }
		public IEnumerable<string> Images { get; set; }
		public bool Enabled { get; set; }

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
			Year = property.Year,
			BedRooms = property.BedRooms,
			BathRooms = property.BathRooms,
			Area = property.Area,
			ParkingLot = property.ParkingLot,
			UpdatedAt = property.UpdatedAt,
			Description = property.Description,
			Images = Enumerable.Empty<string>(),
		};
	}
}
