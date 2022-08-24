using System.Text.RegularExpressions;

namespace VtexChallenge.UseCases
{
	public static class Constans
	{
		public const string IMAGE_REPOSITORY_PATH = "ImageRepositoryPath";
		public const string AVATAR_FOLDER = "Avatars";
		public const string PROPERTIES_FOLDER = "Properties";
		public const string SEPARATOR = ",";

		public const string STRING_FORMAT_EXCEPTION = "Input is not a valid Base-64 string.";
		public const string INVALID_PATH_ERROR = "{0}: invalid path to save image.";

		public static readonly Regex DataUriImage = new(@"^data:image\/(?<type>[a-zA-Z]+);base64,(?<data>[A-Z0-9\+\/\=]+)$", RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);

		public const int MIN_LENGTH_NAME = 5;
		public const int MAX_LENGTH_NAME = 50;

		public const int MAX_LENGTH_ADDRESS = 100;

		public const int MIN_VALUE_PAGE_SIZE = 1;
		public const int MAX_VALUE_PAGE_SIZE = 50;


	}
}
