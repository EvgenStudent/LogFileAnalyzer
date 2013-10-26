using GeneratorLibrary.PartsRecord;
using GeneratorLibrary.Random;

namespace GeneratorLibrary.Generator
{
	public class DateGenerator : IGenerator<Date>
	{
		private readonly RandomWithProbability _random;

		public DateGenerator(RandomWithProbability random)
		{
			_random = random;
		}

		public Date Generate()
		{
			throw new System.NotImplementedException();
		}
	}
}