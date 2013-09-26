using System;
using System.Collections;
using System.Data.Common;
using System.Security.Cryptography;
using GeneratorLibrary.Response;

namespace GeneratorLibrary
{
	public class Ip : IResponse
	{
		private readonly Random random;

		public Ip(Random random)
		{
			this.random = random;
		}

		public string GetValue()
		{
			return string.Format("{0}.{1}.{2}.{3}", random.Next(1, 129), 
				random.Next(0, 256), random.Next(0, 256), random.Next(1, 256));
		}
	}
}