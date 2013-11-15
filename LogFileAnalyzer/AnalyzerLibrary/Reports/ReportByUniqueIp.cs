using System.Collections.Generic;
using System.Linq;
using AnalyzerLibrary.Comparer;
using AnalyzerLibrary.Entities;
using PartsRecord;

namespace AnalyzerLibrary.Reports
{
	public class ReportByUniqueIp : IReport<string>
	{
		private readonly ReportParameters _parameters;

		public ReportByUniqueIp(ReportParameters parameters)
		{
			_parameters = parameters;
		}

		public Report<string> GetReport()
		{
			List<LogRecordParts> findResult = _parameters.LogRecordPartses.Distinct(new IpAddressComparer()).ToList();
			var list = new List<dynamic>(findResult.Count);
			list.AddRange(findResult.Select(t => _parameters.Converter.Convert(t)[0]));

			return new Report<string>(list.Cast<string>().ToList());
		}
	}
}