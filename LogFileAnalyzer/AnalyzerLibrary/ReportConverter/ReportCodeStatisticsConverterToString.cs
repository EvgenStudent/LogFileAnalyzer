using AnalyzerLibrary.ConverterInput;
using AnalyzerLibrary.Entities;

namespace AnalyzerLibrary.ReportConverter
{
	public class ReportCodeStatisticsConverterToString : IConverter<CodeStatistics, string>
	{
		public string Convert(CodeStatistics codeStatistics)
		{
			return string.Format("{0} - {1}%", codeStatistics.Code, codeStatistics.Probability);
		}
	}
}