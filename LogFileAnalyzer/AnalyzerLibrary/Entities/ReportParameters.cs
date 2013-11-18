using System.Collections.Generic;
using PartsRecord;

namespace AnalyzerLibrary.Entities
{
	public class ReportParameters
	{
		public ReportParameters(IEnumerable<LogRecordParts> logRecordPartses, dynamic converter,
			IDictionary<string, object> generalParams)
		{
			LogRecordPartses = logRecordPartses;
			Converter = converter;
			GeneralParams = generalParams;
		}

		public IEnumerable<LogRecordParts> LogRecordPartses { get; private set; }
		public dynamic Converter { get; private set; }
		public IDictionary<string, object> GeneralParams { get; private set; }
	}
}