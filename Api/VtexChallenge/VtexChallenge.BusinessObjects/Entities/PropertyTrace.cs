using System;

namespace VtexChallenge.BusinessObjects.Entities
{
	public class PropertyTrace : BaseEntity
	{
		public int Id { get; set; }
		public DateTime DateSale { get; set; }
		public string Name { get; set; }
		public decimal Value { get; set; }
		public decimal Tax { get; set; }

		public Property Property { get; set; }
	}
}
