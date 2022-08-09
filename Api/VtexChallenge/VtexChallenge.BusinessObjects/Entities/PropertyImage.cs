namespace VtexChallenge.BusinessObjects.Entities
{
	public class PropertyImage : BaseEntity
	{
		public int Id { get; set; }
		public string File { get; set; }
		public bool Enabled { get; set; }

		public Property Property { get; set; }
	}
}
