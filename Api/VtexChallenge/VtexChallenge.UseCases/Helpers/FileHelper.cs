using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VtexChallenge.Entities.Exceptions;

namespace VtexChallenge.UseCases.Helpers
{
	public static class FileHelper
	{
		internal static async Task<string> SaveImage(string rootPath, string imageRepositoryPath, string imageTypePath, string data)
		{
			try
			{
				var fullPath = Path.Combine(
					rootPath,
					imageRepositoryPath,
					imageTypePath);

				if (!Directory.Exists(fullPath))
				{
					Directory.CreateDirectory(fullPath);
				}

				var dataImage = TryParse(data);
				string fileName = $"{Guid.NewGuid()}.{dataImage.Item1}";
				var fullPathWithFileName = Path.Combine(fullPath, fileName);

				await File.WriteAllBytesAsync(fullPathWithFileName, dataImage.Item2);

				return fileName;
			}
			catch (Exception ex)
			{
				var source = $"{nameof(FileHelper)}: {ex.Message}";
				throw new GeneralException(source, ex);
			}
		}

		internal static void DeleteFile(string rootPath, string imageRepositoryPath, string imageTypePath, string fileName)
		{
			var fullPath = Path.Combine(
					rootPath,
					imageRepositoryPath,
					imageTypePath,
					fileName);
			if (File.Exists(fullPath))
			{
				File.Delete(fullPath);
			}
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
