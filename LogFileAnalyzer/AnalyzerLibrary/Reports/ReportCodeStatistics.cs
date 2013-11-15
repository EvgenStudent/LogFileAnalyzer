using System;
using System.Collections.Generic;
using System.Linq;
using AnalyzerLibrary.Entities;
using PartsRecord;

namespace AnalyzerLibrary.Reports
{
	public class ReportCodeStatistics : IReport<string>
	{
		private readonly ReportParameters _parameters;

		public ReportCodeStatistics(ReportParameters parameters)
		{
			_parameters = parameters;
		}

		public Report<string> GetReport()
		{
			var codesCount = new Dictionary<int, int>();
			foreach (LogRecordParts logRecord in _parameters.LogRecordPartses)
			{
				if (codesCount.ContainsKey(logRecord.CodeDefinition.Code))
					codesCount[logRecord.CodeDefinition.Code]++;
				else
					codesCount.Add(logRecord.CodeDefinition.Code, 1);
			}
			int count = codesCount.Sum(x => x.Value);

			List<string> list =
				codesCount.Select(pair => pair.Key + " - " + Math.Round((double) pair.Value/count, 2) + "%").ToList();
			return new Report<string>(list);
		}
	}
}