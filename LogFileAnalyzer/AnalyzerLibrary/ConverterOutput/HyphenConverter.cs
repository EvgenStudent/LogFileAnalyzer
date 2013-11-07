﻿using System.Globalization;
using PartsRecord;

namespace AnalyzerLibrary.ConverterOutput
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