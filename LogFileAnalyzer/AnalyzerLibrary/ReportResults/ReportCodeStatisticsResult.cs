using System.Collections.Generic;
using AnalyzerLibrary.Entities;

namespace AnalyzerLibrary.ReportResults
{
	public class ReportCodeStatisticsResult : ReportResult
	{
		public ReportCodeStatisticsResult(IEnumerable<CodeStatistics> codeCollection)
		{
			CodeCollection = codeCollection;
		}

		public IEnumerable<CodeStatistics> CodeCollection { get; private set; }
	}
}