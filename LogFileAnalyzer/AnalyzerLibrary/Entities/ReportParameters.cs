using System.Collections.Generic;
using PartsRecord;

namespace AnalyzerLibrary.Entities
{
	public class ReportParameters
	{
		public ReportParameters(IEnumerable<LogRecordParts> logRecordPartses, dynamic converter)
		{
			LogRecordPartses = logRecordPartses;
			Converter = converter;
		}

		public IEnumerable<LogRecordParts> LogRecordPartses { get; private set; }
		public dynamic Converter { get; private set; }
	}
}