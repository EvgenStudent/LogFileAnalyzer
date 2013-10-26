using GeneratorLibrary.PartsRecord;
using GeneratorLibrary.Random;

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
			throw new System.NotImplementedException();
		}
	}
}