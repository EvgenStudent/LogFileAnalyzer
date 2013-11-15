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

				//analyzer.FindByDate(new DateTime(2011, 4, 23, 10, 52, 14), new DateTime(2011, 5, 2, 07, 28, 04));
				//analyzer.FindByUniqueIp();
				//analyzer.CodeStatistics();
			}

			string sss = DateTime.MaxValue.ToShortDateString();
		}
	}
}
 