using System;
using GeneratorLibrary.Random;
using PartsRecord;

namespace GeneratorLibrary.Generator
{
	public class DateGenerator : IGenerator<Date>
	{
		private readonly RandomWithProbability _random;
		private DateTime _initialDate;

		public DateGenerator(RandomWithProbability random)
		{
			_random = random;
			_initialDate = new DateTime(random.Next(2011, 2013), DateTime.Now.Month - random.Next(0, DateTime.Now.Month),
				DateTime.Now.Day - random.Next(0, DateTime.Now.Day));
		}

		public Date Generate()
		{
			var incrementTimeSpan = new TimeSpan(_random.Next(0, 2), _random.Next(0, 24), _random.Next(0, 60),
				_random.Next(0, 120));
			_initialDate = _initialDate.Add(incrementTimeSpan);
			return new Date(_initialDate);
		}
	}
}