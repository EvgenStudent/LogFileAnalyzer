namespace GeneratorLibrary.Model
{
	public class ElementWithProbability<T>
	{
		public ElementWithProbability(T value, int probability = 1)
		{
			Value = value;
			Probability = probability;
		}

		public T Value { get; set; }
		public int Probability { get; set; }
	}
}