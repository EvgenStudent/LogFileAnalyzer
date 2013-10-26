namespace GeneratorLibrary.Generator
{
	public interface IGenerator<out T>
		where T : struct
	{
		T Generate();
	}
}