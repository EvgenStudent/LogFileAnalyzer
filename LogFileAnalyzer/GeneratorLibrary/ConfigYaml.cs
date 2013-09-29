using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GeneratorLibrary
{
	public class ConfigYaml
	{
		private readonly IDictionary<string, IDictionary<string, string>> _dictionary;

		public ReadOnlyDictionary<string, string> this[string key]
		{
			get
			{
				return new ReadOnlyDictionary<string, string>(_dictionary[key]);
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