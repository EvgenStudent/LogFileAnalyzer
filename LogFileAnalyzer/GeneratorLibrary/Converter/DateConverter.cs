using GeneratorLibrary.PartsRecord;

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
			throw new System.NotImplementedException();
		}
	}
}