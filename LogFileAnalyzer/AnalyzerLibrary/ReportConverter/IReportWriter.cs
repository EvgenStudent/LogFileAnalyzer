using AnalyzerLibrary.ReportResults;

namespace AnalyzerLibrary.ReportConverter
{
	public interface IReportWriter
	{
		void ReportWrite(ReportResult reportResult);
	}
}