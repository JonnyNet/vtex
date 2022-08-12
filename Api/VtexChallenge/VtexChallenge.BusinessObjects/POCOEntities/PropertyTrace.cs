using System;
using System.Collections.Generic;

namespace VtexChallenge.BusinessObjects.POCOEntities
{
	public class PropertyTrace : BaseEntity
	{
		public int Id { get; set; }
		public DateTime DateSale { get; set; }
		public string Name { get; set; }
		public decimal Value { get; set; }
		public decimal Tax { get; set; }

		public IEnumerable<Property> Properties { get; set; }
	}
}
