using System.Globalization;
using PartsRecord;

namespace ConverterOutput
{
	public class CodeDefinitionConverter : IConverter<string>
	{
		private readonly CodeDefinition _codeDefinition;

		public CodeDefinitionConverter(CodeDefinition codeDefinition)
		{
			_codeDefinition = codeDefinition;
		}

		public string Convert()
		{
			return _codeDefinition.Code.ToString(CultureInfo.InvariantCulture);
		}
	}
}