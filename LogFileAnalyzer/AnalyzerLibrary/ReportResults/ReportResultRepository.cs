using System;
using System.Collections.Generic;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.ReportConverter;
using AnalyzerLibrary.ReportWriter;

namespace AnalyzerLibrary.ReportResults
{
	public class ReportResultRepository
	{
		private readonly Dictionary<string, dynamic> _repository =
			new Dictionary<string, dynamic>(StringComparer.InvariantCultureIgnoreCase);

		public ReportResultRepository(dynamic writer)
		{
			_repository.Add(Keys.Reports.Date, new ReportDateFileWriter(writer));
			_repository.Add(Keys.Reports.UniqueIp, new ReportUniqueIpFileWriter(writer));
			_repository.Add(Keys.Reports.CodeStatistics, new ReportCodeStatisticsFileWriter(writer));
		}

		public IReportWriter GetReportWriter(string key)
		{
			return _repository[key];
		}
	}
}