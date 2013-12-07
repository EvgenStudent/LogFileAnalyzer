using AnalyzerLibrary.ReportResults;

namespace AnalyzerLibrary.ReportWriter
{
	public class ReportGeneralTrafficFileWriter : IReportWriter
	{
		private readonly dynamic _writer;

		public ReportGeneralTrafficFileWriter(dynamic writer)
		{
			_writer = writer;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			var result = (ReportGeneralTrafficResult) reportResult;
			_writer.Write(result.FilesSize);
		}
	}
}