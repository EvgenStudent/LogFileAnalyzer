using System;

namespace AnalyzerLibrary.Writer
{
	public interface IFileWriter<in T> : IDisposable
	{
		void Write(T parameter);
	}
}