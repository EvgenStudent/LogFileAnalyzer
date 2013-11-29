namespace AnalyzerLibrary.Entities
{
	public class CodeStatistics
	{
		public CodeStatistics(int code, double probability)
		{
			Code = code;
			Probability = probability;
		}

		public int Code { get; private set; }
		public double Probability { get; private set; }
	}
}