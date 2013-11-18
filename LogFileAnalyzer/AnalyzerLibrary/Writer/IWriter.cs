using System;

namespace AnalyzerLibrary.Writer
{
	public interface IWriter<in T> : IDisposable
	{
		void Write(T parameter);
	}
}