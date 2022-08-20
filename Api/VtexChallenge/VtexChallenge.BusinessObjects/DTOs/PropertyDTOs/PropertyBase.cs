namespace VtexChallenge.BusinessObjects.DTOs.PropertyDTOs
{
	public class PropertyBase
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public decimal Price { get; set; }
		public int Year { get; set; }
		public int BedRooms { get; set; }
		public int BathRooms { get; set; }
		public decimal Area { get; set; }
		public int ParkingLot { get; set; }
		public string Description { get; set; }
	}
}
