using System.Linq;
using AnalyzerLibrary.ReportResults;

namespace AnalyzerLibrary.ReportConverter
{
	public class ReportCodeStatisticsWriter : IReportWriter
	{
		private readonly ReportCodeStatisticsConverterToString _converter = new ReportCodeStatisticsConverterToString();
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
				double count = result.CodeCollection.Sum(x => x.Probability);
				foreach (var codeStatistic in result.CodeCollection)
					_writer.Write(_converter.Convert(codeStatistic));
			}
		}
	}
}