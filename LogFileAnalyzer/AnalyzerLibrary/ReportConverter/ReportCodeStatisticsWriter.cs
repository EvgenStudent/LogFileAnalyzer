using System.Linq;
using AnalyzerLibrary.ReportResults;

namespace AnalyzerLibrary.ReportConverter
{
	public class ReportCodeStatisticsWriter : IReportWriter
	{
		private readonly ReportCodeStatisticsConverter _converter = new ReportCodeStatisticsConverter();
		private readonly dynamic _writer;

		public ReportCodeStatisticsWriter(dynamic writer)
		{
			_writer = writer;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			using (_writer)
			{
				var result = (ReportCodeStatisticsResult) reportResult;
				double count = result.CodeDictionary.Values.Sum();
				foreach (var pair in result.CodeDictionary)
					_writer.Write(_converter.Convert(pair));
			}
		}
	}
}