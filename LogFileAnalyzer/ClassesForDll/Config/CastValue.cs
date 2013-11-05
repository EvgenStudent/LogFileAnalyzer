namespace Config
{
	public static class CastValue
	{
		public static System.Collections.ObjectModel.ReadOnlyDictionary<string, int> CastValueToInt(this System.Collections.ObjectModel.ReadOnlyDictionary<string, string> dictionary)
		{
			return new System.Collections.ObjectModel.ReadOnlyDictionary<string, int>(System.Linq.Enumerable.ToDictionary(dictionary, x => x.Key, x => int.Parse(x.Value), System.StringComparer.InvariantCultureIgnoreCase));
		}
	}
}