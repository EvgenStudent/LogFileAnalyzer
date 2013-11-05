using System;
using System.Globalization;
using PartsRecord;

namespace AnalyzerLibrary.Converter
{
	public class CodeDefinitionConverter : IConverter<CodeDefinition>
	{
		public CodeDefinition Convert(string record)
		{
			return new CodeDefinition(int.Parse(record));
		}
	}
}