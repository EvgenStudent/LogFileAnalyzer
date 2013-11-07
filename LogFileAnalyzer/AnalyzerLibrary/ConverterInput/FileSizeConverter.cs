using PartsRecord;

namespace AnalyzerLibrary.ConverterInput
{
	public class FileSizeConverter : IConverter<FileSize>
	{
		public FileSize Convert(string record)
		{
			return new FileSize(int.Parse(record));
		}
	}
}