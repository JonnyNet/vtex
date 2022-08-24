namespace VtexChallenge.BusinessObjects.POCOEntities
{
	public class PropertyImage : BaseEntity
	{
		public int Id { get; set; }
		public int PropertyId { get; set; }
		public string File { get; set; }

		public Property Property { get; set; }
	}
}
