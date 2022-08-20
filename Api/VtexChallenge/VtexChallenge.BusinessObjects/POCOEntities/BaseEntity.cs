using System;

namespace VtexChallenge.BusinessObjects.POCOEntities
{
	public class BaseEntity
	{
		public bool Enabled { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
