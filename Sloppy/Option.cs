using System.Collections.Generic;
namespace Sloppy
{
	public class Option
	{
		public object Default { get; set; }

		public string LongName { get; set; }

		public char ShortName { get; set; }

		public bool IsRequired { get; set; }

		public string Description { get; set; }

		public System.Action<string> Callback { get; set; }


		public void ProcessCommand(Stack<string> stack, Arguments arguements)
		{
			string name = LongName;
			object value;
			if (!(stack.IsEmpty() || stack.Peek().IsCommand()))
				value = stack.Pop();
			else
				value = null;
			arguements.Add(name, value);
			if (Callback != null)
				Callback(value.ToString());
		}
	}
}