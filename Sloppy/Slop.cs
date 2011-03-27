using System;
using System.Collections.Generic;
using System.Linq;

namespace Sloppy
{
	public partial class Slop
	{
		private Stack<string> GetStackFromArgs(String[] args)
		{
			Stack<string> stack = new Stack<string>();
			for (int i = args.Length - 1; i >= 0; i--)
			{
				stack.Push(args[i]);
			}
			return stack;
		}

		public Arguments Parse(String[] args)
		{
			var arguements = new Arguments();
			ProcessArguements(args, arguements);

			var keys = arguements.GetKeys();
			var options = _options.ToList();
			foreach (var option in options)
			{
				if (!keys.Contains(option.LongName.ToLower()))
				{
					if (option.IsRequired)
						throw new ArgumentInvalidException();
					if (option.Default != null)
						arguements.Add(option.LongName, option.Default);
				}
			}
			return arguements;
		}

		private void ProcessArguements(String[] args, Arguments arguements)
		{
			Stack<string> stack = GetStackFromArgs(args);
			while (stack.Count > 0)
			{
				string command = stack.Pop();
				if (command.IsLongCommand())
				{
					ProcessLongCommand(stack, arguements, command);
				}
				else if (command.IsShortCommand())
				{
					ProcessShortCommand(stack, arguements, command);
				}
			}
		}

		private void ProcessShortCommand(Stack<string> stack, Arguments arguements, string command)
		{
			char shortCommand = command[1];
			if (!_shortNameLookup.ContainsKey(shortCommand))
				throw new ArgumentInvalidException();
			Option optionInfo = _shortNameLookup[shortCommand];
			optionInfo.ProcessCommand(stack, arguements);
		}

		private void ProcessLongCommand(Stack<string> stack, Arguments arguements, string command)
		{
			command = command.Substring(2, command.Length - 2);
			if (!_longNameLookup.ContainsKey(command))
				throw new ArgumentInvalidException();
			Option optionInfo = _longNameLookup[command];
			optionInfo.ProcessCommand(stack, arguements);
		}

		private readonly List<Option> _options = new List<Option>();
		private readonly Dictionary<char, Option> _shortNameLookup = new Dictionary<char, Option>();
		private readonly Dictionary<string, Option> _longNameLookup = new Dictionary<string, Option>();

		public List<Option> Options
		{
			get { return _options.ToList(); }
		}

		public void AddOption(Option option)
		{
			if (_shortNameLookup.ContainsKey(option.ShortName))
				throw new DuplicateOptionException();
			if (_longNameLookup.ContainsKey(option.LongName))
				throw new DuplicateOptionException();
			_options.Add(option);
			_shortNameLookup.Add(option.ShortName, option);
			_longNameLookup.Add(option.LongName, option);
		}
	}
}