using System;
using System.IO;
using System.Text;

namespace GeneratorLibrary.Writer
{
	public class LogStringWriter : IWriter<string>, IDisposable
	{
		private readonly StreamWriter _file;

		public LogStringWriter(string path)
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