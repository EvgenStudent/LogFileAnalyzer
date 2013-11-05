using System;
using AnalyzerLibrary.Converter;

namespace AnalyzerLibrary
{
	public class LogFileStructure
	{
		private readonly string[] _records;

		private readonly IpAddressConverter _ipAddressConverter = new IpAddressConverter();
		private readonly HyphenConverter _hyphenConverter = new HyphenConverter();
		private readonly UserIdConverter _userIdConverter = new UserIdConverter();
		private readonly DateConverter _dateConverter = new DateConverter();
		private readonly RequestLineConverter _requestLineConverter = new RequestLineConverter();
		private readonly CodeDefinitionConverter _codeDefinitionConverter = new CodeDefinitionConverter();
		private readonly FileSizeConverter _fileSizeConverter = new FileSizeConverter();
		
		public LogFileStructure(string[] records)
		{
			_records = records;
			string[] recordParts;
			foreach (var record in records)
			{
				recordParts = ParseRecord(record);
			}
		}

		private string[] ParseRecord(string record)
		{
			throw new NotImplementedException();	
		}
	}
}