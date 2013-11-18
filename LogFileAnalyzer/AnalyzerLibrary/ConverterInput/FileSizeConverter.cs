using PartsRecord;

namespace AnalyzerLibrary.ConverterInput
{
	public class FileSizeConverter : IConverter<string, FileSize>
	{
		public FileSize Convert(string record)
		{
			return new FileSize(int.Parse(record));
		}
	}
}