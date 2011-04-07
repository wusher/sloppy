using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System;

namespace Sloppy
{
	public class Arguments : DynamicObject
	{
		public List<string> GetKeys()
		{
			return _values.Keys.ToList();
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			string name = binder.Name.ToLower();
			bool canRespond = _values.ContainsKey(name);
			if (canRespond)
				result = _values[name];
			else
			{
				if (name.StartsWith("has"))
				{
					canRespond = true;
					name = name.Substring(3, name.Length - 3);
					result = _values.ContainsKey(name);
				}
				else
					result = null;
			}

			return canRespond;
		}

		private readonly Dictionary<string, object> _values = new Dictionary<string, object>();

		public void Add(string name, object value)
		{
			name = name.ToLower();
			if (!_values.ContainsKey(name))
				_values.Add(name, value);
		}

		public bool HasProperty(string name)
		{
			name = name.ToLower();
			return _values.ContainsKey(name);
		}
	}
}