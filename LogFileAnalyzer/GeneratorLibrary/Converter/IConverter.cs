namespace GeneratorLibrary.Converter
{
	public interface IConverter<out T>
	{
		T Convert();
	}
}