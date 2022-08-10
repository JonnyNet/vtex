using System.Collections.Generic;

namespace VtexChallenge.BusinessObjects.POCOEntities
{
	public class Property : BaseEntity
	{
		public int Id { get; set; }
		public string OwnerId { get; set; }
		public int TraceId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public decimal Price { get; set; }
		public string CodeInternal { get; set; }
		public int Year { get; set; }

		public Owner Owner { get; set; }
		public IEnumerable<PropertyImage> Images { get; set; }
		public PropertyTrace Trace { get; set; }
	}
}
