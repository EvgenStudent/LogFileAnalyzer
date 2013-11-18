using System.Collections.Generic;
using PartsRecord;

namespace AnalyzerLibrary.ReportResults
{
	public class ReportUniqueIpResult : ReportResult
	{
		public IEnumerable<IpAddress> IpAddressCollection { get; private set; }

		public ReportUniqueIpResult(IEnumerable<IpAddress> ipAddresses)
		{
			IpAddressCollection = ipAddresses;
		}
	}
}