using System;

namespace PartsRecord
{
	public struct Date
	{
		public DateTime DateNow { get; private set; }

		public Date(DateTime date)
			: this()
		{
			DateNow = date;
		}
	}
}