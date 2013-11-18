using System;
using AnalyzerLibrary;
using AnalyzerLibrary.Reader;
using ConsoleCommandLibrary;

namespace Analyzer
{
	class Program
	{
		static void Main(string[] args)
		{
			var consoleParameters = new ConsoleParametrsParse(args);

			bool tryConsoleParameters = consoleParameters.TryGetParameters();
			if (tryConsoleParameters)
			{
				IReader reader = new LogReader();
				var analyzer = new LogFileAnalyzer(consoleParameters.Parameters, reader);
				analyzer.CreateReport();
			}
		}
	}
}
 