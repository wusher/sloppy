using System.Collections.Generic;

namespace Sloppy
{
	public static class StackExtensions
	{
		public static bool IsEmpty<T>(this Stack<T> stack)
		{
			return stack == null || stack.Count == 0;
		}
	}
}