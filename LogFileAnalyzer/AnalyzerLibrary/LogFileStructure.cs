using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

				_ipAddressConverter.Convert(recordParts[0]);
				_hyphenConverter.Convert(recordParts[1]);
				_userIdConverter.Convert(recordParts[2]);
				_dateConverter.Convert(recordParts[3]);
				_requestLineConverter.Convert(recordParts[4]);
				_codeDefinitionConverter.Convert(recordParts[5]);
				_fileSizeConverter.Convert(recordParts[6]);
			}
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