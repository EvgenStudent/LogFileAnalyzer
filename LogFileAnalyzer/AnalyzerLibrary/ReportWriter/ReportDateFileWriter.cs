using AnalyzerLibrary.ConverterOutput;
using AnalyzerLibrary.ReportResults;
using PartsRecord;

namespace AnalyzerLibrary.ReportWriter
{
	public class ReportDateFileWriter : IReportWriter
	{
		//private readonly ReportDateConverterToString _converter = new ReportDateConverterToString();
		private readonly ConvertToString _converter = new ConvertToString();
		private readonly dynamic _writer;

		public ReportDateFileWriter(dynamic writer)
		{
			_writer = writer;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			var result = (ReportDateResult) reportResult;
			foreach (LogRecordParts record in result.DateCollection)
				_writer.Write(string.Join(" ", _converter.Convert(record)));
		}
	}
}