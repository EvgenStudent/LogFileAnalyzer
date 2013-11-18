using System.Collections.Generic;
using PartsRecord;

namespace AnalyzerLibrary.ReportResults
{
	public class ReportDateResult : ReportResult
	{
		public IEnumerable<LogRecordParts> DateCollection { get; private set; }

		public ReportDateResult(IEnumerable<LogRecordParts> dateCollection)
		{
			DateCollection = dateCollection;
		}
	}
}