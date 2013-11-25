namespace AnalyzerLibrary.Entities
{
	public class CodeStatistics
	{
		public int Code { get; private set; }
		public double Probability { get; private set; }

		public CodeStatistics(int code, double probability)
		{
			Code = code;
			Probability = probability;
		}
	}
}