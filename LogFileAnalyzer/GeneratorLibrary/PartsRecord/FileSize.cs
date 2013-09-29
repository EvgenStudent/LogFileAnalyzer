using System;
using System.Globalization;

namespace GeneratorLibrary.Response
{
	public class FileSize : IRecordFieldValueGenerator
	{
		private readonly Random random;

		public FileSize(Random random)
		{
			this.random = random;
		}

		public string Generate()
		{
			return random.Next(100, 1000).ToString(CultureInfo.InvariantCulture);
		}
	}
}