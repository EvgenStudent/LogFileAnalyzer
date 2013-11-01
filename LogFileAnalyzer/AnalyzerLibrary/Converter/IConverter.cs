namespace AnalyzerLibrary.Converter
{
	public interface IConverter<out T>
	{
		T Convert();
	}
}