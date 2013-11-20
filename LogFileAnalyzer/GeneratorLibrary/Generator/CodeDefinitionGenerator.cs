using System.Collections.Generic;
using GeneratorLibrary.Model;
using GeneratorLibrary.Random;
using PartsRecord;

namespace GeneratorLibrary.Generator
{
	public class CodeDefinitionGenerator : IGenerator<CodeDefinition>
	{
		private readonly IReadOnlyList<ElementWithProbability<int>> _codes;
		private readonly RandomWithProbability _random;

		public CodeDefinitionGenerator(RandomWithProbability random, IReadOnlyList<ElementWithProbability<int>> codes)
		{
			_random = random;
			_codes = codes;
		}

		public CodeDefinition Generate()
		{
			return new CodeDefinition(_random.Next(_codes));
		}
	}
}