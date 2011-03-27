using System.Text.RegularExpressions;

namespace Sloppy
{
	public static class CommandStringExtensions
	{
		public static bool IsCommand(this string str)
		{
			return IsShortCommand(str) || IsLongCommand(str);
		}

		public static bool IsShortCommand(this string str)
		{
			bool isMatch = Regex.IsMatch(str, @"^-\w$");
			return isMatch;
		}

		public static bool IsLongCommand(this string str)
		{
			bool isMatch = Regex.IsMatch(str, @"^--\w+$");
			return isMatch;
		}
	}
}