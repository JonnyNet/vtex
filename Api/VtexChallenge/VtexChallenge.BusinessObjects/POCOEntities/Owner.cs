using System;
using System.Collections.Generic;

namespace VtexChallenge.BusinessObjects.POCOEntities
{
	public class Owner : BaseEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Photo { get; set; }
		public DateTime Birthday { get; set; }

		public IEnumerable<Property> Properties { get; set; }
	}
}
