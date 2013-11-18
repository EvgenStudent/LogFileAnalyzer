using System.Collections.Generic;
using System.Linq;
using AnalyzerLibrary.Comparer;
using AnalyzerLibrary.Entities;
using AnalyzerLibrary.ReportResults;
using PartsRecord;

namespace AnalyzerLibrary.Reports
{
	public class ReportByUniqueIp : IReport
	{
		private readonly ReportParameters _parameters;

		public ReportByUniqueIp(ReportParameters parameters)
		{
			_parameters = parameters;
		}

		public ReportResult GetReport()
		{
			List<IpAddress> findResult = _parameters.LogRecordPartses.Distinct(new IpAddressComparer()).Select(x => x.IpAddress).ToList();
			return new ReportUniqueIpResult(findResult);
		}
	}
}