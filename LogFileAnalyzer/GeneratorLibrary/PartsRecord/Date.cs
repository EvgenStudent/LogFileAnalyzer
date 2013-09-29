using System;

namespace GeneratorLibrary.Response
{
	class Date : IRecordFieldValueGenerator
	{
		private readonly Random random;
		private DateTime initialDate;

		public Date(Random random)
		{
			this.random = random;
			initialDate = new DateTime(year: random.Next(2011, 2013), month: DateTime.Now.Month - random.Next(0, DateTime.Now.Month), day: DateTime.Now.Day - random.Next(0, DateTime.Now.Day));
		}

		public string Generate()
		{
			TimeSpan incrementTimeSpan = new TimeSpan(days: random.Next(0, 1), hours: random.Next(0, 12), minutes: random.Next(0, 30), seconds: random.Next(0, 60));
			initialDate = initialDate.Add(incrementTimeSpan);
			//if (_dateTime > DateTime.Now)
			//	_dateTime = DateTime.Now;
			return initialDate.ToString(@"[dd/MMM/yyyy:hh:mm:ss zzz]");
		}
	}
}
