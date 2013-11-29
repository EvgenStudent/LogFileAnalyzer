using System.Collections.Generic;
using System.Linq;
using AnalyzerLibrary.Entities;
using AnalyzerLibrary.ReportResults;
using PartsRecord;

namespace AnalyzerLibrary.Reports
{
	public class ReportCodeStatistics : IReport
	{
		private readonly ReportParameters _parameters;

		public ReportCodeStatistics(ReportParameters parameters)
		{
			_parameters = parameters;
		}

		public ReportResult GetReport()
		{
			var codesCount = new Dictionary<int, double>();
			foreach (LogRecordParts logRecord in _parameters.LogRecordPartses)
			{
				if (codesCount.ContainsKey(logRecord.CodeDefinition.Code))
					codesCount[logRecord.CodeDefinition.Code]++;
				else
					codesCount.Add(logRecord.CodeDefinition.Code, 1);
			}
			codesCount = codesCount.OrderBy(k => k.Key).ToDictionary(x => x.Key, x => x.Value/codesCount.Values.Sum()*100);
			IEnumerable<CodeStatistics> codeStatistics = codesCount.Select(x => new CodeStatistics(x.Key, x.Value));

			return new ReportCodeStatisticsResult(codeStatistics);
		}
	}
}