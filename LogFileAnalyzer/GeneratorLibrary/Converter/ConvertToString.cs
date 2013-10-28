using System.Collections.Generic;
using System.Text;
using GeneratorLibrary.Model;

namespace GeneratorLibrary.Converter
{
	public class ConvertToString
	{
		private List<IConverter<string>> listConverter;
		private StringBuilder _stringBuilder;

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