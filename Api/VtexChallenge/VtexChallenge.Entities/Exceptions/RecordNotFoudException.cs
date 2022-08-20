using System;

namespace VtexChallenge.Entities.Exceptions
{
	public class RecordNotFoudException : Exception
	{
		private const string _MESSAGE = "The record with the {0} does not exist";
		public RecordNotFoudException(int idRecord) : base(string.Format(_MESSAGE, idRecord))
		{

		}
	}
}
