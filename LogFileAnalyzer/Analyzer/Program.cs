using AnalyzerLibrary;
using AnalyzerLibrary.Constant;
using AnalyzerLibrary.Reader;
using AnalyzerLibrary.Writer;
using ConsoleCommandLibrary;

namespace Analyzer
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var consoleParameters = new ConsoleParametrsParse(args);

			bool tryConsoleParameters = consoleParameters.TryGetParameters();
			if (tryConsoleParameters)
			{
				IReader reader = new LogReader();
				IWriter<string> writer =
					new LogStringWriter(consoleParameters.Parameters[Keys.Application.Parameters][Keys.Application.ResultFileName]);
				var analyzer = new LogFileAnalyzer(consoleParameters.Parameters, reader, writer);
				analyzer.CreateReport();
			}
		}
	}
}