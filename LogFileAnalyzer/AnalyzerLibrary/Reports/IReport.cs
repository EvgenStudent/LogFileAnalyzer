using AnalyzerLibrary.ReportResults;

namespace AnalyzerLibrary.Reports
{
	public interface IReport
	{
		ReportResult GetReport();
	}
}