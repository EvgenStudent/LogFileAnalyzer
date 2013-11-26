using System.Collections.Generic;
using System.Linq;
using AnalyzerLibrary.ConverterInput;
using AnalyzerLibrary.Entities;
using AnalyzerLibrary.ReportConverter;
using PartsRecord;

namespace AnalyzerForm.ReportConverter
{
	public class ReportUniqueIpConverterToList : IConverter<IEnumerable<IpAddress>, IEnumerable<IpAdressString>>
	{
		private readonly ReportUniqueIpConverterToString _converterToString = new ReportUniqueIpConverterToString();

		public IEnumerable<IpAdressString> Convert(IEnumerable<IpAddress> record)
		{
			IEnumerable<IpAdressString> list = record.Select(ipAddress => new IpAdressString { IpAddress = _converterToString.Convert(ipAddress) });
			return list;
		}
	}
}