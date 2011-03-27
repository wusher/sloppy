using System;
using System.Runtime.Serialization;

namespace Sloppy
{
	public class ArgumentInvalidException : Exception
	{
		public ArgumentInvalidException()
		{
			
		}
		public ArgumentInvalidException(string message)
			: base(message)
		{
			
		}
		public ArgumentInvalidException(string message, Exception innerException)
			: base(message, innerException)
		{
			
		}
		protected ArgumentInvalidException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
			: base(info, context)
		{
			
		}
	}
}