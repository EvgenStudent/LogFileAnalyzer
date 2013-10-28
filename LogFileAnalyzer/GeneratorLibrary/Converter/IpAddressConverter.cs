using GeneratorLibrary.PartsRecord;

namespace GeneratorLibrary.Converter
{
	public class IpAddressConverter : IConverter<string>
	{
		private readonly IpAddress _ipAddress;

		public IpAddressConverter(IpAddress ipAddress)
		{
			_ipAddress = ipAddress;
		}

		public string Convert()
		{
			throw new System.NotImplementedException();
		}
	}
}