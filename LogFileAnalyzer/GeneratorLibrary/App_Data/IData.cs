using System.Collections.Generic;
using Config;
using GeneratorLibrary.Model;

namespace GeneratorLibrary.App_Data
{
	public interface IData
	{
		IReadOnlyList<ElementWithProbability<int>> Codes { get; }
		ElementWithProbability<int> UniqueIpCount { get; }
		RequestLineParameters RequestLineParameters { get; }
		void SetProbability(StructureConfig config);
	}
}