using System.Globalization;
using PartsRecord;

namespace AnalyzerLibrary.ConverterOutput
{
	public class FileSizeConverter : IConverter<string>
	{
		private readonly FileSize _fileSize;

		public FileSizeConverter(FileSize fileSize)
		{
			_fileSize = fileSize;
		}

		public string Convert()
		{
			return _fileSize.Size.ToString(CultureInfo.InvariantCulture);
		}
	}
}