using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace GeneratorLibrary.Response
{
	class CodeDefinition : IRecordFieldValueGenerator
	{
		private readonly IReadOnlyList<int> codes;
		private readonly Random random;

		public CodeDefinition(Random random, IReadOnlyList<int> codes)
		{
			this.codes = codes;
			this.random = random;
		}

		public string Generate()
		{
			return codes[random.Next(0, codes.Count)].ToString(CultureInfo.InvariantCulture);
		}
	}
}
