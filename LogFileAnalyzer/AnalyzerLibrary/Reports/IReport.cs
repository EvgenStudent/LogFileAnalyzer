namespace AnalyzerLibrary.Reports
{
	public interface IReport<T>
	{
		Report<T> GetReport();
	}
}