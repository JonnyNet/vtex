namespace VtexChallenge.Entities
{
	public static class Constans
	{
		public const string RECORD_NOT_FOUND = "the {0} with id {1} does not exist.";
		public const string GENERAL_ERROR_MESSAGE = "An unexpected error occurred. Contact the system administrator.";
		public const string KEY_DOES_NOT_EXIST_ERROR = "key {0} does not exist in the configuration file.";

		public const string NOT_DEFAULT_VALUE_ERROR_MESSAGE = "The {PropertyName} field value is not valid";
		public const string NOT_NULL_ERROR_MESSAGE = "{PropertyName} cannot be null.";
		public const string NOT_EMPTY_ERROR_MESSAGE = "{PropertyName} cannot be empty.";
		public const string LENGTH_ERROR_MESSAGE = "The {PropertyName} must have a length between {MinLength} and {MaxLength}.";
		public const string MAX_LENGTH_ERROR_MESSAGE = "The {PropertyName} must have a length maximum length of {PropertyValue}.";
		public const string INCLUSICE_ERROR_MESSAGE = "The {PropertyName} must have a range from {From} to {To}.";
		public const string EMPTY_LIST_ERROR = "The {PropertyName} list must have at least one element";
		public const string ERROR_INVALID_ITEM_LIST = "The {PropertyName} list has an invalid item";
		public const string ERROR_LESS_THAN = "the value of the {PropertyName} property must be less than {ComparisonValue}.";
		public const string INPUT_DATA_ERROR = "Input data error, please check!";
	}
}
