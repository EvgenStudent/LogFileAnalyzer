using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AnalyzerForm.ReportWriter;
using AnalyzerLibrary.ReportWriter;
using Keys = AnalyzerLibrary.Constant.Keys;

namespace AnalyzerForm.Repository
{
	public class ReportResultControlRepository
	{
		private readonly Dictionary<string, IReportWriter> _repository =
			new Dictionary<string, IReportWriter>(StringComparer.InvariantCultureIgnoreCase);

		public ReportResultControlRepository(DataGridView dataGridView)
		{
			_repository.Add(Keys.Reports.Date, new ReportDateControlWriter(dataGridView));
			_repository.Add(Keys.Reports.UniqueIp, new ReportUniqueIpControlWriter(dataGridView));
			_repository.Add(Keys.Reports.CodeStatistics, new ReportCodeStatisticsControlWriter(dataGridView));
		}

		public IReportWriter GetReportWriter(string key)
		{
			return _repository[key];
		}
	}
}