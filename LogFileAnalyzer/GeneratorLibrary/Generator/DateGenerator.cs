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
			var incrementTimeSpan = new TimeSpan(days: _random.Next(0, 2), hours: _random.Next(0, 24), minutes: _random.Next(0, 60), seconds: _random.Next(0, 120));
			return new Date(incrementTimeSpan);
		}
	}
}