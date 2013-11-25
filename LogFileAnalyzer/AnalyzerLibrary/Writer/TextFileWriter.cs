using System.IO;
using System.Text;

namespace AnalyzerLibrary.Writer
{
	public class TextFileWriter : IFileWriter<string>
	{
		private readonly StreamWriter _file;

		public TextFileWriter(string path)
		{
			_file = new StreamWriter(path, false, Encoding.UTF8);
		}

		public void Dispose()
		{
			_file.Dispose();
		}

		public void Write(string parameter)
		{
			_file.WriteLine(parameter);
		}
	}
}