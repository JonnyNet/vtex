using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VtexChallenge.BusinessObjects.DTOs.PropertyImageDTOs;
using VtexChallenge.Entities.Exceptions;

namespace VtexChallenge.UseCases.Helpers
{
	public static class FileHelper
	{
		internal static async Task<string> SaveImage(string imageRepositoryPath, CreatePropertyImageDTO createPropertyImageDTO)
		{
			try
			{
				var ext = Path.GetExtension("");
				var fileName = $"{Guid.NewGuid()}.{ext}";
				var fullPath = Path.Combine(
					imageRepositoryPath,
					createPropertyImageDTO.PropertyId.ToString());

				if (!Directory.Exists(fullPath))
				{
					Directory.CreateDirectory(fullPath);
				}

				var fullPathWithFileName = Path.Combine(fullPath, fileName);

				var dataImage = TryParse("");

				await File.WriteAllBytesAsync(fullPathWithFileName, dataImage.Item2);

				return fileName;
			}
			catch (Exception ex)
			{
				var source = $"{nameof(FileHelper)}: {ex.Message}";
				throw new GeneralException(source, ex);
			}
		}

		internal static void DeleteFile(string imageRepositoryPath, int propertyId, string fileName)
		{
			throw new NotImplementedException();
		}

		private static (string, byte[]) TryParse(string dataUri)
		{
			Match match = Constans.DataUriImage.Match(dataUri);
			if (!match.Success)
			{
				throw new FormatException(Constans.STRING_FORMAT_EXCEPTION);
			}
			return GetData(match);
		}

		private static (string, byte[]) GetData(Match match)
		{
			string mimeType = match.Groups["type"].Value;
			string base64Data = match.Groups["data"].Value;

			byte[] rawData = Convert.FromBase64String(base64Data);
			if (rawData.Length == 0)
			{
				throw new FormatException(Constans.STRING_FORMAT_EXCEPTION);
			}
			return (mimeType, rawData);
		}
	}
}
