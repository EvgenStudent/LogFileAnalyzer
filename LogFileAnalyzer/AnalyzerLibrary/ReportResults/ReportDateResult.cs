using System.Collections.Generic;
using PartsRecord;

namespace AnalyzerLibrary.ReportResults
{
	public class ReportDateResult : ReportResult
	{
		public ReportDateResult(IEnumerable<LogRecordParts> dateCollection)
		{
			DateCollection = dateCollection;
		}

		public IEnumerable<LogRecordParts> DateCollection { get; private set; }
	}
}