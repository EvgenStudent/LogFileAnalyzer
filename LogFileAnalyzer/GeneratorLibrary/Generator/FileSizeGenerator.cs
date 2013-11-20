using GeneratorLibrary.Random;
using PartsRecord;

namespace GeneratorLibrary.Generator
{
	public class FileSizeGenerator : IGenerator<FileSize>
	{
		private readonly RandomWithProbability _random;

		public FileSizeGenerator(RandomWithProbability random)
		{
			_random = random;
		}

		public FileSize Generate()
		{
			return new FileSize(_random.Next(10, 900));
		}
	}
}