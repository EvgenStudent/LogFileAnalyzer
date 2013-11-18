using System.Collections.Generic;

namespace AnalyzerLibrary.ReportResults
{
	public class ReportCodeStatisticsResult : ReportResult
	{
		public IDictionary<int, double> CodeDictionary { get; private set; }

		public ReportCodeStatisticsResult(IDictionary<int, double> codeDictionary)
		{
			CodeDictionary = codeDictionary;
		}
	}
}