using AnalyzerLibrary.ReportResults;

namespace AnalyzerLibrary.ReportWriter
{
	public interface IReportWriter
	{
		void ReportWrite(ReportResult reportResult);
	}
}