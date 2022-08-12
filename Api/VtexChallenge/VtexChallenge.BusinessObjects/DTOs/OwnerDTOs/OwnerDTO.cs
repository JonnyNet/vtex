using VtexChallenge.BusinessObjects.POCOEntities;

namespace VtexChallenge.BusinessObjects.DTOs.OwnerDTOs
{
	public class OwnerDTO : CreateOwnerDTO
	{
		public int Id { get; set; }

		public static explicit operator OwnerDTO(Owner owner) => new()
		{
			Id = owner.Id,
			Name = owner.Name,
			Address = owner.Address,
			Photo = owner.Address,
			Birthday = owner.Birthday
		};
	}
}
