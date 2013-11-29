using System.Collections.Generic;
using System.Linq;
using AnalyzerForm.Entities;
using AnalyzerLibrary.ConverterInput;
using AnalyzerLibrary.ConverterOutput;
using PartsRecord;

namespace AnalyzerForm.ReportConverter
{
	public class ReportDateConverterToList : IConverter<IEnumerable<LogRecordParts>, IEnumerable<LogRecordStringParts>>
	{
		private readonly ConvertToString _converter = new ConvertToString();

		public IEnumerable<LogRecordStringParts> Convert(IEnumerable<LogRecordParts> record)
		{
			IEnumerable<LogRecordStringParts> rerordList =
				record.Select(logRecordPart => _converter.Convert(logRecordPart)).Select(list => new LogRecordStringParts
				{
					IpAddress = list[0],
					Hyphen = list[1],
					UserId = list[2],
					Date = list[3],
					RequestLine = list[4],
					Code = list[5],
					FileSize = list[6]
				});
			return rerordList;
		}
	}
}