using System.Linq;
using AnalyzerLibrary.Entities;
using AnalyzerLibrary.ReportConverter;
using AnalyzerLibrary.ReportResults;

namespace AnalyzerLibrary.ReportWriter
{
	public class ReportCodeStatisticsFileWriter : IReportWriter
	{
		private readonly ReportCodeStatisticsConverterToString _converter = new ReportCodeStatisticsConverterToString();
		private readonly dynamic _writer;

		public ReportCodeStatisticsFileWriter(dynamic writer)
		{
			_writer = writer;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			using (_writer)
			{
				var result = (ReportCodeStatisticsResult) reportResult;
				double count = result.CodeCollection.Sum(x => x.Probability);
				foreach (CodeStatistics codeStatistic in result.CodeCollection)
					_writer.Write(_converter.Convert(codeStatistic));
			}
		}
	}
}