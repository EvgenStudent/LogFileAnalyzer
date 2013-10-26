using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GeneratorLibrary.Model
{
	public struct StructureConfig 
	{
		private readonly IDictionary<string, IDictionary<string, string>> _dictionary;

		public ReadOnlyDictionary<string, string> this[string key]
		{
			get
			{
				return ContainsKey(key) ? new ReadOnlyDictionary<string, string>(_dictionary[key]) : null;
			}
		}

		public StructureConfig(IDictionary<string, IDictionary<string, string>> dictionary)
		{
			_dictionary = dictionary;
		}

		public bool ContainsKey(string key)
		{
			return _dictionary.ContainsKey(key);
		}
	}
}