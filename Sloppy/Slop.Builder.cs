using System;

namespace Sloppy
{
	public partial class Slop
	{
		private Slop() { }

		public static Sloppy.Slop New()
		{
			return new Slop();
		}

		public Slop Option(char shortName, string longName, string description, object defaultValue = null, bool required = false, Action<string> callback = null)
		{
			var option = new Option
			{
				ShortName = shortName,
				LongName = longName,
				Description = description,
				Default = defaultValue,
				IsRequired = required,
				Callback = callback
			};
			AddOption(option);
			return this;
		}
	}
}