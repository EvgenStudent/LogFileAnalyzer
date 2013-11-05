using System.Linq;
using PartsRecord;

namespace AnalyzerLibrary.Converter
{
	public class IpAddressConverter : IConverter<IpAddress>
	{
		public IpAddress Convert(string record)
		{
			var ip = record.Split(new[] { '.' }).Select(x => System.Convert.ToByte(x)).ToArray();
			return new IpAddress(ip[0], ip[1], ip[2], ip[3]);
		}
	}
}