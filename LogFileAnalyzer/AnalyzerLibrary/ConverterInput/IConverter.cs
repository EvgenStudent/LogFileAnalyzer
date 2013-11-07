namespace AnalyzerLibrary.ConverterInput
{
	public interface IConverter<out T>
	{
		T Convert(string record);
	}
}