using System.Collections.Generic;
using PartsRecord;

namespace AnalyzerLibrary.Comparer
{
	public class IpAddressComparer : IEqualityComparer<LogRecordParts>
	{
		public bool Equals(LogRecordParts x, LogRecordParts y)
		{
			bool match = x.IpAddress.A == y.IpAddress.A &
			             x.IpAddress.B == y.IpAddress.B &
			             x.IpAddress.C == y.IpAddress.C &
			             x.IpAddress.D == y.IpAddress.D;
			return match;
		}

		public int GetHashCode(LogRecordParts obj)
		{
			int hashIp = (obj.IpAddress.A + "." + obj.IpAddress.B + "." + obj.IpAddress.C + "." + obj.IpAddress.D).GetHashCode();
			return hashIp;
		}
	}
}