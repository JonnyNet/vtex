using System.Collections.Generic;

namespace VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs
{
	public class CreatePropertyImageDTO
	{
		public int PropertyId { get; set; }
		public IEnumerable<string> Images { get; set; }
	}
}
