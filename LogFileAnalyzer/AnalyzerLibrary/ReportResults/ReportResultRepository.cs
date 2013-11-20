using System;
using System.Collections.Generic;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.ReportConverter;

namespace AnalyzerLibrary.ReportResults
{
	public class ReportResultRepository
	{
		private readonly Dictionary<string, dynamic> _repository =
			new Dictionary<string, dynamic>(StringComparer.InvariantCultureIgnoreCase);

		public ReportResultRepository(dynamic writer)
		{
			_repository.Add(Keys.Reports.Date, new ReportDateWriter(writer));
			_repository.Add(Keys.Reports.UniqueIp, new ReportUniqueIpWriter(writer));
			_repository.Add(Keys.Reports.CodeStatistics, new ReportCodeStatisticsWriter(writer));
		}

		public IReportWriter GetReportResult(string key)
		{
			return _repository[key];
		}
	}
}