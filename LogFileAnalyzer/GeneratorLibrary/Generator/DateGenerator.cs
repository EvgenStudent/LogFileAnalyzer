using System;
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
			var incrementTimeSpan = new TimeSpan(days: _random.Next(0, 1), hours: _random.Next(0, 12), minutes: _random.Next(0, 30), seconds: _random.Next(0, 60));
			return new Date(incrementTimeSpan);
		}
	}
}