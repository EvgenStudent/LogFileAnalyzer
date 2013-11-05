using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AnalyzerLibrary.Converter;
using PartsRecord;

namespace AnalyzerLibrary
{
	public class LogFileStructure
	{
		public List<LogRecordParts> LogRecords { get; private set; } 

		private readonly IpAddressConverter _ipAddressConverter = new IpAddressConverter();
		private readonly HyphenConverter _hyphenConverter = new HyphenConverter();
		private readonly UserIdConverter _userIdConverter = new UserIdConverter();
		private readonly DateConverter _dateConverter = new DateConverter();
		private readonly RequestLineConverter _requestLineConverter = new RequestLineConverter();
		private readonly CodeDefinitionConverter _codeDefinitionConverter = new CodeDefinitionConverter();
		private readonly FileSizeConverter _fileSizeConverter = new FileSizeConverter();
		
		public LogFileStructure(IEnumerable<string> records)
		{
			LogRecords = new List<LogRecordParts>();
			string[] recordParts;
			foreach (var record in records)
			{
				recordParts = ParseRecord(record);
				LogRecords.Add(GetLogRecord(recordParts));
			}
		}

		private LogRecordParts GetLogRecord(IList<string> recordParts)
		{
			var logrecord = new LogRecordParts
			{
				IpAddress = _ipAddressConverter.Convert(recordParts[0]),
				Hyphen = _hyphenConverter.Convert(recordParts[1]),
				UserId = _userIdConverter.Convert(recordParts[2]),
				Date = _dateConverter.Convert(recordParts[3]),
				RequestLine = _requestLineConverter.Convert(recordParts[4]),
				CodeDefinition = _codeDefinitionConverter.Convert(recordParts[5]),
				FileSize = _fileSizeConverter.Convert(recordParts[6])
			};
			return logrecord;
		}

		private string[] ParseRecord(string record)
		{
			string temp;
			string date = (temp = record.Substring(0, record.LastIndexOf(']'))).Substring(temp.LastIndexOf('[') + 1);
			string requestLine = Regex.Match(record, "([^\"]+)(?=\"[^\"]*$)").Value;
			record = record.Replace("[" + date + "]", "");
			record = record.Replace("\"" + requestLine + "\"", "");

			var partsRecord = new List<string>(record.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries));
			partsRecord.Insert(3, date);
			partsRecord.Insert(4, requestLine);
			
			return partsRecord.ToArray();
		}
	}
}