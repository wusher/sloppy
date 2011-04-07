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
			var arguments = new Arguments();
			ProcessArguments(args, arguments);

			HandleMissingArguments(arguments);
			return arguments;
		}

		private void ProcessArguments(String[] args, Arguments arguments)
		{
			Stack<string> stack = GetStackFromArgs(args);
			while (stack.Count > 0)
			{
				string command = stack.Pop();
				Option option = null;
				if (command.IsLongCommand())
				{
					option = LookupByLongName(command);
				}
				else if (command.IsShortCommand())
				{
					option = LookupByShortName(command);
				}
				if (option != null)
					option.ProcessCommand(stack, arguments);
			}
		}

		private void HandleMissingArguments(Arguments arguments)
		{
			var keys = arguments.GetKeys();
			var options = _options.ToList();
			foreach (var option in options)
			{
				if (!keys.Contains(option.LongName.ToLower()))
				{
					if (option.IsRequired)
						throw new RequiredArgumentMissingException(option.LongName, option.LongName + " is a required command line argument");
					if (option.Default != null)
						arguments.Add(option.LongName, option.Default);
				}
			}
		}

		private Option LookupByShortName(string command)
		{
			char shortCommand = command[1];
			if (!_shortNameLookup.ContainsKey(shortCommand))
				throw new InvalidArgumentException();
			return _shortNameLookup[shortCommand];
		}

		private Option LookupByLongName(string command)
		{
			command = command.Substring(2, command.Length - 2);
			if (!_longNameLookup.ContainsKey(command))
				throw new InvalidArgumentException();
			return _longNameLookup[command];
		}

		private readonly List<Option> _options = new List<Option>();
		private readonly Dictionary<char, Option> _shortNameLookup = new Dictionary<char, Option>();
		private readonly Dictionary<string, Option> _longNameLookup = new Dictionary<string, Option>();

		internal List<Option> Options
		{
			get { return _options.ToList(); }
		}

		internal void AddOption(Option option)
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