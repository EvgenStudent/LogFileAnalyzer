namespace Config
{
	public class StructureConfig 
	{
		private readonly System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, string>> _dictionary;

		public System.Collections.ObjectModel.ReadOnlyDictionary<string, string> this[string key]
		{
			get
			{
				return ContainsKey(key) ? new System.Collections.ObjectModel.ReadOnlyDictionary<string, string>(_dictionary[key]) : null;
			}
		}

		public StructureConfig(System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, string>> dictionary)
		{
			_dictionary = dictionary;
		}

		public void JoinConfig(StructureConfig config)
		{
			foreach (var pair in config._dictionary)
				_dictionary.Add(pair.Key, pair.Value);
		}

		public bool ContainsKey(string key)
		{
			return _dictionary.ContainsKey(key);
		}
	}
}

