namespace GeneratorLibrary.Writer
{
	public interface IWriter<in T>
	{
		void Write(T parameter);
	}
}