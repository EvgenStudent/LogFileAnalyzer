using System.Linq;
using AnalyzerLibrary.Entities;
using AnalyzerLibrary.ReportResults;

namespace AnalyzerLibrary.Reports
{
	public class ReportByGeneralTraffic : IReport
	{
		private readonly ReportParameters _parameters;

		public ReportByGeneralTraffic(ReportParameters parameters)
		{
			_parameters = parameters;
		}

		public ReportResult GetReport()
		{
			double findResult = _parameters.LogRecordPartses.Select(x => x.FileSize).Sum(x => x.Size);

			return new ReportGeneralTrafficResult(findResult);
		}
	}
}