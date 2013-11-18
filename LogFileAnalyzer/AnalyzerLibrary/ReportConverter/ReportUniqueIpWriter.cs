using AnalyzerLibrary.ReportResults;
using AnalyzerLibrary.Writer;

namespace AnalyzerLibrary.ReportConverter
{
	public class ReportUniqueIpWriter : IReportWriter
	{
		private readonly IWriter<string> _writer;
		private readonly ReportUniqueIpConverter _converter = new ReportUniqueIpConverter();

		public ReportUniqueIpWriter(IWriter<string> writer)
		{
			_writer = writer;
		}

		public void ReportWrite(ReportResult reportResult)
		{
			using (_writer)
			{
				var result = (ReportUniqueIpResult)reportResult;
				foreach (var ipAddress in result.IpAddressCollection)
					_writer.Write(_converter.Convert(ipAddress));
			}
		}
	}
}