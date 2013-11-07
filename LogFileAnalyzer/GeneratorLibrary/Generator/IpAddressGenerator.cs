using System;
using GeneratorLibrary.Model;
using PartsRecord;
using GeneratorLibrary.Random;

namespace GeneratorLibrary.Generator
{
	public class IpAddressGenerator : IGenerator<IpAddress>
	{
		private readonly RandomWithProbability _random;
		private readonly ElementWithProbability<int> _uniqueIpCount;

		public IpAddressGenerator(RandomWithProbability random)
		{
			_random = random;
		}

		public IpAddressGenerator(RandomWithProbability random, ElementWithProbability<int> uniqueIpCount)
		{
			_random = random;
			_uniqueIpCount = uniqueIpCount;
		}

		public IpAddress Generate()
		{
			var ipAddress = new IpAddress(Convert.ToByte(_random.Next(1, 129)), Convert.ToByte(_random.Next(0, 256)),
				Convert.ToByte(_random.Next(0, 256)), Convert.ToByte(_random.Next(1, 256)));
			return ipAddress;
		}
	}
}