using System;
using AnalyzerLibrary.ReportResults;

namespace AnalyzerLibrary.ReportConverter
{
	public class ReportDateWriter : IReportWriter
	{
		private readonly ReportDateConverterToString _converter = new ReportDateConverterToString();
		private readonly dynamic _writer;

		public ReportDateWriter(dynamic writer)
		{
			_writer = writer;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			throw new NotImplementedException();
		}
	}
}