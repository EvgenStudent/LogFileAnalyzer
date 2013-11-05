using PartsRecord;

namespace GeneratorLibrary.Converter
{
	public class DateConverter : IConverter<string>
	{
		private readonly Date _date;

		public DateConverter(Date date)
		{
			_date = date;
		}

		public string Convert()
		{
			return _date.DateNow.ToString(@"[dd/MMM/yyyy:hh:mm:ss zzz]");
		}
	}
}