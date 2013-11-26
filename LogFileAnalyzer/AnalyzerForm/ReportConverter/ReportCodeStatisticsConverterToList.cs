using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AnalyzerLibrary.ConverterInput;
using AnalyzerLibrary.Entities;

namespace AnalyzerForm.ReportConverter
{
	public class ReportCodeStatisticsConverterToList : IConverter<IEnumerable<CodeStatistics>, IEnumerable<CodeStatisticString>>
	{
		public IEnumerable<CodeStatisticString> Convert(IEnumerable<CodeStatistics> record)
		{
			var list = record.Select(x => new CodeStatisticString
			{
				Code = x.Code.ToString(CultureInfo.InvariantCulture),
				Probability = x.Probability.ToString(CultureInfo.InvariantCulture) + "%"
			});
			return list;
		}
	}
}