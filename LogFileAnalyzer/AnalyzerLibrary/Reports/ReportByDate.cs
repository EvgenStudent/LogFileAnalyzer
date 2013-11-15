using System;
using System.Collections.Generic;
using System.Linq;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.Entities;
using PartsRecord;

namespace AnalyzerLibrary.Reports
{
	public class ReportByDate : IReport<string>
	{
		private readonly ReportParameters _parameters;

		public ReportByDate(ReportParameters parameters)
		{
			_parameters = parameters;
		}

		public Report<string> GetReport()
		{
			var min = (DateTime) _parameters.OptionalParams[Keys.Reports.Date + Keys.Reports.Min];
			var max = (DateTime) _parameters.OptionalParams[Keys.Reports.Date + Keys.Reports.Max];

			List<LogRecordParts> findResult =
				_parameters.LogRecordPartses.Where(x => x.Date.DateNow >= min & x.Date.DateNow <= max).ToList();


			throw new NotImplementedException();
		}
	}
}