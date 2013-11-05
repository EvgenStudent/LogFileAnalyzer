using System;
using PartsRecord;
using GeneratorLibrary.Random;

namespace GeneratorLibrary.Generator
{
	public class DateGenerator : IGenerator<Date>
	{
		private readonly RandomWithProbability _random;
		private DateTime _initialDate;

		public DateGenerator(RandomWithProbability random)
		{
			_random = random;
			_initialDate = new DateTime(year: random.Next(2011, 2013), month: DateTime.Now.Month - random.Next(0, DateTime.Now.Month), day: DateTime.Now.Day - random.Next(0, DateTime.Now.Day));
		}

		public Date Generate()
		{
			var incrementTimeSpan = new TimeSpan(days: _random.Next(0, 2), hours: _random.Next(0, 24), minutes: _random.Next(0, 60), seconds: _random.Next(0, 120));
			_initialDate = _initialDate.Add(incrementTimeSpan);
			return new Date(_initialDate);
		}
	}
}