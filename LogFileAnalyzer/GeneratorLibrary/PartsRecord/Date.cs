using System;

namespace GeneratorLibrary.PartsRecord
{
	public struct Date
	{
		private static readonly DateTime InitialDate = new DateTime();

		public DateTime DateNow
		{
			get { return InitialDate; }
		}
	}
}