using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GeneratorLibrary
{
	public class ConfigYaml
	{
		private readonly IDictionary<string, IDictionary<string, string>> _dictionary;

		public ReadOnlyDictionary<string, string> this[string key]
		{
			get
			{
				return ContainsKey(key) ? new ReadOnlyDictionary<string, string>(_dictionary[key]) : null;
			}
		}

		public ConfigYaml(IDictionary<string, IDictionary<string, string>> dictionary)
		{
			_dictionary = dictionary;
		}

		public bool ContainsKey(string key)
		{
			return _dictionary.ContainsKey(key);
		}
	}
}