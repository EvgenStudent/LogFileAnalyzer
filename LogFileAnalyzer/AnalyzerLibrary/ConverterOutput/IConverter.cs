namespace AnalyzerLibrary.ConverterOutput
{
	public interface IConverter<out T>
	{
		T Convert();
	}
}