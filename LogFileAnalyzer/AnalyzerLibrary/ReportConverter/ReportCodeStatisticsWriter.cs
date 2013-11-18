using System.Linq;
using AnalyzerLibrary.ReportResults;
using AnalyzerLibrary.Writer;

namespace AnalyzerLibrary.ReportConverter
{
	public class ReportCodeStatisticsWriter : IReportWriter
	{
		private readonly IWriter<string> _writer;
		private readonly ReportCodeStatisticsConverter _converter = new ReportCodeStatisticsConverter();

		public ReportCodeStatisticsWriter(IWriter<string> writer)
		{
			_writer = writer;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			using (_writer)
			{
				var result = (ReportCodeStatisticsResult)reportResult;
				double count = result.CodeDictionary.Values.Sum();
				foreach (var pair in result.CodeDictionary)
					_writer.Write(_converter.Convert(pair));
			}
		}
	}
}