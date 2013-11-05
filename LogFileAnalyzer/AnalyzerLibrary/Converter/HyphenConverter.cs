using System;
using PartsRecord;

namespace AnalyzerLibrary.Converter
{
	public class HyphenConverter : IConverter<Hyphen>
	{
		public Hyphen Convert(string record)
		{
			return new Hyphen(record.ToCharArray()[0]);
		}
	}
}