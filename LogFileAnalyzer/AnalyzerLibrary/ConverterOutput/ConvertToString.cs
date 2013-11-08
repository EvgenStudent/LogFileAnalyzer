using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConverterOutput;
using PartsRecord;

namespace AnalyzerLibrary.ConverterOutput
{
	public class ConvertToString
	{
		private List<IConverter<string>> listConverter;
		private StringBuilder _stringBuilder;

		public List<string> Convert(LogRecordParts recordParts)
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

			return listConverter.Select(x => x.Convert()).ToList();
		}
	}
}