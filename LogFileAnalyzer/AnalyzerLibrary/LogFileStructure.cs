using AnalyzerLibrary.Converter;

namespace AnalyzerLibrary
{
	public class LogFileStructure
	{
		private readonly string[] _records;
		public IConverter[] TemplateConverters { get; set; }
	
		public LogFileStructure(string[] records)
		{
			_records = records;
		}
	}
}