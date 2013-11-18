using PartsRecord;

namespace AnalyzerLibrary.ConverterInput
{
	public class HyphenConverter : IConverter<string, Hyphen>
	{
		public Hyphen Convert(string record)
		{
			return new Hyphen(record.ToCharArray()[0]);
		}
	}
}