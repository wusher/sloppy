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
			string name = FixName(binder.Name);
			bool canRespond = HasProperty(name);
			result = GetValue(name);
			if (result == null)
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

		public object GetValue(string name)
		{
			name = FixName(name);
			object result;
			bool canRespond = HasProperty(name);
			if (canRespond)
				result = _values[name];
			else
				result = null;
			return result;
		}

		public bool HasProperty(string name)
		{
			name = FixName(name);
			return _values.ContainsKey(name);
		}
		private string FixName(string name)
		{
			return name.ToLower();
		}
	}
}