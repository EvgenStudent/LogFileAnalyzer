namespace GeneratorLibrary.Model
{
	public class ElementWithProbability<T>
	{
		public T Value { get; set; }
		public int Probability { get; set; }

		public ElementWithProbability(T value, int probability = 1)
		{
			Value = value;
			Probability = probability;
		}
	}
}