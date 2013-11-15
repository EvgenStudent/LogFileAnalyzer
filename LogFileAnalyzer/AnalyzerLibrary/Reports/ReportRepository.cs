using System;
using System.Collections.Generic;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.Entities;

namespace AnalyzerLibrary.Reports
{
	public class ReportRepository<TReport>
	{
		private readonly Dictionary<string, dynamic> _repository =
			new Dictionary<string, dynamic>(StringComparer.InvariantCultureIgnoreCase);

		public ReportRepository(ReportParameters parameters)
		{
			_repository.Add(Keys.Reports.Date, new ReportByDate(parameters));
			_repository.Add(Keys.Reports.UniqueIp, new ReportByUniqueIp(parameters));
			_repository.Add(Keys.Reports.CodeStatistics, new ReportCodeStatistics(parameters));
		}

		public IReport<TReport> GetReport(string key)
		{
			return _repository[key];
		}
	}
}