using GeneratorLibrary.PartsRecord;
using GeneratorLibrary.Random;

namespace GeneratorLibrary.Generator
{
	public class IpAddressGenerator : IGenerator<IpAddress>
	{
		private readonly RandomWithProbability _random;

		public IpAddressGenerator(RandomWithProbability random)
		{
			_random = random;
		}

		public IpAddress Generate()
		{
			throw new System.NotImplementedException();
		}
	}
}