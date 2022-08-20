using System;
using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.BusinessObjects.DTOs.OwnerDTOs
{
	public class CreateOwnerDTO
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string Photo { get; set; }
		public DateTime Birthday { get; set; }


		public static explicit operator Owner(CreateOwnerDTO ownerDTO) => new()
		{
			Name = ownerDTO.Name,
			Address = ownerDTO.Address,
			Birthday = ownerDTO.Birthday,
		};
	}
}
