using System;
using AnalyzerLibrary.ReportConverter;
using AnalyzerLibrary.ReportResults;

namespace AnalyzerLibrary.ReportWriter
{
	public class ReportDateFileWriter : IReportWriter
	{
		private readonly ReportDateConverterToString _converter = new ReportDateConverterToString();
		private readonly dynamic _writer;

		public ReportDateFileWriter(dynamic writer)
		{
			_writer = writer;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			throw new NotImplementedException();
		}
	}
}