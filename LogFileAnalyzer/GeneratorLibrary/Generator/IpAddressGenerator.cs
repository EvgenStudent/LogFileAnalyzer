using System;
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
			var ipAddress = new IpAddress(Convert.ToByte(_random.Next(1, 129)), Convert.ToByte(_random.Next(0, 256)),
				Convert.ToByte(_random.Next(0, 256)), Convert.ToByte(_random.Next(1, 256)));
			return ipAddress;
		}
	}
}