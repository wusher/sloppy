using System;
using System.Runtime.Serialization;

namespace Sloppy
{
	public class DuplicateOptionException : Exception
	{
	}
	public class RequiredArgumentMissingException : ArgumentOutOfRangeException
	{
		public RequiredArgumentMissingException(string paramName, string message)
			: base(paramName, message)
		{
		}
	}
	public class InvalidArgumentException : Exception
	{
	}
}