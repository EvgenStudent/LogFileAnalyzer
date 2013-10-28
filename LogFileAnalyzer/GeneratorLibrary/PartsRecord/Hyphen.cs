namespace GeneratorLibrary.PartsRecord
{
	public struct Hyphen
	{
		public char Symbol { get; private set; }

		public Hyphen(char symbol = '-')
			: this()
		{
			Symbol = symbol;
		}
	}
}