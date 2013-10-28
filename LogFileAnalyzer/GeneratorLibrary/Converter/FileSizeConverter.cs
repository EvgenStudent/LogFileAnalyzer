using System.Globalization;
using GeneratorLibrary.PartsRecord;

namespace GeneratorLibrary.Converter
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