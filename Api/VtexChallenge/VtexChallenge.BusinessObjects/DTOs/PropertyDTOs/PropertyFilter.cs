using VtexChallenge.Common.Models;

namespace VtexChallenge.BusinessObjects.DTOs.PropertyDTOs
{
	public class PropertyFilter : RequestFilter
	{
		public string Search { get; set; }
		public int? Bedrooms { get; set; }
		public int? Bathrooms { get; set; }
		public int? ParkingLot { get; set; }
		public decimal? AreaFrom { get; set; }
		public decimal? AreaTo { get; set; }
		public decimal? PriceFrom { get; set; }
		public decimal? PriceTo { get; set; }
	}
}
