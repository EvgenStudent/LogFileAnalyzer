using System.Collections.Generic;
using System.Text;
using ConverterOutput;
using PartsRecord;

namespace GeneratorLibrary.Converter
{
	public class ConvertToString
	{
		private StringBuilder _stringBuilder;
		private List<IConverter<string>> listConverter;

		public string Convert(LogRecordParts recordParts)
		{
			listConverter = new List<IConverter<string>>
			{
				new IpAddressConverter(recordParts.IpAddress),
				new HyphenConverter(recordParts.Hyphen),
				new UserIdConverter(recordParts.UserId),
				new DateConverter(recordParts.Date),
				new RequestLineConverter(recordParts.RequestLine),
				new CodeDefinitionConverter(recordParts.CodeDefinition),
				new FileSizeConverter(recordParts.FileSize),
			};

			_stringBuilder = new StringBuilder();
			foreach (var converter in listConverter)
				_stringBuilder.Append(converter.Convert()).Append(" ");
			return _stringBuilder.ToString();
		}
	}
}