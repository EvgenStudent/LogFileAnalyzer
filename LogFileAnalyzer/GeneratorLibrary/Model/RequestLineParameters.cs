using System.Collections.Generic;

namespace GeneratorLibrary.Model
{
	public struct RequestLineParameters
	{
		public IReadOnlyList<ElementWithProbability<string>> Methods { get; set; }
		public IReadOnlyList<ElementWithProbability<string>> Versions { get; set; }
		public IReadOnlyList<ElementWithProbability<string>> Protocols { get; set; }
		public IReadOnlyList<ElementWithProbability<string>> FileExtensions { get; set; }
	}
}