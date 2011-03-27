using System;
using System.Runtime.Serialization;

namespace Sloppy
{
	public class DuplicateOptionException : Exception
	{
		public DuplicateOptionException()
		{
			
		}
		public DuplicateOptionException(string message)
			: base(message)
		{
			
		}
		public DuplicateOptionException(string message, Exception innerException)
			: base(message, innerException)
		{
			
		}
		protected DuplicateOptionException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
			: base(info, context)
		{
			
		}
	}
}