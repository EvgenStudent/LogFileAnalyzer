using System.Collections.Generic;

namespace GeneratorLibrary.App_Data
{
	public interface IData
	{
		IReadOnlyList<int> Codes { get; }
		IReadOnlyList<string> Methods { get; }
		IReadOnlyList<string> Versions { get; }
		IReadOnlyList<string> Protocols { get; }
		IReadOnlyList<string> FileExtensions { get; } 
	}
}