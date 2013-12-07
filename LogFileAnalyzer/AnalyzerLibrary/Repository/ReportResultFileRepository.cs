using System;
using System.Collections.Generic;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.ReportWriter;
using AnalyzerLibrary.Writer;

namespace AnalyzerLibrary.Repository
{
	public class ReportResultFileRepository<T>
	{
		private readonly Dictionary<string, IReportWriter> _repository =
			new Dictionary<string, IReportWriter>(StringComparer.InvariantCultureIgnoreCase);

		public ReportResultFileRepository(IFileWriter<T> writer)
		{
			_repository.Add(Keys.Reports.GeneralTraffic, new ReportGeneralTrafficFileWriter(writer));
			_repository.Add(Keys.Reports.UniqueIp, new ReportUniqueIpFileWriter(writer));
			_repository.Add(Keys.Reports.CodeStatistics, new ReportCodeStatisticsFileWriter(writer));
		}

		public IReportWriter GetReportWriter(string key)
		{
			return _repository[key];
		}
	}
}