using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GeneratorLibrary.Model
{
	public struct StructureConfig 
	{
		private readonly IDictionary<string, IDictionary<string, int>> _dictionary;

		public ReadOnlyDictionary<string, int> this[string key]
		{
			get
			{
				return ContainsKey(key) ? new ReadOnlyDictionary<string, int>(_dictionary[key]) : null;
			}
		}

		public StructureConfig(IDictionary<string, IDictionary<string, int>> dictionary)
		{
			_dictionary = dictionary;
		}

		public bool ContainsKey(string key)
		{
			return _dictionary.ContainsKey(key);
		}
	}
}