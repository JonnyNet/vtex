using System;
using System.Runtime.Serialization;

namespace VtexChallenge.Entities.Exceptions
{
	public class ApplicationException : Exception
	{
		private const string _MESSAGE = "An unexpected error occurred. Contact the system administrator.";
		public ApplicationException() : base(_MESSAGE)
		{

		}

		public ApplicationException(string message) : base(message)
		{

		}

		public ApplicationException(string message, Exception innerException) : base(message, innerException)
		{

		}

		public ApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
		{

		}
	}
}
