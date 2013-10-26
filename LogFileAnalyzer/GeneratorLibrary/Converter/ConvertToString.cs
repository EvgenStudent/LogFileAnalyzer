using GeneratorLibrary.Model;
using GeneratorLibrary.PartsRecord;

namespace GeneratorLibrary.Converter
{
	public class ConvertToString : IConverter<string>
	{
		private readonly LogRecordParts _recordParts;

		public ConvertToString(LogRecordParts recordParts)
		{
			_recordParts = recordParts;
		}

		public string Convert()
		{
			return null;
		}
	}
}