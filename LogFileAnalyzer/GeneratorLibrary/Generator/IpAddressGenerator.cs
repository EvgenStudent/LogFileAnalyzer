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
		private readonly bool match;
		private IpAddress oneIp;

		public IpAddressGenerator(RandomWithProbability random)
		{
			_random = random;
		}

		public IpAddressGenerator(RandomWithProbability random, ElementWithProbability<int> uniqueIpCount)
		{
			_random = random;

			uniqueIpList = new List<IpAddress>(uniqueIpCount.Value);
			while (uniqueIpList.Count != uniqueIpCount.Value)
			{
				oneIp = GenerateOnlyIpAddress();
				if (uniqueIpList.Contains(oneIp))
					continue;
				uniqueIpList.Add(oneIp);
			}
			match = true;

			do
			{
				oneIp = Generate();
			} while (uniqueIpList.Contains(oneIp));
		}

		public IpAddress Generate()
		{
			var ipAddress = new IpAddress();
			if (match & uniqueIpList.Count != 0)
			{
				int num = _random.Next(0, uniqueIpList.Count);
				ipAddress = uniqueIpList[num];
				uniqueIpList.RemoveAt(num);
			}
			else
				ipAddress = oneIp;
			return ipAddress;
		}

		private IpAddress GenerateOnlyIpAddress()
		{
			return new IpAddress(Convert.ToByte(_random.Next(1, 129)), Convert.ToByte(_random.Next(0, 256)),
				Convert.ToByte(_random.Next(0, 256)), Convert.ToByte(_random.Next(1, 256)));
		}
	}
}