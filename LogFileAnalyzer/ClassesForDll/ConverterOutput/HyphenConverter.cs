using System.Globalization;
using PartsRecord;

namespace ConverterOutput
{
	public class HyphenConverter : IConverter<string>
	{
		private readonly Hyphen _hyphen;

		public HyphenConverter(Hyphen hyphen)
		{
			_hyphen = hyphen;
		}

		public string Convert()
		{
			return _hyphen.Symbol.ToString(CultureInfo.InvariantCulture);
		}
	}
}