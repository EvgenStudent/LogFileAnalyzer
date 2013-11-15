using System;
using System.Collections.Generic;
using GeneratorLibrary.Model;
using PartsRecord;
using GeneratorLibrary.Random;

namespace GeneratorLibrary.Generator
{
	public class IpAddressGenerator : IGenerator<IpAddress>
	{
		private readonly RandomWithProbability _random;
		private List<IpAddress> uniqueIpList;
		private IpAddress oneIp;
		private int _counter;

		public IpAddressGenerator(RandomWithProbability random, ElementWithProbability<int> uniqueIpCount)
		{
			_random = random;
			_counter = 0;

			uniqueIpList = new List<IpAddress>(uniqueIpCount.Value);
			while (uniqueIpCount.Value != uniqueIpList.Count)
			{
				oneIp = GenerateOnlyIpAddress();
				if (uniqueIpList.Contains(oneIp))
					continue;
				uniqueIpList.Add(oneIp);
				_counter++;
			}

			_counter = 0;
		}

		public IpAddress Generate()
		{
			return _counter != uniqueIpList.Count ? uniqueIpList[_counter++] : uniqueIpList[_random.Next(0, uniqueIpList.Count)];
		}

		private IpAddress GenerateOnlyIpAddress()
		{
			return new IpAddress(Convert.ToByte(_random.Next(1, 129)), Convert.ToByte(_random.Next(0, 256)),
				Convert.ToByte(_random.Next(0, 256)), Convert.ToByte(_random.Next(1, 256)));
		}
	}
}