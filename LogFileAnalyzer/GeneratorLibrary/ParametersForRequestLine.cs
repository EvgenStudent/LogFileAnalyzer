using System.Collections.Generic;
using GeneratorLibrary.App_Data;

namespace GeneratorLibrary
{
	public class ParametersForRequestLine
	{
		public IReadOnlyList<string> Methods { get; set; }
		public IReadOnlyList<string> Versions { get; set; }
		public IReadOnlyList<string> Protocols { get; set; }
		public IReadOnlyList<string> FileExtensions { get; set; }

		public Probability Probability;
	}
}