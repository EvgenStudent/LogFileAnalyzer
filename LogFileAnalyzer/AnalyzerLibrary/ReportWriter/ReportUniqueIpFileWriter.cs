using AnalyzerLibrary.ReportConverter;
using AnalyzerLibrary.ReportResults;
using PartsRecord;

namespace AnalyzerLibrary.ReportWriter
{
	public class ReportUniqueIpFileWriter : IReportWriter
	{
		private readonly ReportUniqueIpConverterToString _converter = new ReportUniqueIpConverterToString();
		private readonly dynamic _writer;

		public ReportUniqueIpFileWriter(dynamic writer)
		{
			_writer = writer;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			using (_writer)
			{
				var result = (ReportUniqueIpResult) reportResult;
				foreach (IpAddress ipAddress in result.IpAddressCollection)
					_writer.Write(_converter.Convert(ipAddress));
			}
		}
	}
}