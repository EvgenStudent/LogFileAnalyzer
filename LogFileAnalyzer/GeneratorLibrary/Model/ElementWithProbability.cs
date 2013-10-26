namespace GeneratorLibrary.Model
{
	public struct ElementWithProbability<T>
	{
		public T Value { get; set; }
		public int Probability { get; set; }

		public ElementWithProbability(T value, int probability = 1)
			: this()
		{
			Value = value;
			Probability = probability;
		}
	}
}