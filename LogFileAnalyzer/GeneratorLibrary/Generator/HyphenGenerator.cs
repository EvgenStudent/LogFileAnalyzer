using GeneratorLibrary.PartsRecord;

namespace GeneratorLibrary.Generator
{
	public class HyphenGenerator : IGenerator<Hyphen>
	{
		public Hyphen Generate()
		{
			return new Hyphen();
		}
	}
}