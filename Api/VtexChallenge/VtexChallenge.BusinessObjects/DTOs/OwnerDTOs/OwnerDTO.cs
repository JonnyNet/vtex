using System;
using System.Collections.Generic;
using VtexChallenge.BusinessObjects.DTOs.PropertyDTOs;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.BusinessObjects.DTOs.OwnerDTOs
{
	public class OwnerDTO : CreateOwnerDTO
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public IEnumerable<PropertyDTO> Properties { get; set; }

		public static explicit operator OwnerDTO(Owner owner) => new()
		{
			Id = owner.Id,
			Name = owner.Name,
			Address = owner.Address,
			Birthday = owner.Birthday,
			CreatedAt = owner.CreatedAt
		};
	}
}
