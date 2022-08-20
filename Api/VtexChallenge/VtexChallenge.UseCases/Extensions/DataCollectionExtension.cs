using System;
using System.Linq;
using VtexChallenge.Common.Collections;

namespace VtexChallenge.UseCases.Extensions
{
	public static class DataCollectionExtension
	{
		public static DataCollection<TResult> ChangeType<T, TResult>(this DataCollection<T> dataCollection, Func<T, TResult> funcConvert) => new()
		{
			Page = dataCollection.Page,
			PageSize = dataCollection.PageSize,
			Total = dataCollection.Total,
			TotalPages = dataCollection.TotalPages,
			Data = dataCollection.Data.Select(funcConvert)
		};
	}
}
