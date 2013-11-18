namespace AnalyzerLibrary.ConverterInput
{
	public interface IConverter<in TParam, out TReturn>
	{
		TReturn Convert(TParam record);
	}
}