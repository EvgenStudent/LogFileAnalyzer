using AnalyzerLibrary.ReportResults;
using PartsRecord;

namespace AnalyzerLibrary.ReportConverter
{
	public class ReportUniqueIpWriter : IReportWriter
	{
		private readonly ReportUniqueIpConverterToString _converter = new ReportUniqueIpConverterToString();
		private readonly dynamic _writer;

		public ReportUniqueIpWriter(dynamic writer)
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