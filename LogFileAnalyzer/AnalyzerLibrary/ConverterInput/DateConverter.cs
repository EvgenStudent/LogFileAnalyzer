using System;
using System.Globalization;
using PartsRecord;

namespace AnalyzerLibrary.ConverterInput
{
	public class DateConverter : IConverter<string, Date>
	{
		public Date Convert(string record)
		{
			DateTime dateTime = DateTime.ParseExact(record, "dd/MMM/yyyy:hh:mm:ss zzz", CultureInfo.InstalledUICulture);
			return new Date(dateTime);
		}
	}
}