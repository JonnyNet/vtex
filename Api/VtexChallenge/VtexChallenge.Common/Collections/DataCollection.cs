using System.Collections.Generic;

namespace VtexChallenge.Common.Collections
{
	public class DataCollection<T>
	{
		public int Page { get; set; }
		public int PageSize { get; set; }
		public int Total { get; set; }
		public int TotalPages { get; set; }
		public IEnumerable<T> Data { get; set; }
	}
}
