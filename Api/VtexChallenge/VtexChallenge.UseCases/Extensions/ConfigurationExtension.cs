using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using VtexChallenge.Entities.Exceptions;
using static VtexChallenge.Entities.Constans;

namespace VtexChallenge.UseCases.Extensions
{
	public static class ConfigurationExtension
	{
		public static T TryGetValue<T>(this IConfiguration configuration, string key)
		{
			T keyValue = configuration.GetValue<T>(key, default);
			if (EqualityComparer<T>.Default.Equals(keyValue, default))
			{
				var message = string.Format(KEY_DOES_NOT_EXIST_ERROR, key);
				throw new GeneralException(message);
			}
			return keyValue;
		}
	}
}
