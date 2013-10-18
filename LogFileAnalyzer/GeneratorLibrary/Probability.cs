using System.Collections.Generic;

namespace GeneratorLibrary
{
	public class Probability
	{
		public IReadOnlyDictionary<string, string> probabilityMethods { get; set; }
		public IReadOnlyDictionary<string, string> probabilityVersions { get; set; }
		public IReadOnlyDictionary<string, string> probabilityProtocols { get; set; }
		public IReadOnlyDictionary<string, string> probabilityFileExtensions { get; set; } 
	}
}