using AnalyzerLibrary.ReportResults;
using AnalyzerLibrary.Writer;

namespace AnalyzerLibrary.ReportConverter
{
	public class ReportDateWriter : IReportWriter
	{
		private readonly IWriter<string> _writer;
		private readonly ReportDateConverter _converter = new ReportDateConverter();

		public ReportDateWriter(IWriter<string> writer)
		{
			_writer = writer;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			throw new System.NotImplementedException();
		}
	}
}