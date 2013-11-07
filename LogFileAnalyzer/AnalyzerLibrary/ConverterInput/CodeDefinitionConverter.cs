using PartsRecord;

namespace AnalyzerLibrary.ConverterInput
{
	public class CodeDefinitionConverter : IConverter<CodeDefinition>
	{
		public CodeDefinition Convert(string record)
		{
			return new CodeDefinition(int.Parse(record));
		}
	}
}