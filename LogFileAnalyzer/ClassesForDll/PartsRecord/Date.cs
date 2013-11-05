using System;
using GeneratorLibrary.Random;

namespace GeneratorLibrary.PartsRecord
{
	public struct Date
	{
		private static DateTime InitialDate;

		static Date()
		{
			var random = new RandomWithProbability();
			InitialDate = new DateTime(year: random.Next(2011, 2013), month: DateTime.Now.Month - random.Next(0, DateTime.Now.Month), day: DateTime.Now.Day - random.Next(0, DateTime.Now.Day));
		}

		public DateTime DateNow
		{
			get { return InitialDate; }
		}

		public Date(TimeSpan increment)
			: this()
		{
			InitialDate = InitialDate.Add(increment);
		}
	}
}