namespace AnalyzerLibrary.ReportResults
{
	public class ReportGeneralTrafficResult : ReportResult
	{
		public ReportGeneralTrafficResult(double filesSize)
		{
			FilesSize = filesSize;
		}

		public double FilesSize { get; private set; }
	}
}