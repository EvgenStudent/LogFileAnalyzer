using System.Collections.Generic;
using AnalyzerLibrary.ConverterInput;

namespace AnalyzerLibrary.ReportConverter
{
	public class ReportCodeStatisticsConverter : IConverter<KeyValuePair<int, double>, string>
	{
		public string Convert(KeyValuePair<int, double> codeDefinitionPair)
		{
			return string.Format("{0} - {1}%", codeDefinitionPair.Key, codeDefinitionPair.Value);
		}
	}
}