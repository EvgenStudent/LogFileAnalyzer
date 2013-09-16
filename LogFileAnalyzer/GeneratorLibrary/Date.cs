using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLibrary
{
	class Date
	{
		private static volatile Date _instance;
		private static readonly object SyncRoot = new Object();
		private DateTime _dateTime;

		public static Date Instance
		{
			get
			{
				if (_instance == null)
					lock (SyncRoot)
					{
						if (_instance == null)
							_instance = new Date();
					}
				return _instance;
			}
		}

		private Date()
		{
			System.Random rand = new System.Random();
			DateTime to = new DateTime(year: Random.Instance.GetValue(2012, 2014), month: DateTime.Now.Month - Random.Instance.GetValue(0, DateTime.Now.Month), day: DateTime.Now.Day - Random.Instance.GetValue(0, DateTime.Now.Day));
			DateTime from = DateTime.Now;
			var range = to - from;
			var randTimeSpan = new TimeSpan((long)(rand.NextDouble() * range.Ticks));
			_dateTime = from + randTimeSpan;
		}

		public String GetValue()
		{
			TimeSpan timeSpan;
			timeSpan = new TimeSpan(days: Random.Instance.GetValue(0, 5), hours: Random.Instance.GetValue(0, 24), minutes: Random.Instance.GetValue(0, 60), seconds: Random.Instance.GetValue(0, 60));
			_dateTime = _dateTime.Add(timeSpan);

			return _dateTime.ToString(@"[dd/MMM/yyyy:hh:mm:ss zzz]");
		}
	}
}
